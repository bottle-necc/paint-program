using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
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
        private Point previousPoint;        // Remembers the previous mouse position
        private Color penColor = Color.Black;
        private Color drawColor = Color.Black;
        private int penSize = 4;
        private string selected = "pen";
        private Draw draw = new Draw();
        private Square square;
        private Ellipse ellipse;
        private Line line;

        // Bitmap that saves the drawing surface
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
                square = new Square(Graphics.FromImage(drawingSurface), penColor, penSize);
            }
            if (selected == "ellipse")
            {
                ellipse = new Ellipse(Graphics.FromImage(drawingSurface), penColor, penSize);
            }
            if (selected == "line")
            {

            }
        }

        // Runs while the mouse is held, uses the mouse movement to draw
        private void pbxPaper_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && selected == "pen")
            {
                draw.Pen(Graphics.FromImage(drawingSurface), drawColor, penSize, previousPoint, e.Location);
                previousPoint = e.Location;

                // Updates the picture box to reflect the changes
                pbxPaper.Invalidate();
            }
        }

        // Runs when the user releases the mouse button
        private void pbxPaper_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            if (selected == "square")
            {
                square.GetPoints(previousPoint, e.Location);
                square.Draw();
                pbxPaper.Invalidate();
            }
            if (selected == "ellipse")
            {
                ellipse.GetPoints(previousPoint, e.Location);
                ellipse.Draw();
                pbxPaper.Invalidate();
            }
            if (selected == "line")
            {

            }
        }

        private void pbxPaper_Paint(object sender, PaintEventArgs e)
        {
            // Creates the drawing surface on the picture box
            e.Graphics.DrawImage(drawingSurface, Point.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Erases by drawing with the color white
        private void btnEraser_Click(object sender, EventArgs e)
        {
            drawColor = Color.White;
            selected = "pen";
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            drawColor = penColor;
            selected = "pen";
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

        private void btnSquare_Click(object sender, EventArgs e)
        {
            selected = "square";
        }

        private void btnEllips_Click(object sender, EventArgs e)
        {
            selected = "ellipse";
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            selected = "line";
        }
    }

    public class Draw
    {
        public void Pen(Graphics g, Color color, int size, Point previousPoint, Point nextPoint)
        {
            Pen pen = new Pen(color, size);

            // Makes the pen a little bit smoother
            g.SmoothingMode = SmoothingMode.HighQuality;

            // Draws a line from the previous location to the current with the pen
            g.DrawLine(pen, previousPoint, nextPoint);
        }
    }

    // Class containing the common fields and functions of the Square and Ellipse class
    public class Geometry
    {
        protected Graphics _g;
        protected Color _colour;
        protected int _size;
        protected Point _previousPoint;
        protected Point _nextPoint;

        public Graphics G { get { return _g; } set { _g = value; } }
        public Color Colour { get { return _colour; } set { _colour = value; } }
        public int Size { get { return _size; } set { _size = value; } }
        public Point PreviousPoint { get { return _previousPoint; } set { _previousPoint = value; } }
        public Point NextPoint { get { return _nextPoint; } set { _nextPoint = value; } }

        public Geometry(Graphics g, Color colour, int size) 
        {
            G = g;
            Colour = colour;
            Size = size;
        }
    }

    public class Square : Geometry
    {
        public Square(Graphics g, Color colour, int size) : base(g, colour, size) 
        { 
                
        }

        // Gets the relevant positions to draw the figure
        public void GetPoints(Point previousPoint, Point nextPoint)
        {
            PreviousPoint = previousPoint;
            NextPoint = nextPoint;
        }

        // Draws the shape
        public void Draw()
        {
            int oldX = _previousPoint.X;
            int oldY = _previousPoint.Y;
            int newX = _nextPoint.X;
            int newY = _nextPoint.Y;

            // Draws if the mouse moves SE
            if (newX - oldX > 0 && newY - oldY > 0)
            {
                _g.DrawRectangle(new Pen(_colour, _size), oldX, oldY, newX - oldX, newY - oldY);
            }

            // Draws if the mouse moves NW
            else if (newX - oldX < 0 && newY - oldY < 0)
            {
                _g.DrawRectangle(new Pen(_colour, _size), newX, newY, oldX - newX, oldY - newY);
            }

            // Draws if the mouse moves NE
            else if (newX - oldX > 0 &&  newY - oldY < 0)
            {
                _g.DrawRectangle(new Pen(_colour, _size), oldX, newY, newX - oldX, oldY - newY);
            }

            // Draws if the mouse moves SW
            else if (newX - oldX < 0 && newY - oldY > 0)
            {
                _g.DrawRectangle(new Pen(_colour, _size), newX, oldY, oldX - newX, newY - oldY);
            }
        }
    }

    public class Ellipse : Geometry
    {
        public Ellipse(Graphics g, Color colour, int size) : base(g, colour, size)
        {

        }

        // Gets the relevant positions to draw the figure
        public void GetPoints(Point previousPoint, Point nextPoint)
        {
            PreviousPoint = previousPoint;
            NextPoint = nextPoint;
        }

        // Draws the shape
        public void Draw()
        {
            int oldX = _previousPoint.X;
            int oldY = _previousPoint.Y;
            int newX = _nextPoint.X;
            int newY = _nextPoint.Y;

            // Draws if the mouse moves SE
            if (newX - oldX > 0 && newY - oldY > 0)
            {
                _g.DrawEllipse(new Pen(_colour, _size), oldX, oldY, newX - oldX, newY - oldY);
            }

            // Draws if the mouse moves NW
            else if (newX - oldX < 0 && newY - oldY < 0)
            {
                _g.DrawEllipse(new Pen(_colour, _size), newX, newY, oldX - newX, oldY - newY);
            }

            // Draws if the mouse moves NE
            else if (newX - oldX > 0 && newY - oldY < 0)
            {
                _g.DrawEllipse(new Pen(_colour, _size), oldX, newY, newX - oldX, oldY - newY);
            }

            // Draws if the mouse moves SW
            else if (newX - oldX < 0 && newY - oldY > 0)
            {
                _g.DrawEllipse(new Pen(_colour, _size), newX, oldY, oldX - newX, newY - oldY);
            }
        }
    }

    public class Line
    {

        private Color _colour;
        private int _size;
        private Graphics _g;



        /*public void Draw()
        {
            g.DrawLine(new Pen())
        }*/
    }
}
