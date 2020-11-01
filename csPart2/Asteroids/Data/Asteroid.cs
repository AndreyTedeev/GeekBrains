using System.Drawing;

namespace AndreyTedeev.Asteroids.Data
{
    class Asteroid : ImageObject
    {

        public Asteroid() : base()
        {
            _dir = new Point(-(Game.Random.Next(15, 30)), 0);
            _bounds = new Rectangle(
                new Point(
                    Game.Width,
                    Game.Random.Next(1, Game.Height)),
                Image.Size
            );
        }

        private static Image _image = null;

        protected override Image Image => _image ??= LoadImageAndResize("Resources\\asteroid.png", 64 ,64);

        public override void Update()
        {
            _bounds.X += _dir.X;
            if (_bounds.X < -Image.Size.Width) _finished = true;
        }

    }
}
