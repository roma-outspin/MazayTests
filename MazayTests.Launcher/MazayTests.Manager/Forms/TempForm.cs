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
    public partial class TempForm : Form
    {
        public TempForm()
        {
            InitializeComponent();
            TestListLayout.FlowDirection = FlowDirection.TopDown;
            TestListLayout.Controls.Add(GetPanel("новый текст"));
            TestListLayout.Controls.Add(GetPanel("новый текст1"));
            TestListLayout.Controls.Add(GetPanel("новый текст2"));
        }
        private Panel GetPanel(string name)
        {
            Panel panel = new();
            panel.Dock = DockStyle.Top;
            Label label = new();
            label.Font = new Font(FontFamily.GenericMonospace, 16);
            label.Text = name;
            label.Dock = DockStyle.Top;
            panel.Controls.Add(label);
            return panel;
        }

        private void TempForm_Load(object sender, EventArgs e)
        {

        }
    }
}
