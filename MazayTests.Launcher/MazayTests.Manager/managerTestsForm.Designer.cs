
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.settings = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.Serializ = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.testsPanel = new System.Windows.Forms.ListView();
            this.collectionPanel = new System.Windows.Forms.ListView();
            this.start = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // settings
            // 
            this.settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settings.Location = new System.Drawing.Point(684, 24);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(77, 23);
            this.settings.TabIndex = 1;
            this.settings.Text = "параметры";
            this.settings.UseVisualStyleBackColor = true;
            // 
            // update
            // 
            this.update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.update.Location = new System.Drawing.Point(603, 24);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 2;
            this.update.Text = "обновить";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Serializ
            // 
            this.Serializ.Location = new System.Drawing.Point(441, 24);
            this.Serializ.Name = "Serializ";
            this.Serializ.Size = new System.Drawing.Size(75, 23);
            this.Serializ.TabIndex = 5;
            this.Serializ.Text = "Сохранить";
            this.Serializ.UseVisualStyleBackColor = true;
            this.Serializ.Click += new System.EventHandler(this.Serializ_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(224, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 23);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // testsPanel
            // 
            this.testsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testsPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.testsPanel.GridLines = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.testsPanel.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.testsPanel.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.testsPanel.HideSelection = false;
            this.testsPanel.LabelEdit = true;
            this.testsPanel.Location = new System.Drawing.Point(12, 124);
            this.testsPanel.Name = "testsPanel";
            this.testsPanel.Size = new System.Drawing.Size(756, 425);
            this.testsPanel.TabIndex = 7;
            this.testsPanel.TileSize = new System.Drawing.Size(300, 300);
            this.testsPanel.UseCompatibleStateImageBehavior = false;
            this.testsPanel.View = System.Windows.Forms.View.Details;
            // 
            // collectionPanel
            // 
            this.collectionPanel.GridLines = true;
            this.collectionPanel.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.collectionPanel.HideSelection = false;
            this.collectionPanel.LabelWrap = false;
            this.collectionPanel.Location = new System.Drawing.Point(12, 52);
            this.collectionPanel.Name = "collectionPanel";
            this.collectionPanel.ShowGroups = false;
            this.collectionPanel.Size = new System.Drawing.Size(756, 66);
            this.collectionPanel.TabIndex = 8;
            this.collectionPanel.UseCompatibleStateImageBehavior = false;
            this.collectionPanel.View = System.Windows.Forms.View.Details;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(12, 23);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 9;
            this.start.Text = "Запуск теста";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.OpenTest);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(522, 23);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 10;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(360, 24);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 11;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.Add_Click);
            // 
            // ManagerTestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.add);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.start);
            this.Controls.Add(this.collectionPanel);
            this.Controls.Add(this.testsPanel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Serializ);
            this.Controls.Add(this.update);
            this.Controls.Add(this.settings);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ManagerTestsForm";
            this.Text = "ManagerTestsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagerTestsForm_FormClosed);
            this.Load += new System.EventHandler(this.ManagerTestsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button Serializ;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView testsPanel;
        private System.Windows.Forms.ListView collectionPanel;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button add;
    }
}