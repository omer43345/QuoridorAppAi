namespace QuoridorApp.Model
{
    // class that representing the wall the player can place on the board
    public class Wall : Move
    {
        public readonly bool Orientation; // true = vertical, false = horizontal

        public Wall(bool orientation, int x, int y) : base(x, y)
        {
            Orientation = orientation;
        }
        //equals override method that checks if the wall is equal to another wall
        public bool Equals(Wall wall)
        {
            return wall.X == X && wall.Y == Y && wall.Orientation == Orientation;
        }
    }
}