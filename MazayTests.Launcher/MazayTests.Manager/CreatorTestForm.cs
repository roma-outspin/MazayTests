using MazayTests.Core;
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

namespace MazayTests.Manager
{
    public partial class CreatorTestForm : Form
    {
        TestGenerator generator = new();
        ManagerTestsForm managerTests = new();

        public CreatorTestForm()
        {
            InitializeComponent();
            rightAnswers = new List<string>();
            answers = new List<Answer>();
            questions = new List<Question>();
        }
        List<string> rightAnswers;
        List<Answer> answers;
        List<Question> questions;
        private void CreatorTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            new ManagerTestsForm().Show();
            Hide();
        }

        private void addRightAnswer_Click(object sender, EventArgs e)
        {
            rightAnswers.Add(questionTextBox.Text);
            rightAnswerTextBox.Clear();
        }

        private void addAnswer_Click(object sender, EventArgs e)
        {
            Answer answer = new();
            answer.Text = answerTextBox.Text;
            answers.Add(answer);
            answerTextBox.Clear();
        }

        private void addQuestion_Click(object sender, EventArgs e)
        {
            questions.Add(generator.GetQuestion(questionTextBox.Text, rightAnswers, answers));
            questionTextBox.Clear();
        }

        private void saveTest_Click(object sender, EventArgs e)
        {
            var test = new TestGenerator().GetTest(managerTests.NameTest, questions);
            new TestBuilder().SaveTest(test, managerTests.PathToTest);
            new ManagerTestsForm().Show();
            Hide();
        }
    }
}
