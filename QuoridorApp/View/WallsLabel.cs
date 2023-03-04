using System;
using System.Drawing;
using System.Windows.Forms;
using static QuoridorApp.Constants;

namespace QuoridorApp.View;

public sealed class WallsLabel : Label
{
    private int _playerWalls = WallsPerPlayer;
    private string _playerName = "";

    public int PlayerWalls
    {
        get => _playerWalls;
        set
        {
            _playerWalls = value;
            UpdateLabelText();
        }
    }

    public string PlayerName
    {
        get => _playerName;
        set
        {
            _playerName = value;
            UpdateLabelText();
        }
    }

    public WallsLabel()
    {
        // Set the default properties of the label.
        this.TextAlign = ContentAlignment.MiddleCenter;
        this.Font = new Font("Arial", 14, FontStyle.Bold);
        this.BackColor = Color.RoyalBlue;
        this.Size = new Size(150, 50);

        this.MouseEnter += WallsLabel_MouseEnter;
        this.MouseLeave += WallsLabel_MouseLeave;
    }

    private void UpdateLabelText()
    {
        this.Text = _playerName + ": " + _playerWalls;
    }

    private void WallsLabel_MouseEnter(object sender, EventArgs e)
    {
        this.BorderStyle = BorderStyle.FixedSingle;
        this.Padding = new Padding(0);
    }

    private void WallsLabel_MouseLeave(object sender, EventArgs e)
    {
        this.BorderStyle = BorderStyle.None;
        this.Padding = new Padding(0);
    }

}

