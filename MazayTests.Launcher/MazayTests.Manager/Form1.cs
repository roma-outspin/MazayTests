﻿using System.Windows.Forms;

namespace MazayTests.Manager
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
            panel1.AllowDrop = true;
            panel2.AllowDrop = true;

            panel1.DragEnter += panel_DragEnter;
            panel2.DragEnter += panel_DragEnter;

            panel1.DragDrop += panel_DragDrop;
            panel2.DragDrop += panel_DragDrop;

            button1.MouseDown += button1_MouseDown;
        }

        void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.DoDragDrop(button1, DragDropEffects.Move);
        }

        void panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void panel_DragDrop(object sender, DragEventArgs e)
        {
            ((RJButton)e.Data.GetData(typeof(RJButton))).Parent = (Panel)sender;
        }
    }
}
