using System.Collections.Generic;
using System.Drawing;
using QuoridorApp.Controller;

namespace QuoridorApp;
// controller class that handles the logic of the game and the form
public class GameFormController
{
    private GameForm _gameForm;
    private Game _game;
    public GameFormController(GameForm gameForm)
    {
        _gameForm = gameForm;
        _game = Game.GetInstance();
    }
    public void MovePawn(int x, int y)
    {
        _game.MovePawn(x, y);
    }
    public void PlaceWall(int x, int y, bool orientation)
    {
        _game.PlaceWall(x, y, orientation);
    }

    public int[] GetAllowedWallsIndexes()
    {
        return _game.GetAllowedWallsIndexes();
    }
    
    public List<Point> GetPossibleSquares()
    {
        return _game.GetPossibleSquares();
    }
}