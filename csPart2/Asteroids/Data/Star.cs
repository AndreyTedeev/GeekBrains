using System.Drawing;

namespace AndreyTedeev.Asteroids.Data    
{
    class Star : BaseObject
    {
        private Color _color;

        public Star(Point pos, Point dir, Size size, Color color) : base(pos, dir, size)
        {
            _color = color;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(
                new SolidBrush(_color), 
                new Rectangle(Pos, Size));
        }

        public override void Update()
        {
            _pos.X += _dir.X;
            if (_pos.X < 0) _pos.X = Game.Width;
        }
    }
}