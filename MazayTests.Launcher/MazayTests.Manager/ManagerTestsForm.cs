
using MazayTests.Core;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;


namespace MazayTests.Manager
{
    public partial class ManagerTestsForm : Form
    {
        string[] _testCollections;
        string _currentCollection;
        string _currentTest;

        AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        public ManagerTestsForm()
        {
            InitializeComponent();
            _testCollections = Directory.GetDirectories("Tests");
            _currentCollection = _testCollections[0];
            ShowCollections(_testCollections);
            coll.AddRange(_testCollections);
            
        }
        public string PathToTest;
        public string NameTest;

        private void ShowCollections(string[] collectionPathes)
        {
            collectionPanel.Clear();
            GetHeaderCollectionPanel();
            foreach (string coll in collectionPathes)
            {
                ListViewItem collection = new ListViewItem();
                collection.Text = coll;
                collectionPanel.Items.Add(collection);
                collectionPanel.Click += SelectCollection_Click;
            }
        }

        private void GetHeaderCollectionPanel()
        {
            ColumnHeader header = new ColumnHeader();
            collectionPanel.Columns.Add(header);
            collectionPanel.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void SelectCollection_Click(object? sender, EventArgs e)
        {
            _currentTest = string.Empty;
            _currentCollection = collectionPanel.FocusedItem.SubItems[0].Text;
            var testsInCollection = Directory.GetFiles(_currentCollection, "*.json");
            ShowTests(testsInCollection);
        }

        private void ShowTests(string[] tests)
        {
            testsPanel.Clear();
            GetHeaderTestsPanel();
            foreach (string test in tests)
            {
                var testInfo = new FileInfo(test);
                GetTests(testInfo.Name);
            }
        }

        private void GetHeaderTestsPanel()
        {
            ColumnHeader header = new ColumnHeader();
            testsPanel.Columns.Add(header);
            testsPanel.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void GetTests(string name)
        {
            Label test = new();
            test.Text = name;
            test.AutoSize = true;
            testsPanel.Items.Add(new ListViewItem(name));
            testsPanel.Click += SelectTest;
            testsPanel.DoubleClick += OpenTest;
        }

        private void OpenTest(object sender, EventArgs e)
        {
            if (_currentTest == string.Empty)
            {
                MessageBox.Show("Выберите тест для запуска");
            }
            else
            {
                var test = new TestBuilder().OpenTest(_currentTest);
                MessageBox.Show(test.Name);
            }
        }

        private void SelectTest(object sender, EventArgs e)
        {
            _currentTest = _currentCollection + "\\" + testsPanel.FocusedItem.SubItems[0].Text;
        }

        private void ManagerTestsForm_Load(object sender, EventArgs e)
        {
            autoCompleteData();
        }

        private void ManagerTestsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (_currentTest == string.Empty)
            {
                DialogDeleteCollection();
            }
            else
            {
                DialogDeleteTest();
            }
        }

        private void DialogDeleteCollection()
        {
            if (Directory.Exists(_currentCollection))
            {
                string[] tests = Directory.GetFiles(_currentCollection, "*.json");
                if (tests.Length != 0)
                {
                    DialogResult result = MessageBox.Show($"В папке есть тесты {tests.Length} шт. \n Продолжить удаление?",
                     "Сообщение",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.Yes)
                    {
                        DeleteCollection();
                    }
                }
                else DeleteCollection();
            }
            else MessageBox.Show("Коллекции нет");
        }

        private void DeleteCollection()
        {
            Directory.Delete(_currentCollection, true);
            MessageBox.Show($"Папка {_currentCollection} удалена");
            collectionPanel.Items.RemoveAt(collectionPanel.FocusedItem.Index);
        }

        private void DialogDeleteTest()
        {
            if (File.Exists(_currentTest))
            {
                DialogResult result = MessageBox.Show($"Удалить тест {testsPanel.FocusedItem.Text} ?",
                     "Сообщение",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Information,
                      MessageBoxDefaultButton.Button1,
                      MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    DeleteTest();
                }
            }
            else MessageBox.Show("теста нет");
        }

        private void DeleteTest()
        {
            File.Delete(_currentTest);
            MessageBox.Show($"Тест {testsPanel.FocusedItem.Text} удален");
            testsPanel.Items.RemoveAt(testsPanel.FocusedItem.Index);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (_currentTest == string.Empty)
            {
                UpdateCollections();
            }
            else ShowTests(Directory.GetFiles(_currentCollection));
        }

        private void UpdateCollections()
        {
            ShowCollections(Directory.GetDirectories("Tests"));
        }

        private void Add_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Добавить тест в коллекцию {_currentCollection}?\n" +
                $" \n" +
                $"Чтобы создать новую коллекцию с тестами нажмите нет",

                 "Сообщение",
                 MessageBoxButtons.YesNoCancel,
                 MessageBoxIcon.Information,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                ShowCreatorTest();
            }
            if (result == DialogResult.No)
            {
                CreateCollection();
            }
        }

        public void ShowCreatorTest()
        {
            NameTest = Interaction.InputBox("Введите название нового теста:");
            PathToTest = $"{_currentCollection}\\{NameTest}.json";
            if (!File.Exists(PathToTest) && NameTest != string.Empty)
            {
                new CreatorTestForm().Show();
                Hide();
            }
            else MessageBox.Show("Тест не будет создан! \n Возможные причины\n" +
                "-Нажата кнопкка отмены\n" +
                "-Не введен текст\n" +
                "-Тест с таким именем уже существует");
        }

        private void CreateCollection()
        {
            string title = Interaction.InputBox("Введите название новой коллекции:");
            string path = $"Tests\\{title}";
            if (!Directory.Exists($"{path}") && title != string.Empty)
            {
                _currentCollection = Directory.CreateDirectory($"{path}").FullName;
                UpdateCollections();
                ShowCreatorTest();
            }
            else
            {
                MessageBox.Show("Коллекция не будет создана! \n Возможные причины\n" +
                "-Нажата кнопкка отмены\n" +
                "-Не введен текст\n" +
                "-Коллекция с таким именем уже существует");
            }
        }

        private void autoCompleteData()
        {
            searchBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            searchBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
    }
}
