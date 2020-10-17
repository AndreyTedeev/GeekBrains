using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AndreyTedeev.Part1Lesson7
{
    public partial class GuesserControl : UserControl
    {
        int Answer = 0;
        int MaxCount = 10;
        int TryCount = 0;

        public GuesserControl()
        {
            InitializeComponent();
            StartGame();
        }

        public void StartGame() 
        {
            Answer = new Random().Next(1, 100);
            TryCount = 0;
            tbInput.Focus();
            label1.Text = $"Загадано число от 1 до 100. Угадайте с {MaxCount} попыток";
        }

        void EndGame(string message) 
        {
            MessageBox.Show(message);
            StartGame();
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int value;
                if (!int.TryParse(tbInput.Text, out value))
                {
                    MessageBox.Show("Ожидается число. Попробуйте еще раз.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                };
                TryCount++;
                if (value == Answer)
                    EndGame($"Ура вы победили за {TryCount} попыток.");
                else if (TryCount == MaxCount) 
                    EndGame("GAME OVER");
                else if (value < Answer)
                    label1.Text = $"Число слишком МАЛЕНЬКОЕ. Осталось {MaxCount - TryCount} попыток";
                else if (value > Answer)
                    label1.Text = $"Число слишком БОЛЬШОЕ. Осталось {MaxCount - TryCount} попыток";
                tbInput.Text = "";
            }
        }
    }
}
