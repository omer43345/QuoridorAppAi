namespace QuoridorApp.Model
{
    // class that represents a wall on the board and have 3 arguments: orientation,  row and column in bits
    public class Wall
    {

        public readonly int X;// 8 bits for the location of the wall in the row
        public readonly int Y;// 8 bits for the location of the wall in the column
        public readonly bool Orientation;// true = vertical, false = horizontal
        public Wall(bool orientation,int x,int y)
        {
            Orientation = orientation;
            X = x;
            Y = y;
        }
        
    }
}