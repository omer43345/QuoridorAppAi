using System.Collections.Generic;
using System.Drawing;
using QuoridorApp.Model;
using QuoridorApp.View;

namespace QuoridorApp.Controller;

// controller class that handles the logic of the game and the form
public class GameFormController
{
    private GameForm _gameForm;
    private Game _game;
    private static GameFormController _instance;

    public static GameFormController GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameFormController();
        }

        return _instance;
    }

    public void InitializeGameFormController(GameForm gameForm)
    {
        _gameForm = gameForm;
        _game = Game.GetInstance();
        _game.InitializeGame();
    }

    public void GameOver(string message)
    {
        _gameForm.GameOver(message);
    }

    public void ResetGame()
    {
        _game.ResetGame();
    }

    public void MovePawn(int x, int y)
    {
        Move move = new Move(new Point(x, y));
        _game.MakeMove(move);
    }

    public bool PlaceWall(int x, int y, bool orientation)
    {
        Move move = new Move(new Wall(orientation, x, y));
        return _game.MakeMove(move);
    }

    public int[] GetAllowedWallsIndexes()
    {
        return _game.GetAllowedWallsIndexes();
    }

    public List<Point> GetPossibleSquares()
    {
        return _game.GetAllowedMoves();
    }

    public bool CanPlaceWall()
    {
        return _game.CanPlaceWall();
    }

    public bool UserTurn()
    {
        return _game.UserTurn();
    }

    public int GetWallsCounter()
    {
        return _game.GetWallsCounter();
    }

    public void UpdateBoard(Move move)
    {
        if (move.GetMoveType())
        {
            _gameForm.PlaceComputerWall(move.GetWallToPlace().X, move.GetWallToPlace().Y,
                move.GetWallToPlace().Orientation);
        }
        else
        {
            _gameForm.MoveComputerPawn(move.GetPointToMove());
        }
    }
}