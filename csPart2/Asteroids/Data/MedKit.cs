using System.Drawing;

namespace AndreyTedeev.Asteroids.Data
{
    class MedKit : ImageObject
    {

        public MedKit() : base()
        {
            _dir = new Point(-(Game.Random.Next(10, 20)), 0);
            _bounds = new Rectangle(
                new Point(
                    Game.Width,
                    Game.Random.Next(1, Game.Height)),
                Image.Size
            );
        }

        private static Image _image = null;

        protected override Image Image => _image ??= LoadImageAndResize("Resources\\medkit.png", 32 ,32);

        public override void Update()
        {
            _bounds.X += _dir.X;
            if (_bounds.X < -Image.Size.Width) _finished = true;
        }

    }
}
