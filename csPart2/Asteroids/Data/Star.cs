using System;
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

        public Star() : base()
        {
            _bounds = new Rectangle(
                new Point(
                    Game.Random.Next(1, Game.Width),
                    Game.Random.Next(1, Game.Height)),
                new Size(
                    Game.Random.Next(3, 5),
                    Game.Random.Next(2, 4))
            );
            _dir = new Point(-(Game.Random.Next(5, 10)), 0);
            _color = Color.FromArgb(
                Game.Random.Next(0, byte.MaxValue),
                Game.Random.Next(0, byte.MaxValue),
                Game.Random.Next(0, byte.MaxValue)
            );
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(new SolidBrush(_color), _bounds);
        }

        public override void Update()
        {
            _bounds.X += _dir.X;
            if (_bounds.X < 0) _bounds.X = Game.Width;
        }
    }
}