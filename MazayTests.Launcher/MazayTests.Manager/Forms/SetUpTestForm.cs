using MazayTests.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazayTests.Manager
{
    public partial class SetUpTestForm : Form
    {
        //InteractiveTest test
        public SetUpTestForm()
        {
            InitializeComponent();
        }

        private void SetUpTestForm_Load(object sender, EventArgs e)
        {

        }
        private void SetUpTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            new ManagerTestsForm().Show();
            Hide();
        }
    }
}
