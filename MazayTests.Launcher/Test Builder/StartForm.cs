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

namespace ManagerTests
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }
        // Метод заглушка
        private void Start_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("Tests"))
            {
                Directory.CreateDirectory("Tests");
                Directory.CreateDirectory("Tests/Tests1");
            }
            if (!File.Exists("Tests/Tests1/tests1.txt"))
            {
                File.Create("Tests/Tests1/tests1.txt");
            }
            MessageBox.Show("Тест создан");
            Close();
        }
        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
