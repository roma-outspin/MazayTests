using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Builder
{
    public partial class managerTestsForm : Form
    {
        public managerTestsForm()
        {
            InitializeComponent();
            testsButton = new List<Button>();
            folderTest = Directory.GetDirectories("Tests");
            ShowFolderTests(folderTest);
        }
        List<Button> testsButton;
        
        string[] folderTest;
        private void managerTestsForm_Load(object sender, EventArgs e)
        {

        }

        public void CreateButton(int number, string name, int x, int y, EventHandler myMethodName)
        {
            Button button = new Button();
            button.Text = name;
            button.Size = new Size(75, 23);
            button.Click += myMethodName;
            if (number == 0)
            {
                button.Location = new Point(x, y);
            }
            if (number > 0)
            {
                button.Location = new Point( 95 * number, y);
            }
            panel1.Controls.Add(button);
            testsButton.Add(button);
        }

        private void ButtonShowLable(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(vScrollBar1);
            ShowFolderTests(folderTest);
            ShowLableTest(Directory.GetFiles(((Button)sender).Text));
        }



        private void ShowFolderTests(string[] tests)
        {
            for (int i = 0; i < tests.Length; i++)
            {
                CreateButton(i, tests[i], 10, 10, ButtonShowLable);
            }
        }
        public void CreateLableTests(int number, string name)
        {
            Label test = new Label();
            test.Text = name;
            if(number == 0)
            {
                test.Location = new Point(10, 52);
                CreateButton(0, "старт", 200, 50, ButtonStartDelete);
                CreateButton(0, "настройки", 275, 50, ButtonStartDelete);
            }
            if (number > 0)
            {
                test.Location = new Point(10, 22 * number + 50);
                CreateButton(0, "старт", 200, 20 * number + 50,ButtonStartDelete);
                CreateButton(0, "настройки", 275, 20 * number + 50, ButtonStartDelete);
            }
            panel1.Controls.Add(test);
        }
        private void ShowLableTest(string[] files)
        {
            for (int i = 0; i < files.Length; i++)
            {
                CreateLableTests(i, files[i]);
            }
        }
        //метод заглушка для кнопок старт и настройки
        private void ButtonStartDelete(object sender, EventArgs e)
        {
            MessageBox.Show("функция в процессе разработки");
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
