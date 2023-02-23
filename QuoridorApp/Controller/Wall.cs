using System.Windows.Forms;

namespace QuoridorApp
{
    // class that represents a wall on the board and have 3 arguments: orientation,  row and column in bits
    public class Wall
    {

        public readonly int _row;// 8 bits for the location of the wall in the row
        public readonly int _column;// 8 bits for the location of the wall in the column
        public readonly bool _orientation;// true = vertical, false = horizontal
        public Wall(bool orientation,int x,int y)
        {
            _orientation = orientation;
            _row = 1 << (8 - x);
            _column = 1 << (8 - y);
        }
        
    }
}