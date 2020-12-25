using System;
using System.Numerics;
using System.Threading;
using Windows.UI;
using Windows.UI.Composition;

namespace AndreyTedeev.AsteroidsUWP
{
    public class Game
    {
        #region Fields
        public Random Random { get; } = new Random();

        //static public Image _background = Image.FromFile("Resources\\back.jpg");

        ContainerVisual _root;
        #endregion

        public Game()
        {
            Timer _timer = new Timer(TimerCallback, new object(), 100, 100);
        }

        private void TimerCallback(object state)
        {
            foreach (var child in _root.Children)
            {
                Vector3 v3 = child.Offset;
                v3.X -= Random.Next(0, 10);
                if (v3.X < 0)
                    v3.X = _root.Size.X;
                child.Offset = v3;
            }
            //Update();
            //Draw();
        }

        private ShapeVisual RandomStar()
        {
            Compositor compositor = _root.Compositor;
            var ellipse = compositor.CreateEllipseGeometry();
            ellipse.Center = new Vector2(1.5f, 1.5f);
            ellipse.Radius = new Vector2(1.5f, 1.5f);
            CompositionSpriteShape sprite = compositor.CreateSpriteShape(ellipse);
            Color color = Color.FromArgb(
               255,
               (byte)Random.Next(0, byte.MaxValue),
               (byte)Random.Next(0, byte.MaxValue),
               (byte)Random.Next(0, byte.MaxValue)
            );
            sprite.FillBrush = compositor.CreateColorBrush(color);
            ShapeVisual visual = compositor.CreateShapeVisual();
            visual.Size = new Vector2(3, 3);
            visual.Shapes.Add(sprite);
            return visual;
        }

        public void SizeChanged(Vector2 size)
        {
            _root.Size = size;
            foreach (var child in _root.Children)
            {
                child.Offset = new Vector3(
                    Random.Next(0, (int)_root.Size.X),
                    Random.Next(0, (int)_root.Size.Y),
                    0);
            }
        }

        public void Load(ContainerVisual container)
        {
            _root = container;
            for (int i = 0; i < 100; i++)
            {
                _root.Children.InsertAtTop(RandomStar());
            }

        }


    }
}
