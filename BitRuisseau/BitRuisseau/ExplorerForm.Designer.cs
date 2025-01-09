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
            LocalFileView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)LocalFileView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(301, 679);
            panel1.TabIndex = 0;
            // 
            // LocalFileView
            // 
            LocalFileView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LocalFileView.Location = new System.Drawing.Point(361, 188);
            LocalFileView.Name = "LocalFileView";
            LocalFileView.Size = new System.Drawing.Size(861, 454);
            LocalFileView.TabIndex = 1;
            LocalFileView.CellClick += LocalFileView_CellClick;
            // 
            // ExplorerForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(LocalFileView);
            Controls.Add(panel1);
            Text = "Explorer";
            ((System.ComponentModel.ISupportInitialize)LocalFileView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView LocalFileView;
    }
}