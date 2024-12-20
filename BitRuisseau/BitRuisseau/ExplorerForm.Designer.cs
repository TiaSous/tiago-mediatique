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
            panel1 = new System.Windows.Forms.Panel();
            button3 = new System.Windows.Forms.Button();
            Explorer = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            LocalFileView = new System.Windows.Forms.DataGridView();
            SearchBar = new System.Windows.Forms.TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LocalFileView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(Explorer);
            panel1.Controls.Add(button1);
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(301, 679);
            panel1.TabIndex = 0;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(41, 173);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(221, 52);
            button3.TabIndex = 2;
            button3.Text = "Importer";
            button3.UseVisualStyleBackColor = true;
            // 
            // Explorer
            // 
            Explorer.Location = new System.Drawing.Point(41, 104);
            Explorer.Name = "Explorer";
            Explorer.Size = new System.Drawing.Size(221, 52);
            Explorer.TabIndex = 1;
            Explorer.Text = "Explorer";
            Explorer.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(41, 35);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(221, 52);
            button1.TabIndex = 0;
            button1.Text = "Accueil";
            button1.UseVisualStyleBackColor = true;
            // 
            // LocalFileView
            // 
            LocalFileView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LocalFileView.Location = new System.Drawing.Point(361, 188);
            LocalFileView.Name = "LocalFileView";
            LocalFileView.Size = new System.Drawing.Size(861, 454);
            LocalFileView.TabIndex = 1;
            LocalFileView.CellContentClick += LocalFileView_CellContentClick;
            // 
            // SearchBar
            // 
            SearchBar.Location = new System.Drawing.Point(361, 51);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new System.Drawing.Size(472, 23);
            SearchBar.TabIndex = 2;
            // 
            // ExplorerForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(SearchBar);
            Controls.Add(LocalFileView);
            Controls.Add(panel1);
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LocalFileView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Button button1;
        private System.Windows.Forms.DataGridView LocalFileView;
        private Button button3;
        private Button Explorer;
        private TextBox SearchBar;
    }
}