using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace QuoridorApp
{
    partial class Form1
    {
        private System.Windows.Forms.PictureBox [] walls= new System.Windows.Forms.PictureBox[128];
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
        //add walls pictureboxes to the array
        private void AddWalls()
        {
            // vertical walls
            for (int i = 0; i < 64; i++)
            {
                walls[i] = new System.Windows.Forms.PictureBox();
                walls[i].BackColor = System.Drawing.Color.RoyalBlue;
                walls[i].Image = ((System.Drawing.Image)( Properties.Resources.wall));
                walls[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                int y=i%2==0? 53: 91;
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
                int x=i%2==0? 211: 257;
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
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.pictureBox23 = new System.Windows.Forms.PictureBox();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.pictureBox25 = new System.Windows.Forms.PictureBox();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.pictureBox27 = new System.Windows.Forms.PictureBox();
            this.pictureBox28 = new System.Windows.Forms.PictureBox();
            this.pictureBox29 = new System.Windows.Forms.PictureBox();
            this.pictureBox30 = new System.Windows.Forms.PictureBox();
            this.pictureBox31 = new System.Windows.Forms.PictureBox();
            this.pictureBox32 = new System.Windows.Forms.PictureBox();
            this.pictureBox33 = new System.Windows.Forms.PictureBox();
            this.pictureBox34 = new System.Windows.Forms.PictureBox();
            this.pictureBox35 = new System.Windows.Forms.PictureBox();
            this.pictureBox36 = new System.Windows.Forms.PictureBox();
            this.pictureBox37 = new System.Windows.Forms.PictureBox();
            this.pictureBox38 = new System.Windows.Forms.PictureBox();
            this.pictureBox39 = new System.Windows.Forms.PictureBox();
            this.pictureBox40 = new System.Windows.Forms.PictureBox();
            this.pictureBox41 = new System.Windows.Forms.PictureBox();
            this.pictureBox42 = new System.Windows.Forms.PictureBox();
            this.pictureBox43 = new System.Windows.Forms.PictureBox();
            this.pictureBox44 = new System.Windows.Forms.PictureBox();
            this.pictureBox45 = new System.Windows.Forms.PictureBox();
            this.pictureBox46 = new System.Windows.Forms.PictureBox();
            this.pictureBox47 = new System.Windows.Forms.PictureBox();
            this.pictureBox48 = new System.Windows.Forms.PictureBox();
            this.pictureBox49 = new System.Windows.Forms.PictureBox();
            this.pictureBox50 = new System.Windows.Forms.PictureBox();
            this.pictureBox51 = new System.Windows.Forms.PictureBox();
            this.pictureBox52 = new System.Windows.Forms.PictureBox();
            this.pictureBox53 = new System.Windows.Forms.PictureBox();
            this.pictureBox54 = new System.Windows.Forms.PictureBox();
            this.pictureBox55 = new System.Windows.Forms.PictureBox();
            this.pictureBox56 = new System.Windows.Forms.PictureBox();
            this.pictureBox57 = new System.Windows.Forms.PictureBox();
            this.pictureBox58 = new System.Windows.Forms.PictureBox();
            this.pictureBox59 = new System.Windows.Forms.PictureBox();
            this.pictureBox60 = new System.Windows.Forms.PictureBox();
            this.pictureBox61 = new System.Windows.Forms.PictureBox();
            this.pictureBox62 = new System.Windows.Forms.PictureBox();
            this.pictureBox63 = new System.Windows.Forms.PictureBox();
            this.pictureBox64 = new System.Windows.Forms.PictureBox();
            this.pictureBox65 = new System.Windows.Forms.PictureBox();
            this.pictureBox66 = new System.Windows.Forms.PictureBox();
            this.pictureBox67 = new System.Windows.Forms.PictureBox();
            this.pictureBox68 = new System.Windows.Forms.PictureBox();
            this.pictureBox69 = new System.Windows.Forms.PictureBox();
            this.pictureBox70 = new System.Windows.Forms.PictureBox();
            this.pictureBox71 = new System.Windows.Forms.PictureBox();
            this.pictureBox72 = new System.Windows.Forms.PictureBox();
            this.pictureBox73 = new System.Windows.Forms.PictureBox();
            this.pictureBox74 = new System.Windows.Forms.PictureBox();
            this.pictureBox75 = new System.Windows.Forms.PictureBox();
            this.pictureBox76 = new System.Windows.Forms.PictureBox();
            this.pictureBox77 = new System.Windows.Forms.PictureBox();
            this.pictureBox78 = new System.Windows.Forms.PictureBox();
            this.pictureBox79 = new System.Windows.Forms.PictureBox();
            this.pictureBox80 = new System.Windows.Forms.PictureBox();
            this.pictureBox81 = new System.Windows.Forms.PictureBox();
            this.computerPawn = new System.Windows.Forms.PictureBox();
            this.userPawn = new System.Windows.Forms.PictureBox();
            this.canMoveSquare76 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare21 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare20 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare19 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare10 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare9 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare8 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare7 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare6 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare5 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare4 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare3 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare2 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare1 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare73 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare11 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare12 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare13 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare14 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare15 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare16 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare18 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare37 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare38 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare39 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare40 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare41 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare42 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare43 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare44 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare45 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare28 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare29 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare30 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare31 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare32 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare33 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare34 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare35 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare36 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare46 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare47 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare48 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare49 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare50 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare51 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare52 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare53 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare54 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare55 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare56 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare57 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare58 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare59 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare60 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare61 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare62 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare63 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare64 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare65 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare66 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare67 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare68 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare69 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare70 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare71 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare72 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare75 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare77 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare78 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare79 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare81 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare74 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare22 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare23 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare24 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare25 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare27 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare26 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare17 = new System.Windows.Forms.PictureBox();
            this.canMoveSquare80 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox79)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerPawn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPawn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare79)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare80)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(211, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(579, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(533, 45);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(487, 45);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 40);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(441, 45);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(40, 40);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(395, 45);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(40, 40);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(349, 45);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(40, 40);
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(303, 45);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(40, 40);
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(257, 45);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(40, 40);
            this.pictureBox9.TabIndex = 8;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(257, 91);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(40, 40);
            this.pictureBox10.TabIndex = 17;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(303, 91);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(40, 40);
            this.pictureBox11.TabIndex = 16;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(349, 91);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(40, 40);
            this.pictureBox12.TabIndex = 15;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
            this.pictureBox13.Location = new System.Drawing.Point(395, 91);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(40, 40);
            this.pictureBox13.TabIndex = 14;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox14.Image")));
            this.pictureBox14.Location = new System.Drawing.Point(441, 91);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(40, 40);
            this.pictureBox14.TabIndex = 13;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox15.Image")));
            this.pictureBox15.Location = new System.Drawing.Point(487, 91);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(40, 40);
            this.pictureBox15.TabIndex = 12;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox16.Image")));
            this.pictureBox16.Location = new System.Drawing.Point(533, 91);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(40, 40);
            this.pictureBox16.TabIndex = 11;
            this.pictureBox16.TabStop = false;
            // 
            // pictureBox17
            // 
            this.pictureBox17.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox17.Image")));
            this.pictureBox17.Location = new System.Drawing.Point(579, 91);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(40, 40);
            this.pictureBox17.TabIndex = 10;
            this.pictureBox17.TabStop = false;
            // 
            // pictureBox18
            // 
            this.pictureBox18.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox18.Image")));
            this.pictureBox18.Location = new System.Drawing.Point(211, 91);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(40, 40);
            this.pictureBox18.TabIndex = 9;
            this.pictureBox18.TabStop = false;
            // 
            // pictureBox19
            // 
            this.pictureBox19.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox19.Image")));
            this.pictureBox19.Location = new System.Drawing.Point(257, 137);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(40, 40);
            this.pictureBox19.TabIndex = 26;
            this.pictureBox19.TabStop = false;
            // 
            // pictureBox20
            // 
            this.pictureBox20.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox20.Image")));
            this.pictureBox20.Location = new System.Drawing.Point(303, 137);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(40, 40);
            this.pictureBox20.TabIndex = 25;
            this.pictureBox20.TabStop = false;
            // 
            // pictureBox21
            // 
            this.pictureBox21.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox21.Image")));
            this.pictureBox21.Location = new System.Drawing.Point(349, 137);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(40, 40);
            this.pictureBox21.TabIndex = 24;
            this.pictureBox21.TabStop = false;
            // 
            // pictureBox22
            // 
            this.pictureBox22.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox22.Image")));
            this.pictureBox22.Location = new System.Drawing.Point(395, 137);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(40, 40);
            this.pictureBox22.TabIndex = 23;
            this.pictureBox22.TabStop = false;
            // 
            // pictureBox23
            // 
            this.pictureBox23.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox23.Image")));
            this.pictureBox23.Location = new System.Drawing.Point(441, 137);
            this.pictureBox23.Name = "pictureBox23";
            this.pictureBox23.Size = new System.Drawing.Size(40, 40);
            this.pictureBox23.TabIndex = 22;
            this.pictureBox23.TabStop = false;
            // 
            // pictureBox24
            // 
            this.pictureBox24.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox24.Image")));
            this.pictureBox24.Location = new System.Drawing.Point(487, 137);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Size = new System.Drawing.Size(40, 40);
            this.pictureBox24.TabIndex = 21;
            this.pictureBox24.TabStop = false;
            // 
            // pictureBox25
            // 
            this.pictureBox25.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox25.Image")));
            this.pictureBox25.Location = new System.Drawing.Point(533, 137);
            this.pictureBox25.Name = "pictureBox25";
            this.pictureBox25.Size = new System.Drawing.Size(40, 40);
            this.pictureBox25.TabIndex = 20;
            this.pictureBox25.TabStop = false;
            // 
            // pictureBox26
            // 
            this.pictureBox26.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox26.Image")));
            this.pictureBox26.Location = new System.Drawing.Point(579, 137);
            this.pictureBox26.Name = "pictureBox26";
            this.pictureBox26.Size = new System.Drawing.Size(40, 40);
            this.pictureBox26.TabIndex = 19;
            this.pictureBox26.TabStop = false;
            // 
            // pictureBox27
            // 
            this.pictureBox27.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox27.Image")));
            this.pictureBox27.Location = new System.Drawing.Point(211, 137);
            this.pictureBox27.Name = "pictureBox27";
            this.pictureBox27.Size = new System.Drawing.Size(40, 40);
            this.pictureBox27.TabIndex = 18;
            this.pictureBox27.TabStop = false;
            // 
            // pictureBox28
            // 
            this.pictureBox28.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox28.Image")));
            this.pictureBox28.Location = new System.Drawing.Point(257, 183);
            this.pictureBox28.Name = "pictureBox28";
            this.pictureBox28.Size = new System.Drawing.Size(40, 40);
            this.pictureBox28.TabIndex = 35;
            this.pictureBox28.TabStop = false;
            // 
            // pictureBox29
            // 
            this.pictureBox29.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox29.Image")));
            this.pictureBox29.Location = new System.Drawing.Point(303, 183);
            this.pictureBox29.Name = "pictureBox29";
            this.pictureBox29.Size = new System.Drawing.Size(40, 40);
            this.pictureBox29.TabIndex = 34;
            this.pictureBox29.TabStop = false;
            // 
            // pictureBox30
            // 
            this.pictureBox30.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox30.Image")));
            this.pictureBox30.Location = new System.Drawing.Point(349, 183);
            this.pictureBox30.Name = "pictureBox30";
            this.pictureBox30.Size = new System.Drawing.Size(40, 40);
            this.pictureBox30.TabIndex = 33;
            this.pictureBox30.TabStop = false;
            // 
            // pictureBox31
            // 
            this.pictureBox31.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox31.Image")));
            this.pictureBox31.Location = new System.Drawing.Point(395, 183);
            this.pictureBox31.Name = "pictureBox31";
            this.pictureBox31.Size = new System.Drawing.Size(40, 40);
            this.pictureBox31.TabIndex = 32;
            this.pictureBox31.TabStop = false;
            // 
            // pictureBox32
            // 
            this.pictureBox32.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox32.Image")));
            this.pictureBox32.Location = new System.Drawing.Point(441, 183);
            this.pictureBox32.Name = "pictureBox32";
            this.pictureBox32.Size = new System.Drawing.Size(40, 40);
            this.pictureBox32.TabIndex = 31;
            this.pictureBox32.TabStop = false;
            // 
            // pictureBox33
            // 
            this.pictureBox33.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox33.Image")));
            this.pictureBox33.Location = new System.Drawing.Point(487, 183);
            this.pictureBox33.Name = "pictureBox33";
            this.pictureBox33.Size = new System.Drawing.Size(40, 40);
            this.pictureBox33.TabIndex = 30;
            this.pictureBox33.TabStop = false;
            // 
            // pictureBox34
            // 
            this.pictureBox34.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox34.Image")));
            this.pictureBox34.Location = new System.Drawing.Point(533, 183);
            this.pictureBox34.Name = "pictureBox34";
            this.pictureBox34.Size = new System.Drawing.Size(40, 40);
            this.pictureBox34.TabIndex = 29;
            this.pictureBox34.TabStop = false;
            // 
            // pictureBox35
            // 
            this.pictureBox35.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox35.Image")));
            this.pictureBox35.Location = new System.Drawing.Point(579, 183);
            this.pictureBox35.Name = "pictureBox35";
            this.pictureBox35.Size = new System.Drawing.Size(40, 40);
            this.pictureBox35.TabIndex = 28;
            this.pictureBox35.TabStop = false;
            // 
            // pictureBox36
            // 
            this.pictureBox36.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox36.Image")));
            this.pictureBox36.Location = new System.Drawing.Point(211, 183);
            this.pictureBox36.Name = "pictureBox36";
            this.pictureBox36.Size = new System.Drawing.Size(40, 40);
            this.pictureBox36.TabIndex = 27;
            this.pictureBox36.TabStop = false;
            // 
            // pictureBox37
            // 
            this.pictureBox37.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox37.Image")));
            this.pictureBox37.Location = new System.Drawing.Point(257, 229);
            this.pictureBox37.Name = "pictureBox37";
            this.pictureBox37.Size = new System.Drawing.Size(40, 40);
            this.pictureBox37.TabIndex = 44;
            this.pictureBox37.TabStop = false;
            // 
            // pictureBox38
            // 
            this.pictureBox38.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox38.Image")));
            this.pictureBox38.Location = new System.Drawing.Point(303, 229);
            this.pictureBox38.Name = "pictureBox38";
            this.pictureBox38.Size = new System.Drawing.Size(40, 40);
            this.pictureBox38.TabIndex = 43;
            this.pictureBox38.TabStop = false;
            // 
            // pictureBox39
            // 
            this.pictureBox39.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox39.Image")));
            this.pictureBox39.Location = new System.Drawing.Point(349, 229);
            this.pictureBox39.Name = "pictureBox39";
            this.pictureBox39.Size = new System.Drawing.Size(40, 40);
            this.pictureBox39.TabIndex = 42;
            this.pictureBox39.TabStop = false;
            // 
            // pictureBox40
            // 
            this.pictureBox40.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox40.Image")));
            this.pictureBox40.Location = new System.Drawing.Point(395, 229);
            this.pictureBox40.Name = "pictureBox40";
            this.pictureBox40.Size = new System.Drawing.Size(40, 40);
            this.pictureBox40.TabIndex = 41;
            this.pictureBox40.TabStop = false;
            // 
            // pictureBox41
            // 
            this.pictureBox41.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox41.Image")));
            this.pictureBox41.Location = new System.Drawing.Point(441, 229);
            this.pictureBox41.Name = "pictureBox41";
            this.pictureBox41.Size = new System.Drawing.Size(40, 40);
            this.pictureBox41.TabIndex = 40;
            this.pictureBox41.TabStop = false;
            // 
            // pictureBox42
            // 
            this.pictureBox42.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox42.Image")));
            this.pictureBox42.Location = new System.Drawing.Point(487, 229);
            this.pictureBox42.Name = "pictureBox42";
            this.pictureBox42.Size = new System.Drawing.Size(40, 40);
            this.pictureBox42.TabIndex = 39;
            this.pictureBox42.TabStop = false;
            // 
            // pictureBox43
            // 
            this.pictureBox43.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox43.Image")));
            this.pictureBox43.Location = new System.Drawing.Point(533, 229);
            this.pictureBox43.Name = "pictureBox43";
            this.pictureBox43.Size = new System.Drawing.Size(40, 40);
            this.pictureBox43.TabIndex = 38;
            this.pictureBox43.TabStop = false;
            // 
            // pictureBox44
            // 
            this.pictureBox44.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox44.Image")));
            this.pictureBox44.Location = new System.Drawing.Point(579, 229);
            this.pictureBox44.Name = "pictureBox44";
            this.pictureBox44.Size = new System.Drawing.Size(40, 40);
            this.pictureBox44.TabIndex = 37;
            this.pictureBox44.TabStop = false;
            // 
            // pictureBox45
            // 
            this.pictureBox45.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox45.Image")));
            this.pictureBox45.Location = new System.Drawing.Point(211, 229);
            this.pictureBox45.Name = "pictureBox45";
            this.pictureBox45.Size = new System.Drawing.Size(40, 40);
            this.pictureBox45.TabIndex = 36;
            this.pictureBox45.TabStop = false;
            // 
            // pictureBox46
            // 
            this.pictureBox46.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox46.Image")));
            this.pictureBox46.Location = new System.Drawing.Point(257, 275);
            this.pictureBox46.Name = "pictureBox46";
            this.pictureBox46.Size = new System.Drawing.Size(40, 40);
            this.pictureBox46.TabIndex = 53;
            this.pictureBox46.TabStop = false;
            // 
            // pictureBox47
            // 
            this.pictureBox47.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox47.Image")));
            this.pictureBox47.Location = new System.Drawing.Point(303, 275);
            this.pictureBox47.Name = "pictureBox47";
            this.pictureBox47.Size = new System.Drawing.Size(40, 40);
            this.pictureBox47.TabIndex = 52;
            this.pictureBox47.TabStop = false;
            // 
            // pictureBox48
            // 
            this.pictureBox48.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox48.Image")));
            this.pictureBox48.Location = new System.Drawing.Point(349, 275);
            this.pictureBox48.Name = "pictureBox48";
            this.pictureBox48.Size = new System.Drawing.Size(40, 40);
            this.pictureBox48.TabIndex = 51;
            this.pictureBox48.TabStop = false;
            // 
            // pictureBox49
            // 
            this.pictureBox49.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox49.Image")));
            this.pictureBox49.Location = new System.Drawing.Point(395, 275);
            this.pictureBox49.Name = "pictureBox49";
            this.pictureBox49.Size = new System.Drawing.Size(40, 40);
            this.pictureBox49.TabIndex = 50;
            this.pictureBox49.TabStop = false;
            // 
            // pictureBox50
            // 
            this.pictureBox50.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox50.Image")));
            this.pictureBox50.Location = new System.Drawing.Point(441, 275);
            this.pictureBox50.Name = "pictureBox50";
            this.pictureBox50.Size = new System.Drawing.Size(40, 40);
            this.pictureBox50.TabIndex = 49;
            this.pictureBox50.TabStop = false;
            // 
            // pictureBox51
            // 
            this.pictureBox51.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox51.Image")));
            this.pictureBox51.Location = new System.Drawing.Point(487, 275);
            this.pictureBox51.Name = "pictureBox51";
            this.pictureBox51.Size = new System.Drawing.Size(40, 40);
            this.pictureBox51.TabIndex = 48;
            this.pictureBox51.TabStop = false;
            // 
            // pictureBox52
            // 
            this.pictureBox52.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox52.Image")));
            this.pictureBox52.Location = new System.Drawing.Point(533, 275);
            this.pictureBox52.Name = "pictureBox52";
            this.pictureBox52.Size = new System.Drawing.Size(40, 40);
            this.pictureBox52.TabIndex = 47;
            this.pictureBox52.TabStop = false;
            // 
            // pictureBox53
            // 
            this.pictureBox53.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox53.Image")));
            this.pictureBox53.Location = new System.Drawing.Point(579, 275);
            this.pictureBox53.Name = "pictureBox53";
            this.pictureBox53.Size = new System.Drawing.Size(40, 40);
            this.pictureBox53.TabIndex = 46;
            this.pictureBox53.TabStop = false;
            // 
            // pictureBox54
            // 
            this.pictureBox54.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox54.Image")));
            this.pictureBox54.Location = new System.Drawing.Point(211, 275);
            this.pictureBox54.Name = "pictureBox54";
            this.pictureBox54.Size = new System.Drawing.Size(40, 40);
            this.pictureBox54.TabIndex = 45;
            this.pictureBox54.TabStop = false;
            // 
            // pictureBox55
            // 
            this.pictureBox55.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox55.Image")));
            this.pictureBox55.Location = new System.Drawing.Point(257, 321);
            this.pictureBox55.Name = "pictureBox55";
            this.pictureBox55.Size = new System.Drawing.Size(40, 40);
            this.pictureBox55.TabIndex = 62;
            this.pictureBox55.TabStop = false;
            // 
            // pictureBox56
            // 
            this.pictureBox56.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox56.Image")));
            this.pictureBox56.Location = new System.Drawing.Point(303, 321);
            this.pictureBox56.Name = "pictureBox56";
            this.pictureBox56.Size = new System.Drawing.Size(40, 40);
            this.pictureBox56.TabIndex = 61;
            this.pictureBox56.TabStop = false;
            // 
            // pictureBox57
            // 
            this.pictureBox57.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox57.Image")));
            this.pictureBox57.Location = new System.Drawing.Point(349, 321);
            this.pictureBox57.Name = "pictureBox57";
            this.pictureBox57.Size = new System.Drawing.Size(40, 40);
            this.pictureBox57.TabIndex = 60;
            this.pictureBox57.TabStop = false;
            // 
            // pictureBox58
            // 
            this.pictureBox58.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox58.Image")));
            this.pictureBox58.Location = new System.Drawing.Point(395, 321);
            this.pictureBox58.Name = "pictureBox58";
            this.pictureBox58.Size = new System.Drawing.Size(40, 40);
            this.pictureBox58.TabIndex = 59;
            this.pictureBox58.TabStop = false;
            // 
            // pictureBox59
            // 
            this.pictureBox59.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox59.Image")));
            this.pictureBox59.Location = new System.Drawing.Point(441, 321);
            this.pictureBox59.Name = "pictureBox59";
            this.pictureBox59.Size = new System.Drawing.Size(40, 40);
            this.pictureBox59.TabIndex = 58;
            this.pictureBox59.TabStop = false;
            // 
            // pictureBox60
            // 
            this.pictureBox60.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox60.Image")));
            this.pictureBox60.Location = new System.Drawing.Point(487, 321);
            this.pictureBox60.Name = "pictureBox60";
            this.pictureBox60.Size = new System.Drawing.Size(40, 40);
            this.pictureBox60.TabIndex = 57;
            this.pictureBox60.TabStop = false;
            // 
            // pictureBox61
            // 
            this.pictureBox61.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox61.Image")));
            this.pictureBox61.Location = new System.Drawing.Point(533, 321);
            this.pictureBox61.Name = "pictureBox61";
            this.pictureBox61.Size = new System.Drawing.Size(40, 40);
            this.pictureBox61.TabIndex = 56;
            this.pictureBox61.TabStop = false;
            // 
            // pictureBox62
            // 
            this.pictureBox62.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox62.Image")));
            this.pictureBox62.Location = new System.Drawing.Point(579, 321);
            this.pictureBox62.Name = "pictureBox62";
            this.pictureBox62.Size = new System.Drawing.Size(40, 40);
            this.pictureBox62.TabIndex = 55;
            this.pictureBox62.TabStop = false;
            // 
            // pictureBox63
            // 
            this.pictureBox63.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox63.Image")));
            this.pictureBox63.Location = new System.Drawing.Point(211, 321);
            this.pictureBox63.Name = "pictureBox63";
            this.pictureBox63.Size = new System.Drawing.Size(40, 40);
            this.pictureBox63.TabIndex = 54;
            this.pictureBox63.TabStop = false;
            // 
            // pictureBox64
            // 
            this.pictureBox64.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox64.Image")));
            this.pictureBox64.Location = new System.Drawing.Point(257, 367);
            this.pictureBox64.Name = "pictureBox64";
            this.pictureBox64.Size = new System.Drawing.Size(40, 40);
            this.pictureBox64.TabIndex = 71;
            this.pictureBox64.TabStop = false;
            // 
            // pictureBox65
            // 
            this.pictureBox65.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox65.Image")));
            this.pictureBox65.Location = new System.Drawing.Point(303, 367);
            this.pictureBox65.Name = "pictureBox65";
            this.pictureBox65.Size = new System.Drawing.Size(40, 40);
            this.pictureBox65.TabIndex = 70;
            this.pictureBox65.TabStop = false;
            // 
            // pictureBox66
            // 
            this.pictureBox66.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox66.Image")));
            this.pictureBox66.Location = new System.Drawing.Point(349, 367);
            this.pictureBox66.Name = "pictureBox66";
            this.pictureBox66.Size = new System.Drawing.Size(40, 40);
            this.pictureBox66.TabIndex = 69;
            this.pictureBox66.TabStop = false;
            // 
            // pictureBox67
            // 
            this.pictureBox67.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox67.Image")));
            this.pictureBox67.Location = new System.Drawing.Point(395, 367);
            this.pictureBox67.Name = "pictureBox67";
            this.pictureBox67.Size = new System.Drawing.Size(40, 40);
            this.pictureBox67.TabIndex = 68;
            this.pictureBox67.TabStop = false;
            // 
            // pictureBox68
            // 
            this.pictureBox68.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox68.Image")));
            this.pictureBox68.Location = new System.Drawing.Point(441, 367);
            this.pictureBox68.Name = "pictureBox68";
            this.pictureBox68.Size = new System.Drawing.Size(40, 40);
            this.pictureBox68.TabIndex = 67;
            this.pictureBox68.TabStop = false;
            // 
            // pictureBox69
            // 
            this.pictureBox69.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox69.Image")));
            this.pictureBox69.Location = new System.Drawing.Point(487, 367);
            this.pictureBox69.Name = "pictureBox69";
            this.pictureBox69.Size = new System.Drawing.Size(40, 40);
            this.pictureBox69.TabIndex = 66;
            this.pictureBox69.TabStop = false;
            // 
            // pictureBox70
            // 
            this.pictureBox70.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox70.Image")));
            this.pictureBox70.Location = new System.Drawing.Point(533, 367);
            this.pictureBox70.Name = "pictureBox70";
            this.pictureBox70.Size = new System.Drawing.Size(40, 40);
            this.pictureBox70.TabIndex = 65;
            this.pictureBox70.TabStop = false;
            // 
            // pictureBox71
            // 
            this.pictureBox71.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox71.Image")));
            this.pictureBox71.Location = new System.Drawing.Point(579, 367);
            this.pictureBox71.Name = "pictureBox71";
            this.pictureBox71.Size = new System.Drawing.Size(40, 40);
            this.pictureBox71.TabIndex = 64;
            this.pictureBox71.TabStop = false;
            // 
            // pictureBox72
            // 
            this.pictureBox72.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox72.Image")));
            this.pictureBox72.Location = new System.Drawing.Point(211, 367);
            this.pictureBox72.Name = "pictureBox72";
            this.pictureBox72.Size = new System.Drawing.Size(40, 40);
            this.pictureBox72.TabIndex = 63;
            this.pictureBox72.TabStop = false;
            // 
            // pictureBox73
            // 
            this.pictureBox73.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox73.Image")));
            this.pictureBox73.Location = new System.Drawing.Point(257, 413);
            this.pictureBox73.Name = "pictureBox73";
            this.pictureBox73.Size = new System.Drawing.Size(40, 40);
            this.pictureBox73.TabIndex = 80;
            this.pictureBox73.TabStop = false;
            // 
            // pictureBox74
            // 
            this.pictureBox74.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox74.Image")));
            this.pictureBox74.Location = new System.Drawing.Point(303, 413);
            this.pictureBox74.Name = "pictureBox74";
            this.pictureBox74.Size = new System.Drawing.Size(40, 40);
            this.pictureBox74.TabIndex = 79;
            this.pictureBox74.TabStop = false;
            // 
            // pictureBox75
            // 
            this.pictureBox75.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox75.Image")));
            this.pictureBox75.Location = new System.Drawing.Point(349, 413);
            this.pictureBox75.Name = "pictureBox75";
            this.pictureBox75.Size = new System.Drawing.Size(40, 40);
            this.pictureBox75.TabIndex = 78;
            this.pictureBox75.TabStop = false;
            // 
            // pictureBox76
            // 
            this.pictureBox76.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox76.Image")));
            this.pictureBox76.Location = new System.Drawing.Point(395, 413);
            this.pictureBox76.MaximumSize = new System.Drawing.Size(40, 40);
            this.pictureBox76.MinimumSize = new System.Drawing.Size(40, 40);
            this.pictureBox76.Name = "pictureBox76";
            this.pictureBox76.Size = new System.Drawing.Size(40, 40);
            this.pictureBox76.TabIndex = 77;
            this.pictureBox76.TabStop = false;
            // 
            // pictureBox77
            // 
            this.pictureBox77.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox77.Image")));
            this.pictureBox77.Location = new System.Drawing.Point(441, 413);
            this.pictureBox77.Name = "pictureBox77";
            this.pictureBox77.Size = new System.Drawing.Size(40, 40);
            this.pictureBox77.TabIndex = 76;
            this.pictureBox77.TabStop = false;
            // 
            // pictureBox78
            // 
            this.pictureBox78.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox78.Image")));
            this.pictureBox78.Location = new System.Drawing.Point(487, 413);
            this.pictureBox78.Name = "pictureBox78";
            this.pictureBox78.Size = new System.Drawing.Size(40, 40);
            this.pictureBox78.TabIndex = 75;
            this.pictureBox78.TabStop = false;
            // 
            // pictureBox79
            // 
            this.pictureBox79.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox79.Image")));
            this.pictureBox79.Location = new System.Drawing.Point(533, 413);
            this.pictureBox79.Name = "pictureBox79";
            this.pictureBox79.Size = new System.Drawing.Size(40, 40);
            this.pictureBox79.TabIndex = 74;
            this.pictureBox79.TabStop = false;
            // 
            // pictureBox80
            // 
            this.pictureBox80.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox80.Image")));
            this.pictureBox80.Location = new System.Drawing.Point(579, 413);
            this.pictureBox80.Name = "pictureBox80";
            this.pictureBox80.Size = new System.Drawing.Size(40, 40);
            this.pictureBox80.TabIndex = 73;
            this.pictureBox80.TabStop = false;
            // 
            // pictureBox81
            // 
            this.pictureBox81.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox81.Image")));
            this.pictureBox81.Location = new System.Drawing.Point(211, 413);
            this.pictureBox81.Name = "pictureBox81";
            this.pictureBox81.Size = new System.Drawing.Size(40, 40);
            this.pictureBox81.TabIndex = 72;
            this.pictureBox81.TabStop = false;
            // 
            // computerPawn
            // 
            this.computerPawn.BackColor = System.Drawing.Color.DarkGray;
            this.computerPawn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.computerPawn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.computerPawn.Image = ((System.Drawing.Image)(resources.GetObject("computerPawn.Image")));
            this.computerPawn.Location = new System.Drawing.Point(395, 45);
            this.computerPawn.Name = "computerPawn";
            this.computerPawn.Size = new System.Drawing.Size(40, 40);
            this.computerPawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.computerPawn.TabIndex = 82;
            this.computerPawn.TabStop = false;
            // 
            // userPawn
            // 
            this.userPawn.BackColor = System.Drawing.Color.DarkGray;
            this.userPawn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.userPawn.Image = ((System.Drawing.Image)(resources.GetObject("userPawn.Image")));
            this.userPawn.Location = new System.Drawing.Point(395, 413);
            this.userPawn.Name = "userPawn";
            this.userPawn.Size = new System.Drawing.Size(40, 40);
            this.userPawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.userPawn.TabIndex = 83;
            this.userPawn.TabStop = false;
            this.userPawn.Click += new System.EventHandler(this.userPawn_Click);
            // 
            // canMoveSquare76
            // 
            this.canMoveSquare76.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare76.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare76.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare76.Image")));
            this.canMoveSquare76.Location = new System.Drawing.Point(349, 413);
            this.canMoveSquare76.Name = "canMoveSquare76";
            this.canMoveSquare76.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare76.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare76.TabIndex = 84;
            this.canMoveSquare76.TabStop = false;
            this.canMoveSquare76.Visible = false;
            // 
            // canMoveSquare21
            // 
            this.canMoveSquare21.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare21.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare21.Image")));
            this.canMoveSquare21.Location = new System.Drawing.Point(303, 137);
            this.canMoveSquare21.Name = "canMoveSquare21";
            this.canMoveSquare21.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare21.TabIndex = 85;
            this.canMoveSquare21.TabStop = false;
            this.canMoveSquare21.Visible = false;
            // 
            // canMoveSquare20
            // 
            this.canMoveSquare20.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare20.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare20.Image")));
            this.canMoveSquare20.Location = new System.Drawing.Point(257, 137);
            this.canMoveSquare20.Name = "canMoveSquare20";
            this.canMoveSquare20.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare20.TabIndex = 86;
            this.canMoveSquare20.TabStop = false;
            this.canMoveSquare20.Visible = false;
            // 
            // canMoveSquare19
            // 
            this.canMoveSquare19.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare19.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare19.Image")));
            this.canMoveSquare19.Location = new System.Drawing.Point(211, 137);
            this.canMoveSquare19.Name = "canMoveSquare19";
            this.canMoveSquare19.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare19.TabIndex = 87;
            this.canMoveSquare19.TabStop = false;
            this.canMoveSquare19.Visible = false;
            // 
            // canMoveSquare10
            // 
            this.canMoveSquare10.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare10.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare10.Image")));
            this.canMoveSquare10.Location = new System.Drawing.Point(211, 91);
            this.canMoveSquare10.Name = "canMoveSquare10";
            this.canMoveSquare10.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare10.TabIndex = 88;
            this.canMoveSquare10.TabStop = false;
            this.canMoveSquare10.Visible = false;
            // 
            // canMoveSquare9
            // 
            this.canMoveSquare9.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare9.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare9.Image")));
            this.canMoveSquare9.Location = new System.Drawing.Point(579, 45);
            this.canMoveSquare9.Name = "canMoveSquare9";
            this.canMoveSquare9.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare9.TabIndex = 89;
            this.canMoveSquare9.TabStop = false;
            this.canMoveSquare9.Visible = false;
            // 
            // canMoveSquare8
            // 
            this.canMoveSquare8.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare8.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare8.Image")));
            this.canMoveSquare8.Location = new System.Drawing.Point(533, 45);
            this.canMoveSquare8.Name = "canMoveSquare8";
            this.canMoveSquare8.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare8.TabIndex = 90;
            this.canMoveSquare8.TabStop = false;
            this.canMoveSquare8.Visible = false;
            // 
            // canMoveSquare7
            // 
            this.canMoveSquare7.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare7.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare7.Image")));
            this.canMoveSquare7.Location = new System.Drawing.Point(487, 45);
            this.canMoveSquare7.Name = "canMoveSquare7";
            this.canMoveSquare7.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare7.TabIndex = 91;
            this.canMoveSquare7.TabStop = false;
            this.canMoveSquare7.Visible = false;
            // 
            // canMoveSquare6
            // 
            this.canMoveSquare6.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare6.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare6.Image")));
            this.canMoveSquare6.Location = new System.Drawing.Point(441, 45);
            this.canMoveSquare6.Name = "canMoveSquare6";
            this.canMoveSquare6.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare6.TabIndex = 92;
            this.canMoveSquare6.TabStop = false;
            this.canMoveSquare6.Visible = false;
            // 
            // canMoveSquare5
            // 
            this.canMoveSquare5.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare5.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare5.Image")));
            this.canMoveSquare5.Location = new System.Drawing.Point(395, 45);
            this.canMoveSquare5.Name = "canMoveSquare5";
            this.canMoveSquare5.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare5.TabIndex = 93;
            this.canMoveSquare5.TabStop = false;
            this.canMoveSquare5.Visible = false;
            // 
            // canMoveSquare4
            // 
            this.canMoveSquare4.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare4.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare4.Image")));
            this.canMoveSquare4.Location = new System.Drawing.Point(349, 45);
            this.canMoveSquare4.Name = "canMoveSquare4";
            this.canMoveSquare4.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare4.TabIndex = 94;
            this.canMoveSquare4.TabStop = false;
            this.canMoveSquare4.Visible = false;
            // 
            // canMoveSquare3
            // 
            this.canMoveSquare3.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare3.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare3.Image")));
            this.canMoveSquare3.Location = new System.Drawing.Point(303, 45);
            this.canMoveSquare3.Name = "canMoveSquare3";
            this.canMoveSquare3.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare3.TabIndex = 95;
            this.canMoveSquare3.TabStop = false;
            this.canMoveSquare3.Visible = false;
            // 
            // canMoveSquare2
            // 
            this.canMoveSquare2.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare2.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare2.Image")));
            this.canMoveSquare2.Location = new System.Drawing.Point(257, 45);
            this.canMoveSquare2.Name = "canMoveSquare2";
            this.canMoveSquare2.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare2.TabIndex = 96;
            this.canMoveSquare2.TabStop = false;
            this.canMoveSquare2.Visible = false;
            // 
            // canMoveSquare1
            // 
            this.canMoveSquare1.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare1.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare1.Image")));
            this.canMoveSquare1.Location = new System.Drawing.Point(211, 45);
            this.canMoveSquare1.Name = "canMoveSquare1";
            this.canMoveSquare1.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare1.TabIndex = 97;
            this.canMoveSquare1.TabStop = false;
            this.canMoveSquare1.Visible = false;
            // 
            // canMoveSquare73
            // 
            this.canMoveSquare73.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare73.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare73.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare73.Image")));
            this.canMoveSquare73.Location = new System.Drawing.Point(211, 413);
            this.canMoveSquare73.Name = "canMoveSquare73";
            this.canMoveSquare73.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare73.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare73.TabIndex = 106;
            this.canMoveSquare73.TabStop = false;
            this.canMoveSquare73.Visible = false;
            // 
            // canMoveSquare11
            // 
            this.canMoveSquare11.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare11.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare11.Image")));
            this.canMoveSquare11.Location = new System.Drawing.Point(257, 91);
            this.canMoveSquare11.Name = "canMoveSquare11";
            this.canMoveSquare11.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare11.TabIndex = 105;
            this.canMoveSquare11.TabStop = false;
            this.canMoveSquare11.Visible = false;
            // 
            // canMoveSquare12
            // 
            this.canMoveSquare12.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare12.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare12.Image")));
            this.canMoveSquare12.Location = new System.Drawing.Point(303, 91);
            this.canMoveSquare12.Name = "canMoveSquare12";
            this.canMoveSquare12.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare12.TabIndex = 104;
            this.canMoveSquare12.TabStop = false;
            this.canMoveSquare12.Visible = false;
            // 
            // canMoveSquare13
            // 
            this.canMoveSquare13.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare13.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare13.Image")));
            this.canMoveSquare13.Location = new System.Drawing.Point(349, 91);
            this.canMoveSquare13.Name = "canMoveSquare13";
            this.canMoveSquare13.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare13.TabIndex = 103;
            this.canMoveSquare13.TabStop = false;
            this.canMoveSquare13.Visible = false;
            // 
            // canMoveSquare14
            // 
            this.canMoveSquare14.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare14.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare14.Image")));
            this.canMoveSquare14.Location = new System.Drawing.Point(395, 91);
            this.canMoveSquare14.Name = "canMoveSquare14";
            this.canMoveSquare14.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare14.TabIndex = 102;
            this.canMoveSquare14.TabStop = false;
            this.canMoveSquare14.Visible = false;
            // 
            // canMoveSquare15
            // 
            this.canMoveSquare15.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare15.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare15.Image")));
            this.canMoveSquare15.Location = new System.Drawing.Point(441, 91);
            this.canMoveSquare15.Name = "canMoveSquare15";
            this.canMoveSquare15.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare15.TabIndex = 101;
            this.canMoveSquare15.TabStop = false;
            this.canMoveSquare15.Visible = false;
            // 
            // canMoveSquare16
            // 
            this.canMoveSquare16.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare16.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare16.Image")));
            this.canMoveSquare16.Location = new System.Drawing.Point(487, 91);
            this.canMoveSquare16.Name = "canMoveSquare16";
            this.canMoveSquare16.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare16.TabIndex = 100;
            this.canMoveSquare16.TabStop = false;
            this.canMoveSquare16.Visible = false;
            // 
            // canMoveSquare18
            // 
            this.canMoveSquare18.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare18.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare18.Image")));
            this.canMoveSquare18.Location = new System.Drawing.Point(579, 91);
            this.canMoveSquare18.Name = "canMoveSquare18";
            this.canMoveSquare18.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare18.TabIndex = 98;
            this.canMoveSquare18.TabStop = false;
            this.canMoveSquare18.Visible = false;
            // 
            // canMoveSquare37
            // 
            this.canMoveSquare37.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare37.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare37.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare37.Image")));
            this.canMoveSquare37.Location = new System.Drawing.Point(211, 229);
            this.canMoveSquare37.Name = "canMoveSquare37";
            this.canMoveSquare37.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare37.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare37.TabIndex = 115;
            this.canMoveSquare37.TabStop = false;
            this.canMoveSquare37.Visible = false;
            // 
            // canMoveSquare38
            // 
            this.canMoveSquare38.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare38.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare38.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare38.Image")));
            this.canMoveSquare38.Location = new System.Drawing.Point(257, 229);
            this.canMoveSquare38.Name = "canMoveSquare38";
            this.canMoveSquare38.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare38.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare38.TabIndex = 114;
            this.canMoveSquare38.TabStop = false;
            this.canMoveSquare38.Visible = false;
            // 
            // canMoveSquare39
            // 
            this.canMoveSquare39.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare39.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare39.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare39.Image")));
            this.canMoveSquare39.Location = new System.Drawing.Point(303, 229);
            this.canMoveSquare39.Name = "canMoveSquare39";
            this.canMoveSquare39.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare39.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare39.TabIndex = 113;
            this.canMoveSquare39.TabStop = false;
            this.canMoveSquare39.Visible = false;
            // 
            // canMoveSquare40
            // 
            this.canMoveSquare40.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare40.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare40.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare40.Image")));
            this.canMoveSquare40.Location = new System.Drawing.Point(349, 229);
            this.canMoveSquare40.Name = "canMoveSquare40";
            this.canMoveSquare40.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare40.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare40.TabIndex = 112;
            this.canMoveSquare40.TabStop = false;
            this.canMoveSquare40.Visible = false;
            // 
            // canMoveSquare41
            // 
            this.canMoveSquare41.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare41.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare41.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare41.Image")));
            this.canMoveSquare41.Location = new System.Drawing.Point(395, 229);
            this.canMoveSquare41.Name = "canMoveSquare41";
            this.canMoveSquare41.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare41.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare41.TabIndex = 111;
            this.canMoveSquare41.TabStop = false;
            this.canMoveSquare41.Visible = false;
            // 
            // canMoveSquare42
            // 
            this.canMoveSquare42.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare42.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare42.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare42.Image")));
            this.canMoveSquare42.Location = new System.Drawing.Point(441, 229);
            this.canMoveSquare42.Name = "canMoveSquare42";
            this.canMoveSquare42.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare42.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare42.TabIndex = 110;
            this.canMoveSquare42.TabStop = false;
            this.canMoveSquare42.Visible = false;
            // 
            // canMoveSquare43
            // 
            this.canMoveSquare43.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare43.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare43.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare43.Image")));
            this.canMoveSquare43.Location = new System.Drawing.Point(487, 229);
            this.canMoveSquare43.Name = "canMoveSquare43";
            this.canMoveSquare43.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare43.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare43.TabIndex = 109;
            this.canMoveSquare43.TabStop = false;
            this.canMoveSquare43.Visible = false;
            // 
            // canMoveSquare44
            // 
            this.canMoveSquare44.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare44.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare44.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare44.Image")));
            this.canMoveSquare44.Location = new System.Drawing.Point(533, 229);
            this.canMoveSquare44.Name = "canMoveSquare44";
            this.canMoveSquare44.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare44.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare44.TabIndex = 108;
            this.canMoveSquare44.TabStop = false;
            this.canMoveSquare44.Visible = false;
            // 
            // canMoveSquare45
            // 
            this.canMoveSquare45.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare45.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare45.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare45.Image")));
            this.canMoveSquare45.Location = new System.Drawing.Point(579, 229);
            this.canMoveSquare45.Name = "canMoveSquare45";
            this.canMoveSquare45.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare45.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare45.TabIndex = 107;
            this.canMoveSquare45.TabStop = false;
            this.canMoveSquare45.Visible = false;
            // 
            // canMoveSquare28
            // 
            this.canMoveSquare28.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare28.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare28.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare28.Image")));
            this.canMoveSquare28.Location = new System.Drawing.Point(211, 183);
            this.canMoveSquare28.Name = "canMoveSquare28";
            this.canMoveSquare28.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare28.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare28.TabIndex = 124;
            this.canMoveSquare28.TabStop = false;
            this.canMoveSquare28.Visible = false;
            // 
            // canMoveSquare29
            // 
            this.canMoveSquare29.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare29.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare29.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare29.Image")));
            this.canMoveSquare29.Location = new System.Drawing.Point(257, 183);
            this.canMoveSquare29.Name = "canMoveSquare29";
            this.canMoveSquare29.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare29.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare29.TabIndex = 123;
            this.canMoveSquare29.TabStop = false;
            this.canMoveSquare29.Visible = false;
            // 
            // canMoveSquare30
            // 
            this.canMoveSquare30.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare30.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare30.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare30.Image")));
            this.canMoveSquare30.Location = new System.Drawing.Point(303, 183);
            this.canMoveSquare30.Name = "canMoveSquare30";
            this.canMoveSquare30.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare30.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare30.TabIndex = 122;
            this.canMoveSquare30.TabStop = false;
            this.canMoveSquare30.Visible = false;
            // 
            // canMoveSquare31
            // 
            this.canMoveSquare31.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare31.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare31.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare31.Image")));
            this.canMoveSquare31.Location = new System.Drawing.Point(349, 183);
            this.canMoveSquare31.Name = "canMoveSquare31";
            this.canMoveSquare31.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare31.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare31.TabIndex = 121;
            this.canMoveSquare31.TabStop = false;
            this.canMoveSquare31.Visible = false;
            // 
            // canMoveSquare32
            // 
            this.canMoveSquare32.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare32.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare32.Image")));
            this.canMoveSquare32.Location = new System.Drawing.Point(395, 183);
            this.canMoveSquare32.Name = "canMoveSquare32";
            this.canMoveSquare32.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare32.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare32.TabIndex = 120;
            this.canMoveSquare32.TabStop = false;
            this.canMoveSquare32.Visible = false;
            // 
            // canMoveSquare33
            // 
            this.canMoveSquare33.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare33.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare33.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare33.Image")));
            this.canMoveSquare33.Location = new System.Drawing.Point(441, 183);
            this.canMoveSquare33.Name = "canMoveSquare33";
            this.canMoveSquare33.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare33.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare33.TabIndex = 119;
            this.canMoveSquare33.TabStop = false;
            this.canMoveSquare33.Visible = false;
            // 
            // canMoveSquare34
            // 
            this.canMoveSquare34.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare34.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare34.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare34.Image")));
            this.canMoveSquare34.Location = new System.Drawing.Point(487, 183);
            this.canMoveSquare34.Name = "canMoveSquare34";
            this.canMoveSquare34.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare34.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare34.TabIndex = 118;
            this.canMoveSquare34.TabStop = false;
            this.canMoveSquare34.Visible = false;
            // 
            // canMoveSquare35
            // 
            this.canMoveSquare35.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare35.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare35.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare35.Image")));
            this.canMoveSquare35.Location = new System.Drawing.Point(533, 183);
            this.canMoveSquare35.Name = "canMoveSquare35";
            this.canMoveSquare35.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare35.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare35.TabIndex = 117;
            this.canMoveSquare35.TabStop = false;
            this.canMoveSquare35.Visible = false;
            // 
            // canMoveSquare36
            // 
            this.canMoveSquare36.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare36.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare36.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare36.Image")));
            this.canMoveSquare36.Location = new System.Drawing.Point(579, 183);
            this.canMoveSquare36.Name = "canMoveSquare36";
            this.canMoveSquare36.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare36.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare36.TabIndex = 116;
            this.canMoveSquare36.TabStop = false;
            this.canMoveSquare36.Visible = false;
            // 
            // canMoveSquare46
            // 
            this.canMoveSquare46.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare46.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare46.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare46.Image")));
            this.canMoveSquare46.Location = new System.Drawing.Point(211, 275);
            this.canMoveSquare46.Name = "canMoveSquare46";
            this.canMoveSquare46.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare46.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare46.TabIndex = 133;
            this.canMoveSquare46.TabStop = false;
            this.canMoveSquare46.Visible = false;
            // 
            // canMoveSquare47
            // 
            this.canMoveSquare47.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare47.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare47.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare47.Image")));
            this.canMoveSquare47.Location = new System.Drawing.Point(257, 275);
            this.canMoveSquare47.Name = "canMoveSquare47";
            this.canMoveSquare47.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare47.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare47.TabIndex = 132;
            this.canMoveSquare47.TabStop = false;
            this.canMoveSquare47.Visible = false;
            // 
            // canMoveSquare48
            // 
            this.canMoveSquare48.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare48.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare48.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare48.Image")));
            this.canMoveSquare48.Location = new System.Drawing.Point(303, 275);
            this.canMoveSquare48.Name = "canMoveSquare48";
            this.canMoveSquare48.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare48.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare48.TabIndex = 131;
            this.canMoveSquare48.TabStop = false;
            this.canMoveSquare48.Visible = false;
            // 
            // canMoveSquare49
            // 
            this.canMoveSquare49.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare49.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare49.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare49.Image")));
            this.canMoveSquare49.Location = new System.Drawing.Point(349, 275);
            this.canMoveSquare49.Name = "canMoveSquare49";
            this.canMoveSquare49.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare49.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare49.TabIndex = 130;
            this.canMoveSquare49.TabStop = false;
            this.canMoveSquare49.Visible = false;
            // 
            // canMoveSquare50
            // 
            this.canMoveSquare50.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare50.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare50.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare50.Image")));
            this.canMoveSquare50.Location = new System.Drawing.Point(395, 275);
            this.canMoveSquare50.Name = "canMoveSquare50";
            this.canMoveSquare50.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare50.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare50.TabIndex = 129;
            this.canMoveSquare50.TabStop = false;
            this.canMoveSquare50.Visible = false;
            // 
            // canMoveSquare51
            // 
            this.canMoveSquare51.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare51.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare51.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare51.Image")));
            this.canMoveSquare51.Location = new System.Drawing.Point(441, 275);
            this.canMoveSquare51.Name = "canMoveSquare51";
            this.canMoveSquare51.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare51.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare51.TabIndex = 128;
            this.canMoveSquare51.TabStop = false;
            this.canMoveSquare51.Visible = false;
            // 
            // canMoveSquare52
            // 
            this.canMoveSquare52.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare52.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare52.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare52.Image")));
            this.canMoveSquare52.Location = new System.Drawing.Point(487, 275);
            this.canMoveSquare52.Name = "canMoveSquare52";
            this.canMoveSquare52.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare52.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare52.TabIndex = 127;
            this.canMoveSquare52.TabStop = false;
            this.canMoveSquare52.Visible = false;
            // 
            // canMoveSquare53
            // 
            this.canMoveSquare53.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare53.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare53.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare53.Image")));
            this.canMoveSquare53.Location = new System.Drawing.Point(533, 275);
            this.canMoveSquare53.Name = "canMoveSquare53";
            this.canMoveSquare53.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare53.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare53.TabIndex = 126;
            this.canMoveSquare53.TabStop = false;
            this.canMoveSquare53.Visible = false;
            // 
            // canMoveSquare54
            // 
            this.canMoveSquare54.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare54.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare54.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare54.Image")));
            this.canMoveSquare54.Location = new System.Drawing.Point(579, 275);
            this.canMoveSquare54.Name = "canMoveSquare54";
            this.canMoveSquare54.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare54.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare54.TabIndex = 125;
            this.canMoveSquare54.TabStop = false;
            this.canMoveSquare54.Visible = false;
            // 
            // canMoveSquare55
            // 
            this.canMoveSquare55.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare55.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare55.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare55.Image")));
            this.canMoveSquare55.Location = new System.Drawing.Point(211, 321);
            this.canMoveSquare55.Name = "canMoveSquare55";
            this.canMoveSquare55.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare55.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare55.TabIndex = 142;
            this.canMoveSquare55.TabStop = false;
            this.canMoveSquare55.Visible = false;
            // 
            // canMoveSquare56
            // 
            this.canMoveSquare56.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare56.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare56.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare56.Image")));
            this.canMoveSquare56.Location = new System.Drawing.Point(257, 321);
            this.canMoveSquare56.Name = "canMoveSquare56";
            this.canMoveSquare56.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare56.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare56.TabIndex = 141;
            this.canMoveSquare56.TabStop = false;
            this.canMoveSquare56.Visible = false;
            // 
            // canMoveSquare57
            // 
            this.canMoveSquare57.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare57.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare57.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare57.Image")));
            this.canMoveSquare57.Location = new System.Drawing.Point(303, 321);
            this.canMoveSquare57.Name = "canMoveSquare57";
            this.canMoveSquare57.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare57.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare57.TabIndex = 140;
            this.canMoveSquare57.TabStop = false;
            this.canMoveSquare57.Visible = false;
            // 
            // canMoveSquare58
            // 
            this.canMoveSquare58.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare58.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare58.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare58.Image")));
            this.canMoveSquare58.Location = new System.Drawing.Point(349, 321);
            this.canMoveSquare58.Name = "canMoveSquare58";
            this.canMoveSquare58.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare58.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare58.TabIndex = 139;
            this.canMoveSquare58.TabStop = false;
            this.canMoveSquare58.Visible = false;
            // 
            // canMoveSquare59
            // 
            this.canMoveSquare59.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare59.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare59.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare59.Image")));
            this.canMoveSquare59.Location = new System.Drawing.Point(395, 321);
            this.canMoveSquare59.Name = "canMoveSquare59";
            this.canMoveSquare59.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare59.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare59.TabIndex = 138;
            this.canMoveSquare59.TabStop = false;
            this.canMoveSquare59.Visible = false;
            // 
            // canMoveSquare60
            // 
            this.canMoveSquare60.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare60.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare60.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare60.Image")));
            this.canMoveSquare60.Location = new System.Drawing.Point(441, 321);
            this.canMoveSquare60.Name = "canMoveSquare60";
            this.canMoveSquare60.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare60.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare60.TabIndex = 137;
            this.canMoveSquare60.TabStop = false;
            this.canMoveSquare60.Visible = false;
            // 
            // canMoveSquare61
            // 
            this.canMoveSquare61.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare61.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare61.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare61.Image")));
            this.canMoveSquare61.Location = new System.Drawing.Point(487, 321);
            this.canMoveSquare61.Name = "canMoveSquare61";
            this.canMoveSquare61.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare61.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare61.TabIndex = 136;
            this.canMoveSquare61.TabStop = false;
            this.canMoveSquare61.Visible = false;
            // 
            // canMoveSquare62
            // 
            this.canMoveSquare62.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare62.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare62.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare62.Image")));
            this.canMoveSquare62.Location = new System.Drawing.Point(533, 321);
            this.canMoveSquare62.Name = "canMoveSquare62";
            this.canMoveSquare62.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare62.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare62.TabIndex = 135;
            this.canMoveSquare62.TabStop = false;
            this.canMoveSquare62.Visible = false;
            // 
            // canMoveSquare63
            // 
            this.canMoveSquare63.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare63.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare63.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare63.Image")));
            this.canMoveSquare63.Location = new System.Drawing.Point(579, 321);
            this.canMoveSquare63.Name = "canMoveSquare63";
            this.canMoveSquare63.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare63.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare63.TabIndex = 134;
            this.canMoveSquare63.TabStop = false;
            this.canMoveSquare63.Visible = false;
            // 
            // canMoveSquare64
            // 
            this.canMoveSquare64.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare64.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare64.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare64.Image")));
            this.canMoveSquare64.Location = new System.Drawing.Point(211, 367);
            this.canMoveSquare64.Name = "canMoveSquare64";
            this.canMoveSquare64.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare64.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare64.TabIndex = 151;
            this.canMoveSquare64.TabStop = false;
            this.canMoveSquare64.Visible = false;
            // 
            // canMoveSquare65
            // 
            this.canMoveSquare65.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare65.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare65.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare65.Image")));
            this.canMoveSquare65.Location = new System.Drawing.Point(257, 367);
            this.canMoveSquare65.Name = "canMoveSquare65";
            this.canMoveSquare65.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare65.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare65.TabIndex = 150;
            this.canMoveSquare65.TabStop = false;
            this.canMoveSquare65.Visible = false;
            // 
            // canMoveSquare66
            // 
            this.canMoveSquare66.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare66.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare66.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare66.Image")));
            this.canMoveSquare66.Location = new System.Drawing.Point(303, 367);
            this.canMoveSquare66.Name = "canMoveSquare66";
            this.canMoveSquare66.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare66.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare66.TabIndex = 149;
            this.canMoveSquare66.TabStop = false;
            this.canMoveSquare66.Visible = false;
            // 
            // canMoveSquare67
            // 
            this.canMoveSquare67.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare67.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare67.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare67.Image")));
            this.canMoveSquare67.Location = new System.Drawing.Point(349, 367);
            this.canMoveSquare67.Name = "canMoveSquare67";
            this.canMoveSquare67.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare67.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare67.TabIndex = 148;
            this.canMoveSquare67.TabStop = false;
            this.canMoveSquare67.Visible = false;
            // 
            // canMoveSquare68
            // 
            this.canMoveSquare68.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare68.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare68.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare68.Image")));
            this.canMoveSquare68.Location = new System.Drawing.Point(395, 367);
            this.canMoveSquare68.Name = "canMoveSquare68";
            this.canMoveSquare68.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare68.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare68.TabIndex = 147;
            this.canMoveSquare68.TabStop = false;
            this.canMoveSquare68.Visible = false;
            // 
            // canMoveSquare69
            // 
            this.canMoveSquare69.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare69.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare69.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare69.Image")));
            this.canMoveSquare69.Location = new System.Drawing.Point(441, 367);
            this.canMoveSquare69.Name = "canMoveSquare69";
            this.canMoveSquare69.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare69.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare69.TabIndex = 146;
            this.canMoveSquare69.TabStop = false;
            this.canMoveSquare69.Visible = false;
            // 
            // canMoveSquare70
            // 
            this.canMoveSquare70.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare70.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare70.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare70.Image")));
            this.canMoveSquare70.Location = new System.Drawing.Point(487, 367);
            this.canMoveSquare70.Name = "canMoveSquare70";
            this.canMoveSquare70.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare70.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare70.TabIndex = 145;
            this.canMoveSquare70.TabStop = false;
            this.canMoveSquare70.Visible = false;
            // 
            // canMoveSquare71
            // 
            this.canMoveSquare71.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare71.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare71.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare71.Image")));
            this.canMoveSquare71.Location = new System.Drawing.Point(533, 367);
            this.canMoveSquare71.Name = "canMoveSquare71";
            this.canMoveSquare71.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare71.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare71.TabIndex = 144;
            this.canMoveSquare71.TabStop = false;
            this.canMoveSquare71.Visible = false;
            // 
            // canMoveSquare72
            // 
            this.canMoveSquare72.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare72.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare72.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare72.Image")));
            this.canMoveSquare72.Location = new System.Drawing.Point(579, 367);
            this.canMoveSquare72.Name = "canMoveSquare72";
            this.canMoveSquare72.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare72.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare72.TabIndex = 143;
            this.canMoveSquare72.TabStop = false;
            this.canMoveSquare72.Visible = false;
            // 
            // canMoveSquare75
            // 
            this.canMoveSquare75.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare75.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare75.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare75.Image")));
            this.canMoveSquare75.Location = new System.Drawing.Point(303, 413);
            this.canMoveSquare75.Name = "canMoveSquare75";
            this.canMoveSquare75.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare75.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare75.TabIndex = 152;
            this.canMoveSquare75.TabStop = false;
            this.canMoveSquare75.Visible = false;
            // 
            // canMoveSquare77
            // 
            this.canMoveSquare77.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare77.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare77.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare77.Image")));
            this.canMoveSquare77.Location = new System.Drawing.Point(395, 413);
            this.canMoveSquare77.Name = "canMoveSquare77";
            this.canMoveSquare77.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare77.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare77.TabIndex = 153;
            this.canMoveSquare77.TabStop = false;
            this.canMoveSquare77.Visible = false;
            // 
            // canMoveSquare78
            // 
            this.canMoveSquare78.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare78.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare78.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare78.Image")));
            this.canMoveSquare78.Location = new System.Drawing.Point(441, 413);
            this.canMoveSquare78.Name = "canMoveSquare78";
            this.canMoveSquare78.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare78.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare78.TabIndex = 154;
            this.canMoveSquare78.TabStop = false;
            this.canMoveSquare78.Visible = false;
            // 
            // canMoveSquare79
            // 
            this.canMoveSquare79.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare79.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare79.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare79.Image")));
            this.canMoveSquare79.Location = new System.Drawing.Point(487, 413);
            this.canMoveSquare79.Name = "canMoveSquare79";
            this.canMoveSquare79.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare79.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare79.TabIndex = 155;
            this.canMoveSquare79.TabStop = false;
            this.canMoveSquare79.Visible = false;
            // 
            // canMoveSquare81
            // 
            this.canMoveSquare81.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare81.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare81.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare81.Image")));
            this.canMoveSquare81.Location = new System.Drawing.Point(579, 413);
            this.canMoveSquare81.Name = "canMoveSquare81";
            this.canMoveSquare81.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare81.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare81.TabIndex = 157;
            this.canMoveSquare81.TabStop = false;
            this.canMoveSquare81.Visible = false;
            // 
            // canMoveSquare74
            // 
            this.canMoveSquare74.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare74.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare74.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare74.Image")));
            this.canMoveSquare74.Location = new System.Drawing.Point(257, 413);
            this.canMoveSquare74.Name = "canMoveSquare74";
            this.canMoveSquare74.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare74.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare74.TabIndex = 158;
            this.canMoveSquare74.TabStop = false;
            this.canMoveSquare74.Visible = false;
            // 
            // canMoveSquare22
            // 
            this.canMoveSquare22.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare22.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare22.Image")));
            this.canMoveSquare22.Location = new System.Drawing.Point(349, 137);
            this.canMoveSquare22.Name = "canMoveSquare22";
            this.canMoveSquare22.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare22.TabIndex = 159;
            this.canMoveSquare22.TabStop = false;
            this.canMoveSquare22.Visible = false;
            // 
            // canMoveSquare23
            // 
            this.canMoveSquare23.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare23.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare23.Image")));
            this.canMoveSquare23.Location = new System.Drawing.Point(395, 137);
            this.canMoveSquare23.Name = "canMoveSquare23";
            this.canMoveSquare23.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare23.TabIndex = 160;
            this.canMoveSquare23.TabStop = false;
            this.canMoveSquare23.Visible = false;
            // 
            // canMoveSquare24
            // 
            this.canMoveSquare24.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare24.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare24.Image")));
            this.canMoveSquare24.Location = new System.Drawing.Point(441, 137);
            this.canMoveSquare24.Name = "canMoveSquare24";
            this.canMoveSquare24.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare24.TabIndex = 161;
            this.canMoveSquare24.TabStop = false;
            this.canMoveSquare24.Visible = false;
            // 
            // canMoveSquare25
            // 
            this.canMoveSquare25.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare25.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare25.Image")));
            this.canMoveSquare25.Location = new System.Drawing.Point(487, 137);
            this.canMoveSquare25.Name = "canMoveSquare25";
            this.canMoveSquare25.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare25.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare25.TabIndex = 162;
            this.canMoveSquare25.TabStop = false;
            this.canMoveSquare25.Visible = false;
            // 
            // canMoveSquare27
            // 
            this.canMoveSquare27.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare27.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare27.Image")));
            this.canMoveSquare27.Location = new System.Drawing.Point(579, 137);
            this.canMoveSquare27.Name = "canMoveSquare27";
            this.canMoveSquare27.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare27.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare27.TabIndex = 164;
            this.canMoveSquare27.TabStop = false;
            this.canMoveSquare27.Visible = false;
            // 
            // canMoveSquare26
            // 
            this.canMoveSquare26.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare26.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare26.Image")));
            this.canMoveSquare26.Location = new System.Drawing.Point(533, 137);
            this.canMoveSquare26.Name = "canMoveSquare26";
            this.canMoveSquare26.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare26.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare26.TabIndex = 165;
            this.canMoveSquare26.TabStop = false;
            this.canMoveSquare26.Visible = false;
            // 
            // canMoveSquare17
            // 
            this.canMoveSquare17.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare17.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare17.Image")));
            this.canMoveSquare17.Location = new System.Drawing.Point(533, 91);
            this.canMoveSquare17.Name = "canMoveSquare17";
            this.canMoveSquare17.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare17.TabIndex = 166;
            this.canMoveSquare17.TabStop = false;
            this.canMoveSquare17.Visible = false;
            // 
            // canMoveSquare80
            // 
            this.canMoveSquare80.BackColor = System.Drawing.Color.LightGray;
            this.canMoveSquare80.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canMoveSquare80.Image = ((System.Drawing.Image)(resources.GetObject("canMoveSquare80.Image")));
            this.canMoveSquare80.Location = new System.Drawing.Point(533, 413);
            this.canMoveSquare80.Name = "canMoveSquare80";
            this.canMoveSquare80.Size = new System.Drawing.Size(40, 40);
            this.canMoveSquare80.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.canMoveSquare80.TabIndex = 156;
            this.canMoveSquare80.TabStop = false;
            this.canMoveSquare80.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(823, 577);
            this.Controls.Add(this.canMoveSquare17);
            this.Controls.Add(this.canMoveSquare26);
            this.Controls.Add(this.canMoveSquare27);
            this.Controls.Add(this.canMoveSquare25);
            this.Controls.Add(this.canMoveSquare24);
            this.Controls.Add(this.canMoveSquare23);
            this.Controls.Add(this.canMoveSquare22);
            this.Controls.Add(this.canMoveSquare74);
            this.Controls.Add(this.canMoveSquare81);
            this.Controls.Add(this.canMoveSquare80);
            this.Controls.Add(this.canMoveSquare79);
            this.Controls.Add(this.canMoveSquare78);
            this.Controls.Add(this.canMoveSquare77);
            this.Controls.Add(this.canMoveSquare75);
            this.Controls.Add(this.canMoveSquare64);
            this.Controls.Add(this.canMoveSquare65);
            this.Controls.Add(this.canMoveSquare66);
            this.Controls.Add(this.canMoveSquare67);
            this.Controls.Add(this.canMoveSquare68);
            this.Controls.Add(this.canMoveSquare69);
            this.Controls.Add(this.canMoveSquare70);
            this.Controls.Add(this.canMoveSquare71);
            this.Controls.Add(this.canMoveSquare72);
            this.Controls.Add(this.canMoveSquare55);
            this.Controls.Add(this.canMoveSquare56);
            this.Controls.Add(this.canMoveSquare57);
            this.Controls.Add(this.canMoveSquare58);
            this.Controls.Add(this.canMoveSquare59);
            this.Controls.Add(this.canMoveSquare60);
            this.Controls.Add(this.canMoveSquare61);
            this.Controls.Add(this.canMoveSquare62);
            this.Controls.Add(this.canMoveSquare63);
            this.Controls.Add(this.canMoveSquare46);
            this.Controls.Add(this.canMoveSquare47);
            this.Controls.Add(this.canMoveSquare48);
            this.Controls.Add(this.canMoveSquare49);
            this.Controls.Add(this.canMoveSquare50);
            this.Controls.Add(this.canMoveSquare51);
            this.Controls.Add(this.canMoveSquare52);
            this.Controls.Add(this.canMoveSquare53);
            this.Controls.Add(this.canMoveSquare54);
            this.Controls.Add(this.canMoveSquare28);
            this.Controls.Add(this.canMoveSquare29);
            this.Controls.Add(this.canMoveSquare30);
            this.Controls.Add(this.canMoveSquare31);
            this.Controls.Add(this.canMoveSquare32);
            this.Controls.Add(this.canMoveSquare33);
            this.Controls.Add(this.canMoveSquare34);
            this.Controls.Add(this.canMoveSquare35);
            this.Controls.Add(this.canMoveSquare36);
            this.Controls.Add(this.canMoveSquare37);
            this.Controls.Add(this.canMoveSquare38);
            this.Controls.Add(this.canMoveSquare39);
            this.Controls.Add(this.canMoveSquare40);
            this.Controls.Add(this.canMoveSquare41);
            this.Controls.Add(this.canMoveSquare42);
            this.Controls.Add(this.canMoveSquare43);
            this.Controls.Add(this.canMoveSquare44);
            this.Controls.Add(this.canMoveSquare45);
            this.Controls.Add(this.canMoveSquare73);
            this.Controls.Add(this.canMoveSquare11);
            this.Controls.Add(this.canMoveSquare12);
            this.Controls.Add(this.canMoveSquare13);
            this.Controls.Add(this.canMoveSquare14);
            this.Controls.Add(this.canMoveSquare15);
            this.Controls.Add(this.canMoveSquare16);
            this.Controls.Add(this.canMoveSquare18);
            this.Controls.Add(this.canMoveSquare1);
            this.Controls.Add(this.canMoveSquare2);
            this.Controls.Add(this.canMoveSquare3);
            this.Controls.Add(this.canMoveSquare4);
            this.Controls.Add(this.canMoveSquare5);
            this.Controls.Add(this.canMoveSquare6);
            this.Controls.Add(this.canMoveSquare7);
            this.Controls.Add(this.canMoveSquare8);
            this.Controls.Add(this.canMoveSquare9);
            this.Controls.Add(this.canMoveSquare10);
            this.Controls.Add(this.canMoveSquare19);
            this.Controls.Add(this.canMoveSquare20);
            this.Controls.Add(this.canMoveSquare21);
            this.Controls.Add(this.canMoveSquare76);
            this.Controls.Add(this.userPawn);
            this.Controls.Add(this.computerPawn);
            this.Controls.Add(this.pictureBox73);
            this.Controls.Add(this.pictureBox74);
            this.Controls.Add(this.pictureBox75);
            this.Controls.Add(this.pictureBox76);
            this.Controls.Add(this.pictureBox77);
            this.Controls.Add(this.pictureBox78);
            this.Controls.Add(this.pictureBox79);
            this.Controls.Add(this.pictureBox80);
            this.Controls.Add(this.pictureBox81);
            this.Controls.Add(this.pictureBox64);
            this.Controls.Add(this.pictureBox65);
            this.Controls.Add(this.pictureBox66);
            this.Controls.Add(this.pictureBox67);
            this.Controls.Add(this.pictureBox68);
            this.Controls.Add(this.pictureBox69);
            this.Controls.Add(this.pictureBox70);
            this.Controls.Add(this.pictureBox71);
            this.Controls.Add(this.pictureBox72);
            this.Controls.Add(this.pictureBox55);
            this.Controls.Add(this.pictureBox56);
            this.Controls.Add(this.pictureBox57);
            this.Controls.Add(this.pictureBox58);
            this.Controls.Add(this.pictureBox59);
            this.Controls.Add(this.pictureBox60);
            this.Controls.Add(this.pictureBox61);
            this.Controls.Add(this.pictureBox62);
            this.Controls.Add(this.pictureBox63);
            this.Controls.Add(this.pictureBox46);
            this.Controls.Add(this.pictureBox47);
            this.Controls.Add(this.pictureBox48);
            this.Controls.Add(this.pictureBox49);
            this.Controls.Add(this.pictureBox50);
            this.Controls.Add(this.pictureBox51);
            this.Controls.Add(this.pictureBox52);
            this.Controls.Add(this.pictureBox53);
            this.Controls.Add(this.pictureBox54);
            this.Controls.Add(this.pictureBox37);
            this.Controls.Add(this.pictureBox38);
            this.Controls.Add(this.pictureBox39);
            this.Controls.Add(this.pictureBox40);
            this.Controls.Add(this.pictureBox41);
            this.Controls.Add(this.pictureBox42);
            this.Controls.Add(this.pictureBox43);
            this.Controls.Add(this.pictureBox44);
            this.Controls.Add(this.pictureBox45);
            this.Controls.Add(this.pictureBox28);
            this.Controls.Add(this.pictureBox29);
            this.Controls.Add(this.pictureBox30);
            this.Controls.Add(this.pictureBox31);
            this.Controls.Add(this.pictureBox32);
            this.Controls.Add(this.pictureBox33);
            this.Controls.Add(this.pictureBox34);
            this.Controls.Add(this.pictureBox35);
            this.Controls.Add(this.pictureBox36);
            this.Controls.Add(this.pictureBox19);
            this.Controls.Add(this.pictureBox20);
            this.Controls.Add(this.pictureBox21);
            this.Controls.Add(this.pictureBox22);
            this.Controls.Add(this.pictureBox23);
            this.Controls.Add(this.pictureBox24);
            this.Controls.Add(this.pictureBox25);
            this.Controls.Add(this.pictureBox26);
            this.Controls.Add(this.pictureBox27);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.pictureBox17);
            this.Controls.Add(this.pictureBox18);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quoridor";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanPlaceVerticalWall);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox79)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerPawn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPawn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare79)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canMoveSquare80)).EndInit();
            this.ResumeLayout(false);
        }


        private System.Windows.Forms.PictureBox canMoveSquare27;
        private System.Windows.Forms.PictureBox canMoveSquare26;
        private System.Windows.Forms.PictureBox canMoveSquare17;

        private System.Windows.Forms.PictureBox canMoveSquare21;
        private System.Windows.Forms.PictureBox canMoveSquare20;
        private System.Windows.Forms.PictureBox canMoveSquare19;
        private System.Windows.Forms.PictureBox canMoveSquare10;
        private System.Windows.Forms.PictureBox canMoveSquare9;
        private System.Windows.Forms.PictureBox canMoveSquare8;
        private System.Windows.Forms.PictureBox canMoveSquare7;
        private System.Windows.Forms.PictureBox canMoveSquare6;
        private System.Windows.Forms.PictureBox canMoveSquare5;
        private System.Windows.Forms.PictureBox canMoveSquare4;
        private System.Windows.Forms.PictureBox canMoveSquare3;
        private System.Windows.Forms.PictureBox canMoveSquare2;
        private System.Windows.Forms.PictureBox canMoveSquare1;
        private System.Windows.Forms.PictureBox canMoveSquare73;
        private System.Windows.Forms.PictureBox canMoveSquare11;
        private System.Windows.Forms.PictureBox canMoveSquare12;
        private System.Windows.Forms.PictureBox canMoveSquare13;
        private System.Windows.Forms.PictureBox canMoveSquare14;
        private System.Windows.Forms.PictureBox canMoveSquare15;
        private System.Windows.Forms.PictureBox canMoveSquare16;
        private System.Windows.Forms.PictureBox canMoveSquare18;
        private System.Windows.Forms.PictureBox canMoveSquare37;
        private System.Windows.Forms.PictureBox canMoveSquare38;
        private System.Windows.Forms.PictureBox canMoveSquare39;
        private System.Windows.Forms.PictureBox canMoveSquare40;
        private System.Windows.Forms.PictureBox canMoveSquare41;
        private System.Windows.Forms.PictureBox canMoveSquare42;
        private System.Windows.Forms.PictureBox canMoveSquare43;
        private System.Windows.Forms.PictureBox canMoveSquare44;
        private System.Windows.Forms.PictureBox canMoveSquare45;
        private System.Windows.Forms.PictureBox canMoveSquare28;
        private System.Windows.Forms.PictureBox canMoveSquare29;
        private System.Windows.Forms.PictureBox canMoveSquare30;
        private System.Windows.Forms.PictureBox canMoveSquare31;
        private System.Windows.Forms.PictureBox canMoveSquare32;
        private System.Windows.Forms.PictureBox canMoveSquare33;
        private System.Windows.Forms.PictureBox canMoveSquare34;
        private System.Windows.Forms.PictureBox canMoveSquare35;
        private System.Windows.Forms.PictureBox canMoveSquare36;
        private System.Windows.Forms.PictureBox canMoveSquare46;
        private System.Windows.Forms.PictureBox canMoveSquare47;
        private System.Windows.Forms.PictureBox canMoveSquare48;
        private System.Windows.Forms.PictureBox canMoveSquare49;
        private System.Windows.Forms.PictureBox canMoveSquare50;
        private System.Windows.Forms.PictureBox canMoveSquare51;
        private System.Windows.Forms.PictureBox canMoveSquare52;
        private System.Windows.Forms.PictureBox canMoveSquare53;
        private System.Windows.Forms.PictureBox canMoveSquare54;
        private System.Windows.Forms.PictureBox canMoveSquare55;
        private System.Windows.Forms.PictureBox canMoveSquare56;
        private System.Windows.Forms.PictureBox canMoveSquare57;
        private System.Windows.Forms.PictureBox canMoveSquare58;
        private System.Windows.Forms.PictureBox canMoveSquare59;
        private System.Windows.Forms.PictureBox canMoveSquare60;
        private System.Windows.Forms.PictureBox canMoveSquare61;
        private System.Windows.Forms.PictureBox canMoveSquare62;
        private System.Windows.Forms.PictureBox canMoveSquare63;
        private System.Windows.Forms.PictureBox canMoveSquare64;
        private System.Windows.Forms.PictureBox canMoveSquare65;
        private System.Windows.Forms.PictureBox canMoveSquare66;
        private System.Windows.Forms.PictureBox canMoveSquare67;
        private System.Windows.Forms.PictureBox canMoveSquare68;
        private System.Windows.Forms.PictureBox canMoveSquare69;
        private System.Windows.Forms.PictureBox canMoveSquare70;
        private System.Windows.Forms.PictureBox canMoveSquare71;
        private System.Windows.Forms.PictureBox canMoveSquare72;
        private System.Windows.Forms.PictureBox canMoveSquare75;
        private System.Windows.Forms.PictureBox canMoveSquare77;
        private System.Windows.Forms.PictureBox canMoveSquare78;
        private System.Windows.Forms.PictureBox canMoveSquare79;
        private System.Windows.Forms.PictureBox canMoveSquare80;
        private System.Windows.Forms.PictureBox canMoveSquare81;
        private System.Windows.Forms.PictureBox canMoveSquare74;
        private System.Windows.Forms.PictureBox canMoveSquare22;
        private System.Windows.Forms.PictureBox canMoveSquare23;
        private System.Windows.Forms.PictureBox canMoveSquare24;
        private System.Windows.Forms.PictureBox canMoveSquare25;

        private System.Windows.Forms.PictureBox canMoveSquare76;

        private System.Windows.Forms.PictureBox userPawn;

        private System.Windows.Forms.PictureBox computerPawn;

        private System.Windows.Forms.PictureBox pictureBox73;
        private System.Windows.Forms.PictureBox pictureBox74;
        private System.Windows.Forms.PictureBox pictureBox75;
        private System.Windows.Forms.PictureBox pictureBox76;
        private System.Windows.Forms.PictureBox pictureBox77;
        private System.Windows.Forms.PictureBox pictureBox78;
        private System.Windows.Forms.PictureBox pictureBox79;
        private System.Windows.Forms.PictureBox pictureBox80;
        private System.Windows.Forms.PictureBox pictureBox81;

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.PictureBox pictureBox19;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.PictureBox pictureBox21;
        private System.Windows.Forms.PictureBox pictureBox22;
        private System.Windows.Forms.PictureBox pictureBox23;
        private System.Windows.Forms.PictureBox pictureBox24;
        private System.Windows.Forms.PictureBox pictureBox25;
        private System.Windows.Forms.PictureBox pictureBox26;
        private System.Windows.Forms.PictureBox pictureBox27;
        private System.Windows.Forms.PictureBox pictureBox28;
        private System.Windows.Forms.PictureBox pictureBox29;
        private System.Windows.Forms.PictureBox pictureBox30;
        private System.Windows.Forms.PictureBox pictureBox31;
        private System.Windows.Forms.PictureBox pictureBox32;
        private System.Windows.Forms.PictureBox pictureBox33;
        private System.Windows.Forms.PictureBox pictureBox34;
        private System.Windows.Forms.PictureBox pictureBox35;
        private System.Windows.Forms.PictureBox pictureBox36;
        private System.Windows.Forms.PictureBox pictureBox37;
        private System.Windows.Forms.PictureBox pictureBox38;
        private System.Windows.Forms.PictureBox pictureBox39;
        private System.Windows.Forms.PictureBox pictureBox40;
        private System.Windows.Forms.PictureBox pictureBox41;
        private System.Windows.Forms.PictureBox pictureBox42;
        private System.Windows.Forms.PictureBox pictureBox43;
        private System.Windows.Forms.PictureBox pictureBox44;
        private System.Windows.Forms.PictureBox pictureBox45;
        private System.Windows.Forms.PictureBox pictureBox46;
        private System.Windows.Forms.PictureBox pictureBox47;
        private System.Windows.Forms.PictureBox pictureBox48;
        private System.Windows.Forms.PictureBox pictureBox49;
        private System.Windows.Forms.PictureBox pictureBox50;
        private System.Windows.Forms.PictureBox pictureBox51;
        private System.Windows.Forms.PictureBox pictureBox52;
        private System.Windows.Forms.PictureBox pictureBox53;
        private System.Windows.Forms.PictureBox pictureBox54;
        private System.Windows.Forms.PictureBox pictureBox55;
        private System.Windows.Forms.PictureBox pictureBox56;
        private System.Windows.Forms.PictureBox pictureBox57;
        private System.Windows.Forms.PictureBox pictureBox58;
        private System.Windows.Forms.PictureBox pictureBox59;
        private System.Windows.Forms.PictureBox pictureBox60;
        private System.Windows.Forms.PictureBox pictureBox61;
        private System.Windows.Forms.PictureBox pictureBox62;
        private System.Windows.Forms.PictureBox pictureBox63;
        private System.Windows.Forms.PictureBox pictureBox64;
        private System.Windows.Forms.PictureBox pictureBox65;
        private System.Windows.Forms.PictureBox pictureBox66;
        private System.Windows.Forms.PictureBox pictureBox67;
        private System.Windows.Forms.PictureBox pictureBox68;
        private System.Windows.Forms.PictureBox pictureBox69;
        private System.Windows.Forms.PictureBox pictureBox70;
        private System.Windows.Forms.PictureBox pictureBox71;
        private System.Windows.Forms.PictureBox pictureBox72;
        private System.Windows.Forms.PictureBox pictureBox1;
        

        #endregion
    }
}