using System.Collections.Generic;
using System.Drawing;
using static QuoridorApp.Constants;

namespace QuoridorApp.Model;

// class that represents the AI of the game and contains the logic of the AI.
public class Ai
{
    private readonly Game _game; // game copy
    private readonly Graph _graph; // graph copy

    public Ai()
    {
        _game = Game.GetInstance(); // copy the game state
        _graph = new Graph(_game.GetBoard()); // copy the graph state
    }

    public Move GetAiMove()
    {
        double bestEval = int.MinValue;
        Move bestMove = null;
        IEnumerable<Move> possibleMoves = _game.GetPossibleMoves();
        Point userSquare = _game.GetBoard().GetPawnLocation(UserInd);
        Point aiSquare = _game.GetBoard().GetPawnLocation(AiInd);
        int userWalls = _game.GetBoard().GetWallCount(UserInd);
        int aiWalls = _game.GetBoard().GetWallCount(AiInd);
        foreach (Move move in possibleMoves)
        {
            if (MakeTempMove(move, ref aiWalls, ref aiSquare))
            {
                double eval = EvaluateMove(userSquare, aiSquare, userWalls, aiWalls);
                if (eval > bestEval)
                {
                    bestEval = eval;
                    bestMove = move;
                }

                UndoAiMove(move, ref aiWalls, ref aiSquare);
            }
        }

        return bestMove;
    }

    private bool MakeTempMove(Move move, ref int aiWalls, ref Point aiSquare)
    {
        if (move.GetMoveType())
        {
            _graph.AddBoundary(move.GetWallToPlace());
            if (!_graph.IsPathsExist(_game.GetBoard().GetPawnLocation(UserInd), ComputerPawnStartingPoint.Y, aiSquare,
                    UserPawnStartingPoint.Y))
            {
                _graph.RemoveBoundary(move.GetWallToPlace());
                return false;
            }

            aiWalls--;
        }
        else
        {
            aiSquare = move.GetPointToMove();
        }

        return true;
    }

    private void UndoAiMove(Move move, ref int aiWalls, ref Point aiSquare)
    {
        if (move.GetMoveType())
        {
            _graph.RemoveBoundary(move.GetWallToPlace());
            aiWalls++;
        }
        else
        {
            aiSquare = _game.GetBoard().GetPawnLocation(AiInd);
        }
    }

    private double EvaluateMove(Point pointUser, Point pointAi, int userWalls, int aiWalls)
    {
        int userPathToWin = _graph.GetMinimumDistanceToY(pointUser, ComputerPawnStartingPoint.Y);
        int userMinPaths = _graph.GetMinimumPathsCount();
        int aiPathToWin = _graph.GetMinimumDistanceToY(pointAi, UserPawnStartingPoint.Y);
        int aiMinPaths = _graph.GetMinimumPathsCount();
        double aiEval = userWalls <= aiWalls
            ? aiPathToWin * ShortestPathWeight
            : aiPathToWin * ShortestPathWeight + userWalls * NumberOfWallsWeight;
        double userEval = userWalls <= aiWalls
            ? userPathToWin * ShortestPathWeight
            : userPathToWin * ShortestPathWeight + aiWalls * NumberOfWallsWeight;
        double aiMinPathEval = aiMinPaths == _graph.CountPathsToY(pointAi, UserPawnStartingPoint.Y)
            ? aiMinPaths * PathCountWeight
            : 0;
        double userMinPathEval = userMinPaths == _graph.CountPathsToY(pointUser, ComputerPawnStartingPoint.Y)
            ? userMinPaths * PathCountWeight
            : 0;
        double eval = userEval - aiEval;
        eval -= userPathToWin == 1 && aiPathToWin != 0 ? 1000 : 0;
        eval += _graph.CountPathsToY(pointAi, UserPawnStartingPoint.Y) == 1 ? 100 : 0;
        eval -= _graph.CountPathsToY(pointUser, ComputerPawnStartingPoint.Y) == 1 ? 100 : 0;
        double createMinimumPathOption = aiMinPathEval - userMinPathEval;
        return eval + createMinimumPathOption;
    }
}