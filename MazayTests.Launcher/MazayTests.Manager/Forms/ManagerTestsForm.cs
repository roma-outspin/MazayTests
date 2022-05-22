
using CustomControls;
using MazayTests.Core;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;




namespace MazayTests.Manager
{
    public partial class ManagerTestsForm : Form
    {
        string[] _testCollections;
        public string _currentCollection;
        string _currentTest;
        DialogNameForm dialogName;
        TableLayoutPanel _collectionPanel;
        FlowLayoutPanel _testPanel;

        public ManagerTestsForm()
        {
            InitializeComponent();
            _testCollections = Directory.GetDirectories("Tests");
            _currentCollection = _testCollections[0];
            ShowCollections(_testCollections);
            var testsInCollection = Directory.GetFiles(_currentCollection, "*.json");
            ShowTests(testsInCollection);
            dialogName = new DialogNameForm(); 
        }
        private void ShowCollections(string[] collectionPathes)
        {
            int height = 40 * collectionPathes.Length;
            Button button;
            BasisCollectionPanel.Controls.Clear();
            BasisCollectionPanel.Controls.Add(CollectionScrollbar);
            CollectionScrollbar.BringToFront();
            _collectionPanel = new TableLayoutPanel();
            _collectionPanel.ColumnCount = 1;
            _collectionPanel.RowCount = collectionPathes.Length + 1;
            _collectionPanel.AutoScroll = true;
            _collectionPanel.Dock = DockStyle.Fill;
            _collectionPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this._collectionPanel_MouseWheel);
            for (int i = 0; i < collectionPathes.Length; i++)
            {
                _collectionPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                button = AddButton(collectionPathes[i].Substring(6));
                if (_currentCollection == collectionPathes[i])
                {
                    button.BackColor = System.Drawing.Color.Gainsboro;
                }
                else button.BackColor = System.Drawing.Color.White;
                button.Dock = DockStyle.Fill;
                button.Click += Collection_Click;
                button.FlatAppearance.BorderColor = System.Drawing.Color.White;
                button.Font = new System.Drawing.Font("Comfortaa Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                button.ForeColor = System.Drawing.SystemColors.AppWorkspace;
                button.Margin = new Padding(0, 0, 0, 0);
               // button.AutoSize = true;
                _collectionPanel.Controls.Add(button);      
            }
            CollectionTable.Controls.Add(LogoLable, 0, 0);
            CollectionTable.Controls.Add(SearchPanel, 0, 1);
            CollectionTable.Controls.Add(ButtonConrolsPanel, 0, 2);
            CollectionTable.Controls.Add(BasisCollectionPanel, 0, 3);
            BasisCollectionPanel.Controls.Add(_collectionPanel);
            if (height > _collectionPanel.ClientSize.Height)
                CollectionScrollbar.Visible = true;
            else CollectionScrollbar.Visible = false;
            _collectionPanel.VerticalScroll.Maximum = 40 * collectionPathes.Length;
            this.CollectionScrollbar.Minimum = _collectionPanel.VerticalScroll.Minimum;
            this.CollectionScrollbar.Maximum = height + 10;
            this.CollectionScrollbar.LargeChange = CollectionScrollbar.Maximum / CollectionScrollbar.Height + _collectionPanel.Height;
            this.CollectionScrollbar.SmallChange = CollectionScrollbar.Minimum / CollectionScrollbar.Height + _collectionPanel.Height;
            this.CollectionScrollbar.Value = Math.Abs(_collectionPanel.AutoScrollPosition.Y);
        }

        private void _collectionPanel_MouseWheel(object? sender, MouseEventArgs e)
        {
            this.CollectionScrollbar.Value = Math.Abs(_collectionPanel.AutoScrollPosition.Y);
        }

        private Button AddButton(string text)
        {
            var button = new  Button()
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
            };
            return button;
        }
        private RJButton AddrJButton(string text)
        {
            var rjButton = new RJButton()
            {
                Text = text,
                Cursor = Cursors.Hand
            };
            return rjButton;
        }

