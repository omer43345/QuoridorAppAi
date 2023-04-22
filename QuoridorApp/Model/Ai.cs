
using System.Collections.Generic;
using System.Drawing;
using static QuoridorApp.Constants;

namespace QuoridorApp.Model;

// class that represents the AI of the game and contains the logic of the AI.
public class Ai
{
    private readonly Game _game; // game copy
    private Graph _graph; // graph copy
    private readonly Board _board; // board copy

    public Ai()
    {
        _game = Game.GetInstance(); // copy the game state
        _board = _game.GetBoardCopy(); // copy the board state
        if (_board.GetIfSpecialMove())
            _board.RemoveSpecialMovePoints(_game.GetPlacedWalls());
        _graph = new Graph(_board); // copy the graph state

            
    }
    
    /// <summary>
    /// return the best move for the AI to make for the current state of the game
    /// </summary>
    /// <returns></returns>
    public Move GetAiMove()
    {
        double bestEval = int.MinValue;
        Move bestMove = null;
        IEnumerable<Move> possibleMoves = _game.GetPossibleMoves();
        Point userSquare = _board.GetPawnLocation(UserInd);
        Point aiSquare = _board.GetPawnLocation(AiInd);
        int userWalls = _board.GetWallCount(UserInd);
        int aiWalls = _board.GetWallCount(AiInd);
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
    /// <summary>
    ///  make a temporary move for the AI to evaluate it, change the state of the game and return true if the move is valid, also taking care of the special move if it exists in the new state of the game
    /// </summary>
    /// <param name="move"></param>
    /// <param name="aiWalls"></param>
    /// <param name="aiSquare"></param>
    /// <returns></returns>
    private bool MakeTempMove(Move move, ref int aiWalls, ref Point aiSquare)
    {
        if (move.GetMoveType())
        {
            _graph.AddBoundary(move.GetWallToPlace());
            if (!_graph.IsPathsExist(_board.GetPawnLocation(UserInd), ComputerPawnStartingPoint.Y, aiSquare,
                    UserPawnStartingPoint.Y))
            {
                _graph.RemoveBoundary(move.GetWallToPlace());
                return false;
            }
            _board.PlaceWall(AiInd, move.GetWallToPlace());
            aiWalls--;
        }
        else
        {
            aiSquare = move.GetPointToMove();
            _board.MovePawn(AiInd, aiSquare);
        }
        if (_board.GetIfSpecialMove())
            _graph = new Graph(_board);

        return true;
    }
    /// <summary>
    ///  undo the temporary move for the AI to evaluate it, change the state of the game to the previous state, also removing the special move if there was one in the previous state of the game.
    /// </summary>
    /// <param name="move"></param>
    /// <param name="aiWalls"></param>
    /// <param name="aiSquare"></param>
    private void UndoAiMove(Move move, ref int aiWalls, ref Point aiSquare)
    {
        if (move.GetMoveType())
        {
            _graph.RemoveBoundary(move.GetWallToPlace());
            _board.RemoveWall(AiInd);
            aiWalls++;
        }
        else
        {
            _board.ReturnToLastLocation(AiInd);
            aiSquare = _board.GetPawnLocation(AiInd);
            
        }
        if (_board.GetIfSpecialMove())
        {
            _board.RemoveSpecialMovePoints(_game.GetPlacedWalls());
            _graph = new Graph(_board); 
        }

    }
    
    /// <summary>
    ///  evaluate the move taking into account the shortest path to the other side, the number of walls left,
    ///  number of paths to the other side and number of paths that are the shortest paths to the other side.
    /// </summary>
    /// <param name="pointUser"> the point the user is on</param>
    /// <param name="pointAi">the point the ai is on</param>
    /// <param name="userWalls">the number of walls left for the user</param>
    /// <param name="aiWalls">the number of walls left for the ai</param>
    /// <returns></returns>
    private double EvaluateMove(Point pointUser, Point pointAi, int userWalls, int aiWalls)
    {
        // calculate for each player what the shortest path to the other side is and how many paths there are to the other side
        int userPathToWin = _graph.GetMinimumDistanceToY(pointUser, ComputerPawnStartingPoint.Y);
        int userMinPaths = _graph.GetMinimumPathsCount();
        int aiPathToWin = _graph.GetMinimumDistanceToY(pointAi, UserPawnStartingPoint.Y);
        int aiMinPaths = _graph.GetMinimumPathsCount();
        // calculate the evaluation of the move taking into account the the number of walls left.
        double aiEval = aiPathToWin * ShortestPathWeight+(userWalls <= aiWalls ? 0 : (userWalls-aiWalls) * NumberOfWallsWeight);
        double userEval = userPathToWin * ShortestPathWeight+(userWalls >= aiWalls ? 0 : (aiWalls-userWalls) * NumberOfWallsWeight);
        // if the player has number of paths that all are the shortest paths to the other side, give him a bonus.
        double aiMinPathEval = aiMinPaths == _graph.CountPathsToY(pointAi, UserPawnStartingPoint.Y) ? aiMinPaths * PathCountWeight : 0;
        double userMinPathEval = userMinPaths == _graph.CountPathsToY(pointUser, ComputerPawnStartingPoint.Y) ? userMinPaths * PathCountWeight : 0;
        double eval = userEval - aiEval;
        // if the user can win in the next move and the ai can not win in the current move reduce the evaluation to the minimum.
        eval -= userPathToWin == 1 && aiPathToWin != 0 ? 10000 : 0;
        // if the player has only one path to the other side, give him a bonus.
        eval += _graph.CountPathsToY(pointAi, UserPawnStartingPoint.Y) ==1 ? OnePathBonus : 0;
        eval -= _graph.CountPathsToY(pointUser, ComputerPawnStartingPoint.Y) ==1 ?OnePathBonus : 0;
        double createMinimumPathOption = aiMinPathEval - userMinPathEval;
        return eval + createMinimumPathOption;
    }
}