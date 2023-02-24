namespace QuoridorApp.Controller
{
    // class that represents a wall on the board and have 3 arguments: orientation,  row and column in bits
    public class Wall
    {

        public readonly int Row;// 8 bits for the location of the wall in the row
        public readonly int Column;// 8 bits for the location of the wall in the column
        public readonly bool Orientation;// true = vertical, false = horizontal
        public Wall(bool orientation,int x,int y)
        {
            Orientation = orientation;
            Row = 1 << (7 - x);
            Column = 1 << (7 - y);
        }
        
    }
}