        private void Collection_Click(object? sender, EventArgs e)
        {
            MenuPanel.Visible = false;
            _currentTest = string.Empty;
            _currentCollection = "Tests" + "\\" + ((Button)sender).Text;
            ShowCollections(Directory.GetDirectories("Tests"));
            var testsInCollection = Directory.GetFiles(_currentCollection, "*.json");
            ShowTests(testsInCollection);
        }
        private void TestScrollbar_Scroll(object? sender, EventArgs e)
        {
            _testPanel.AutoScrollPosition = new Point(0, TestScrollbar.Value);
            TestScrollbar.Value = _testPanel.VerticalScroll.Value;
            TestScrollbar.Invalidate();
            Application.DoEvents();
        }
        private void CollectionScrollbar_Scroll(object? sender, EventArgs e)
        {
            _collectionPanel.AutoScrollPosition = new Point(0, CollectionScrollbar.Value);
            CollectionScrollbar.Value = _collectionPanel.VerticalScroll.Value;
            CollectionScrollbar.Invalidate();
            Application.DoEvents();
        }
        private void Form_ResizeEnd(Object sender, EventArgs e)
        {
            this.TestScrollbar.Minimum = _testPanel.VerticalScroll.Minimum;
            this.TestScrollbar.Maximum = _testPanel.VerticalScroll.Maximum;
            this.TestScrollbar.LargeChange = TestScrollbar.Maximum / TestScrollbar.Height + _testPanel.Height;
            this.TestScrollbar.SmallChange = 15;
            this.TestScrollbar.Value = Math.Abs(_testPanel.AutoScrollPosition.Y);
            this.CollectionScrollbar.Minimum = _collectionPanel.VerticalScroll.Minimum;
            this.CollectionScrollbar.Maximum = _collectionPanel.VerticalScroll.Maximum;
            this.CollectionScrollbar.LargeChange = CollectionScrollbar.Maximum / CollectionScrollbar.Height + _collectionPanel.Height;
            this.CollectionScrollbar.SmallChange = 15;
            this.CollectionScrollbar.Value = Math.Abs(_collectionPanel.AutoScrollPosition.Y);  
        }
        private void ShowTests(string[] tests)
        {
            int num = 0;
            TestTable.Controls.Clear();
            _testPanel = new FlowLayoutPanel();
            _testPanel.Update();
            _testPanel.AutoScroll = true;         
            _testPanel.Dock = DockStyle.Fill;
            _testPanel.Padding =  new System.Windows.Forms.Padding(30, 10, 30, 30);
            _testPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Test_MouseWheel);
            for (int i = 0; i < tests.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(tests[i]);
                var button = AddrJButton(fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.')));
                button.BackColor = System.Drawing.Color.DodgerBlue;
                button.Click += Test_Click;
                button.BorderRadius = 20;
                button.FlatAppearance.BorderColor = System.Drawing.Color.White;
                button.Size = new System.Drawing.Size(180, 180);
                button.Font = new System.Drawing.Font("Exo 2 SemiBold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold ))), System.Drawing.GraphicsUnit.Point);
                button.ForeColor = ForeColor = System.Drawing.Color.AliceBlue;
                button.Margin = new Padding(30, 30, 30, 30);
                _testPanel.Controls.Add(button);
                num += button.Size.Height; 
            }

            TestTable.Controls.Add(_testPanel);

            if (num > _testPanel.ClientSize.Height)
                TestScrollbar.Visible = true;
            else
                TestScrollbar.Visible = false;

            this.TestScrollbar.Minimum = _testPanel.VerticalScroll.Minimum;
            this.TestScrollbar.Maximum = (tests.Length/3)*265;
            this.TestScrollbar.LargeChange = TestScrollbar.Maximum / TestScrollbar.Height + _testPanel.Height;
            this.TestScrollbar.SmallChange = TestScrollbar.Minimum / TestScrollbar.Height + _testPanel.Height;
            this.TestScrollbar.Value = Math.Abs(_testPanel.AutoScrollPosition.Y);
        }

        private void Test_MouseWheel(object? sender, MouseEventArgs e)
        {
            this.TestScrollbar.Value = Math.Abs(_testPanel.AutoScrollPosition.Y);
        }

        private void OpenTest(object? sender, EventArgs e)
        {
            if (_currentTest == null || _currentTest == string.Empty)
            {
                MessageBox.Show("Выберите тест для запуска");
            }
            else
            {
                DialogResult result = MessageBox.Show("Настроить параметры запускаемого теста? \n" +
                    "Чтобы запустить тест c настройками по умолчанию нажмите 'нет'", "Сообщение",
                         MessageBoxButtons.YesNoCancel,
                         MessageBoxIcon.Information,
                         MessageBoxDefaultButton.Button1,
                         MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    new SetUpTestForm().Show();
                    Hide();
                }
                if (result == DialogResult.No)
                {
                    Process _process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "MazayTests.Player.exe";
                    startInfo.Arguments = _currentTest;
                    _process.StartInfo = startInfo;
                    _process.Start();
                }
            }
        }

        private void Test_Click(object sender, EventArgs e)
        {
            MenuPanel.Visible = true;
            MenuPanel.BringToFront();
            _testPanel.Enabled = false;
            _currentTest = _currentCollection + "\\" + ((Button)sender).Text + ".json";
        }

        private void ManagerTestsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void DeleteCollection_Click(object sender, EventArgs e)
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
                        DeleteCollections();
                    }
                }
                else DeleteCollections();
            }
            else MessageBox.Show("Коллекции нет");
        }

        private void DeleteCollections()
        {
            Directory.Delete(_currentCollection, true);
            TestTable.Controls.Clear();
            MessageBox.Show($"Папка {GetNameCollection()} удалена");
            _currentCollection = _testCollections[0];
            UpdateCollections();
        }
        private string GetNameCollection()
        {
            return _currentCollection.Substring(_currentCollection.IndexOf('\\') + 1);
        }
        private string GetNameTest()
        {
            return _currentTest.Substring(_currentTest.LastIndexOf('\\') + 1);
        }
        private void DeleteTest_Click(object sender, EventArgs e)
        {
            if (File.Exists(_currentTest))
            {
                DialogResult result = MessageBox.Show($"Удалить {GetNameTest()} тест ?",
                     "Сообщение",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Information,
                      MessageBoxDefaultButton.Button1,
                      MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    DeleteTests();
                }
            }
            else MessageBox.Show("Выберите тест");
        }

        private void DeleteTests()
        {
            File.Delete(_currentTest);
            MessageBox.Show($"Тест {GetNameTest()} удален");
            ShowTests(Directory.GetFiles(_currentCollection, "*.json"));
            _currentTest = string.Empty;
        }

        private void UpdateCollections()
        {
            CollectionTable.Controls.Clear();
            ShowCollections(Directory.GetDirectories("Tests"));
        }

        private void Add_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Добавить тест в коллекцию {GetNameCollection()}?\n" +
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
            dialogName.ShowDialog();
            if (!File.Exists(GetPath()) && dialogName.newName != string.Empty)
            {
                new CreatorTestForm(dialogName.newName, GetPath()).Show();
                Hide();
            }
            else MessageBox.Show("Тест не будет создан! \n Возможные причины\n" +
                "-Нажата кнопкка отмены\n" +
                "-Не введен текст\n" +
                "-Тест с таким именем уже существует");
        }
        public string GetPath()
        {
           return $"{_currentCollection}\\{dialogName.newName}.json";
        }
        private void CreateCollection()
        {
            dialogName.ShowDialog(); 
            string path = $"Tests\\{dialogName.newName}";
            if (!Directory.Exists($"{path}"))
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

        private void CancelMenu_Click(object sender, EventArgs e)
        {
            MenuPanel.Visible = false;
            MenuPanel.SendToBack();
            _testPanel.Enabled = true;
        }

    }
}
