using ManegerTests;
using MazayTests.Core.Model;
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
using Test_Builder;

namespace ManagerTests
{
    public partial class ManagerTestsForm : Form
    {
        List<Button> _generatedButton;
        string[] _foldersTest;

        public ManagerTestsForm()
        {
            InitializeComponent();
            _generatedButton = new List<Button>();
            _foldersTest = Directory.GetDirectories("Tests");
            ShowFolders(_foldersTest);
        }
        private void CreateButton(int number, string name, int x, int y, EventHandler functionClick)
        {
            Button button = new Button();
            button.Text = name;
            button.Size = new Size(75, 23);
            button.Click += functionClick;
            if (number == 0)
            {
                button.Location = new Point(x, y);
            }
            else
            {
                button.Location = new Point( 95 * number, y);
            }
            panel1.Controls.Add(button);
            _generatedButton.Add(button);
        }

        private void Folder_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(vScrollBar1);
            ShowFolders(_foldersTest);
            ShowTests(Directory.GetFiles(((Button)sender).Text));
        }
        private void ShowFolders(string[] tests)
        {
            for (int i = 0; i < tests.Length; i++)
            {
                CreateButton(i, tests[i], 10, 10, Folder_Click);
            }
        }
        private void GetButtonsForTest(int y)
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
        private void GetTestWithButtons(int number, string name)
        {
            Label test = new();
            test.Text = name;
            test.AutoSize = true;
            if (number == 0)
            {
                test.Location = new Point(10, 50);
                GetButtonsForTest(50);
            }
            else
            {
                test.Location = new Point(10, 22 * number + 50);
                GetButtonsForTest(20 * number + 50);
            }
            panel1.Controls.Add(test);
        }
        private void ShowTests(string[] fileTests)
        {
            for (int i = 0; i < fileTests.Length; i++)
            {
                GetTestWithButtons(i, fileTests[i]);
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
        private void Serializ_Click(object sender, EventArgs e)
        {
            TestGenerator test = new();
            Serialization serialization = new();
            serialization.Serialize(test.GetTest());
        }
        private void Deserializ_Click(object sender, EventArgs e)
        {
            Deserialization deserialization = new();
            deserialization.Deserialize();
        }
        private void ManagerTestsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
