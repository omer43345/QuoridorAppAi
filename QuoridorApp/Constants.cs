using System.Drawing;

namespace QuoridorApp;

public static class Constants
{
    public const int BoardSize = 9;
    public const int NumberOfWallsInTheBoard=128;
    public const int WallsPerPlayer=10;
    public const int NumberOfPlayers=2;
    public const int WallsPerRowAndColumn=8;
    public const bool Vertical=true;
    public const bool Horizontal=false;
    public static Point UserPawnStartingPoint=new Point(4,8);
    public static Point ComputerPawnStartingPoint=new Point(4,0);
    public const string WinnerMessage="Congratulations! You beat the computer!";
    public const string LoserMessage="You lost! Better luck next time!";
    public const string RestartMessage="Do you want to play again?";
    
    
    
    
}