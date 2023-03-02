using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuoridorApp.Controller;
using static QuoridorApp.Constants;

namespace QuoridorApp.View
{
    public partial class GameForm : Form
    {
        private GameFormController _gameFormController;
        private List<Point> _possibleSquares;

        public GameForm()
        {
            AddPawns();
            AddWalls();
            AddCanMoveSquares();
            AddSquares();
            AddWallCounters();
            AddResetGameButton();
            InitializeComponent();
            _gameFormController = GameFormController.GetInstance();
            _possibleSquares = new List<Point>();
        }


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
                        bool placeWall = index > 63
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


        private void userPawn_Click(object sender, EventArgs e)
        {
            if (_gameFormController.UserTurn())
            {
                _clickedOnPawn = !_clickedOnPawn;
                _possibleSquares = _gameFormController.GetPossibleSquares();
                ChangeVisibilityOfCanMoveSquares(_possibleSquares, _clickedOnPawn);
            }
        }

        private void ChangeVisibilityOfCanMoveSquares(List<Point> possibleSquares, bool visible)
        {
            foreach (var square in possibleSquares)
            {
                canMoveSquares[square.Y, square.X].Visible = visible;
            }
        }

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
            numOfWallsLeftForUser.Text = "USER :" + _gameFormController.GetWallsCounter();
        }

        public void MoveComputerPawn(Point point)
        {
            computerPawn.Location = canMoveSquares[point.Y, point.X].Location;
        }

        public void PlaceComputerWall(int x, int y, bool orientation)
        {
            int wallIndex = orientation ? x * 8 + y : 64 + y * 8 + x;
            walls[wallIndex].Visible = true;
            walls[wallIndex].MouseClick -= PlaceWall;
            walls[wallIndex].MouseLeave -= LeaveChosenWall;
            numOfWallsLeftForComputer.Text = "COMPUTER :" + (_gameFormController.GetWallsCounter() - 1);
        }

        private void LeaveChosenWall(object sender, EventArgs e)
        {
            PictureBox clickedWall = (PictureBox)sender;
            clickedWall.Visible = false;
        }

        private void NotAllowedWall()
        {
            MessageBox.Show(WallPlacementErrorMessage);
        }

        public void GameOver(string message)
        {
            // creating dialog box with the winner message and a button to reset the game or exit
            DialogResult dialogResult =
                MessageBox.Show(message + "\n" + RestartMessage, "Game Over", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                Application.Exit();
            ResetGame();
        }

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
            ChangeVisibilityOfCanMoveSquares( _possibleSquares, false);
            numOfWallsLeftForUser.Text = "USER : 10";
            numOfWallsLeftForComputer.Text = "COMPUTER : 10";
            _gameFormController.ResetGame();
        }

        private void ResetGameButton_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}