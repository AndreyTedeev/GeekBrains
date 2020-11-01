using System;
using System.Collections.Generic;
using System.Text;

namespace AndreyTedeev.Asteroids.Data
{
    class GameException : Exception
    {
        public GameException(string message) : base(message)
        {
        }
    }
}
