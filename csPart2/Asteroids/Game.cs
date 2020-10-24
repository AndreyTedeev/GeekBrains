using System;
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
        //static int _speed
        static BaseObject[] _data;
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

        private static Star RandomStar() {
            Point p = new Point(Random.Next(1, Width), Random.Next(1, Height));
            return new Star(p, new Point(-(Random.Next(5,10)), 0), new Size(3, 3));
        }        

        static public void Load()
        {
            _data = new BaseObject[100];
            for (int i = 0; i < _data.Length; i++)
                _data[i] = RandomStar();
        }

        static public void Draw()
        {
            Buffer.Graphics.DrawImage(_background, 0, 0);
            foreach (BaseObject obj in _data)
                 obj.Draw();
            Buffer.Render();
        }

        static public void Update()
        {
            foreach (BaseObject obj in _data)
                obj.Update();
        }
    }
    
}