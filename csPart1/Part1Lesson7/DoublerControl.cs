using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AndreyTedeev.Part1Lesson7
{
    public partial class DoublerControl : UserControl
    {

        Stack<int> undoStack = new Stack<int>();
        int answer = 0;

        public DoublerControl()
        {
            InitializeComponent();
            StartGame();
        }

        public void StartGame()
        {
            lblNumber.Text = "0";
            undoStack.Clear();
            lblCounter.Text = "0";
            answer = new Random().Next(20, 100);
            lblMessage.Text = $"Загадано число : {answer}.";
            btnUndo.Enabled = false;
        }

        private void EndGame(string message)
        {
            MessageBox.Show(message);
            StartGame();
        }

        private void OnMove(int value)
        {
            int oldValue = int.Parse(lblNumber.Text);
            undoStack.Push(oldValue);
            lblNumber.Text = value.ToString();
            lblCounter.Text = undoStack.Count.ToString();
            btnUndo.Enabled = undoStack.Count > 0;
            if (value > answer)
                EndGame("GAME OVER");
            else if (value == answer)
                EndGame($"Ура. Вы победили за {undoStack.Count} ходов.");
        }

        private void Undo()
        {
            int value = undoStack.Pop();
            lblNumber.Text = value.ToString();
            lblCounter.Text = undoStack.Count.ToString();
            btnUndo.Enabled = undoStack.Count > 0;
        }

        private void btnCommand3_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            OnMove(int.Parse(lblNumber.Text) * 2);
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            OnMove(int.Parse(lblNumber.Text) + 1);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

    }
}
