using System.Drawing;

namespace QuoridorApp;

public static class Constants
{
    public const int BoardSize = 9;
    public const int UserInd = 0;
    public const int AiInd = 1;
    public const int NumberOfWallsInTheBoard = 128;
    public const int WallsPerPlayer = 10;
    public const int WallsPerRowAndColumn = 8;
    public static Point UserPawnStartingPoint = new(4, 8);
    public static Point ComputerPawnStartingPoint = new(4, 0);
    public const string WinnerMessage = "Congratulations! You beat the computer!";
    public const string LoserMessage = "You lost! Better luck next time!";
    public const string RestartMessage = "Do you want to play again?";
    public const string WallPlacementErrorMessage = "You must leave at least one path for you and your opponent to win";
    public const string Right = "right";
    public const string Left = "left";
    public const string Up = "up";
    public const string Down = "down";
    public const double NumberOfWallsWeight = 4; // Weight of the number of walls in the evaluation function
    public const double ShortestPathWeight = 1; // Weight of the shortest path in the evaluation function
}