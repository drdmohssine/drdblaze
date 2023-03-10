
using SkiaSharp;
using System.ComponentModel.DataAnnotations;

namespace drdblaze.Shapes
{

    public class Rectangle
    {
        [Key]
        public int RectangleID { get; set; }

        private float _x;
        private float _y;
        private int _width;
        private int _height;

        public float X
        {
            get { return _x; }
            set
            {
                _x = value;
                UpdatePoints();
            }
        }

        public float Y
        {
            get { return _y; }
            set
            {
                _y = value;
                UpdatePoints();
            }
        }

        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                UpdatePoints();
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;
                UpdatePoints();
            }
        }

        public bool Selected { get; set; }
        public string Fill { get; set; }
        public string Text { get; set; }

        public Point TL { get; } = new Point();
        public Point TM { get; } = new Point();
        public Point TR { get; } = new Point();
        public Point ML { get; } = new Point();
        public Point MC { get; } = new Point();
        public Point MR { get; } = new Point();
        public Point BL { get; } = new Point();
        public Point BM { get; } = new Point();
        public Point BR { get; } = new Point();

        public Rectangle(float x, float y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Selected = false;
            // Initialize the points with their positions
            UpdatePoints();
        }

        private void UpdatePoints()
        {
            TL.Position = new SKPoint(X, Y);
            TM.Position = new SKPoint(X + Width / 2, Y);
            TR.Position = new SKPoint(X + Width, Y);
            ML.Position = new SKPoint(X, Y + Height / 2);
            MC.Position = new SKPoint(X + Width / 2, Y + Height / 2);
            MR.Position = new SKPoint(X + Width, Y + Height / 2);
            BL.Position = new SKPoint(X, Y + Height);
            BM.Position = new SKPoint(X + Width / 2, Y + Height);
            BR.Position = new SKPoint(X + Width, Y + Height);
        }
    }

    public class Point
    {
        private SKPoint _position;
        public SKPoint Position
        {
            get { return _position; }
            set
            {
                _position = value;
              
            }
        }
        public List<Line> Lines { get; set; } = new List<Line>();

    }


    public class RectPoints
    {
        public Point TL { get; set; } = new Point(); // Top-left corner
        public Point TM { get; set; } = new Point(); // Top-middle point
        public Point TR { get; set; } = new Point(); // Top-right corner
        public Point ML { get; set; } = new Point(); // Middle-left point
        public Point MC { get; set; } = new Point(); // Center point
        public Point MR { get; set; } = new Point(); // Middle-right point
        public Point BL { get; set; } = new Point(); // Bottom-left corner
        public Point BM { get; set; } = new Point(); // Bottom-middle point
        public Point BR { get; set; } = new Point(); // Bottom-right corner
    }

    public class Line
    {
        public Line(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;

        }
        public Point Point1;
        public Point Point2;
        public bool Selected { get; set; } = false;
        public string Stroke { get; set; }
        public int StrokeWidth { get; set; }
    }



}
