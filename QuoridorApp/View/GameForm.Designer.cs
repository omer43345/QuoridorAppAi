using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace QuoridorApp
{
    partial class GameForm
    {
        private System.Windows.Forms.PictureBox [] walls= new System.Windows.Forms.PictureBox[128];
        private System.Windows.Forms.PictureBox[,] canMoveSquares= new System.Windows.Forms.PictureBox[9,9];
        private System.Windows.Forms.PictureBox userPawn;
        private System.Windows.Forms.PictureBox computerPawn;
        
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
        
        private void AddWalls()
        {
            // vertical walls
            for (int i = 0; i < 64; i++)
            {
                walls[i] = new System.Windows.Forms.PictureBox();
                walls[i].BackColor = System.Drawing.Color.RoyalBlue;
                walls[i].Image = ((System.Drawing.Image)( Properties.Resources.wall));
                walls[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                int y=i%2==0? 51: 95;
                walls[i].Location = new System.Drawing.Point(251+(46*(i/8)), y+((i%8)/2*92));
                walls[i].Name = "wallv" + i/8+"_"+i%8;
                walls[i].Size = new System.Drawing.Size(6, 78);
                walls[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                walls[i].TabIndex = 200+i;
                walls[i].TabStop = false;
                walls[i].Visible = false;
                this.Controls.Add(walls[i]);
            }
            // horizontal walls
            for (int i = 64; i < 128; i++)
            {
                walls[i] = new System.Windows.Forms.PictureBox();
                walls[i].BackColor = System.Drawing.Color.RoyalBlue;
                walls[i].Image = ((System.Drawing.Image)(Properties.Resources.wall));
                walls[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                int x=i%2==0? 213: 260;
                walls[i].Location = new System.Drawing.Point(x+((i%8)/2*92), 85+(46*(i%64/8)));
                walls[i].Name = "wallh" + i/8+"_"+i%8;
                walls[i].Size = new System.Drawing.Size(78, 6);
                walls[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                walls[i].TabIndex = 200+i;
                walls[i].TabStop = false;
                walls[i].Visible = false;
                walls[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                this.Controls.Add(walls[i]);
            }
        }

        private void AddCanMoveSquares()
        {
            Image canMoveSquare = Properties.Resources.canMove;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    canMoveSquares[i, j] = new System.Windows.Forms.PictureBox();
                    canMoveSquares[i, j].BackColor = System.Drawing.Color.LightGray;
                    canMoveSquares[i, j].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    canMoveSquares[i, j].Image = ((System.Drawing.Image)(canMoveSquare));
                    canMoveSquares[i, j].Location = new System.Drawing.Point(211 + (46 * j), 45 + (46 * i));
                    canMoveSquares[i, j].Name = "canMoveSquare" + (i+1)*(j+1);
                    canMoveSquares[i, j].Size = new System.Drawing.Size(40, 40);
                    canMoveSquares[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    canMoveSquares[i,j].Visible = false;
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
                    PictureBox boardSquare = new System.Windows.Forms.PictureBox();
                    boardSquare.Image = ((System.Drawing.Image)(square));
                    boardSquare.Location = new System.Drawing.Point(211 + (46 * j), 45 + (46 * i));
                    boardSquare.Name = "square" + (i+1)*(j+1);
                    boardSquare.Size = new System.Drawing.Size(40, 40);
                    Controls.Add(boardSquare);
                }
            }
        }

        private void AddPawns()
        {
            //
            // computerPawn
            //
            computerPawn = new System.Windows.Forms.PictureBox();
            computerPawn.BackColor = System.Drawing.Color.DarkGray;
            computerPawn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            computerPawn.Cursor = System.Windows.Forms.Cursors.Hand;  
            computerPawn.Image = ((System.Drawing.Image)(Properties.Resources.pawn2));
            computerPawn.Location = new System.Drawing.Point(395, 45);
            computerPawn.Name = "computerPawn";
            computerPawn.Size = new System.Drawing.Size(40, 40);
            computerPawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // userPawn
            // 
            userPawn = new System.Windows.Forms.PictureBox();
            userPawn.BackColor = System.Drawing.Color.DarkGray;
            userPawn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            userPawn.Cursor = System.Windows.Forms.Cursors.Hand; 
            userPawn.Image = ((System.Drawing.Image)(Properties.Resources.pawn1));
            userPawn.Location = new System.Drawing.Point(395, 413);
            userPawn.Name = "userPawn";
            userPawn.Size = new System.Drawing.Size(40, 40);
            userPawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            userPawn.Click += new System.EventHandler(this.userPawn_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(823, 613);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quoridor";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanPlaceVerticalWall);
            this.ResumeLayout(false);
        }
        #endregion
    }
}