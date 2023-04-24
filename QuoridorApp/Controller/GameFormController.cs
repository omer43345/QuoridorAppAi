using System.Collections.Generic;
using System.Drawing;
using QuoridorApp.Model;
using QuoridorApp.View;

namespace QuoridorApp.Controller;

// controller class that connect between the logic of the game and the form that the user sees
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

    // initialize the game form controller by getting the instance of the game logic and initializing it also save the given game form
    public void InitializeGameFormController(GameForm gameForm)
    {
        _gameForm = gameForm;
        _game = Game.GetInstance();
        _game.InitializeGame();
    }

    //inform the game form that the game is over and deliver the message
    public void GameOver(string message)
    {
        _gameForm.GameOver(message);
    }

    // reset the game logic
    public void ResetGame()
    {
        _game.ResetGame();
    }

    // making a new move from the given cords and update the game logic
    public void MovePawn(int x, int y)
    {
        Move move = new Cell(x, y);
        _game.MakeMove(move);
    }
    // making a new move from wall type from the given cords and orientation of the wall and update the game logic
    public bool PlaceWall(int x, int y, bool orientation)
    {
        Move move = new Wall(orientation,x,y);
        return _game.MakeMove(move);
    }

    // return the allowed walls indexes from the game logic
    public int[] GetAllowedWallsIndexes()
    {
        return _game.GetAllowedWallsIndexes();
    }
    
    // return the allowed points to move from the game logic
    public List<Cell> GetPossibleSquares()
    {
        return _game.GetAllowedMoves();
    }

    // return if the player can place a wall from the game logic
    public bool CanPlaceWall()
    {
        return _game.CanPlaceWall();
    }

    // return if this is the user turn from the game logic
    public bool UserTurn()
    {
        return _game.UserTurn();
    }

    // return the number of walls left that the pawn that his turn has from the game logic
    public int GetWallsCounter()
    {
        return _game.GetWallsCounter();
    }
    // update the game form in the given move to visualize the move
    public void UpdateBoard(Move move)
    {
        if (move.GetType()==typeof(Wall))
        {
            Wall wall = (Wall) move;
            _gameForm.PlaceComputerWall(wall.X, wall.Y, wall.Orientation);
        }
        else
        {
            _gameForm.MoveComputerPawn(new Point(move.X, move.Y));
        }
    }
}