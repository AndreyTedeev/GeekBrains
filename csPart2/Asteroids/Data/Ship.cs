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
        int _speed = 2;

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
            if (_bounds.X < 0) {
                _dir.X = 0;
                _bounds.X = 0;
            }
            if (_bounds.X > Game.Width - _image.Size.Width)
            {
                _dir.X = 0;
                _bounds.X = Game.Width - _image.Size.Width;
            }
            if (_bounds.Y < 0) {
                _dir.Y = 0;
                _bounds.Y = 0;
            }
            if (_bounds.Y > Game.Height - _image.Size.Height)
            {
                _dir.Y = 0;
                _bounds.Y = Game.Height - _image.Size.Height;
            }
        }

        public void MoveUp() {
            _dir.Y -= _speed;
        }

        public void MoveDown()
        {
            _dir.Y += _speed;
        }

        public void MoveLeft()
        {
            _dir.X -= _speed;
        }

        public void MoveRight()
        {
            _dir.X += _speed;
        }

        public Bullet Fire() {
            Point pos = new Point(_bounds.X + Image.Size.Width, _bounds.Y + Image.Size.Height / 2);
            return new Bullet(pos);
        }
    }
}
