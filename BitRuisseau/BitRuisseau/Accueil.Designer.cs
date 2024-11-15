namespace BitRuisseau
{
    partial class Accueil
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
            panel1 = new Panel();
            button1 = new Button();
            LocalFileView = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            SearchBar = new TextBox();
            button4 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LocalFileView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(301, 679);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(41, 35);
            button1.Name = "button1";
            button1.Size = new Size(221, 52);
            button1.TabIndex = 0;
            button1.Text = "Accueil";
            button1.UseVisualStyleBackColor = true;
            // 
            // LocalFileView
            // 
            LocalFileView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LocalFileView.Location = new Point(361, 188);
            LocalFileView.Name = "LocalFileView";
            LocalFileView.Size = new Size(861, 454);
            LocalFileView.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(41, 104);
            button2.Name = "button2";
            button2.Size = new Size(221, 52);
            button2.TabIndex = 1;
            button2.Text = "Explorer";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(41, 173);
            button3.Name = "button3";
            button3.Size = new Size(221, 52);
            button3.TabIndex = 2;
            button3.Text = "Importer";
            button3.UseVisualStyleBackColor = true;
            // 
            // SearchBar
            // 
            SearchBar.Location = new Point(361, 51);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(472, 23);
            SearchBar.TabIndex = 2;
            // 
            // button4
            // 
            button4.Location = new Point(1052, 135);
            button4.Name = "button4";
            button4.Size = new Size(170, 47);
            button4.TabIndex = 3;
            button4.Text = "Delete all";
            button4.UseVisualStyleBackColor = true;
            // 
            // Accueil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(button4);
            Controls.Add(SearchBar);
            Controls.Add(LocalFileView);
            Controls.Add(panel1);
            Name = "Accueil";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LocalFileView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private DataGridView LocalFileView;
        private Button button3;
        private Button button2;
        private TextBox SearchBar;
        private Button button4;
    }
}
