namespace QuoridorApp.Model
{
    // class that representing a cell in the board
    public class Cell : Move
    {
        public Cell(int x, int y) : base(x, y)
        {
        }
        // equals override method that checks if the cell is equal to another cell
        public override bool Equals(object obj)
        {
            if (obj is Cell cellMove)
            {
                return cellMove.X == X && cellMove.Y == Y;
            }
            return false;
        }
        
    }
}