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
            label1 = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            LocalFileView = new DataGridView();
            SearchBar = new TextBox();
            button4 = new Button();
            label2 = new Label();
            label3 = new Label();
            Host = new TextBox();
            User = new TextBox();
            Password = new TextBox();
            ValidateButton = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LocalFileView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(ValidateButton);
            panel1.Controls.Add(Password);
            panel1.Controls.Add(User);
            panel1.Controls.Add(Host);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(301, 679);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 288);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 3;
            label1.Text = "Host";
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
            // button2
            // 
            button2.Location = new Point(41, 104);
            button2.Name = "button2";
            button2.Size = new Size(221, 52);
            button2.TabIndex = 1;
            button2.Text = "Explorer";
            button2.UseVisualStyleBackColor = true;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 350);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Utilisateur";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 411);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 5;
            label3.Text = "Mot de passe";
            // 
            // Host
            // 
            Host.Location = new Point(102, 306);
            Host.Name = "Host";
            Host.Size = new Size(100, 23);
            Host.TabIndex = 6;
            // 
            // User
            // 
            User.Location = new Point(102, 368);
            User.Name = "User";
            User.Size = new Size(100, 23);
            User.TabIndex = 7;
            // 
            // Password
            // 
            Password.Location = new Point(102, 429);
            Password.Name = "Password";
            Password.Size = new Size(100, 23);
            Password.TabIndex = 8;
            // 
            // ValidateButton
            // 
            ValidateButton.Location = new Point(112, 491);
            ValidateButton.Name = "ValidateButton";
            ValidateButton.Size = new Size(75, 23);
            ValidateButton.TabIndex = 9;
            ValidateButton.Text = "Valider";
            ValidateButton.UseVisualStyleBackColor = true;
            ValidateButton.Click += ValidateButton_Click;
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
            panel1.PerformLayout();
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
        private Label label1;
        private TextBox Password;
        private TextBox User;
        private TextBox Host;
        private Label label3;
        private Label label2;
        private Button ValidateButton;
    }
}
