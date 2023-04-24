using System.Drawing;

namespace QuoridorApp.Model;

// class that representing the chosen move of the player
public class Move
{
    public readonly int X;// represent the move x coordinate
    public readonly int Y;// represent the move y coordinate


    // constructor for wall move type
    protected Move(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

}