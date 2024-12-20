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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new System.Windows.Forms.Panel();
            ValidateButton = new System.Windows.Forms.Button();
            Password = new System.Windows.Forms.TextBox();
            User = new System.Windows.Forms.TextBox();
            Host = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            Explorer = new System.Windows.Forms.Button();
            LocalFileView = new System.Windows.Forms.DataGridView();
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
            panel1.Controls.Add(Explorer);
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(301, 679);
            panel1.TabIndex = 0;
            // 
            // ValidateButton
            // 
            ValidateButton.Location = new System.Drawing.Point(112, 491);
            ValidateButton.Name = "ValidateButton";
            ValidateButton.Size = new System.Drawing.Size(75, 23);
            ValidateButton.TabIndex = 9;
            ValidateButton.Text = "Valider";
            ValidateButton.UseVisualStyleBackColor = true;
            ValidateButton.Click += ValidateButton_Click;
            // 
            // Password
            // 
            Password.Location = new System.Drawing.Point(102, 429);
            Password.Name = "Password";
            Password.Size = new System.Drawing.Size(100, 23);
            Password.TabIndex = 8;
            // 
            // User
            // 
            User.Location = new System.Drawing.Point(102, 368);
            User.Name = "User";
            User.Size = new System.Drawing.Size(100, 23);
            User.TabIndex = 7;
            // 
            // Host
            // 
            Host.Location = new System.Drawing.Point(102, 306);
            Host.Name = "Host";
            Host.Size = new System.Drawing.Size(100, 23);
            Host.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(102, 411);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(77, 15);
            label3.TabIndex = 5;
            label3.Text = "Mot de passe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(102, 350);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Utilisateur";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(102, 288);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 15);
            label1.TabIndex = 3;
            label1.Text = "Host";
            // 
            // Explorer
            // 
            Explorer.Location = new System.Drawing.Point(44, 38);
            Explorer.Name = "Explorer";
            Explorer.Size = new System.Drawing.Size(221, 52);
            Explorer.TabIndex = 1;
            Explorer.Text = "Explorer";
            Explorer.UseVisualStyleBackColor = true;
            Explorer.Click += Explorer_Click;
            // 
            // LocalFileView
            // 
            LocalFileView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LocalFileView.Location = new System.Drawing.Point(361, 188);
            LocalFileView.Name = "LocalFileView";
            LocalFileView.Size = new System.Drawing.Size(861, 454);
            LocalFileView.TabIndex = 1;
            // 
            // Accueil
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(LocalFileView);
            Controls.Add(panel1);
            Text = "Accueil";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LocalFileView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DataGridView LocalFileView;
        private System.Windows.Forms.Button Explorer;
        private Label label1;
        private TextBox Password;
        private TextBox User;
        private TextBox Host;
        private Label label3;
        private Label label2;
        private Button ValidateButton;
    }
}
