namespace QuoridorApp
{
    // class that represents a pawn on the board and have 2 properties: square in bits
    public class Pawn
    {
        public readonly int _location;// 18 bits, first 9 for x and last 9 for y
        public Pawn(int x,int y)
        {
            _location = (1 << (18-x)) | (1 << (9-y)); 
        }
        
    }
}