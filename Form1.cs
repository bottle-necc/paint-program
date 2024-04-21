using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
        private Pencil pencil;
        private Square square;
        private Ellipse ellipse;
        private Line line;
        private HistoryManager historyManager = new HistoryManager();

        // Bitmap that saves the drawing surface
        private Bitmap drawingSurface = new Bitmap(659, 360);

        public Form1()
        {
            InitializeComponent();
            InitializeDrawingSurface();
            historyManager.FirstState(new Bitmap(drawingSurface));
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

            if (selected == "pen")
            {
                pencil = new Pencil(Graphics.FromImage(drawingSurface), drawColor, penSize);
            }
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
                line = new Line(Graphics.FromImage(drawingSurface), penColor, penSize);
            }
        }

        // Runs while the mouse is held, uses the mouse movement to draw
        private void pbxPaper_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && selected == "pen")
            {
                pencil.Draw(previousPoint, e.Location);
                previousPoint = e.Location;

                // Updates the picture box to reflect the changes
                pbxPaper.Invalidate();
            }
        }

        // Runs when the user releases the mouse button
        private void pbxPaper_MouseUp(object sender, MouseEventArgs e)
        {            
            if (selected == "square")
            {
                square.Draw(previousPoint, e.Location);
            }
            if (selected == "ellipse")
            {
                ellipse.Draw(previousPoint, e.Location);
            }
            if (selected == "line")
            {
                line.Draw(previousPoint, e.Location);
            }
            if (isDrawing)
            {
                isDrawing = false;
                historyManager.AddState(new Bitmap(drawingSurface));
                pbxPaper.Invalidate();
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

        private void btnUndo_Click(object sender, EventArgs e)
        {
            drawingSurface = historyManager.Undo(drawingSurface);
            pbxPaper.Invalidate();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            drawingSurface = historyManager.Redo(drawingSurface);
            pbxPaper.Invalidate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Filter = "PNG files (*.png)|*.png";
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                drawingSurface.Save(saveFD.FileName, ImageFormat.Png);
            }
        }
    }

    // Contains the common fields and functions for all drawing classes
    public class Draw
    {
        protected Graphics _g;
        protected Color _colour;
        protected int _size;

        public Graphics G { get { return _g; } set { _g = value; } }
        public Color Colour { get { return _colour; } set { _colour = value; } }
        public int Size { get { return _size; } set { _size = value; } }

        public Draw(Graphics g, Color colour, int size)
        {
            G = g;
            Colour = colour;
            Size = size;
        }
    }

    public class Pencil : Draw
    {
        public Pencil(Graphics g, Color colour, int size) : base(g, colour, size)
        {

        }

        public void Draw(Point previousPoint, Point nextPoint)
        {
            Pen pen = new Pen(_colour, _size);

            // Makes the pen a little bit smoother
            _g.SmoothingMode = SmoothingMode.HighQuality;

            // Draws a line from the previous location to the current with the pen
            _g.DrawLine(pen, previousPoint, nextPoint);
        }
    }

    public class Square : Draw
    {
        public Square(Graphics g, Color colour, int size) : base(g, colour, size) 
        { 
                
        }

        // Draws the shape
        public void Draw(Point previousPoint, Point nextPoint)
        {
            int oldX = previousPoint.X;
            int oldY = previousPoint.Y;
            int newX = nextPoint.X;
            int newY = nextPoint.Y;

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

    public class Ellipse : Draw
    {
        public Ellipse(Graphics g, Color colour, int size) : base(g, colour, size)
        {

        }

        // Draws the shape
        public void Draw(Point previousPoint, Point nextPoint)
        {
            int oldX = previousPoint.X;
            int oldY = previousPoint.Y;
            int newX = nextPoint.X;
            int newY = nextPoint.Y;

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

    public class Line : Draw
    {
        public Line(Graphics g, Color colour, int size) : base(g, colour, size)
        {

        }

        // Draws the shape
        public void Draw(Point previousPoint, Point nextPoint) 
        { 
            _g.DrawLine(new Pen(Colour, _size), previousPoint, nextPoint);
        }
    }

    // Uses a LIFO structure to store the relevant changes in runtime
    public class HistoryManager
    {
        private Stack<Bitmap> undoStack = new Stack<Bitmap>();
        private Stack<Bitmap> redoStack = new Stack<Bitmap>();
        private Bitmap startState;

        public void FirstState(Bitmap status)
        {
            startState = status.Clone() as Bitmap;
        }

        // Adds the current bitmap status to the undo stack and clears the redo stack
        public void AddState(Bitmap status)
        {
            undoStack.Push(status); 
            redoStack.Clear();
        }

        public Bitmap Undo(Bitmap currentStatus)
        {
            // If there are no previous versions, return the current one
            if (undoStack.Count == 0)
            {
                undoStack.Push(startState.Clone() as Bitmap);
                return startState.Clone() as Bitmap;
            }

            // Takes the latest version from the stack
            Bitmap previousStatus = undoStack.Pop();

            // Adds the current version into the redo stack
            redoStack.Push(currentStatus.Clone() as Bitmap);

            return previousStatus;
        }

        public Bitmap Redo(Bitmap currentStatus)
        {
            // If there are no states to redo, return the current status
            if (redoStack.Count == 0)
            {
                return currentStatus;
            }

            // Takes the latest version from the stack
            Bitmap nextStatus = redoStack.Pop();

            // Adds the current version into the undo stack
            undoStack.Push(currentStatus.Clone() as Bitmap);

            return nextStatus;
        }
    }
}
