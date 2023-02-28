using System.Collections.Generic;
using System.Drawing;
using static QuoridorApp.Constants;

namespace QuoridorApp.Model;

// class that represents the AI of the game and contains the logic of the AI.
public class Ai
{
    private Graph _graph; // graph of the game
    private Game _game; // game instance
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
        Dictionary<int, Wall> allowedWalls = _game.GetAllowedWalls();
        List<Point> allowedMoves = _game.GetAllowedMoves();
        int userPathToWin = _graph.GetMinimumDistanceToY(_game.GetBoard().GetPawnLocation(0), 0) ;
        int aiPathToWin = _graph.GetMinimumDistanceToY(_game.GetBoard().GetPawnLocation(1), BoardSize - 1);
        int maxDifference = userPathToWin - aiPathToWin;
        
        foreach (var move in allowedMoves)
        {
            aiPathToWin  = _graph.GetMinimumDistanceToY(move, BoardSize - 1);
            if (userPathToWin - aiPathToWin > maxDifference)
            {
                maxDifference = userPathToWin - aiPathToWin;
                _aiMove = new AiMove(move);
            }
        }
        int userWallCount = _game.GetBoard().GetWallCount(0);
        int aiWallCount = _game.GetBoard().GetWallCount(1)-1;
        if (aiWallCount >= 0 && aiPathToWin > userPathToWin)
        {
            foreach (var wall in allowedWalls)
            {
                _graph.AddBoundary(wall.Value);
                int userPath = _graph.GetMinimumDistanceToY(_game.GetBoard().GetPawnLocation(0), 0);
                int aiPath = _graph.GetMinimumDistanceToY(_game.GetBoard().GetPawnLocation(1), BoardSize - 1);
                if (userPath != -1 && aiPath != -1)
                {
                    userPathToWin = userPath + aiWallCount;
                    aiPathToWin = aiPath + userWallCount;
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

