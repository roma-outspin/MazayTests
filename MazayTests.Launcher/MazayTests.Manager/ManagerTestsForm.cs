
using MazayTests.Core;
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


namespace MazayTests.Manager
{
    public partial class ManagerTestsForm : Form
    {
        string[] _testCollections;
        string _currentCollection;
        string _currentTest;

        public ManagerTestsForm()
        {
            InitializeComponent();
            _testCollections = Directory.GetDirectories("Tests\\");
           // _currentCollection = _testCollections[0];
            ShowCollections(_testCollections);
        }

        private void ShowCollections(string[] collectionPathes)
        {
            for (int i = 0; i < collectionPathes.Length; i++)
            {
                CreateCollectionButton(i, collectionPathes[i], 10, 2, SelectCollection_Click);
            }
        }

        private void CreateCollectionButton(int number, string name, int x, int y, EventHandler functionClick)
        {
            Button button = new Button();
            button.Text = name;
            button.Size = new Size(75, 23);
            button.Click += functionClick;

            button.Location = new Point(85 * number+x, y);

            collectionPanel.Controls.Add(button);
           
        }

        private void SelectCollection_Click(object sender, EventArgs e)
        {
            testsPanel.Items.Clear();
            //testsPanel.Controls.Add(vScrollBar1);
             ShowCollections(_testCollections);
             _currentCollection = ((Button)sender).Text;
            var testsInCollection = Directory.GetFiles(((Button)sender).Text, "*.json");
            ShowTests(testsInCollection);
        }

        private void ShowTests(string[] tests)
        {
            foreach (string test in tests)
            {
                var testInfo = new FileInfo(test);
                GetTests(testInfo.Name);
            }
        }

        private void GetTests(string name)
        {
            Label test = new();
            test.Click += SelectTest;
            test.DoubleClick += OpenTest;
            test.Text = name;
            test.AutoSize = true;


            testsPanel.Items.Add(new ListViewItem(name));

        }

        private void OpenTest(object sender, EventArgs e)
        {
            var test = new TestBuilder().OpenTest(_currentTest);
            MessageBox.Show(test.Name);
        }

        private void SelectTest(object sender, EventArgs e)
        {
            foreach(var lbl in testsPanel.Controls)
            {
                if (lbl is Label)
                {
                    ((Label)lbl).BackColor = Color.Transparent;
                }
            }
            ((Label)sender).BackColor = Color.Red;
            _currentTest = ((Label)sender).Text;

        }

        private void Serializ_Click(object sender, EventArgs e)
        {
            var test = new TestGenerator().GetTest(textBox1.Text);
            new TestBuilder().SaveTest(test, _currentCollection+$"\\{test.Name}.json");
        }

        private void ManagerTestsForm_Load(object sender, EventArgs e)
        {

        }

        private void ManagerTestsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length < 1)
            {
                Serializ.Enabled = false;
            }
            else
            {
                Serializ.Enabled = true;
            }
        }

        private void UpdateCollections()
        {
            //метод сканирования папки Tests и добавления/удаления коллекций с формы
        }
        private void DeleteColections()
        {

        }
        private void CreateCollection(string Name)
        {
            //метод создания новой коллекции
            //+аналогичный метод для удаления коллекции с проверкой на присутствие в ней тестов
        }

        private void testsPanel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //вынести отдельно кнопки старт/сеттингс
        //CreateCollectionButton() поправить
    }
}
