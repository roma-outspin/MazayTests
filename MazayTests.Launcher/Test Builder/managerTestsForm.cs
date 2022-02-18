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
    public partial class ManagerTestsForm : Form
    {
        //для пулреквеста
        public ManagerTestsForm()
        {
            InitializeComponent();
            generatedButton = new List<Button>();
            foldersTest = Directory.GetDirectories("Tests");
            ShowFoldersTests(foldersTest);
        }
        List<Button> generatedButton;
        
        string[] foldersTest;
        private void ManagerTestsForm_Load(object sender, EventArgs e)
        {

        }

        public void CreateButton(int number, string name, int x, int y, EventHandler functionClick)
        {
            Button button = new Button();
            button.Text = name;
            button.Size = new Size(75, 23);
            button.Click += functionClick;
            if (number == 0)
            {
                button.Location = new Point(x, y);
            }
            if (number > 0)
            {
                button.Location = new Point( 95 * number, y);
            }
            panel1.Controls.Add(button);
            generatedButton.Add(button);
        }

        private void FolderTest_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(vScrollBar1);
            ShowFoldersTests(foldersTest);
            ShowLablesTests(Directory.GetFiles(((Button)sender).Text));
        }
        private void ShowFoldersTests(string[] tests)
        {
            for (int i = 0; i < tests.Length; i++)
            {
                CreateButton(i, tests[i], 10, 10, FolderTest_Click);
            }
        }
        public void CreateButtonsStartSettings(int y)
        {
            string[] nameButton =  { "старт", "настройки" };
            
            for (int i = 0; i < nameButton.Length; i++)
                if(nameButton[i] == "старт") 
                {
                    int x = 300;
                    CreateButton(i, nameButton[i], x, y, Start_Click);
                    CreateButton(i, nameButton[i+1], x + 75, y, Settings_Click);
                }   
        }
        public void CreateLableTestsWithButtons(int number, string name)
        {
            Label test = new();
            test.Text = name;
            test.AutoSize = true;
            if (number == 0)
            {
                test.Location = new Point(10, 50);
                CreateButtonsStartSettings(50);
            }
            if (number > 0)
            {
                test.Location = new Point(10, 22 * number + 50);
                CreateButtonsStartSettings(20 * number + 50);
            }
            panel1.Controls.Add(test);
        }
        private void ShowLablesTests(string[] fileTests)
        {
            for (int i = 0; i < fileTests.Length; i++)
            {
                CreateLableTestsWithButtons(i, fileTests[i]);
            }
        }
        //метод заглушка для кнопоки старт
        private void Start_Click(object sender, EventArgs e)
        {
            MessageBox.Show("нажата кнопка старт");
        }
        //метод заглушка для кнопки настройки
        private void Settings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("нажата кнопка настройки");
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
