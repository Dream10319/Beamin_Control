using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.Controls
{
    public partial class Rider_ProgressBar: ProgressBar
    {
        public string Rider_Assignment_Time = "...";
        public string Pickup_Complete_Time = "...";

        public  Rider_ProgressBar()
        {


            this.SetStyle (ControlStyles.OptimizedDoubleBuffer, true);  
            this.Style = ProgressBarStyle.Blocks;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.WhiteSmoke;
           
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            int valueWidth = (int)((float)this.Value / this.Maximum * this.Width);

            Brush Rider_Assignment_Complete_Color = Brushes.SlateGray;
            Brush Pickup_Complete_Color = Brushes.SlateGray;
            Brush Delivered_Color = Brushes.SlateGray;

            //Rectangle rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            //rectangle.Inflate(-30, -30); // Adjust for the border


            e.Graphics.DrawLine(new Pen(Brushes.SlateGray, 5), 0, (this.Height) / 2, this.Width, (this.Height) / 2);

            e.Graphics.DrawLine(new Pen(Brushes.DeepSkyBlue, 5), 0, (this.Height) / 2, valueWidth, (this.Height) / 2);

         

      


            if (valueWidth >= 50)
            {
                Rider_Assignment_Complete_Color = Brushes.DeepSkyBlue;
            }

            if (valueWidth >= (this.Width - 15) / 2)
            {
                Pickup_Complete_Color = Brushes.DeepSkyBlue;
            }

            if (valueWidth >= (this.Width - 50))
            {
                Delivered_Color = Brushes.DeepSkyBlue;
            }

            StringFormat SFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.NoFontFallback,
                LineAlignment = StringAlignment.Far,
            };
            SFormat.Trimming = StringTrimming.EllipsisCharacter;




            e.Graphics.DrawString(Rider_Assignment_Time, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50,20, SFormat);
            e.Graphics.DrawString(Pickup_Complete_Time, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, (this.Width) / 2, 20, SFormat);




            e.Graphics.FillEllipse(Rider_Assignment_Complete_Color, 50, (this.Height - 15) / 2, 15, 15);
            e.Graphics.FillEllipse(Pickup_Complete_Color, (this.Width - 15) / 2, (this.Height - 15) / 2, 15, 15);
            e.Graphics.FillEllipse(Delivered_Color, (this.Width - 50), (this.Height - 15) / 2, 15, 15);



            string ss = "Rider Assignment Complete";

            Font Font = new Font("Arial", 12, FontStyle.Bold);
            e.Graphics.DrawString(ss, Font, Rider_Assignment_Complete_Color, 12, (this.Height - 15), new StringFormat()
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });


            string ss2 = "Pickup Complete";
    
            e.Graphics.DrawString(ss2, Font, Pickup_Complete_Color, this.Width / 2, (this.Height - 15), new StringFormat()
            {
                Alignment = StringAlignment.Center ,
                LineAlignment = StringAlignment.Center
            });


            string ss3 = "Delivered";
            e.Graphics.DrawString(ss3, Font, Delivered_Color, this.Width-15, (this.Height - 15), new StringFormat()
            {
                Alignment = StringAlignment.Far  ,
                LineAlignment = StringAlignment.Center
            });



            //e.Graphics.DrawString(ss2, Font, Brushes.Black,( this.Width /2), (this.Height - 15), SFormat);
            //e.Graphics.DrawString("Pickup Complete", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, (this.Width) / 2, (this.Height - 15), SFormat);
            //e.Graphics.DrawString("Delivered", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, (this.Width - 50), (this.Height - 15), SFormat);
            //Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            //rect.Inflate(-3, -3);

       //     GraphicsPath path = new GraphicsPath();

       //     path.AddString(ss, Font.FontFamily, 0, 12, new PointF(10, 70), 
       //         new StringFormat() { Alignment = StringAlignment.Near   ,
       //          LineAlignment = StringAlignment.Center
       //         } );


       //     path.AddString(ss2, Font.FontFamily, 0, 12, new PointF((this.Width /2), 70),
       //new StringFormat()
       //{
       //    Alignment = StringAlignment.Center,
       //    LineAlignment = StringAlignment.Center
       //});
            //pa
            //th.AddString(ss2, Font.FontFamily, 0 , 12,new PointF(200,70), SFormat);

            //e.Graphics.DrawPath(new Pen(Brushes.Black ,1),path);

            
     
            
            //e.Graphics.DrawString("Tesdfdfdfdfddfdfdfdt test", new Font("Arial", 10), Brushes.Black, rect, SFormat);


            //DrawCircle(e.Graphics);
        }



        
        //private void DrawCircle(Graphics g)
        //{
        //    // Calculate the rectangle to fit the circle inside the progress bar
        //    Rectangle rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

        //    // Adjust rectangle if there's a border
        //    if (ProgressBarRenderer.IsSupported)
        //    {
        //        rectangle.Inflate(-3, -3); // Adjust for the border
        //    }
        //    else
        //    {
        //        rectangle.Inflate(-1, -1); // Adjust for the border
        //    }

        //    // Calculate the position and size of the circle based on the current value of the progress bar
        //    int valueWidth = (int)((float)this.Value / this.Maximum * this.Width);
        //    int diameter = Math.Min(valueWidth, this.Height);

        //    // Draw the circle
        //    g.DrawEllipse(Pens.Red, 0, 0, diameter, diameter);
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    Graphics g = e.Graphics;

        //    // Specify pen color and thickness
        //    Pen pen = new Pen(Color.Red, 6);

        //    // Calculate the center and radius of the circle
        //    int centerX = this.Width / 2;
        //    int centerY = this.Height / 2;
        //    int radius = Math.Min(this.Width, this.Height) / 4;

        //    // Draw the circle
        //    //g.DrawEllipse(pen, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
        //    g.DrawEllipse(pen, 10,20,30,40);
        //}
    }
}
