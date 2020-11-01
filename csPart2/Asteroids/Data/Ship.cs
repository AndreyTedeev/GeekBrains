using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreyTedeev.Asteroids.Data
{
    class Ship : ImageObject
    {
        int _speed = 5;

        public Ship() : base()
        {
            _dir = new Point(0, 0);
            _bounds = new Rectangle(new Point(0, Game.Height / 2), Image.Size);
        }

        private static Image _image = null;

        protected override Image Image => _image ??= LoadImageAndResize("Resources\\ship.png", 64, 64);

        public override void Update()
        {
            _bounds.X += _dir.X;
            _bounds.Y += _dir.Y;
            if ((_bounds.X < 0) || (_bounds.X > Game.Width - _image.Size.Width)) 
                    _dir.X = 0;
            if ((_bounds.Y < 0) || (_bounds.Y > Game.Height - _image.Size.Height))
                    _dir.Y = 0;
        }

        public void MoveUp() {
            _dir += new Size(0, -_speed);
        }

        public void MoveDown()
        {
            _dir += new Size(0, _speed);
        }

        public void MoveLeft()
        {
            _dir += new Size(-_speed, 0);
        }

        public void MoveRight()
        {
            _dir += new Size(_speed, 0);
        }


    }
}
