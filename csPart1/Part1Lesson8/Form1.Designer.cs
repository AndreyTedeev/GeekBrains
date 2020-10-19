namespace AndreyTedeev.Part1Lesson8
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbAnswer = new System.Windows.Forms.CheckBox();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbQuestion = new System.Windows.Forms.TextBox();
            this.pnEditor = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            this.pnEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPlay,
            this.miFile,
            this.miAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miPlay
            // 
            this.miPlay.Name = "miPlay";
            this.miPlay.Size = new System.Drawing.Size(57, 24);
            this.miPlay.Text = "Игра";
            this.miPlay.Click += new System.EventHandler(this.miPlay_Click);
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miOpen,
            this.miSave,
            this.toolStripSeparator1,
            this.miConvert,
            this.toolStripSeparator2,
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(86, 24);
            this.miFile.Text = "Редактор";
            // 
            // miNew
            // 
            this.miNew.Name = "miNew";
            this.miNew.Size = new System.Drawing.Size(207, 26);
            this.miNew.Text = "Новый";
            this.miNew.Click += new System.EventHandler(this.miNew_Click);
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.Size = new System.Drawing.Size(207, 26);
            this.miOpen.Text = "Открыть";
            this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Size = new System.Drawing.Size(207, 26);
            this.miSave.Text = "Сохранить";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            // 
            // miConvert
            // 
            this.miConvert.Name = "miConvert";
            this.miConvert.Size = new System.Drawing.Size(207, 26);
            this.miConvert.Text = "Конвертировать";
            this.miConvert.Click += new System.EventHandler(this.miConvert_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(204, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(207, 26);
            this.miExit.Text = "Выйти";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(118, 24);
            this.miAbout.Text = "О программе";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbAnswer);
            this.panel1.Controls.Add(this.nudNumber);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 342);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 80);
            this.panel1.TabIndex = 1;
            // 
            // cbAnswer
            // 
            this.cbAnswer.AutoSize = true;
            this.cbAnswer.Location = new System.Drawing.Point(214, 26);
            this.cbAnswer.Name = "cbAnswer";
            this.cbAnswer.Size = new System.Drawing.Size(105, 24);
            this.cbAnswer.TabIndex = 4;
            this.cbAnswer.Text = "True / False";
            this.cbAnswer.UseVisualStyleBackColor = true;
            // 
            // nudNumber
            // 
            this.nudNumber.Location = new System.Drawing.Point(125, 24);
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Size = new System.Drawing.Size(72, 27);
            this.nudNumber.TabIndex = 3;
            this.nudNumber.ValueChanged += new System.EventHandler(this.nudNumber_ValueChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(339, 21);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(94, 29);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(453, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 29);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbQuestion
            // 
            this.tbQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbQuestion.Location = new System.Drawing.Point(0, 0);
            this.tbQuestion.Multiline = true;
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.Size = new System.Drawing.Size(800, 342);
            this.tbQuestion.TabIndex = 2;
            // 
            // pnEditor
            // 
            this.pnEditor.Controls.Add(this.tbQuestion);
            this.pnEditor.Controls.Add(this.panel1);
            this.pnEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnEditor.Location = new System.Drawing.Point(0, 28);
            this.pnEditor.Name = "pnEditor";
            this.pnEditor.Size = new System.Drawing.Size(800, 422);
            this.pnEditor.TabIndex = 3;
            this.pnEditor.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnEditor);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "To Trust, Or Not To Trust";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            this.pnEditor.ResumeLayout(false);
            this.pnEditor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbQuestion;
        private System.Windows.Forms.CheckBox cbAnswer;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.ToolStripMenuItem miConvert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem miPlay;
        private System.Windows.Forms.Panel pnEditor;
    }
}

