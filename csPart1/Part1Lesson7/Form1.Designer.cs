namespace AndreyTedeev.Part1Lesson7
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
            this.menuItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.miDoubler = new System.Windows.Forms.ToolStripMenuItem();
            this.miGuesser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 7;
            // 
            // menuItemMenu
            // 
            this.menuItemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDoubler,
            this.miGuesser});
            this.menuItemMenu.Name = "menuItemMenu";
            this.menuItemMenu.Size = new System.Drawing.Size(57, 24);
            this.menuItemMenu.Text = "Игра";
            // 
            // miDoubler
            // 
            this.miDoubler.Name = "miDoubler";
            this.miDoubler.Size = new System.Drawing.Size(165, 26);
            this.miDoubler.Text = "Удвоитель";
            // 
            // miGuesser
            // 
            this.miGuesser.Name = "miGuesser";
            this.miGuesser.Size = new System.Drawing.Size(165, 26);
            this.miGuesser.Text = "Угадайка";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "ДЗ 7";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemMenu;
        private System.Windows.Forms.ToolStripMenuItem miDoubler;
        private System.Windows.Forms.ToolStripMenuItem miGuesser;
    }
}

