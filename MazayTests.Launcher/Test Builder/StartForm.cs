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

namespace Test_Builder
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // Метод заглушка
        private void Start_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тест создан");
            if (!Directory.Exists("Tests"))
            {
                Directory.CreateDirectory("Tests");
                Directory.CreateDirectory("Tests/Tests1");
            }
            if (!File.Exists("Tests/Tests1/tests1.txt"))
            {
                File.Create("Tests/Tests1/tests1.txt");
            }
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
