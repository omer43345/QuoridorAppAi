using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuoridorApp.Controller;
using QuoridorApp.Model;
using static QuoridorApp.Constants;

namespace QuoridorApp.View
{
    // class that represents the game form that the user sees when he starts a new game, it is communicating with the game form controller to visualize the game to the user and update the game state in the game class
    public partial class GameForm : Form
    {
        private readonly GameFormController _gameFormController;
        private List<Cell> _possibleSquares;

        // initialize the form by adding the components, creating a new game form controller and initializing the game form controller
        public GameForm()
        {
            AddHomeIcon();
            AddPawns();
            AddWalls();
            AddCanMoveSquares();
            AddSquares();
            AddWallCounters();
            AddResetGameButton();
            InitFrom();
            _gameFormController = GameFormController.GetInstance();
            _possibleSquares = new List<Cell>();
        }

        // called for every mouse move on the game form, it checks if the user can place a wall in the current mouse position and if so it shows the wall in the current mouse position
        private void CanPlaceWall(object sender, MouseEventArgs e)
        {
            if (_gameFormController.UserTurn() && _gameFormController.CanPlaceWall())
            {
                if (!_clickedOnPawn)
                {
                    int[] allowedWallsIndexes = _gameFormController.GetAllowedWallsIndexes();
                    foreach (int index in allowedWallsIndexes)
                    {
                        // check if the mouse is over the control
                        bool placeWall = index > NumberOfWallsInTheBoard / 2-1
                            ? (e.Y >= walls[index].Location.Y && e.Y <= walls[index].Location.Y + walls[index].Height &&
                               e.X >= walls[index].Location.X &&
                               e.X <= walls[index].Location.X + walls[index].Width / 2)
                            : (e.Y >= walls[index].Location.Y &&
                               e.Y <= walls[index].Location.Y + walls[index].Height / 2 &&
                               e.X >= walls[index].Location.X && e.X <= walls[index].Location.X + walls[index].Width);
                        walls[index].Visible = placeWall;
                    }
                }
            }
        }

        // called when the user clicks on his pawn, it shows the possible squares that the pawn can move to if it is the user turn
        private void userPawn_Click(object sender, EventArgs e)
        {
            if (_gameFormController.UserTurn())
            {
                _clickedOnPawn = !_clickedOnPawn;
                _possibleSquares = _gameFormController.GetPossibleSquares();
                ChangeVisibilityOfCanMoveSquares(_possibleSquares, _clickedOnPawn);
            }
        }
        // called when a user click on his pawn and it changes the visibility of the possible squares that the pawn can move to
        private void ChangeVisibilityOfCanMoveSquares(List<Cell> possibleSquares, bool visible)
        {
            foreach (var square in possibleSquares)
            {
                canMoveSquares[square.Y, square.X].Visible = visible;
            }
        }
        // called when the user clicks on a possible square that was shown if he clicked on his pawn, it moves the pawn to the clicked square and hides the possible squares
        private void CanMoveSquaresClicked(object sender, MouseEventArgs e)
        {
            PictureBox clickedSquare = (PictureBox)sender;
            int x = (clickedSquare.Location.X - 158) / 32;
            int y = (clickedSquare.Location.Y - 37) / 37;
            _clickedOnPawn = false;
            ChangeVisibilityOfCanMoveSquares(_possibleSquares, false);
            userPawn.Location = clickedSquare.Location;
            _gameFormController.MovePawn(x, y);
        }

        // called when the user clicks on a wall that was shown to him, it places the wall in the clicked position if it is the user turn
        // and if the wall not blocking one of the pawns from reaching the other side of the board, if it is, it shows a message to the user
        private void PlaceWall(object sender, MouseEventArgs e)
        {
            PictureBox clickedWall = (PictureBox)sender;
            bool orientation = clickedWall.Height > clickedWall.Width;
            int wallIndex = walls.IndexOf(clickedWall);
            int x = orientation ? wallIndex / 8 : wallIndex % 8;
            int y = orientation ? wallIndex % 8 : (wallIndex - 64) / 8;
            bool allowedWall = _gameFormController.PlaceWall(x, y, orientation);
            if (!allowedWall)
            {
                NotAllowedWall();
                return;
            }

            clickedWall.MouseLeave -= LeaveChosenWall;
            clickedWall.MouseClick -= PlaceWall;
            numOfWallsLeftForUser.PlayerWalls = _gameFormController.GetWallsCounter();
        }
        // called when the computer moves his pawn, it moves the pawn to the given point coordinates on the board. 
        public void MoveComputerPawn(Point point)
        {
            computerPawn.Location = canMoveSquares[point.Y, point.X].Location;
        }
        // called when the computer places a wall, it shows the wall in the clicked position and updates the number of walls left for the computer
        public void PlaceComputerWall(int x, int y, bool orientation)
        {
            int wallIndex = orientation ? x * 8 + y : 64 + y * 8 + x;
            walls[wallIndex].Visible = true;
            walls[wallIndex].MouseClick -= PlaceWall;
            walls[wallIndex].MouseLeave -= LeaveChosenWall;
            numOfWallsLeftForComputer.PlayerWalls = _gameFormController.GetWallsCounter() - 1;
        }
        // when a user leaves a wall that was shown to him, it hides the wall
        private void LeaveChosenWall(object sender, EventArgs e)
        {
            PictureBox clickedWall = (PictureBox)sender;
            clickedWall.Visible = false;
        }
        // shows a message to the user when he tries to place a wall that is not allowed
        private void NotAllowedWall()
        {
            MessageBox.Show(WallPlacementErrorMessage);
        }
        // called when the game is over, it shows a message to the user with the winner and a button to reset the game or exit
        public void GameOver(string message)
        {
            // creating dialog box with the winner message and a button to reset the game or exit
            DialogResult dialogResult =
                MessageBox.Show(message + "\n" + RestartMessage, "Game Over", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                Application.Exit();
            ResetGame();
        }

        // called when the user decides to reset the game, it resets the game to the initial state and informs the controller to reset the game
        private void ResetGame()
        {
            // return the form to the initial state, the pawn to the initial location and all the walls invisible and clickable
            userPawn.Location = canMoveSquares[UserPawnStartingPoint.Y, UserPawnStartingPoint.X].Location;
            computerPawn.Location = canMoveSquares[ComputerPawnStartingPoint.Y, ComputerPawnStartingPoint.X].Location;
            foreach (var wall in walls)
            {
                if (wall.Visible)
                {
                    wall.Visible = false;
                    wall.MouseClick += PlaceWall;
                    wall.MouseLeave += LeaveChosenWall;
                }
            }

            ChangeVisibilityOfCanMoveSquares(_possibleSquares, false);
            numOfWallsLeftForUser.PlayerWalls = WallsPerPlayer;
            numOfWallsLeftForComputer.PlayerWalls = WallsPerPlayer;
            _gameFormController.ResetGame();
        }
        // called when the user clicks on the reset game button, it resets the game
        private void ResetGameButton_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
        // called when the user clicks on the HomeIcon, it shows the home form and closes the current form
        private void HomeIcon_Click(object sender, MouseEventArgs e)
        {
            HomeForm homeForm = new HomeForm();
            this.Hide();
            homeForm.ShowDialog();
            this.Close();
        }
    }
}