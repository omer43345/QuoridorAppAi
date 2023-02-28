using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using QuoridorApp.Controller;
using static QuoridorApp.Constants;

namespace QuoridorApp.Model
{
    // class that represents the game and have hashmap of walls that can be placed, contains the turn of the player and  manages the game
    public class Game
    {
        private static Game _instance;
        private Dictionary<int, Wall> _allowedWalls;
        private int _turn;
        private readonly GameFormController _gameFormController = GameFormController.GetInstance();
        private Board _board;
        private Graph _graph;
        private Ai _ai;
        private List<Wall> _placedWalls;
        private Dictionary<int, Wall> _removedWalls;
        private Move _lastMove;


        public static Game GetInstance()
        {
            return _instance ??= new Game();
        }

        public void InitializeGame()
        {
            _removedWalls = new Dictionary<int, Wall>();
            _lastMove = null;
            _placedWalls = new List<Wall>();
            _allowedWalls = new Dictionary<int, Wall>();
            _board = new Board();
            _graph = new Graph(_board);
            for (int i = 0;
                 i < NumberOfWallsInTheBoard;
                 i++) // first 64 are vertical walls and the rest are horizontal walls
            {
                bool orientation = i < NumberOfWallsInTheBoard / 2;
                int x = orientation
                    ? i / WallsPerRowAndColumn
                    : (i - NumberOfWallsInTheBoard / 2) % WallsPerRowAndColumn;
                int y = orientation
                    ? i % WallsPerRowAndColumn
                    : (i - NumberOfWallsInTheBoard / 2) / WallsPerRowAndColumn;
                _allowedWalls.Add(i, new Wall(orientation, x, y));
            }

            _turn = UserInd;
        }

        private void MovePawn(Point newLocation)
        {
            _board.MovePawn(_turn, newLocation);
            if ((newLocation.Y == ComputerPawnStartingPoint.Y && _turn == UserInd) ||
                (newLocation.Y == UserPawnStartingPoint.Y && _turn == AiInd))
                _gameFormController.GameOver(_turn == UserInd ? WinnerMessage : LoserMessage);
        }


        private bool PlaceWall(Wall wall)
        {
            _placedWalls.Add(wall);
            _graph.AddBoundary(wall);
            if (_graph.GetMinimumDistanceToY(_board.GetPawnLocation(UserInd), ComputerPawnStartingPoint.Y) == -1 ||
                _graph.GetMinimumDistanceToY(_board.GetPawnLocation(AiInd), UserPawnStartingPoint.Y) == -1)
            {
                _graph.RemoveBoundary(wall);
                return false;
            }

            UpdateWallList(wall);
            _board.PlaceWall(_turn, wall);
            _lastMove = new Move(wall);
            return true;
        }

        public bool MakeMove(Move move, bool isAi = false)
        {
            if (isAi)
                _gameFormController.UpdateBoard(move);
            bool doneSuccessfully = true;
            if (_board.GetIfSpecialMove())
            {
                _board.RemoveSpecialMovePoints(_placedWalls);
                _graph = new Graph(_board);
            }

            if (move.GetMoveType())
                doneSuccessfully = PlaceWall(move.GetWallToPlace());
            else
                MovePawn(move.GetPointToMove());
            if (!doneSuccessfully)
                return false;
            if (_board.GetIfSpecialMove())
                _graph = new Graph(_board);
            ChangeTurn();
            if (!isAi)
            {
                _ai = new Ai();
                move = _ai.GetAiMove();
                MakeMove(move, true);
            }

            return true;
        }

        public bool MakeAiMove(Move move)
        {
            bool doneSuccessfully = true;
            if (_board.GetIfSpecialMove())
            {
                _board.RemoveSpecialMovePoints(_placedWalls);
                _graph = new Graph(_board);
            }

            if (move.GetMoveType())
                doneSuccessfully = PlaceWall(move.GetWallToPlace());
            else
                MoveAiPawn(move.GetPointToMove());
            if (!doneSuccessfully)
                return false;

            if (_board.GetIfSpecialMove())
                _graph = new Graph(_board);
            return true;
        }

        private void MoveAiPawn(Point getPointToMove)
        {
            _lastMove = new Move(_board.GetPawnLocation(AiInd));
            _board.MovePawn(_turn, getPointToMove);
        }

        public bool CanPlaceWall()
        {
            return _board.GetWallCount(_turn) > 0;
        }

        public List<Point> GetPossibleSquares(Point square)
        {
            int x = square.X;
            int y = square.Y;
            Dictionary<string, Point> possibleSquares = new Dictionary<string, Point>
            {
                { Down, new Point(x, y + 1) },
                { Up, new Point(x, y - 1) },
                { Left, new Point(x - 1, y) },
                { Right, new Point(x + 1, y) }
            };
            BoundariesCheck(possibleSquares);
            return possibleSquares.Values.ToList();
        }


