﻿using System.Collections.Generic;
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
        _game.MovePawn(new Point(x, y));
    }
    public bool PlaceWall(int x, int y, bool orientation)
    {
        return _game.PlaceWall(x, y, orientation);
        
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
    
    public void UpdateBoard(AiMove aiMove)
    {
        if (aiMove.GetMoveType())
        {
            _gameForm.PlaceComputerWall(aiMove.GetWallToPlace().X, aiMove.GetWallToPlace().Y, aiMove.GetWallToPlace().Orientation);
        }
        else
        {
            _gameForm.MoveComputerPawn(aiMove.GetPointToMove());
        }
    }

}