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
    public partial class DialogNameForm : Form
    {
        public string newName;
        public DialogNameForm()
        {
            InitializeComponent();
            newName = GetName();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            GetName();
           // textBox1.Clear();
            Close();
        }
        public string GetName()
        {
            return newName = textBox1.Text;
        }
    }
}
