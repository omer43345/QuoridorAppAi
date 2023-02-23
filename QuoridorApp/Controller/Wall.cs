using System.Windows.Forms;

namespace QuoridorApp
{
    // class that represents a wall on the board and have 4 properties: canBePlaced, orientation, Placed and binary location
    public class Wall
    {

        public readonly int _location;// 16 bits, first 8 for x and last 8 for y
        private bool CanBePlaced { get; set; }
        private bool Placed { get; set; }
        private bool Orientation { get; set; }// true = vertical, false = horizontal
        public Wall(bool orientation,int x,int y)
        {
            CanBePlaced = true;
            Placed = false;
            Orientation = orientation;
            _location = (1 << (16-x)) | (1 << (8-y)); 
        }
        
    }
}