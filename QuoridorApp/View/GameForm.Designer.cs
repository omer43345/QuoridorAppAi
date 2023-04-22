using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static QuoridorApp.Constants;

namespace QuoridorApp.View
{
    partial class GameForm
    {
        private PictureBox homeIcon; // the home icon that the user can click on to go back to the home form
        private bool _clickedOnPawn = false; // a flag that indicates if the user clicked on his pawn
        private List<System.Windows.Forms.PictureBox> walls = new List<PictureBox>(); // a list of the walls that the user can place on the board
        private PictureBox[,] canMoveSquares = new PictureBox[9, 9];// a matrix of the squares that the user can move to if he clicks on his pawn
        private PictureBox userPawn;// the user pawn
        private PictureBox computerPawn;// the computer pawn
        private WallsLabel numOfWallsLeftForUser;// the label that shows the number of walls that the user has left
        private WallsLabel numOfWallsLeftForComputer;// the label that shows the number of walls that the computer has left
        private QuoridorButton resetGameButton;// the button that the user can click on to reset the game

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }
        // this function adds the home icon to the form
        private void AddHomeIcon()
        {
            homeIcon = new PictureBox();
            homeIcon.Location = new Point(773, 0);
            homeIcon.Name = "HomeAnimation";
            homeIcon.Size = new Size(50, 50);
            homeIcon.BackColor = Color.Transparent;
            homeIcon.Image = ((Image)(Properties.Resources.homeIcon));
            homeIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(homeIcon, "Go back to the main menu");
            homeIcon.MouseClick += new MouseEventHandler(HomeIcon_Click);
            Controls.Add(homeIcon);
        }
        // this function adds the reset game button to the form
        private void AddResetGameButton()
        {
            resetGameButton = new QuoridorButton();
            resetGameButton.Location = new Point(261, 480);
            resetGameButton.Name = "ResetGameButton";
            resetGameButton.Text = "Reset Game";
            resetGameButton.Font = new Font(resetGameButton.Font.FontFamily, 20, FontStyle.Bold);
            resetGameButton.Size = new Size(300, 100);
            resetGameButton.ToolTipText = "Reset the game";
            resetGameButton.MouseClick += new MouseEventHandler(ResetGameButton_Click);
            Controls.Add(resetGameButton);
        }
        // this function adds the wall counters to the form
        private void AddWallCounters()
        {
            numOfWallsLeftForUser = new WallsLabel();
            numOfWallsLeftForComputer = new WallsLabel();
            Label WallLeftLabel = new Label();


            WallLeftLabel.Location = new Point(12, 0);
            WallLeftLabel.Name = "Walls_Left";
            WallLeftLabel.Text = "Walls Left";
            WallLeftLabel.Font = new Font(WallLeftLabel.Font.FontFamily, 13, FontStyle.Bold | FontStyle.Underline);
            WallLeftLabel.Size = new Size(150, 30);

            numOfWallsLeftForUser.Location = new Point(12, 30);
            numOfWallsLeftForUser.Name = User;
            numOfWallsLeftForUser.PlayerName= User;
            numOfWallsLeftForUser.Font = new Font(numOfWallsLeftForComputer.Font.FontFamily, 10, FontStyle.Bold);
            numOfWallsLeftForUser.Size = new Size(150, 20);

            numOfWallsLeftForComputer.Location = new Point(12, 55);
            numOfWallsLeftForComputer.Name = Computer;
            numOfWallsLeftForComputer.PlayerName = Computer;
            numOfWallsLeftForComputer.Font = new Font(numOfWallsLeftForComputer.Font.FontFamily, 10, FontStyle.Bold);
            numOfWallsLeftForComputer.Size = new Size(150, 20);

            Controls.Add(numOfWallsLeftForUser);
            Controls.Add(numOfWallsLeftForComputer);
            Controls.Add(WallLeftLabel);
        }
        // this function adds the walls to the form
        private void AddWalls()
        {
            PictureBox wall;
            // vertical walls
            for (int i = 0; i < NumberOfWallsInTheBoard/2; i++)
            {
                wall = new PictureBox();
                wall.Image = ((Image)(Properties.Resources.wall));
                int y = i % 2 == 0 ? 51 : 95;
                wall.Location = new Point(251 + (46 * (i / WallsPerRowAndColumn)), y + ((i % WallsPerRowAndColumn) / 2 * 92));
                wall.Name = "wallv" + i / WallsPerRowAndColumn + "_" + i % WallsPerRowAndColumn;
                wall.Size = new Size(6, 78);
                wall.SizeMode = PictureBoxSizeMode.CenterImage;
                wall.Visible = false;
                wall.MouseClick += new MouseEventHandler(this.PlaceWall);
                wall.MouseLeave += new EventHandler(this.LeaveChosenWall);
                this.Controls.Add(wall);
                walls.Add(wall);
            }

            // horizontal walls
            for (int i = NumberOfWallsInTheBoard/2; i < NumberOfWallsInTheBoard; i++)
            {
                wall = new PictureBox();
                wall.Image = ((Image)(Properties.Resources.wall));
                int x = i % 2 == 0 ? 213 : 260;
                wall.Location = new Point(x + ((i % WallsPerRowAndColumn) / 2 * 92), 85 + (46 * (i % 64 / WallsPerRowAndColumn)));
                wall.Name = "wallh" + i / WallsPerRowAndColumn + "_" + i % WallsPerRowAndColumn;
                wall.Size = new Size(78, 6);
                wall.SizeMode = PictureBoxSizeMode.CenterImage;
                wall.Visible = false;
                wall.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                wall.MouseClick += new MouseEventHandler(this.PlaceWall);
                wall.MouseLeave += new EventHandler(this.LeaveChosenWall);
                this.Controls.Add(wall);
                walls.Add(wall);
            }
        }
        // this function adds the squares that the user can move to
        private void AddCanMoveSquares()
        {
            Image canMoveSquare = Properties.Resources.canMove;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    canMoveSquares[i, j] = new PictureBox();
                    canMoveSquares[i, j].BackColor = Color.LightGray;
                    canMoveSquares[i, j].BackgroundImageLayout = ImageLayout.Center;
                    canMoveSquares[i, j].Image = ((Image)(canMoveSquare));
                    canMoveSquares[i, j].Location = new Point(211 + (46 * j), 45 + (46 * i));
                    canMoveSquares[i, j].Name = "canMoveSquare" + (i + 1) * (j + 1);
                    canMoveSquares[i, j].Size = new Size(40, 40);
                    canMoveSquares[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                    canMoveSquares[i, j].Visible = false;
                    canMoveSquares[i, j].MouseClick += new MouseEventHandler(this.CanMoveSquaresClicked);
                    Controls.Add(canMoveSquares[i, j]);
                }
            }
        }
        // this function adds the squares to the form
        private void AddSquares()
        {
            Image square = Properties.Resources.board_square;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    PictureBox boardSquare = new PictureBox();
                    boardSquare.Image = ((Image)(square));
                    boardSquare.Location = new Point(211 + (46 * j), 45 + (46 * i));
                    boardSquare.Name = "square" + (i + 1) * (j + 1);
                    boardSquare.Size = new Size(40, 40);
                    Controls.Add(boardSquare);
                }
            }
        }
        // this function adds the pawns to the form
        private void AddPawns()
        {
            //
            // computerPawn
            //
            computerPawn = new PictureBox();
            computerPawn.BackColor = Color.DarkGray;
            computerPawn.BackgroundImageLayout = ImageLayout.Center;
            computerPawn.Image = ((Image)(Properties.Resources.pawn2));
            computerPawn.Location = new Point(395, 45);
            computerPawn.Name = "computerPawn";
            computerPawn.Size = new Size(40, 40);
            computerPawn.SizeMode = PictureBoxSizeMode.CenterImage;
            // 
            // userPawn
            // 
            userPawn = new PictureBox();
            userPawn.BackColor = Color.DarkGray;
            userPawn.BackgroundImageLayout = ImageLayout.Center;
            userPawn.Image = ((Image)(Properties.Resources.pawn1));
            userPawn.Location = new Point(395, 413);
            userPawn.Name = "userPawn";
            userPawn.Size = new Size(40, 40);
            userPawn.SizeMode = PictureBoxSizeMode.CenterImage;
            userPawn.Click += new EventHandler(this.userPawn_Click);
            Controls.Add(computerPawn);
            Controls.Add(userPawn);
        }
        // this function initializes the form
        private void InitFrom()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.SuspendLayout();
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(FormWidth, FormHeight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quoridor";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanPlaceWall);
            this.ResumeLayout(false);
        }
        #region Windows Form Designer generated code
        #endregion
    }
}