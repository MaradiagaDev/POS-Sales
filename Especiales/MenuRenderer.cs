﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NeoCobranza.Especiales
{
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        //Campos
        private Color primaryColor;
        private Color textColor;
        private int arrowThickness;

        //Constructo

        public MenuRenderer( bool isMainMenu,Color primaryColor, Color textColor):base(new MenuColorTable(isMainMenu,primaryColor))
        {
            this.primaryColor = primaryColor;
            this.textColor = textColor;
            if (isMainMenu) arrowThickness = 3;
            else arrowThickness = 2;
        }

        //Anulaciones
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            e.Item.ForeColor = e.Item.Selected ? Color.White : textColor;
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            base.OnRenderArrow(e);
            // Campos

            var graph = e.Graphics;
            var arrowSize = new Size(4,11);
            var arrowColor = e.Item.Selected ? Color.White : primaryColor;
            var rect = new Rectangle(e.ArrowRectangle.Location.X,(e.ArrowRectangle.Height-arrowSize.Height)/2,arrowSize.Width,arrowSize.Height);
            using (GraphicsPath path = new GraphicsPath()) 
            using (Pen pen = new Pen(arrowColor, arrowThickness))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rect.Left,rect.Top,rect.Right,rect.Top+ rect.Height/2);
                path.AddLine(rect.Right, rect.Top + rect.Height / 2,rect.Left,rect.Top+rect.Height);
                graph.DrawPath(pen,path);
            }
        }

        //Final de las anulaciones
    }
}
