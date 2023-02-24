using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace QuoridorApp.Controller
{
    // class that represents the game and have hashmap of walls that can be placed, contains the turn of the player and  manages the game
    public class Game
    {
        private static Game _instance;
        private static readonly Dictionary<int,Wall> AllowedWalls = new Dictionary<int,Wall>();
        private List<Wall> _placedWalls = new List<Wall>();

        private static readonly Pawn[] _pawns = new Pawn[2];// 0 = user, 1 = computer
        private static int _turn;// 0 = user, 1 = computer
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
            for (int i = 0; i < 128; i++)
            {
                bool orientation = i < 64;
                int x = orientation ? i / 8 : (i - 64) % 8;
                int y = orientation ? i % 8 : (i - 64) / 8;
                AllowedWalls.Add(i, new Wall(orientation, x, y));
            }
            _pawns[0] = new Pawn(4, 8);
            _pawns[1] = new Pawn(4, 0);
            _turn = 0;
        }
        public void MovePawn(int x,int y)
        {
            _pawns[_turn].setLocation(x,y);
        }
        public void PlaceWall(int x,int y, bool orientation)
        {
            // update the dictionary of walls
            UpdateWallList(x, y, orientation);
        }
        public List<Point> GetPossibleSquares()
        {
            int x = _pawns[_turn]._column;
            int y = _pawns[_turn]._row;
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
            foreach (var wall in AllowedWalls)
            {
                if (wall.Value._orientation == orientation)
                {
                    int wallX = orientation ? wall.Key / 8 : (wall.Key - 64) % 8;
                    int wallY = orientation ? wall.Key % 8 : (wall.Key - 64) / 8;
                    if (wallX == x && wallY == y)
                    {
                        int i = wall.Key;
                        _placedWalls.Add(wall.Value);
                        AllowedWalls.Remove(i);
                        int index = orientation ? wallY*8+wallX+64 : wallY+wallX*8;
                        if (AllowedWalls.ContainsKey(index))
                            AllowedWalls.Remove(index);
                        if ((i % 8) > 0)
                            AllowedWalls.Remove(i - 1);
                        if ((i % 8) != 7)
                            AllowedWalls.Remove(i + 1);
                        break;
                    }
                }
            }
        }
        public int[] GetAllowedWallsIndexes()
        {
            return AllowedWalls.Keys.ToArray();
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
                if (square.X is < 0 or > 8 || square.Y is < 0 or > 8)
                    possibleSquares.Remove(key);
            }
        }
        /// <summary>
        ///  remove the squares that are blocked by walls
        /// </summary>
        /// <param name="possibleSquares">Dictionary of the possible squares to move</param>
        private void CheckWalls(Dictionary<String,Point> possibleSquares)
        {
            int bitRow = _pawns[_turn]._bitRow;
            int bitColumn = _pawns[_turn]._bitColumn;
            foreach (var wall in _placedWalls)
            {
                if (wall._orientation) // horizontal for checking the left and right squares to move
                {
                    if ((((wall._row << 1) ^ bitRow) == 0 || (wall._row ^ bitRow) == 0) && ((wall._column ^ bitColumn) == 0 || ((wall._column << 1) ^ bitColumn) == 0))
                        possibleSquares.Remove((wall._row^ bitRow) == 0? "left" : "right");
                }
                else // vertical for checking the up and down squares to move
                {
                    if ((((wall._column<<1)^bitColumn)==0||(wall._column^bitColumn)==0) && ((wall._row^bitRow)==0|| ((wall._row<<1)^bitRow)==0))
                        possibleSquares.Remove((wall._column ^ bitColumn) == 0 ? "up" : "down");
                }
            }
        }
    }
}