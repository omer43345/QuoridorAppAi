﻿using System.Drawing;
using QuoridorApp.Model;

namespace QuoridorApp;

public static class Constants
{
    public const int BoardSize = 9;
    public const int UserInd = 0;
    public const int AiInd = 1;
    public const int NumberOfWallsInTheBoard = 128;
    public const int WallsPerPlayer = 10;
    public const int WallsPerRowAndColumn = 8;
    public static readonly Cell UserPawnStartingPoint = new Cell(4, 8);
    public static readonly Cell ComputerPawnStartingPoint = new Cell(4, 0);
    public const string WinnerMessage = "Congratulations! You beat the computer!";
    public const string LoserMessage = "You lost! Better luck next time!";
    public const string RestartMessage = "Do you want to play again?";
    public const string WallPlacementErrorMessage = "You must leave at least one path for you and your opponent to win";
    public const string Right = "right";
    public const string Left = "left";
    public const string Up = "up";
    public const string Down = "down";
    public const string Computer = "Computer";
    public const string User = "User";
    public const double NumberOfWallsWeight = 0.8; // Weight of the number of walls in the evaluation function
    public const double ShortestPathWeight = 3.2; // Weight of the shortest path in the evaluation function
    public const double PathCountWeight = 5; // Weight when the number of paths is equal to the number of shortest paths in the evaluation function
    public const double OnePathBonus = 100; // bonus for having only one path
    public const int LoseOption = 10000;// punishment for a move that leads to a loss
    public const string QuoridorRules =
        "Quoridor is played on a game board of 81 square spaces (9x9). Each player is represented by a pawn which" +
        " begins at the center space of one edge of the board (in a two-player game, the pawns begin opposite each other)." +
        " The objective is to be the first player to move their pawn to any space on the opposite side of the game board from which it begins.\n\n" +
        "The distinguishing characteristic of Quoridor is its twenty walls. Walls are flat two-space-wide pieces which" +
        " can be placed in the groove that runs between the spaces. Walls block the path of all pawns, which must go" +
        " around them. The walls are divided equally among the players at the start of the game, and once placed," +
        " cannot be moved or removed. On a turn, a player may either move their pawn, or, if possible, place a wall" +
        "Pawns can be moved to any space at a right angle (but not diagonally). If adjacent to another pawn, the" +
        " pawn may jump over that pawn. If that square is not accessible (e.g., off the edge of the board or blocked by" +
        " a third pawn or a wall), the player may move to either space that is immediately adjacent (left or right) to the" +
        " first pawn. Multiple pawns may not be jumped. Walls may not be jumped, including when moving laterally" +
        " due to a pawn or wall being behind a jumped pawn.\n\n" +
        "Walls can be placed directly between two spaces, in any groove not already occupied by a wall. However," +
        " a wall may not be placed which cuts off the only remaining path of any pawn to the side of the board it must reach.";
    public const int FormWidth = 823;
    public const int FormHeight = 649;
    
    
    
    
}