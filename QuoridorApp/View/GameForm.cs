
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuoridorApp
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
            InitializeComponent();
            _gameFormController = new GameFormController(this);
            _possibleSquares = new List<Point>();
        }



        private void CanPlaceWall(object sender, MouseEventArgs e)
        {
            // TODO: creating temp array of walls that only the legal walls are in
            
            if (!_clickedOnPawn)
            {
                int[] allowedWallsIndexes = _gameFormController.GetAllowedWallsIndexes();
                foreach (int index in allowedWallsIndexes)
                {
                    // check if the mouse is over the control
                    bool placeWall = index > 63
                        ? (e.Y >= walls[index].Location.Y && e.Y <= walls[index].Location.Y + walls[index].Height &&
                           e.X >= walls[index].Location.X && e.X <= walls[index].Location.X + walls[index].Width / 2)
                        : (e.Y >= walls[index].Location.Y && e.Y <= walls[index].Location.Y + walls[index].Height / 2 &&
                           e.X >= walls[index].Location.X && e.X <= walls[index].Location.X + walls[index].Width);
                    walls[index].Visible = placeWall;
                }
                

            }
        }


        private void userPawn_Click(object sender, EventArgs e)
        {
            _clickedOnPawn = !_clickedOnPawn;
            _possibleSquares = _gameFormController.GetPossibleSquares();
            ChangeVisibilityOfCanMoveSquares(_possibleSquares, _clickedOnPawn);
        }
        private void ChangeVisibilityOfCanMoveSquares(List<Point> possibleSquares, bool visible)
        {
            foreach (var square in possibleSquares)
            {
                canMoveSquares[square.Y,square.X].Visible = visible;
            }
        }

        private void CanMoveSquaresClicked(object sender, MouseEventArgs e)
        {
            
            PictureBox clickedSquare = (PictureBox)sender;
            int x = (clickedSquare.Location.X - 158) / 32;
            int y = (clickedSquare.Location.Y - 37) / 37;
            _gameFormController.MovePawn(x, y);
            _clickedOnPawn = false;           
            ChangeVisibilityOfCanMoveSquares(_possibleSquares, false);
            userPawn.Location = clickedSquare.Location;

        }

        private void PlaceWall(object sender, MouseEventArgs e)
        {
            PictureBox clickedWall = (PictureBox)sender;
            bool orientation = clickedWall.Height > clickedWall.Width;
            int wallIndex = walls.IndexOf(clickedWall);
            int x = orientation? wallIndex / 8: wallIndex % 8;
            int y = orientation?wallIndex % 8: (wallIndex-64) / 8;
            _gameFormController.PlaceWall(x, y, orientation);
            clickedWall.MouseLeave-=LeaveChosenWall;
            clickedWall.MouseClick -= PlaceWall;
        }

        private void LeaveChosenWall(object sender, EventArgs e)
        {
            PictureBox clickedWall = (PictureBox)sender;
            clickedWall.Visible = false;
        }
    }
}