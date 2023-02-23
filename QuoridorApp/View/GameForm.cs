
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



        private void CanPlaceVerticalWall(object sender, MouseEventArgs e)
        {
            // TODO: creating temp array of walls that only the legal walls are in
            // check if the mouse is over the control
            for(int i = 0; i < walls.Length; i++)
            {
                bool placeWall= i>63 ? (e.Y >= walls[i].Location.Y && e.Y <= walls[i].Location.Y + walls[i].Height && e.X >= walls[i].Location.X && e.X <= walls[i].Location.X + walls[i].Width/2) :
                                       (e.Y >= walls[i].Location.Y && e.Y <= walls[i].Location.Y + walls[i].Height/2 && e.X >= walls[i].Location.X && e.X <= walls[i].Location.X + walls[i].Width);
                walls[i].Visible = placeWall;
            }
        }


        private void userPawn_Click(object sender, EventArgs e)
        {
            
        }
    }
}