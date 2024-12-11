using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CurvedPanel : Panel
{
    // Property for corner radius
    private int _cornerRadius = 40;
    public int CornerRadius
    {
        get { return _cornerRadius; }
        set { _cornerRadius = value; this.Invalidate(); }
    }

    // Constructor to set default properties
    public CurvedPanel()
    {
        this.DoubleBuffered = true; // To reduce flickering
        this.BackColor = Color.FromArgb(128, 128, 128); // Default color, adjust as needed
        this.Size = new Size(150, 100); // Default size, can be adjusted
    }

    // Method to draw rounded edges
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        Rectangle bounds = this.ClientRectangle;
        int radius = _cornerRadius;

        using (GraphicsPath path = new GraphicsPath())
        {
            // Define the rounded rectangle path
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            // Fill the panel with color
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            this.Region = new Region(path); // Set the panel's region to the rounded path
        }
    }
}
