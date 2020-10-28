using System.Drawing;

namespace AndreyTedeev.Asteroids.Data
{
    public class BaseObject
    {
        protected Point _pos, _dir;
        protected Size _sz;

        public Point Pos { get => _pos; set => _pos = value; }
        public Point Dir { get => _dir; set => _dir = value; }
        public Size Size { get => _sz; set => _sz = value; }

        public BaseObject(Point pos, Point dir, Size size)
        {
            _pos = pos;
            _dir = dir;
            _sz = size;
        }
        public virtual void Draw() {}

        public virtual void Update() {}

    }
}