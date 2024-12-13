namespace BitRuisseau
{
    partial class ExplorerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            ValidateButton = new Button();
            Password = new TextBox();
            User = new TextBox();
            Host = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button3 = new Button();
            Explorer = new Button();
            button1 = new Button();
            LocalFileView = new DataGridView();
            SearchBar = new TextBox();
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
            panel1.Controls.Add(Explorer);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(301, 679);
            panel1.TabIndex = 0;
            // 
            // ValidateButton
            // 
            ValidateButton.Location = new Point(112, 491);
            ValidateButton.Name = "ValidateButton";
            ValidateButton.Size = new Size(75, 23);
            ValidateButton.TabIndex = 9;
            ValidateButton.Text = "Valider";
            ValidateButton.UseVisualStyleBackColor = true;
            // 
            // Password
            // 
            Password.Location = new Point(102, 429);
            Password.Name = "Password";
            Password.Size = new Size(100, 23);
            Password.TabIndex = 8;
            // 
            // User
            // 
            User.Location = new Point(102, 368);
            User.Name = "User";
            User.Size = new Size(100, 23);
            User.TabIndex = 7;
            // 
            // Host
            // 
            Host.Location = new Point(102, 306);
            Host.Name = "Host";
            Host.Size = new Size(100, 23);
            Host.TabIndex = 6;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 350);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Utilisateur";
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
            // Explorer
            // 
            Explorer.Location = new Point(41, 104);
            Explorer.Name = "Explorer";
            Explorer.Size = new Size(221, 52);
            Explorer.TabIndex = 1;
            Explorer.Text = "Explorer";
            Explorer.UseVisualStyleBackColor = true;
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
            // ExplorerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(SearchBar);
            Controls.Add(LocalFileView);
            Controls.Add(panel1);
            Name = "ExplorerForm";
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
        private Button Explorer;
        private TextBox SearchBar;
        private Label label1;
        private TextBox Password;
        private TextBox User;
        private TextBox Host;
        private Label label3;
        private Label label2;
        private Button ValidateButton;
    }
}