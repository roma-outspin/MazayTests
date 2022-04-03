using MazayTests.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazayTests.Player
{
    public partial class MainForm : Form
    {
        private int _answCount;
        private TableLayoutPanel _answersPanel;
        private InteractiveTest _test;

        public MainForm(InteractiveTest test)
        {
            InitializeComponent();
            _test = test;
            QuestionLabel.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.";
            //NextButton();
            _answCount = 7;
            ShowAnswers(_answCount);
            NextButton(test.StartProperties.withNextButton);
        }

        private void ShowAnswers(int answCount)
        {
            _answersPanel = new TableLayoutPanel();
            var colWidth = 100F / answCount;
            _answersPanel.ColumnCount = answCount;

            if (answCount>4)
            {

                _answersPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                _answersPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                _answersPanel.ColumnCount = (int)Math.Ceiling((double)answCount / 2);

            }
            
            _answersPanel.Dock = DockStyle.Fill;
            _answersPanel.RowCount = 1;
            _answersPanel.Padding = new Padding(50, 50, 50, 50);


            int columnBuffer = 0;
            for (int i = 0; i < answCount;i++)
            {
                if (i < _answersPanel.ColumnCount)
                {
                    _answersPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, colWidth));
                    _answersPanel.Controls.Add(AddButton("Ответ " + (i + 1)));

                } else {
                    if(answCount==5&& i==4)
                    {
                        _answersPanel.Controls.Add(AddButton("Ответ " + (i + 1)), columnBuffer+1, 1);
                        columnBuffer++;
                    } else
                    {
                        _answersPanel.Controls.Add(AddButton("Ответ " + (i + 1)), columnBuffer, 1);
                        columnBuffer++;
                    }
                    
                }
                
                

                
            }
            MainTablePanel.Controls.Add(_answersPanel, 0, 1);
        }
        private Button AddButton(string text)
        {
            return new Button() { 
            Text =text,
            Dock = DockStyle.Fill
            };
        }
        private void NextButton(bool isReg)
        {
            if (isReg)
            {
                var nextButton = new Button()
                {
                    Text = "ДАЛЕЕ",
                    Width = 150,
                    Height = 80,
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                    Location = new Point(this.Width - 180, this.Height - 120)

                };
                Controls.Add(nextButton);
                nextButton.BringToFront();
            }
            
        }
    }
}
 