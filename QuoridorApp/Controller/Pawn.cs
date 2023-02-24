using static QuoridorApp.Constants;

namespace QuoridorApp.Controller
{
    // class that represents a pawn on the board and have 2 properties: row and column in bits
    public class Pawn
    {
        public int Row;// the row of the pawn
        public int Column; // the column of the pawn
        public int BitRow;// 9 bits for the location of the pawn in the row
        public int BitColumn;// 9 bits for the location of the pawn in the column
        private int _wallCount;// the number of walls that the pawn has left
        public Pawn(int x,int y)
        {
            Row = y;
            Column = x;
            BitRow = 1 << (BoardSize-1 - x);
            BitColumn = 1 << (BoardSize-1 - y);
            _wallCount = 10;
        }
        public void SetLocation(int x,int y)
        {
            Row = y;
            Column = x;
            BitRow = 1 << (BoardSize-1 - x);
            BitColumn = 1 << (BoardSize-1 - y);
        }
        public void PlaceWall()
        {
            _wallCount--;
        }
        public bool CanPlaceWall()
        {
            return _wallCount > 0;
        }
        public int GetWallCount()
        {
            return _wallCount;
        }
        
        
    }
}