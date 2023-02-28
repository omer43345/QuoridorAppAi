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
        private static Dictionary<int, Wall> _allowedWalls;
        private static int _turn; // 0 = user, 1 = computer
        private GameFormController _gameFormController = GameFormController.GetInstance();
        private static Board _board;
        private static Graph _graph;
        private static Ai _ai;
        private static List<Wall> _placedWalls;

        public static Game GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Game();
                InitializeGame();
            }

            return _instance;
        }

        private static void InitializeGame()
        {
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

            _turn = 0;
        }

        public void MovePawn(Point newLocation, bool isAi = false)
        {
            if (_board.GetIfSpecialMove())
            {
                _board.RemoveSpecialMovePoints(_placedWalls);
                _graph = new Graph(_board);
            }
            _board.MovePawn(_turn, newLocation);
            if ((newLocation.Y == 0 && _turn == 0) || (newLocation.Y == BoardSize - 1 && _turn == 1))
                _gameFormController.GameOver(_turn == 0 ? WinnerMessage : LoserMessage);
            if (_board.GetIfSpecialMove())
            {
                _graph = new Graph(_board);
            }
            ChangeTurn();
            if (!isAi)
                MakeAiMove();
        }
        

        public bool PlaceWall(int x, int y, bool orientation, bool isAi = false)
        {
            if (_board.GetIfSpecialMove())
            {
                _board.RemoveSpecialMovePoints(_placedWalls);
                _graph = new Graph(_board);
            }
            Wall wall = new Wall(orientation, x, y);
            _placedWalls.Add(wall);
            _graph.AddBoundary(wall);
            if (!isAi && _graph.GetMinimumDistanceToY(_board.GetPawnLocation(0), 0) == -1 ||
                _graph.GetMinimumDistanceToY(_board.GetPawnLocation(1), BoardSize - 1) == -1)
            {
                _graph.RemoveBoundary(wall);
                return false;
            }

            UpdateWallList(wall);
            _board.PlaceWall(_turn, wall);
            ChangeTurn();
            if (!isAi)
                MakeAiMove();
            return true;
        }

        private void MakeAiMove()
        {
            _ai = new Ai(_graph);
            AiMove move = _ai.GetAiMove();
            _gameFormController.UpdateBoard(move);
            if (move.GetMoveType())
                PlaceWall(move.GetWallToPlace().X, move.GetWallToPlace().Y, move.GetWallToPlace().Orientation, true);
            else
                MovePawn(move.GetPointToMove(), true);
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
                { "down", new Point(x, y + 1) },
                { "left", new Point(x - 1, y) },
                { "right", new Point(x + 1, y) },
                { "up", new Point(x, y - 1) }
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
                if (wall.Value.Orientation == placedWall.Orientation)
                {
                    int wallX = placedWall.Orientation
                        ? wall.Key / WallsPerRowAndColumn
                        : (wall.Key - NumberOfWallsInTheBoard / 2) % WallsPerRowAndColumn;
                    int wallY = placedWall.Orientation
                        ? wall.Key % WallsPerRowAndColumn
                        : (wall.Key - NumberOfWallsInTheBoard / 2) / WallsPerRowAndColumn;
                    if (wallX == placedWall.X && wallY == placedWall.Y)
                    {
                        int i = wall.Key;
                        _allowedWalls.Remove(i);
                        int index = placedWall.Orientation
                            ? wallY * WallsPerRowAndColumn + wallX + (NumberOfWallsInTheBoard / 2)
                            : wallY + wallX * WallsPerRowAndColumn;
                        _allowedWalls.Remove(index);
                        if ((i % WallsPerRowAndColumn) > 0)
                            _allowedWalls.Remove(i - 1);
                        if ((i % WallsPerRowAndColumn) != WallsPerRowAndColumn - 1)
                            _allowedWalls.Remove(i + 1);
                        break;
                    }
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
            return _turn == 0;
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
            _turn = _turn == 0 ? 1 : 0;
        }

        public Dictionary<int, Wall> GetAllowedWalls()
        {
            return _allowedWalls;
        }

        public Board GetBoard()
        {
            return _board;
        }
    }
}