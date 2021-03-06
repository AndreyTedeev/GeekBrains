﻿using System.Windows.Forms;

namespace AndreyTedeev.Asteroids
{
    class Program
    {
        static void Main()
        {
            Form form = new Form
            {
                Width = 800,
                Height = 600
            };
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
