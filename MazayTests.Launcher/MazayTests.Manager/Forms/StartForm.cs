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
        ManagerTestsForm managerTests = new();
        public StartForm()
        {
            InitializeComponent();
        }
        
        private void Start_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("Tests"))
            {
                Directory.CreateDirectory("Tests");
                managerTests.ShowCreatorTest();
            }
            Hide();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
