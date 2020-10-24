using System.Drawing;

namespace AndreyTedeev.Asteroids.Data    
{
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(
                Brushes.White, 
                new Rectangle(Pos, Size));
        }

        public override void Update()
        {
            _pos.X += _dir.X;
            if (_pos.X < 0) _pos.X = Game.Width;
        }
    }
}