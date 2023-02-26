using System.Drawing;
using QuoridorApp.Controller;

namespace QuoridorApp.Model;
// class that representing the ai chosen move, contains wall to place or point to move to
public class AiMove
{
    
    private Point _pointToMove;// point to move to
    private Wall _wallToPlace;// wall to place
    private bool _moveType;// true if wall to place, false if point to move
    
    public AiMove(Wall wall)
    {
        _wallToPlace = wall;
        _pointToMove = new Point(-1, -1);
        _moveType = true;
    }

    
    public AiMove(Point point)
    {
        _pointToMove = point;
        _wallToPlace = null;
        _moveType = false;
    }
    
    public bool GetMoveType()
    {
        return _moveType;
    }
    
    public Point GetPointToMove()
    {
        return _pointToMove;
    }
    
    public Wall GetWallToPlace()
    {
        return _wallToPlace;
    }
    

    



}