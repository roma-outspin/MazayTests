
namespace MazayTests.Manager
{
    partial class TempForm
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
            this.TestListLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // TestListLayout
            // 
            this.TestListLayout.AutoScroll = true;
            this.TestListLayout.Location = new System.Drawing.Point(0, 0);
            this.TestListLayout.Name = "TestListLayout";
            this.TestListLayout.Size = new System.Drawing.Size(800, 119);
            this.TestListLayout.TabIndex = 0;
            // 
            // TempForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TestListLayout);
            this.Name = "TempForm";
            this.Text = "TempForm";
            this.Load += new System.EventHandler(this.TempForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel TestListLayout;
    }
}