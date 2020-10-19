using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndreyTedeev.Part1Lesson8
{
    public partial class Form1 : Form
    {
        TrueFalse database;

        public Form1()
        {
            InitializeComponent();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                InitDatabase();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                ShowQuestion(0);
            };
            pnEditor.Visible = true;
        }

        private void InitDatabase()
        {
            database.Add("123", true);
            database.Save();
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "xml files (*.xml)|*.xml"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                database.Load();
                if (database.Count == 0)
                    InitDatabase();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
                ShowQuestion(0);
            }
            pnEditor.Visible = true;
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database.Save();
                pnEditor.Visible = false;
            }
            else
                MessageBox.Show("База данных не создана");
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            ShowQuestion((int)nudNumber.Value - 1);
        }

        private void ShowQuestion(int index)
        {
            tbQuestion.Text = database[index].Text;
            cbAnswer.Checked = database[index].Answer;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            database.Add((database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null)
            {
                MessageBox.Show("База данных пуста", "Сообщение");
                return;
            }
            if (MessageBox.Show(
                "Вы уверены, что хотите удалить вопрос?",
                "Внимание",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            database.Remove((int)nudNumber.Value);
            nudNumber.Maximum--;
            if (nudNumber.Value > 1)
                nudNumber.Value = nudNumber.Value;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null)
            {
                MessageBox.Show("База данных пуста", "Сообщение");
                return;
            }
            database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
            database[(int)nudNumber.Value - 1].Answer = cbAnswer.Checked;
        }

        private void miConvert_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "txt files (*.txt)|*.txt"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    InitialDirectory = Application.StartupPath,
                    Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    database = new TrueFalse(sfd.FileName);
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        string[] fields;
                        while (!sr.EndOfStream)
                        {
                            try
                            {
                                fields = sr.ReadLine().Split('|');
                                database.Add(fields[0], bool.Parse(fields[1]));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"ОШИБКА! {ex.Message}");
                            }
                        }
                    }
                    database.Save();
                    nudNumber.Minimum = 1;
                    nudNumber.Maximum = database.Count;
                    nudNumber.Value = 1;
                };
            }
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void miPlay_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Выберите файл с вопросами",
                InitialDirectory = Application.StartupPath,
                Filter = "xml files (*.xml)|*.xml"
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            database = new TrueFalse(ofd.FileName);
            database.Load();
            if (database.Count < 5)
            {
                MessageBox.Show("В этом файле меньше пяти вопросов.");
                return;
            }
            Random random = new Random();
            int count = 5, total = 0, randomQuestion;
            for (int i = 0; i < count; i++)
            {
                randomQuestion = random.Next(0, database.Count - 1);
                total += AskQuestion(i + 1, database[randomQuestion]);
            }
            MessageBox.Show($"Вы набрали {total} баллов.");
        }

        private int AskQuestion(int number, Question question)
        {
            DialogResult result = MessageBox.Show(
                question.Text,
                $"Вопрос {number} из 5",
                MessageBoxButtons.YesNo);
            if ((result == DialogResult.Yes) && (question.Answer))
                return 1;
            else if ((result == DialogResult.No) && (!question.Answer))
                return 1;
            else 
                return 0;
        }
    }
}
