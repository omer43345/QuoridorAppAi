using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuoridorApp.View
{
    partial class GameForm
    {
        private bool _clickedOnPawn=false;
        private List<System.Windows.Forms.PictureBox>  walls= new List<PictureBox>();
        private PictureBox[,] canMoveSquares= new PictureBox[9,9];
        private PictureBox userPawn;
        private PictureBox computerPawn;
        private Label  numOfWallsLeftForUser;
        private Label  numOfWallsLeftForComputer;
        private Button resetGameButton;

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
        private void AddResetGameButton()
        {
            resetGameButton = new Button();
            resetGameButton.Location = new Point(12, 80);
            resetGameButton.Name = "ResetGameButton";
            resetGameButton.Text = "Reset Game";
            resetGameButton.Font = new Font(resetGameButton.Font.FontFamily, 10, FontStyle.Bold);
            resetGameButton.Size = new Size(150, 50);
            resetGameButton.MouseClick += new MouseEventHandler(ResetGameButton_Click);
            Controls.Add(resetGameButton);
        }
        private void AddWallCounters()
        {
            numOfWallsLeftForUser = new Label();
            numOfWallsLeftForComputer = new Label();
            Label WallLeftLabel = new Label();
            
            
            WallLeftLabel.Location = new Point(12, 0);
            WallLeftLabel.Name = "Walls_Left";
            WallLeftLabel.Text = "Walls Left";
            WallLeftLabel.Font = new Font(WallLeftLabel.Font.FontFamily, 13,FontStyle.Bold | FontStyle.Underline);
            WallLeftLabel.Size = new Size(150, 30);
            
            numOfWallsLeftForUser.Location = new Point(12, 30);
            numOfWallsLeftForUser.Name = "USER";
            numOfWallsLeftForUser.Text = "USER : 10";
            numOfWallsLeftForUser.Font = new Font(numOfWallsLeftForComputer.Font.FontFamily,8, FontStyle.Bold);
            numOfWallsLeftForUser.Size = new Size(150, 20);

            numOfWallsLeftForComputer.Location = new Point(12, 55);
            numOfWallsLeftForComputer.Name = "COMPUTER";
            numOfWallsLeftForComputer.Text = "COMPUTER : 10";
            numOfWallsLeftForComputer.Font = new Font(numOfWallsLeftForComputer.Font.FontFamily, 8, FontStyle.Bold);
            numOfWallsLeftForComputer.Size = new Size(150, 20);

            Controls.Add(numOfWallsLeftForUser);
            Controls.Add(numOfWallsLeftForComputer);
            Controls.Add(WallLeftLabel);
            
        }
        private void AddWalls()
        {
            PictureBox wall;
            // vertical walls
            for (int i = 0; i < 64; i++)
            {
                wall = new PictureBox();
                wall.Image = ((Image)( Properties.Resources.wall));
                int y=i%2==0? 51: 95;
                wall.Location = new Point(251+(46*(i/8)), y+((i%8)/2*92));
                wall.Name = "wallv" + i/8+"_"+i%8;
                wall.Size = new Size(6, 78);
                wall.SizeMode = PictureBoxSizeMode.CenterImage;
                wall.Visible = false;
                wall.MouseClick += new MouseEventHandler(this.PlaceWall);
                wall.MouseLeave += new EventHandler(this.LeaveChosenWall);
                this.Controls.Add(wall);
                walls.Add(wall);
            }
            // horizontal walls
            for (int i = 64; i < 128; i++)
            {
                wall = new PictureBox();
                wall.Image = ((Image)(Properties.Resources.wall));
                int x=i%2==0? 213: 260;
                wall.Location = new Point(x+((i%8)/2*92), 85+(46*(i%64/8)));
                wall.Name = "wallh" + i/8+"_"+i%8;
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

        private void AddCanMoveSquares()
        {
            Image canMoveSquare = Properties.Resources.canMove;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    canMoveSquares[i, j] = new PictureBox();
                    canMoveSquares[i, j].BackColor = Color.LightGray;
                    canMoveSquares[i, j].BackgroundImageLayout = ImageLayout.Center;
                    canMoveSquares[i, j].Image = ((Image)(canMoveSquare));
                    canMoveSquares[i, j].Location = new Point(211 + (46 * j), 45 + (46 * i));
                    canMoveSquares[i, j].Name = "canMoveSquare" + (i+1)*(j+1);
                    canMoveSquares[i, j].Size = new Size(40, 40);
                    canMoveSquares[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                    canMoveSquares[i,j].Visible = false;
                    canMoveSquares[i, j].MouseClick += new MouseEventHandler(this.CanMoveSquaresClicked);
                    Controls.Add(canMoveSquares[i, j]);
                }
            }
        }

        private void AddSquares()
        {
            Image square = Properties.Resources.board_square;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    PictureBox boardSquare = new PictureBox();
                    boardSquare.Image = ((Image)(square));
                    boardSquare.Location = new Point(211 + (46 * j), 45 + (46 * i));
                    boardSquare.Name = "square" + (i+1)*(j+1);
                    boardSquare.Size = new Size(40, 40);
                    Controls.Add(boardSquare);
                }
            }
        }

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
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.SuspendLayout();
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(823, 649);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quoridor";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanPlaceWall);
            this.ResumeLayout(false);
        }

        #endregion
    }
}