        public List<Point> GetAllowedMoves()
        {
            return _board.GetAllowedMoves(_turn);
        }


        /// <summary>
        ///  update the dictionary of walls and remove the walls that are not allowed to be placed, also add the wall that was placed to the list of placed walls
        /// </summary>
        /// <param name="placedWall">the wall that was placed</param>
        private void UpdateWallList(Wall placedWall)
        {
            foreach (var wall in _allowedWalls)
            {
                if (placedWall.Equals(wall.Value))
                {
                    _removedWalls.Add(wall.Key, wall.Value);

                    int index = placedWall.Orientation
                        ? placedWall.Y * WallsPerRowAndColumn + placedWall.X + (NumberOfWallsInTheBoard / 2)
                        : placedWall.Y + placedWall.X * WallsPerRowAndColumn;

                    if (_allowedWalls.ContainsKey(index))
                        _removedWalls.Add(index, _allowedWalls[index]);

                    if (_allowedWalls.ContainsKey(wall.Key - 1))
                        _removedWalls.Add(wall.Key - 1, _allowedWalls[wall.Key - 1]);

                    if (_allowedWalls.ContainsKey(wall.Key + 1))
                        _removedWalls.Add(wall.Key + 1, _allowedWalls[wall.Key + 1]);

                    _allowedWalls.Remove(wall.Key);
                    _allowedWalls.Remove(wall.Key - 1);
                    _allowedWalls.Remove(wall.Key + 1);
                    _allowedWalls.Remove(index);
                    break;
                }
            }
        }

        public int[] GetAllowedWallsIndexes()
        {
            return _allowedWalls.Keys.ToArray();
        }

        /// <summary>
        /// remove the squares that are out of boundaries
        /// </summary>
        /// <param name="possibleSquares">Dictionary of the possible squares to move</param>
        private void BoundariesCheck(Dictionary<String, Point> possibleSquares)
        {
            for (int i = possibleSquares.Keys.Count - 1; i >= 0; i--)
            {
                var key = possibleSquares.Keys.ElementAt(i);
                var square = possibleSquares[key];
                if (square.X is < 0 or > WallsPerRowAndColumn || square.Y is < 0 or > WallsPerRowAndColumn)
                    possibleSquares.Remove(key);
            }
        }


        public bool UserTurn()
        {
            return _turn == UserInd;
        }

        public int GetWallsCounter()
        {
            return _board.GetWallCount(_turn);
        }

        public void ResetGame()
        {
            InitializeGame();
        }

        private void ChangeTurn()
        {
            _turn = _turn == UserInd ? AiInd : UserInd;
        }

        public Board GetBoard()
        {
            return _board;
        }

        public Game CopyState()
        {
            // Create a new instance of the Game class
            Game copy = new Game
            {
                // Copy the state of the instance variables
                _turn = _turn,
                _board = new Board(),
                _removedWalls = new Dictionary<int, Wall>()
            };

            copy._board.MakeTheSameStates(_board);
            copy._graph = new Graph(copy._board);

            // Create a new dictionary and copy the allowed walls
            copy._allowedWalls = new Dictionary<int, Wall>();
            foreach (KeyValuePair<int, Wall> kvp in _allowedWalls)
            {
                copy._allowedWalls.Add(kvp.Key, kvp.Value);
            }

            copy._placedWalls = new List<Wall>();
            foreach (Wall wall in _placedWalls)
            {
                copy._placedWalls.Add(wall);
            }

            return copy;
        }


        public IEnumerable<Move> GetPossibleMoves()
        {
            List<Move> moves = new List<Move>();
            foreach (var point in GetAllowedMoves())
            {
                moves.Add(new Move(point));
            }

            if (CanPlaceWall())
            {
                foreach (var wall in _allowedWalls)
                {
                    moves.Add(new Move(new Wall(wall.Value.Orientation, wall.Value.X, wall.Value.Y)));
                }
            }

            return moves;
        }

        public void UndoLastMove()
        {
            if (_board.GetIfSpecialMove())
            {
                _board.RemoveSpecialMovePoints(_placedWalls);
                _graph = new Graph(_board);
            }

            if (_lastMove != null)
            {
                if (_lastMove.GetMoveType())
                {
                    _placedWalls.Remove(_lastMove.GetWallToPlace());
                    _board.RemoveSpecialMovePoints(_placedWalls);
                    _board.AddToWallCount(_turn);
                    _graph = new Graph(_board);
                    foreach (var wall in _removedWalls)
                    {
                        _allowedWalls.Add(wall.Key, wall.Value);
                    }

                    _removedWalls.Clear();
                }
                else
                {
                    _board.MovePawn(_turn, _lastMove.GetPointToMove());
                }

                _lastMove = null;
            }
        }

        public Graph GetGraph()
        {
            return _graph;
        }
    }
}