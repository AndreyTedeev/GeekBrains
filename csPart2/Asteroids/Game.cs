using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AndreyTedeev.Asteroids.Data;

namespace AndreyTedeev.Asteroids
{
    static class Game
    {
        #region Fields
        static public ulong Counter { get; private set; } = 0;
        static BufferedGraphicsContext _context;
        static public BufferedGraphics Buffer { get; private set; }
        static public Random Random { get; } = new Random();
        static public int Width { get; private set; }
        static public int Height { get; private set; }
        static public Image _background = Image.FromFile("Resources\\back.jpg");
        static Timer _timer = new Timer();
        static int _starCount = 200;
        static int _asteroidCount = 10;
        static List<BaseObject> _data;
        static List<BaseObject> _finished = new List<BaseObject>();
        static Ship _ship;
        #endregion

        static Game()
        {

        }

        static public void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();// Создаём объект - поверхность рисования и связываем его с формой
                                      // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            _timer.Interval = 100;
            _timer.Tick += Timer_Tick;
            _timer.Start();
            Load();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        static public void Load()
        {
            _data = new List<BaseObject>();
            for (int i = 0; i < _starCount; i++)
                _data.Add(new Star());
            for (int i = 0; i < _asteroidCount; i++)
                _data.Add(new Asteroid());
            _ship = new Ship();
            for (int i = 0; i < 5; i++)
                _data.Add(new Bullet());
        }

        static public void Draw()
        {
            Buffer.Graphics.DrawImage(_background, 0, 0);
            foreach (BaseObject obj in _data)
            {
                obj.Draw();
            }
            _ship.Draw();
            Buffer.Render();
        }

        static public void Update()
        {
            foreach (BaseObject obj in _data)
            {
                obj.Update();
                if (obj is Star)
                    continue;
                if (obj is Bullet) {
                    BulletCollision(obj as Bullet);
                }
                if (obj.IsFinished)
                {
                    _finished.Add(obj);
                }
            }
            _ship.Update();
            foreach (BaseObject obj in _finished) {
                _data.Remove(obj);
                if (obj is Asteroid)
                    _data.Add(new Asteroid());
                else if (obj is Bullet)
                    _data.Add(new Bullet());
            }
            _finished.Clear();
        }

        private static void BulletCollision(Bullet bullet) {
            foreach (BaseObject obj in _data) {
                if ((obj is Star) || (bullet == obj))
                    continue;
                else if (bullet.Collision(obj)) {
                    _finished.Add(obj);
                    _finished.Add(bullet);
                    return;
                }
            }
        }
    }

}