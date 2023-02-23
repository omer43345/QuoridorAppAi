namespace QuoridorApp
{
    // class that represents a pawn on the board and have 2 properties: row and column in bits
    public class Pawn
    {
        public readonly int _row;// 9 bits for the location of the pawn in the row
        public readonly int _column;// 9 bits for the location of the pawn in the column
        public Pawn(int x,int y)
        {
            _row = 1 << (9 - x);
            _column = 1 << (9 - y);
        }
        
    }
}