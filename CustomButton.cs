using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CustomButton : Button
{
    private int _borderRadius = 5;
    private Color _borderColor = Color.DarkCyan;

    public int BorderRadius
    {
        get { return _borderRadius; }
        set
        {
            _borderRadius = value;
            this.Invalidate(); // Redraw the control
        }
    }

    public Color BorderColor
    {
        get { return _borderColor; }
        set
        {
            _borderColor = value;
            this.Invalidate(); // Redraw the control
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Draw rounded rectangle with specified border color and radius
        using (GraphicsPath path = new GraphicsPath())
        using (Pen pen = new Pen(_borderColor, 2))
        {
            // Define the rounded rectangle path
            path.AddArc(0, 0, _borderRadius, _borderRadius, 180, 90);
            path.AddArc(this.Width - _borderRadius - 1, 0, _borderRadius, _borderRadius, 270, 90);
            path.AddArc(this.Width - _borderRadius - 1, this.Height - _borderRadius - 1, _borderRadius, _borderRadius, 0, 90);
            path.AddArc(0, this.Height - _borderRadius - 1, _borderRadius, _borderRadius, 90, 90);
            path.CloseFigure();

            // Set the button region for rounded edges
            this.Region = new Region(path);

            // Draw border
            pevent.Graphics.DrawPath(pen, path);
        }
    }
}
