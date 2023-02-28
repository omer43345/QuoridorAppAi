using System.Collections.Generic;
using static QuoridorApp.Constants;

namespace QuoridorApp.Model;

// class that represents the AI of the game and contains the logic of the AI.
public class Ai
{
    private readonly Game _game; // game copy

    public Ai()
    {
        _game = Game.GetInstance().CopyState(); // copy the game state
    }

    public Move GetAiMove()
    {
        double bestEval = int.MinValue;
        Move bestMove = null;
        IEnumerable<Move> possibleMoves = _game.GetPossibleMoves();
        foreach (Move move in possibleMoves)
        {
            if (_game.MakeAiMove(move))
            {
                double eval = EvaluateMove();
                if (eval >= bestEval)
                {
                    bestEval = eval;
                    bestMove = move;
                }
            }

            _game.UndoLastMove();
        }

        return bestMove;
    }

    private double EvaluateMove()
    {
        int userPathToWin = _game.GetGraph()
            .GetMinimumDistanceToY(_game.GetBoard().GetPawnLocation(UserInd), ComputerPawnStartingPoint.Y);
        int aiPathToWin = _game.GetGraph()
            .GetMinimumDistanceToY(_game.GetBoard().GetPawnLocation(AiInd), UserPawnStartingPoint.Y);
        int userWalls = _game.GetBoard().GetWallCount(UserInd);
        int aiWalls = _game.GetBoard().GetWallCount(AiInd);

        double aiEval = userWalls < aiWalls
            ? aiPathToWin * ShortestPathWeight
            : aiPathToWin * ShortestPathWeight + userWalls * NumberOfWallsWeight;
        double userEval = userWalls < aiWalls
            ? userPathToWin * ShortestPathWeight
            : userPathToWin * ShortestPathWeight + aiWalls * NumberOfWallsWeight;

        return userEval - aiEval;
    }
}