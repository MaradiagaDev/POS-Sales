using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Controladores
{
    [DefaultEvent("_TextChanged")]
    public partial class LoginUserControl : UserControl
    {
        // Variables para el entorno
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underLineFlat = false;
        private Color borderFocusColor = Color.HotPink;
        private bool isFocus = false;
        private int borderRadius=0;


        private Color placeHolderColor = Color.DarkGray;
        private string placeHolderText = "";
        private bool isPlaceHolder = false;
        private bool isPasswordchard = false;
        //Constructor
        public LoginUserControl()
        {
            InitializeComponent();
        }
        public event EventHandler _TextChanged;


        //Properties

        [Category("Sobreescritura Nueva")]
        public Color BorderColor {
            get => borderColor;

            set { borderColor = value;
                this.Invalidate();
            }
        }
        public int BorderSize { get => borderSize;

            set { borderSize = value;
                this.Invalidate();
            }
        }
        public bool UnderLineFlat { get => underLineFlat;

            set { underLineFlat = value;
                this.Invalidate();
            } }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if(borderRadius > 1)
            {
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth,-borderSize,-borderSize);

                int smoothSize = borderSize>0 ? borderSize :1 ;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius)) 
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize)) 
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize)) 
                using (Pen PenBorder = new Pen(borderColor, borderSize))
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        this.Region = new Region( pathBorderSmooth);
                        if (borderRadius > 15) SetTextBoxRedoundedRegion();
                        graph.SmoothingMode = SmoothingMode.AntiAlias;
                        penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                        if (isFocus)
                        {
                            penBorder.Color = borderFocusColor;

                        }
                        if (underLineFlat)
                        {
                            graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                            graph.SmoothingMode = SmoothingMode.None;
                            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                        }
                        else
                        {
                            graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                            graph.DrawPath(penBorder,pathBorder);
                        }
                    }

                }

            }
            else
            {

                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (!isFocus)
                    {

                        if (underLineFlat) // Line Style
                            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                        else //Border Style
                            graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                    }
                    else
                    {
                        penBorder.Color = borderFocusColor;
                        if (underLineFlat) // Line Style
                            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                        else //Border Style
                            graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                    }
                }

            }
        }

        private void SetTextBoxRedoundedRegion()
        {
            GraphicsPath pathTxt;
            if (Multilinea)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, BorderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else 
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderSize*2);
                textBox1.Region = new Region(pathTxt);
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float cursiveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X,rect.Y,cursiveSize,cursiveSize,180,90);
            path.AddArc(rect.Right - cursiveSize,rect.Y,cursiveSize,cursiveSize,270,90);
            path.AddArc(rect.Right- cursiveSize, rect.Bottom-cursiveSize,cursiveSize,cursiveSize,0,90);
            path.AddArc(rect.X,rect.Bottom-cursiveSize,cursiveSize,cursiveSize,90,90);
            path.CloseFigure();
            return path;



        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(this.DesignMode)
            UpdateControlHeigth();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeigth();
        }

        public bool PasswordChar
        {
            get { return isPasswordchard; }
            set {
                isPasswordchard = value; 
                textBox1.UseSystemPasswordChar = value; }
        }
        public void clear()
        {
            textBox1.Clear();
        }

        
        public bool Multilinea
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }

        }
        public override Color BackColor 
        { get => base.BackColor;
            set 
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        public string Texts 
        {
            get {
                if (isPlaceHolder)
                {
                    return "";
                }else {
                    return textBox1.Text;
                } }
            //base.Text = value
            set
            {
                base.Text = value;
                SetPlaceHolder();
            }
        }

        public string Set(String entrada)
        {
            return textBox1.Text+entrada;
        }

        public override Color ForeColor 
        { get => base.ForeColor;
            set { base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        public override Font Font 
        { get => base.Font;
            set { base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    UpdateControlHeigth();
            } }

        public Color BorderFocusColor 
        { get => borderFocusColor; set => borderFocusColor = value; }
        public int BorderRadius { get => borderRadius;
            set {
                if(value>=0)
                { borderRadius = value;
                    this.Invalidate();
                }
                
            
            }
        }

        public Color PlaceHolderColor { get => placeHolderColor; set { placeHolderColor = value;
                if (isPasswordchard)
                    textBox1.ForeColor = value;
            
            } }
        public string PlaceHolderText { get => placeHolderText; set { placeHolderText = value;
                textBox1.Text = "";
                SetPlaceHolder();
            } }

        private void SetPlaceHolder()
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text)&&placeHolderText != "")
            {
                isPlaceHolder = true;
                textBox1.Text = placeHolderText;
                textBox1.ForeColor = placeHolderColor;
                if (isPasswordchard)
                    textBox1.UseSystemPasswordChar = false;
            }
        }
        private void RemovePlaceHolder()
        {
            if (isPlaceHolder && placeHolderText != "")
            {
                isPlaceHolder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordchard)
                    textBox1.UseSystemPasswordChar = true;
            }

        }
        //Altura adecuada y restringir el cambio
        private void UpdateControlHeigth()
        {
           if(textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text",this.Font).Height+1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0,txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }


        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
        
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocus = true;
            this.Invalidate();
            RemovePlaceHolder();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocus = false;
            this.Invalidate();
            SetPlaceHolder();
        }
    }
}
