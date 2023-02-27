using System.Collections.Generic;
using System.Drawing;
using QuoridorApp.Controller;
using static QuoridorApp.Constants;

namespace QuoridorApp.Model;

public class Board
{
    private readonly Pawn[] _pawns;

    private readonly List<Point>[,]
        _board; // Two dimensional array that representing the board when every square has a list of points that can be reached from it

    private readonly Game _game;

    public Board()
    {
        _pawns = new Pawn[2];
        _pawns[0] = new Pawn(UserPawnStartingPoint);
        _pawns[1] = new Pawn(ComputerPawnStartingPoint);
        _board = new List<Point>[BoardSize, BoardSize];
        _game = Game.GetInstance();
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                _board[i, j] = new List<Point>();
            }
        }

        AddStartingPoints();
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

    public Point GetPawnLocation(int turn)
    {
        return _pawns[turn].Location;
    }
}