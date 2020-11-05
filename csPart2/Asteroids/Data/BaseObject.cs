using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AndreyTedeev.Asteroids.Data
{

    public interface ICollision
    {
        Rectangle Bounds();
        bool Collision(ICollision other);
    }

    abstract class BaseObject : ICollision
    {
        protected Point _dir;
        protected Rectangle _bounds;
        protected bool _finished = false;

        public abstract void Draw();

        public abstract void Update();

        public Point Dir { get => _dir; set => _dir = value; }

        public bool IsFinished { get => _finished; }

        public BaseObject() 
        { 
        }

        public BaseObject(Point pos, Point dir, Size size)
        {
            _dir = dir;
            _bounds = new Rectangle(pos, size);
        }

        public Rectangle Bounds()
        {
            return _bounds;
        }

        public bool Collision(ICollision other)
        {
            return other.Bounds().IntersectsWith(this.Bounds());
        }

    }

}