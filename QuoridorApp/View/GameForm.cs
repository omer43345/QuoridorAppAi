
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoridorApp
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            AddPawns();
            AddWalls();
            AddCanMoveSquares();
            AddSquares();
            InitializeComponent();
        }



        private void CanPlaceWall(object sender, MouseEventArgs e)
        {
            // TODO: creating temp array of walls that only the legal walls are in
            if (!_clickedOnPawn)
            {
                // check if the mouse is over the control
                for (int i = 0; i < walls.Count; i++)
                {
                    bool placeWall = i > 63
                        ? (e.Y >= walls[i].Location.Y && e.Y <= walls[i].Location.Y + walls[i].Height &&
                           e.X >= walls[i].Location.X && e.X <= walls[i].Location.X + walls[i].Width / 2)
                        : (e.Y >= walls[i].Location.Y && e.Y <= walls[i].Location.Y + walls[i].Height / 2 &&
                           e.X >= walls[i].Location.X && e.X <= walls[i].Location.X + walls[i].Width);
                    walls[i].Visible = placeWall;
                }
            }
        }


        private void userPawn_Click(object sender, EventArgs e)
        {
            _clickedOnPawn = !_clickedOnPawn;
            ChangeVisibilityOfCanMoveSquares(canMoveSquares, _clickedOnPawn);
        }
        private void ChangeVisibilityOfCanMoveSquares(PictureBox[,] canMoveSquares, bool visible)
        {
            for (int i = 0; i < canMoveSquares.GetLength(0); i++)
            {
                for (int j = 0; j < canMoveSquares.GetLength(1); j++)
                {
                    canMoveSquares[i, j].Visible = visible;
                }
            }
        }

        private void CanMoveSquaresClicked(object sender, MouseEventArgs e)
        {
            PictureBox clickedSquare = (PictureBox)sender;
            _clickedOnPawn = false;           
            ChangeVisibilityOfCanMoveSquares(canMoveSquares, false);
            userPawn.Location = clickedSquare.Location;

        }

        private void PlaceWall(object sender, MouseEventArgs e)
        {
            PictureBox clickedWall = (PictureBox)sender;
            clickedWall.MouseLeave-=LeaveChosenWall;
            clickedWall.MouseClick -= PlaceWall;
            walls.Remove(clickedWall);
        }

        private void LeaveChosenWall(object sender, EventArgs e)
        {
            PictureBox clickedWall = (PictureBox)sender;
            clickedWall.Visible = false;
        }
    }
}