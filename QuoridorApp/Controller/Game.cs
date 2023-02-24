using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static QuoridorApp.Constants;

namespace QuoridorApp.Controller
{
    // class that represents the game and have hashmap of walls that can be placed, contains the turn of the player and  manages the game
    public class Game
    {
        private static Game _instance;
        private static Dictionary<int,Wall> _allowedWalls;
        private readonly List<Wall> _placedWalls = new List<Wall>();
        private static Pawn[] _pawns;// 0 = user, 1 = computer
        private static int _turn;// 0 = user, 1 = computer
        private GameFormController _gameFormController = GameFormController.GetInstance();

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
            _allowedWalls = new Dictionary<int, Wall>();
            _pawns = new Pawn[2];
            for (int i = 0; i < NumberOfWallsInTheBoard; i++)// first 64 are vertical walls and the rest are horizontal walls
            {
                bool orientation = i < NumberOfWallsInTheBoard / 2;
                int x = orientation ? i / WallsPerRowAndColumn : (i - NumberOfWallsInTheBoard / 2) % WallsPerRowAndColumn;
                int y = orientation ? i % WallsPerRowAndColumn : (i - NumberOfWallsInTheBoard / 2) / WallsPerRowAndColumn;
                _allowedWalls.Add(i, new Wall(orientation, x, y));
            }
            _pawns[0] = new Pawn(UserPawnStartingPoint.X, UserPawnStartingPoint.Y);
            _pawns[1] = new Pawn(ComputerPawnStartingPoint.X, ComputerPawnStartingPoint.Y);
            _turn = 0;
        }
        public void MovePawn(int x,int y)
        {
            _pawns[_turn].SetLocation(x,y);
            if((_pawns[_turn].Row == 0 &&_turn == 0) || (_pawns[_turn].Row == BoardSize-1 && _turn == 1))
                _gameFormController.GameOver(_turn==0?WinnerMessage:LoserMessage);
        }
        public void PlaceWall(int x,int y, bool orientation)
        {
            // update the dictionary of walls
            UpdateWallList(x, y, orientation);
            _pawns[_turn].PlaceWall();
        }
        
        public bool CanPlaceWall()
        {
            return _pawns[_turn].CanPlaceWall();
        }
        public List<Point> GetPossibleSquares()
        {
            int x = _pawns[_turn].Column;
            int y = _pawns[_turn].Row;
            Dictionary<string, Point> possibleSquares = new Dictionary<string, Point>
            {
                { "left", new Point(x - 1, y) },
                { "right", new Point(x + 1, y) },
                { "up", new Point(x, y - 1) },
                { "down", new Point(x, y + 1) }
            };
            BoundariesCheck(possibleSquares);
            CheckWalls(possibleSquares);
            return possibleSquares.Values.ToList();
        }
        
        /// <summary>
        ///  update the dictionary of walls and remove the walls that are not allowed to be placed, also add the wall that was placed to the list of placed walls
        /// </summary> 
        /// <param name="x">representing the x of the wall we want to place</param>
        /// <param name="y">representing the y of the wall we want to place</param>
        /// <param name="orientation">representing the orientation of the wall we want to place</param>
        private void UpdateWallList(int x, int y, bool orientation)
        {
            foreach (var wall in _allowedWalls)
            {
                if (wall.Value.Orientation == orientation)
                {
                    int wallX = orientation ? wall.Key / WallsPerRowAndColumn : (wall.Key - NumberOfWallsInTheBoard / 2) % WallsPerRowAndColumn;
                    int wallY = orientation ? wall.Key % WallsPerRowAndColumn : (wall.Key - NumberOfWallsInTheBoard / 2) / WallsPerRowAndColumn;
                    if (wallX == x && wallY == y)
                    {
                        int i = wall.Key;
                        _placedWalls.Add(wall.Value);
                        _allowedWalls.Remove(i);
                        int index = orientation ? wallY*WallsPerRowAndColumn+wallX+ (NumberOfWallsInTheBoard / 2) : wallY+wallX*WallsPerRowAndColumn;
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
        private void BoundariesCheck(Dictionary<String,Point> possibleSquares)
        {
            for (int i = possibleSquares.Keys.Count - 1; i >= 0; i--)
            {
                var key = possibleSquares.Keys.ElementAt(i);
                var square = possibleSquares[key];
                if (square.X is < 0 or > WallsPerRowAndColumn || square.Y is < 0 or > WallsPerRowAndColumn)
                    possibleSquares.Remove(key);
            }
        }
        /// <summary>
        ///  remove the squares that are blocked by walls
        /// </summary>
        /// <param name="possibleSquares">Dictionary of the possible squares to move</param>
        private void CheckWalls(Dictionary<String,Point> possibleSquares)
        {
            int bitRow = _pawns[_turn].BitRow;
            int bitColumn = _pawns[_turn].BitColumn;
            foreach (var wall in _placedWalls)
            {
                if (wall.Orientation) // horizontal for checking the left and right squares to move
                {
                    if ((((wall.Row << 1) ^ bitRow) == 0 || (wall.Row ^ bitRow) == 0) && ((wall.Column ^ bitColumn) == 0 || ((wall.Column << 1) ^ bitColumn) == 0))
                        possibleSquares.Remove((wall.Row^ bitRow) == 0? "left" : "right");
                }
                else // vertical for checking the up and down squares to move
                {
                    if ((((wall.Column<<1)^bitColumn)==0||(wall.Column^bitColumn)==0) && ((wall.Row^bitRow)==0|| ((wall.Row<<1)^bitRow)==0))
                        possibleSquares.Remove((wall.Column ^ bitColumn) == 0 ? "up" : "down");
                }
            }
        }

        public bool UserTurn()
        {
            return _turn == 0;
        }

        public int GetWallsCounter()
        {
            return _pawns[_turn].GetWallCount();
        }

        public void ResetGame()
        {
            _placedWalls.Clear();
            InitializeGame();
        }
    }
}