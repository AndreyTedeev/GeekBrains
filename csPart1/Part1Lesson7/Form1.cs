using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndreyTedeev.Part1Lesson7
{
    public partial class Form1 : Form
    {

        DoublerControl doubler = new DoublerControl();
        GuesserControl guesser = new GuesserControl();

        public Form1()
        {
            InitializeComponent();
            miDoubler.Click += MiDoubler_Click;
            miGuesser.Click += MiGuesser_Click;
        }

        private void MiGuesser_Click(object sender, EventArgs e)
        {
            Controls.Remove(doubler);
            guesser.StartGame();
            Controls.Add(guesser);
        }

        private void MiDoubler_Click(object sender, EventArgs e)
        {
            Controls.Remove(guesser);
            doubler.StartGame();
            Controls.Add(doubler);
        }

        
    }
}
