﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace MazayTests.Manager
{
    class RJToggleButton:CheckBox
    {
        private Color onBackColor = Color.MediumSlateBlue;
        private Color offBackColor = Color.Gray;
        

        public Color OnBackColor
        {
            get
            {
               return onBackColor;
            }
            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }
           
        public Color OffBackColor
        {
            get 
            {
               return offBackColor; 
            }
            set
            {
                offBackColor = value;
                this.Invalidate();
            }
        }

        public RJToggleButton()
        {
            this.MinimumSize = new Size(45,22);
        }
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if(this.Checked) //on
            {
                pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                //toggle
                //pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                //    new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else //off
            {
                pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                //toggle
                //pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                //    new Rectangle(2, 2, toggleSize, toggleSize));
            }

        }


    }
}
