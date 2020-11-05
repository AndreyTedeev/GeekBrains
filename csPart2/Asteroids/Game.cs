using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
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
        static int _width = 0;
        static public int Width
        {
            get { return _width; }
            private set
            {
                if ((value > 800) || (value < 0))
                    throw new GameException("Wrong Width");
                _width = value;
            }
        }
        static int _height = 0;
        static public int Height
        {
            get { return _height; }
            private set
            {
                if ((value > 600) || (value < 0))
                    throw new GameException("Wrong Height");
                _height = value;
            }
        }
        static public Image _background = Image.FromFile("Resources\\back.jpg");
        static Timer _timer = new Timer();
        static int _starCount = 200;
        static int _asteroidCount = 10;
        static List<BaseObject> _data;
        static List<BaseObject> _finished = new List<BaseObject>();
        static Ship _ship;
        static int _score = 0;
        static int _lives = 5;
        static Form _form;
        #endregion

        static Game()
        {

        }

        static public void Init(Form form)
        {
            _form = form;
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
            form.KeyDown += Form_KeyDown;
            _timer.Start();
            Load();
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                _ship.MoveUp();
            if (e.KeyCode == Keys.Down)
                _ship.MoveDown();
            if (e.KeyCode == Keys.Left)
                _ship.MoveLeft();
            if (e.KeyCode == Keys.Right)
                _ship.MoveRight();
            if (e.KeyCode == Keys.Space)
                _data.Add(_ship.Fire());
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
            if (_lives == 0)
                GameOver();
        }

        static public void Load()
        {
            _data = new List<BaseObject>();
            for (int i = 0; i < _starCount; i++)
                _data.Add(new Star());
            for (int i = 0; i < _asteroidCount; i++)
                _data.Add(new Asteroid());
            _data.Add(new MedKit());
            _ship = new Ship();
        }

        static public void Draw()
        {
            Buffer.Graphics.DrawImage(_background, 0, 0);
            Buffer.Graphics.DrawString(
                $"SCORE: {_score:####0}    LIVES: {_lives:####0}", SystemFonts.DefaultFont, Brushes.White, new Point(0, 0));
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
                if (obj is Bullet)
                {
                    BulletCollision(obj as Bullet);
                }
                if (obj.IsFinished)
                {
                    _finished.Add(obj);
                }
            }
            _ship.Update();
            ShipCollision(_ship);
            
            foreach (BaseObject obj in _finished)
            {
                _data.Remove(obj);
                if (obj is Asteroid)
                    _data.Add(new Asteroid());
                if (obj is MedKit)
                    _data.Add(new MedKit());
            }
            _finished.Clear();
            
        }

        private static void GameOver()
        {
            _timer.Stop();
            MessageBox.Show("GAME OVER");
            _form.Close();
            
        }

        private static void BulletCollision(Bullet bullet)
        {
            foreach (BaseObject obj in _data)
            {
                if ((obj is Star) || (bullet == obj))
                    continue;
                else if (bullet.Collision(obj))
                {
                    _score++;
                    _finished.Add(obj);
                    _finished.Add(bullet);
                    return;
                }
            }
        }

        private static void ShipCollision(Ship ship) {
            foreach (BaseObject obj in _data)
            {
                if (obj is Star)
                    continue;
                else if (ship.Collision(obj))
                {
                    if (obj is Asteroid)
                        _lives--;
                    else if (obj is MedKit)
                        _lives++;
                    _finished.Add(obj);
                }
            }
        }
    }

}