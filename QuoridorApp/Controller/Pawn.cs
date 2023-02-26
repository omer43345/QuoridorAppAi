using System.Drawing;
using static QuoridorApp.Constants;

namespace QuoridorApp.Controller
{
    // class that represents a pawn on the board and have 2 properties: row and column in bits
    public class Pawn
    {
        public Point Location;
        private int _wallCount;// the number of walls that the pawn has left
        public Pawn(Point startLocation)
        {
            Location = startLocation;
            _wallCount = 10;
        }
        public void SetLocation(Point newLocation)
        {
            Location = newLocation;
        }
        public void PlaceWall()
        {
            _wallCount--;
        }
        public int GetWallCount()
        {
            return _wallCount;
        }
        
        
    }
}