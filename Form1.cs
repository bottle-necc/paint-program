using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Ideas:
// - Put the draw functions in their own class where every time the user draws a new object is created.
//   Could make it possible to make the undo and redo buttons work.

namespace mspaint
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;
        private Point previousPoint;        // Remembers the previous mouse position.
        private Color penColor = Color.Black;
        private Color drawColor = Color.Black;
        private int penSize = 4;
        private string selected = "pen";

        // Bitmap that saves the drawing surface.
        private Bitmap drawingSurface = new Bitmap(800, 600);

        public Form1()
        {
            InitializeComponent();
            InitializeDrawingSurface();

        }

        // Clears the drawing surface
        private void InitializeDrawingSurface()
        {
            using (Graphics g = Graphics.FromImage(drawingSurface))
            {
                g.Clear(Color.White);
            }
        }

        // Runs when the user holds down a mouse button.
        private void pbxPaper_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            previousPoint = e.Location;         // Saves the location of the mouse when it began drawing

            if (selected == "square") 
            { 
            
            
            }
        }

        // Runs while the mouse is held, uses the mouse movement to draw.
        private void pbxPaper_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && selected == "pen")
            {
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    Pen pen = new Pen(drawColor, penSize);

                    // Makes the pen a little bit smoother.
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    // Draws a line from the previous location to the current with the pen.
                    g.DrawLine(pen, previousPoint, e.Location);
                }
                previousPoint = e.Location;

                // Updates the picture box to reflect the changes.
                pbxPaper.Invalidate();
            }
        }

        // Runs when the user releases the mouse button.
        private void pbxPaper_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void pbxPaper_Paint(object sender, PaintEventArgs e)
        {
            // Creates the drawing surface on the picture box
            e.Graphics.DrawImage(drawingSurface, Point.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Erases by drawing with the color white.

        private void btnEraser_Click(object sender, EventArgs e)
        {
            selected = "pen";
            drawColor = Color.White;
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            selected = "pen";
            drawColor = penColor;
        }

        private void nudThickness_ValueChanged(object sender, EventArgs e)
        {
            penSize = (int)nudThickness.Value;
        }

        private void btnRGBSelect_Click(object sender, EventArgs e)
        {
            int r = (int)nudRed.Value;
            int g = (int)nudGreen.Value;
            int b = (int)nudBlue.Value;

            penColor = Color.FromArgb(r, g, b);
            drawColor = penColor;
        }
    }
}
