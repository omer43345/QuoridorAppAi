using System.Collections.Generic;
using System.Drawing;
using static QuoridorApp.Constants;

namespace QuoridorApp.Model;
// class that represents the AI of the game and contains the logic of the AI.
public class Ai
{
    private Graph _graph;// graph of the game
    private Game _game;// game instance
    private AiMove _aiMove;
    
    public Ai(Graph graph)
    {
        _graph = graph;
        _game = Game.GetInstance();
        EvaluateMove();
    }
    
    public AiMove GetAiMove()
    {
        return _aiMove;
    }
    
    private void EvaluateMove()
    {
        Dictionary<int,Wall> allowedWalls = _game.GetAllowedWalls();
        List<Point> allowedMoves = _game.GetAllowedMoves();
        int userWallCount = _game.GetBoard().GetWallCount(0);
        int aiWallCount = _game.GetBoard().GetWallCount(1);
        int userPathToWin = _graph.GetMinimumDistanceToY(_game.GetBoard().GetPawnLocation(0), 0)+ userWallCount;
        int aiPathToWin = _graph.GetMinimumDistanceToY(_game.GetBoard().GetPawnLocation(1), BoardSize - 1)+aiWallCount;
        int maxDifference = userPathToWin - aiPathToWin;

        foreach (var move in allowedMoves)
        {
            int aiPath = _graph.GetMinimumDistanceToY(move, BoardSize - 1);
            aiPathToWin = aiPath+aiWallCount;
            if (userPathToWin - aiPathToWin > maxDifference)
            {
                maxDifference = userPathToWin - aiPathToWin;
                _aiMove = new AiMove(move);
            }
        }

        if (_game.CanPlaceWall())
        {
            foreach( var wall in allowedWalls)
            {
                _graph.AddBoundary(wall.Value);
                int userPath = _graph.GetMinimumDistanceToY(_game.GetBoard().GetPawnLocation(0), 0);
                int aiPath = _graph.GetMinimumDistanceToY(_game.GetBoard().GetPawnLocation(1), BoardSize - 1);
                if (userPath != -1 && aiPath != -1)
                {
                    userPathToWin = userPath + userWallCount;
                    aiPathToWin = aiPath + (aiWallCount - 1);
                    if (userPathToWin - aiPathToWin > maxDifference)
                    {
                        maxDifference = userPathToWin - aiPathToWin;
                        _aiMove = new AiMove(wall.Value);
                    }
                }
                _graph.RemoveBoundary(wall.Value);
            }
        }


    }











}

