using System;
using System.Drawing;

namespace AndreyTedeev.Asteroids.Data
{
    class Bullet : BaseObject
    {
        private Color _color;

        public Bullet(Point pos, Point dir, Size size, Color color) : base(pos, dir, size)
        {
            _color = color;
        }

        public Bullet() : base()
        {
            _bounds = new Rectangle(
                new Point(0, Game.Random.Next(1, Game.Height)),
                new Size(12, 4)
            );
            _dir = new Point(15, 0);
            _color = Color.Red;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(new SolidBrush(_color), _bounds);
        }

        public override void Update()
        {
            _bounds.X += _dir.X;
            if (_bounds.X > Game.Width) _finished = true;
        }


    }
}