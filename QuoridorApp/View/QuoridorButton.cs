using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuoridorApp.View;

public class QuoridorButton : Button
{
    private const int Radius = 10;
    private string _toolTipText;
    
    
    public string ToolTipText
    {
        get => _toolTipText;
        set
        {
            _toolTipText = value;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this, _toolTipText);
        }
    }

    public QuoridorButton()
    {
        // Set the default properties of the button.
        this.BackColor = Color.White;
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
        this.FlatAppearance.BorderSize = 0;
        this.Size = new Size(30, 30);

        // Set the round edges of the button.
        this.Region = GetRegion(this.Size, Radius);
    }

    public sealed override Color BackColor
    {
        get => base.BackColor;
        set => base.BackColor = value;
    }

    protected override void OnPaint(PaintEventArgs e)
    {

        
        base.OnPaint(e);
        // draw a filled red triangle in the button corner
        Point[] triangle = new Point[] { new Point(10, 8), new Point(10, 30), new Point(30, 20) };
        e.Graphics.FillPolygon(Brushes.Green, triangle);


    }



    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        // Set the round edges of the button based on its new size.
        this.Region = GetRegion(this.Size, Radius);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        // Shrink the size of the button when it is pressed.
        this.Size = new Size(this.Width - 1, this.Height - 1);
        this.Region = GetRegion(this.Size, Radius - 2);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        // Restore the size of the button when the mouse button is released.
        this.Size = new Size(this.Width + 1, this.Height + 1);
        this.Region = GetRegion(this.Size, Radius);
    }

    private static GraphicsPath GetRoundRect(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();

        path.AddLine(rect.X + radius, rect.Y, rect.X + rect.Width - (radius * 2), rect.Y);
        path.AddArc(rect.X + rect.Width - (radius * 2), rect.Y, radius * 2, radius * 2, 270, 90);
        path.AddLine(rect.X + rect.Width, rect.Y + radius, rect.X + rect.Width, rect.Y + rect.Height - (radius * 2));
        path.AddArc(rect.X + rect.Width - (radius * 2), rect.Y + rect.Height - (radius * 2), radius * 2, radius * 2, 0, 90);
        path.AddLine(rect.X + rect.Width - (radius * 2), rect.Y + rect.Height, rect.X + radius, rect.Y + rect.Height);
        path.AddArc(rect.X, rect.Y + rect.Height - (radius * 2), radius * 2, radius * 2, 90, 90);
        path.AddLine(rect.X, rect.Y + rect.Height - (radius * 2), rect.X, rect.Y + radius);
        path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);

        path.CloseFigure();
        return path;
    }

    private static Region GetRegion(Size size, int radius)
    {
        Rectangle rect = new Rectangle(0, 0, size.Width, size.Height);
        GraphicsPath path = GetRoundRect(rect, radius);
        Region region = new Region(path);

        return region;
    }
}