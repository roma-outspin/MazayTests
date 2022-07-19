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
       // private object currentButton = null;
        TableLayoutPanel _collectionPanel;
        FlowLayoutPanel _testPanel;
        Repository Repo;


        public ManagerTestsForm()
        {
            InitializeComponent();
            Repo = new();
            _testCollections = Repo.GetCollections();
            _currentCollection = _testCollections[0];
            PaintManager();
            ShowCollection(_testCollections);
            ShowTests(Repo.GetTests(_currentCollection));
        }
        private void PaintManager()
        {
            CollectionTable.Controls.Add(LogoLable, 0, 0);
            CollectionTable.Controls.Add(SearchPanel, 0, 1);
            CollectionTable.Controls.Add(ButtonConrolsPanel, 0, 2);
            CollectionTable.Controls.Add(BasisCollectionPanel, 0, 3);  
        }
        private TableLayoutPanel CreateCollectionPanel(string[] collectionPathes)
        {
            _collectionPanel = new TableLayoutPanel();
            _collectionPanel.ColumnCount = 1;
            _collectionPanel.RowCount = collectionPathes.Length + 1;
            _collectionPanel.HorizontalScroll.Maximum = 0;
            _collectionPanel.AutoScroll = true;
            _collectionPanel.Dock = DockStyle.Fill;
            _collectionPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this._collectionPanel_MouseWheel);
            
            return _collectionPanel;
        }
        private void CheckCollectionScrollbar(string[] collectionPathes)
        {
            BasisCollectionPanel.Controls.Add(CollectionScrollbar);
            CollectionScrollbar.BringToFront();
            if (_collectionPanel.VerticalScroll.Visible == true)
                CollectionScrollbar.Visible = true;
            else CollectionScrollbar.Visible = false;

            _collectionPanel.VerticalScroll.Maximum = 40 * collectionPathes.Length;
            this.CollectionScrollbar.Maximum = 40 * collectionPathes.Length;
            this.CollectionScrollbar.Minimum = _collectionPanel.VerticalScroll.Minimum;
            this.CollectionScrollbar.LargeChange = CollectionScrollbar.Maximum / CollectionScrollbar.Height + _collectionPanel.Height;
            this.CollectionScrollbar.SmallChange = CollectionScrollbar.Minimum / CollectionScrollbar.Height + _collectionPanel.Height;
            this.CollectionScrollbar.Value = Math.Abs(_collectionPanel.AutoScrollPosition.Y);
            BasisCollectionPanel.Controls.Add(_collectionPanel);
        }

        public void ShowCollection(string[] collectionPathes)
        {
            BasisCollectionPanel.Controls.Clear();

            Button button;
            _collectionPanel = CreateCollectionPanel(Repo.GetCollections());
            for (int i = 0; i < collectionPathes.Length; i++)
            {
                _collectionPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                button = AddButton(collectionPathes[i].Substring(6));
                if (_currentCollection == collectionPathes[i])
                {
                    button.BackColor = System.Drawing.Color.Gainsboro;
                }
                else button.BackColor = System.Drawing.Color.White;

                button.Click += Collection_Click;
                button.DragEnter += Collection_DragEnter;
                button.DragDrop += Collection_DragDrop;
                _collectionPanel.Controls.Add(button);
                CheckCollectionScrollbar(Repo.GetCollections());
            }
        }

        private void Collection_DragDrop(object sender, DragEventArgs e)
        {
            _currentCollection = "Tests" + "\\" + ((Button)sender).Text;
            
            File.Move(_currentTest, _currentCollection + "\\" + Repo.GetNameTest(_currentTest));
            UpdateForm();
        }

        private void Collection_DragEnter(object sender, DragEventArgs e)
        {
                e.Effect = DragDropEffects.Move;
        }

        private void _collectionPanel_MouseWheel(object? sender, MouseEventArgs e)
        {
            this.CollectionScrollbar.Value = Math.Abs(_collectionPanel.AutoScrollPosition.Y);
        }

        private Button AddButton(string text)
        {
            var button = new Button()
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Comfortaa Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
                ForeColor = System.Drawing.SystemColors.AppWorkspace,
                Margin = new Padding(0, 0, 0, 0),
                AllowDrop = true
            };
            button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            return button;
        }

        private RJButton CreateButtonTest(string text)
        {
            var rjButton = new RJButton()
            {
                Text = text,
                Cursor = Cursors.Hand,
                BackColor = System.Drawing.Color.DodgerBlue,
                BorderRadius = 20,
                BorderColor = System.Drawing.Color.White,
                Size = new System.Drawing.Size(180, 180),
                Font = new System.Drawing.Font("Exo 2 SemiBold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point),
                ForeColor = System.Drawing.Color.AliceBlue,
                Margin = new Padding(30, 30, 30, 30),
                Anchor = AnchorStyles.None
                
            };
            return rjButton;
        }

        private void Collection_Click(object? sender, EventArgs e)
        {
            MenuPanel.Visible = false;
            _currentTest = string.Empty;
            _currentCollection = "Tests" + "\\" + ((Button)sender).Text;
            PaintManager();
            ShowCollection(Repo.GetCollections());
            ShowTests(Repo.GetTests(_currentCollection));
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
            this.CollectionScrollbar.Value = Math.Abs(_collectionPanel.AutoScrollPosition.Y);
            CollectionScrollbar.Invalidate();
            Application.DoEvents();
        }

        private void Form_ResizeEnd(Object sender, EventArgs e)
        {
            ShowCollection(Repo.GetCollections());
            ShowTests(Repo.GetTests(_currentCollection));
        }
        private FlowLayoutPanel CreateTestPanel()
        {
            _testPanel = new FlowLayoutPanel();
            _testPanel.Update();
            _testPanel.MinimumSize = TestTable.MinimumSize;
            _testPanel.AutoScroll = true;
            TestScrollbar.BringToFront();
            _testPanel.Dock = DockStyle.Fill;
            _testPanel.Margin = new System.Windows.Forms.Padding(0);
            _testPanel.Padding = new System.Windows.Forms.Padding(30, 10, 30, 30);
            _testPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Test_MouseWheel);
            return _testPanel;
        }
        private void CheckTestScrollbar()
        {
            if (_testPanel.VerticalScroll.Visible == true)
            {
                TestScrollbar.Visible = true;
            }
            else
                TestScrollbar.Visible = false;
            this.TestScrollbar.Minimum = _testPanel.VerticalScroll.Minimum;
            this.TestScrollbar.Maximum = _testPanel.VerticalScroll.Maximum;
            this.TestScrollbar.LargeChange = TestScrollbar.Maximum / TestScrollbar.Height + _testPanel.Height;
            this.TestScrollbar.SmallChange = 15;
            this.TestScrollbar.Value = Math.Abs(_testPanel.AutoScrollPosition.Y);
        }
        private void ShowTests(string[] tests)
        {
            int height = 0;
           
            TestTable.Controls.Clear();
            _testPanel = CreateTestPanel();
            var buttonAddTest = CreateButtonTest("Создать тест");
            buttonAddTest.Click += AddTest_Click;
            _testPanel.Controls.Add(buttonAddTest);
            for (int i = 0; i < tests.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(tests[i]);
                var button = CreateButtonTest(fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.')));
                button.Click += Test_Click;
                button.MouseDown += Test_MouseDown; 
                _testPanel.Controls.Add(button);
                height += button.Size.Height;
            }
            TestTable.Controls.Add(_testPanel);
            CheckTestScrollbar();
        }

        private void Test_MouseDown(object? sender, MouseEventArgs e)
        {
            _currentTest = _currentCollection + "\\" + ((Button)sender).Text + ".json";
            ((RJButton)sender).DoDragDrop((DataFormats.FileDrop), DragDropEffects.Move);
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
            //currentButton = sender;
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
                string[] tests = Repo.GetTests(_currentCollection);
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
                        Repo.DeleteColection(_currentCollection);
                        CheckCollection();
                    }
                }
                else 
                {
                    Repo.DeleteColection(_currentCollection);
                    CheckCollection();
                }
            }
            else MessageBox.Show("Коллекции нет");
        }
        private void CheckCollection()
        {
            if (Repo.GetCollections().Length == 0)
            {
                MessageBox.Show("Вы удалили все коллекции, для продолжения рaботы необходимо добавить новую коллекцию");
                Hide();
                new StartForm().Show();
            }
            else
            {
                _currentCollection = Repo.GetCollections()[0];
                UpdateForm();
            }
        }
        private void UpdateForm()
        {
            ShowCollection(Repo.GetCollections());
            ShowTests(Repo.GetTests(_currentCollection));
        }
        private void DeleteTest_Click(object sender, EventArgs e)
        {
            if (File.Exists(_currentTest))
            {
                DialogResult result = MessageBox.Show($"Удалить {Repo.GetNameTest(_currentTest)} тест ?",
                     "Сообщение",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Information,
                      MessageBoxDefaultButton.Button1,
                      MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                   Repo.DeleteTest(_currentTest);
                    ShowTests(Repo.GetTests(_currentCollection));
                    _currentTest = string.Empty;
                    MenuPanel.Visible = false;
                }
            }
            else MessageBox.Show("Выберите тест");
        }

        private void AddTest_Click(object sender, EventArgs e)
        {
            DialogNameForm dialogName = new();
            dialogName.GetLabel("Введите название теста");
            dialogName.ShowDialog();
            if (!File.Exists($"{_currentCollection}\\{dialogName.newName}.json") && dialogName.newName != string.Empty)
            {
                new CreatorTestForm(dialogName.newName, $"{_currentCollection}\\{dialogName.newName}.json").ShowDialog();
                ShowTests(Repo.GetTests(_currentCollection));
            }
            else MessageBox.Show("Тест не будет создан! \n Возможные причины\n" +
                "-Нажата кнопкка отмены\n" +
                "-Не введен текст\n" +
                "-Тест с таким именем уже существует");
        }

        private void AddCollection_Click(object sender, EventArgs e)
        {
            DialogNameForm dialogName = new();
            dialogName.GetLabel("Введите название колекции в которой будут хранится тесты");
            dialogName.ShowDialog(); 
            string path = $"Tests\\{dialogName.newName}";
            if (!Directory.Exists($"{path}"))
            {
                Repo.CreateCollection(path);
                _currentCollection = path;
                UpdateForm();
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
