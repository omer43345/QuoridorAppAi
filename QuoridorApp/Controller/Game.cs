using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace QuoridorApp
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
                AllowedWalls.Add(i, new Wall(i < 63, i % 8 + 1, i / 8 + 1));
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
            List<Point> possibleSquares = new List<Point>();
            int x= _pawns[_turn]._column;
            int y= _pawns[_turn]._row;
            if (x > 0)
                possibleSquares.Add(new Point( x - 1, y));
            if (x < 8)
                possibleSquares.Add(new Point( x + 1, y));
            if (y > 0)
                possibleSquares.Add(new Point( x, y - 1));
            if (y < 8)
                possibleSquares.Add(new Point( x, y + 1));
            return possibleSquares;
        }
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
    }
}