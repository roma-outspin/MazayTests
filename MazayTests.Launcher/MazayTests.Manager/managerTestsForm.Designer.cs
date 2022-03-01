
namespace MazayTests.Manager
{
    partial class ManagerTestsForm
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
            this.buttonParams = new System.Windows.Forms.Button();
            this.ReFresh = new System.Windows.Forms.Button();
            this.Serializ = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.testsPanel = new System.Windows.Forms.ListView();
            this.collectionPanel = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // buttonParams
            // 
            this.buttonParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonParams.Location = new System.Drawing.Point(684, 24);
            this.buttonParams.Name = "buttonParams";
            this.buttonParams.Size = new System.Drawing.Size(77, 23);
            this.buttonParams.TabIndex = 1;
            this.buttonParams.Text = "параметры";
            this.buttonParams.UseVisualStyleBackColor = true;
            // 
            // ReFresh
            // 
            this.ReFresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReFresh.Location = new System.Drawing.Point(603, 24);
            this.ReFresh.Name = "ReFresh";
            this.ReFresh.Size = new System.Drawing.Size(75, 23);
            this.ReFresh.TabIndex = 2;
            this.ReFresh.Text = "обновить";
            this.ReFresh.UseVisualStyleBackColor = true;
            // 
            // Serializ
            // 
            this.Serializ.Location = new System.Drawing.Point(457, 24);
            this.Serializ.Name = "Serializ";
            this.Serializ.Size = new System.Drawing.Size(75, 23);
            this.Serializ.TabIndex = 5;
            this.Serializ.Text = "Сохранить";
            this.Serializ.UseVisualStyleBackColor = true;
            this.Serializ.Click += new System.EventHandler(this.Serializ_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(330, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // testsPanel
            // 
            this.testsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testsPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.testsPanel.HideSelection = false;
            this.testsPanel.Location = new System.Drawing.Point(12, 91);
            this.testsPanel.Name = "testsPanel";
            this.testsPanel.Size = new System.Drawing.Size(756, 374);
            this.testsPanel.TabIndex = 7;
            this.testsPanel.TileSize = new System.Drawing.Size(300, 300);
            this.testsPanel.UseCompatibleStateImageBehavior = false;
            this.testsPanel.View = System.Windows.Forms.View.Tile;
            // 
            // collectionPanel
            // 
            this.collectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.collectionPanel.HideSelection = false;
            this.collectionPanel.Location = new System.Drawing.Point(12, 53);
            this.collectionPanel.Name = "collectionPanel";
            this.collectionPanel.Size = new System.Drawing.Size(756, 32);
            this.collectionPanel.TabIndex = 8;
            this.collectionPanel.UseCompatibleStateImageBehavior = false;
            // 
            // ManagerTestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.collectionPanel);
            this.Controls.Add(this.testsPanel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Serializ);
            this.Controls.Add(this.ReFresh);
            this.Controls.Add(this.buttonParams);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ManagerTestsForm";
            this.Text = "ManagerTestsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagerTestsForm_FormClosed);
            this.Load += new System.EventHandler(this.ManagerTestsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonParams;
        private System.Windows.Forms.Button ReFresh;
        private System.Windows.Forms.Button Serializ;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView testsPanel;
        private System.Windows.Forms.ListView collectionPanel;
    }
}