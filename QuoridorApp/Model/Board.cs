using System;
using System.Collections.Generic;
using System.Drawing;
using static QuoridorApp.Constants;

namespace QuoridorApp.Model;

public class Board
{
    private Pawn[] _pawns;

    private List<Point>[,]
        _board; // Two dimensional array that representing the board when every square has a list of points that can be reached from it

    private bool _specialMove; // boolean that indicates if the last move was a special move 
    private readonly Game _game;

    public Board()
    {
        _specialMove = false;
        _pawns = new Pawn[2];
        _pawns[UserInd] = new Pawn(UserPawnStartingPoint);
        _pawns[AiInd] = new Pawn(ComputerPawnStartingPoint);
        _board = new List<Point>[BoardSize, BoardSize];
        _game = Game.GetInstance();
        InitBoard();
    }

    private void AddStartingPoints()
    {
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                _board[i, j] = _game.GetPossibleSquares(new Point(j, i));
            }
        }
    }

    public void PlaceWall(int turn, Wall wall)
    {
        _pawns[turn].PlaceWall();
        UpdateBoard(wall);
        CheckSpecialMove();
    }


    // update the board after placing a wall by removing the points that can be reached from the squares that the wall is blocking
    // always we will remove 4 points from the board because the wall is blocking 4 squares
    private void UpdateBoard(Wall wall)
    {
        int x = wall.X;
        int y = wall.Y;
        bool orientation = wall.Orientation;
        if (orientation)
        {
            _board[y, x].Remove(new Point(x + 1, y));
            _board[y, x + 1].Remove(new Point(x, y));
            _board[y + 1, x].Remove(new Point(x + 1, y + 1));
            _board[y + 1, x + 1].Remove(new Point(x, y + 1));
        }
        else
        {
            _board[y, x].Remove(new Point(x, y + 1));
            _board[y, x + 1].Remove(new Point(x + 1, y + 1));
            _board[y + 1, x].Remove(new Point(x, y));
            _board[y + 1, x + 1].Remove(new Point(x + 1, y));
        }
    }

    public void MovePawn(int turn, Point newLocation)
    {
        _pawns[turn].SetLocation(newLocation);
        CheckSpecialMove();
    }

    private void CheckSpecialMove()
    {
        if (_board[_pawns[UserInd].Location.Y, _pawns[UserInd].Location.X].Contains(_pawns[AiInd].Location))
        {
            TakeCareOfSpecialMove();
            _specialMove = true;
        }
    }

    public bool GetIfSpecialMove()
    {
        return _specialMove;
    }

    public void RemoveSpecialMovePoints(List<Wall> placedWalls)
    {
        InitBoard();
        _specialMove = false;
        foreach (var wall in placedWalls)
        {
            UpdateBoard(wall);
        }
    }

    private void InitBoard()
    {
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                _board[i, j] = new List<Point>();
            }
        }

        AddStartingPoints();
    }


    private void TakeCareOfSpecialMove()
    {
        int pawn1 = UserInd, pawn2 = AiInd;
        _board[_pawns[pawn1].Location.Y, _pawns[pawn1].Location.X].Remove(_pawns[pawn2].Location);
        _board[_pawns[pawn2].Location.Y, _pawns[pawn2].Location.X].Remove(_pawns[pawn1].Location);
        pawn1 = _pawns[pawn1].Location.Y > _pawns[pawn2].Location.Y ||
                _pawns[pawn1].Location.X > _pawns[pawn2].Location.X
            ? pawn1
            : pawn2;
        pawn2 = pawn1 == UserInd ? AiInd : UserInd;
        bool yCase = _pawns[pawn1].Location.X == _pawns[pawn2].Location.X;
        AddSpecialPoints(yCase, pawn1, pawn2, true);
        AddSpecialPoints(yCase, pawn2, pawn1, false);
    }

    private void AddSpecialPoints(bool yCase, int pawn1, int pawn2, bool above)
    {
        int addWhenAboveY = above ? 1 : -1;
        addWhenAboveY = yCase ? addWhenAboveY : 0;
        int addWhenAboveX = above ? 1 : -1;
        addWhenAboveX = !yCase ? addWhenAboveX : 0;
        int addWhenYCase = yCase ? 1 : 0;
        int addWhenXCase = !yCase ? 1 : 0;
        if (_board[_pawns[pawn1].Location.Y, _pawns[pawn1].Location.X]
            .Contains(new Point(_pawns[pawn1].Location.X + addWhenAboveX, _pawns[pawn1].Location.Y + addWhenAboveY)))
        {
            _board[_pawns[pawn2].Location.Y, _pawns[pawn2].Location.X].Add(
                new Point(_pawns[pawn1].Location.X + addWhenAboveX, _pawns[pawn1].Location.Y + addWhenAboveY));
            return;
        }

        if (_board[_pawns[pawn1].Location.Y, _pawns[pawn1].Location.X]
            .Contains(new Point(_pawns[pawn1].Location.X - addWhenYCase, _pawns[pawn1].Location.Y - addWhenXCase)))
            _board[_pawns[pawn2].Location.Y, _pawns[pawn2].Location.X].Add(
                new Point(_pawns[pawn1].Location.X - addWhenYCase, _pawns[pawn1].Location.Y - addWhenXCase));
        if (_board[_pawns[pawn1].Location.Y, _pawns[pawn1].Location.X]
            .Contains(new Point(_pawns[pawn1].Location.X + addWhenYCase, _pawns[pawn1].Location.Y + addWhenXCase)))
            _board[_pawns[pawn2].Location.Y, _pawns[pawn2].Location.X].Add(
                new Point(_pawns[pawn1].Location.X + addWhenYCase, _pawns[pawn1].Location.Y + addWhenXCase));
    }

    public int GetWallCount(int turn)
    {
        return _pawns[turn].GetWallCount();
    }

    public List<Point> GetAllowedMoves(int turn)
    {
        return _board[_pawns[turn].Location.Y, _pawns[turn].Location.X];
    }

    // return a copy of the board so the user can't change the board
    public List<Point>[,] GetBoardCopy()
    {
        List<Point>[,] boardCopy = new List<Point>[BoardSize, BoardSize];
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                boardCopy[i, j] = new List<Point>();
                foreach (var point in _board[i, j])
                {
                    boardCopy[i, j].Add(point);
                }
            }
        }

        return boardCopy;
    }

    public void MakeTheSameStates(Board board)
    {
        this._board = board.GetBoardCopy();
        this._pawns[UserInd].Location = new Point(board.GetPawnLocation(UserInd).X, board.GetPawnLocation(UserInd).Y);
        this._pawns[AiInd].Location = new Point(board.GetPawnLocation(AiInd).X, board.GetPawnLocation(AiInd).Y);
        this._pawns[UserInd].SetWallCount(board.GetWallCount(UserInd));
        this._pawns[AiInd].SetWallCount(board.GetWallCount(AiInd));
    }


    public Point GetPawnLocation(int turn)
    {
        return _pawns[turn].Location;
    }

    public void AddToWallCount(int turn)
    {
        _pawns[turn].AddWall();
    }
}