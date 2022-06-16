using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MazayTests.Core;

namespace MazayTests.Manager
{
    public partial class StartForm : Form
    {
        DialogNameForm dialogName;
       // CreatorTestForm creatorTest;
        string pathTest;
        //ManagerTestsForm managerTests = new();
        public StartForm()
        {
            InitializeComponent();
            dialogName = new();
        }
        
        private void Start_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("Tests"))
            {
                Directory.CreateDirectory("Tests");
                CreateCollection();
            }
            else
            {
                CreateCollection();
            }
            Hide();
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
            return $"{pathTest}\\{dialogName.newName}.json";
        }
        private void CreateCollection()
        {
            dialogName.ShowDialog();
            string path = $"Tests\\{dialogName.newName}";
            if (!Directory.Exists($"{path}"))
            {
                pathTest = Directory.CreateDirectory($"{path}").FullName;
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

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
