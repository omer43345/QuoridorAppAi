using System;
using System.Drawing;
using System.Windows.Forms;
using static QuoridorApp.Constants;

namespace QuoridorApp.View;

// Class that represents a label that shows the number of walls that a player has left. it inherits from Label and add 2 properties: player walls and player name.
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

    // Constructor that sets the default properties of the label and add event handlers for mouse enter and mouse leave.
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

    // Method that updates the text of the label. it is called when the player walls or player name properties are changed.
    private void UpdateLabelText()
    {
        this.Text = _playerName + ": " + _playerWalls;
    }

    // Event handler for mouse enter and mouse leave events. it changes the border style and padding of the label.
    
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

