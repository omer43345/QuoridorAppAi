using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static QuoridorApp.Constants;


namespace QuoridorApp.View;

partial class HomeForm
{
    private QuoridorButton playButton;
    private Label QuoridorLabel;
    private PictureBox rulesIcon;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
    // this function adds the Quoridor label to the form
    private void AddQuoridorLabel()
    {
        QuoridorLabel = new Label();
        QuoridorLabel.Location = new Point(0, 0);
        QuoridorLabel.Name = "QuoridorLabel";
        QuoridorLabel.Text = "Quoridor";
        QuoridorLabel.BackColor = Color.FromArgb(90, Color.White);
        QuoridorLabel.ForeColor = Color.DarkOrange;
        QuoridorLabel.Font = new Font(QuoridorLabel.Font.FontFamily, 70, FontStyle.Bold);
        QuoridorLabel.Size = new Size(600, 170);
        QuoridorLabel.TextAlign = ContentAlignment.MiddleCenter;
        Controls.Add(QuoridorLabel);

    }
    // this function adds the rules icon to the form
    private void AddRulesIcon()
    {
        rulesIcon = new PictureBox();
        rulesIcon.Location = new Point(723, 0);
        rulesIcon.Name = "rulesIcon";
        rulesIcon.Size = new Size(100, 100);
        rulesIcon.Image = ((Image)(Properties.Resources.rulesIcon));
        rulesIcon.SizeMode = PictureBoxSizeMode.StretchImage;
        rulesIcon.BackColor =  Color.FromArgb(220, Color.White);
        ToolTip toolTip = new ToolTip();
        toolTip.SetToolTip(rulesIcon, "see the rules of the game");
        rulesIcon.MouseClick += new MouseEventHandler(rulesIcon_Click);
        Controls.Add(rulesIcon);
    }
    // this function adds the play button to the form
    private void AddStartGameButton()
    {
        playButton = new QuoridorButton();
        playButton.Location = new Point(261, 220);
        playButton.Name = "PlayButton";
        playButton.Text = "Play";
        playButton.Font = new Font(playButton.Font.FontFamily, 40, FontStyle.Bold);
        playButton.BackColor = Color.FromArgb(240, Color.LimeGreen);
        playButton.Size = new Size(300, 150);
        playButton.ToolTipText = "Start a new game";
        playButton.MouseClick += new MouseEventHandler(StartGameButton_Click);
        Controls.Add(playButton);
    }
    // this function initializes the form
    private void InitForm()
    {
        this.SuspendLayout();
        // 
        // HomeForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.homeBackground));
        this.ClientSize = new System.Drawing.Size(FormWidth, FormHeight);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Name = "GameForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Quoridor";
        this.ResumeLayout(false);
    }
    #region Windows Form Designer generated code
    #endregion
}