namespace QuoridorApp
{
    // class that represents a pawn on the board and have 2 properties: row and column in bits
    public class Pawn
    {
        public int _row;// the row of the pawn
        public int _column; // the column of the pawn
        public int _bitRow;// 9 bits for the location of the pawn in the row
        public int _bitColumn;// 9 bits for the location of the pawn in the column
        public Pawn(int x,int y)
        {
            _row = y;
            _column = x;
            _bitRow = 1 << (9 - x);
            _bitColumn = 1 << (9 - y);
        }
        public void setLocation(int x,int y)
        {
            _row = y;
            _column = x;
            _bitRow = 1 << (9 - x);
            _bitColumn = 1 << (9 - y);
        }
        
        
    }
}