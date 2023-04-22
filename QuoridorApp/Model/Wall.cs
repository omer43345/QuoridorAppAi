namespace QuoridorApp.Model
{
    // class that represents a wall on the board and have 3 arguments: orientation,  row and column in bits
    public class Wall
    {
        public readonly int X;// represent the row of the wall
        public readonly int Y;// represent the column of the wall
        public readonly bool Orientation; // true = vertical, false = horizontal

        public Wall(bool orientation, int x, int y)
        {
            Orientation = orientation;
            X = x;
            Y = y;
        }
        //equals override method that checks if the wall is equal to another wall
        public bool Equals(Wall wall)
        {
            return wall.X == X && wall.Y == Y && wall.Orientation == Orientation;
        }
    }
}