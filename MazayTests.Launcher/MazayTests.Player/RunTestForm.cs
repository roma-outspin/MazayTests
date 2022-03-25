using MazayTests.Core;
using MazayTests.Core.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazayTests.Manager
{
    public partial class RunTestForm : Form
    {
        InteractiveTest _test;
        int numberQuestion;
        string _pathToTest;

        public RunTestForm(string pathToTest)
        {
            InitializeComponent();
            _pathToTest = pathToTest;
            _test = new TestBuilder().OpenTest(_pathToTest);
            numberQuestion = 0;
            ShowQuestion(numberQuestion);  
        }

        private void RunTestForm_Load(object sender, EventArgs e)
        {

        }

        private void ShowQuestion(int number)
        {
            Label q = new();
            q.Text = _test.Questions[number].Text;
            QuestionPanel.Controls.Add(q);
            ShowAnswer(number);
        }

        private void Answerbutton_Click(object sender, EventArgs e)
        {
            QuestionPanel.Controls.Clear();
            AnswersPanel.Controls.Clear();
            if (numberQuestion == _test.Questions.Count - 1)
            {
                MessageBox.Show("Вы ответили на все вопросы");
            }
            else
            {
                numberQuestion += 1;
                ShowQuestion(numberQuestion);
            }
        }

        private void ShowAnswer(int number)
        {
            for (int i = 0; i < _test.Questions[number].Answers.Count; i++)
            {
                CreateRadioButton(i, _test.Questions[number].Answers[i].Text);
            }
        }

        private void CreateRadioButton(int number, string text)
        {
            RadioButton answer = new();
            answer.Text = text;
            if (number == 0)
            {
                answer.Location = new Point(3, 3);
            }
            else
            {
                answer.Location = new Point(3, 3 * number + 30);
            }
            AnswersPanel.Controls.Add(answer);
        }
    }
}
