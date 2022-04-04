
namespace MazayTests.Manager
{
    partial class RunTestForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.QuestionPanel = new System.Windows.Forms.Panel();
            this.AnswersPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Answerbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1, 1);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(800, 28);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вопрос";
            // 
            // QuestionPanel
            // 
            this.QuestionPanel.Location = new System.Drawing.Point(12, 50);
            this.QuestionPanel.Name = "QuestionPanel";
            this.QuestionPanel.Size = new System.Drawing.Size(776, 145);
            this.QuestionPanel.TabIndex = 2;
            // 
            // AnswersPanel
            // 
            this.AnswersPanel.Location = new System.Drawing.Point(12, 222);
            this.AnswersPanel.Name = "AnswersPanel";
            this.AnswersPanel.Size = new System.Drawing.Size(776, 187);
            this.AnswersPanel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ответы";
            // 
            // Answerbutton
            // 
            this.Answerbutton.Location = new System.Drawing.Point(713, 415);
            this.Answerbutton.Name = "Answerbutton";
            this.Answerbutton.Size = new System.Drawing.Size(75, 23);
            this.Answerbutton.TabIndex = 5;
            this.Answerbutton.Text = "Ответить";
            this.Answerbutton.UseVisualStyleBackColor = true;
            this.Answerbutton.Click += new System.EventHandler(this.Answerbutton_Click);
            // 
            // RunTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Answerbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AnswersPanel);
            this.Controls.Add(this.QuestionPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Name = "RunTestForm";
            this.Text = "RunTestForm";
            this.Load += new System.EventHandler(this.RunTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel QuestionPanel;
        private System.Windows.Forms.Panel AnswersPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Answerbutton;
    }
}