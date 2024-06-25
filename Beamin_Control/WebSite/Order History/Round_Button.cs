using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Beamin_Control.WebSite.Order_History
{
    public class Round_Button : Button
    {
        public string url_name;
        public Round_Button()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseOverBackColor = Color.PowderBlue;
            this.SetStyle(ControlStyles.Selectable, false);
            this.Cursor = Cursors.Hand;
           
        }


      
       



        protected override void OnCreateControl()

        {
            
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.AutoSize = true;
            this.Padding = new Padding(3,0,3,0);
            this.Margin = new Padding(3,0,3,0);



            Size ff = new Size(30,30);
          
            this.MinimumSize = ff;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;


            //if ( this.Text.Length > 10 ) { this.TextAlign = ContentAlignment.MiddleRight; }

          
        }

        protected override void OnPaint( System.Windows.Forms.PaintEventArgs e )
        {

            base.OnPaint(e);
            Rectangle Rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath GraphPath = new GraphicsPath();

            int IWidth = 30;
            int IHeight = 30;

            GraphPath.AddArc(Rect.X, Rect.Y,IWidth, IHeight, 180, 90);

            GraphPath.AddArc(Rect.X + Rect.Width - IWidth, Rect.Y, IWidth ,IHeight, 270, 90);

            GraphPath.AddArc(Rect.X + Rect.Width - IWidth, Rect.Y + Rect.Height - IHeight,IWidth, IHeight, 0, 90);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - IHeight,IWidth, IHeight, 90, 90);
            this.Region = new Region(GraphPath);


        }

        //protected override void OnLostFocus(EventArgs e)
        //{
        //    base.OnLostFocus(e);

        //    Rectangle Rect = new Rectangle(0, 0, this.Width, this.Height);
        //    GraphicsPath GraphPath = new GraphicsPath();
        //    GraphPath.AddArc(Rect.X, Rect.Y, 30, 30, 180, 90);

        //    GraphPath.AddArc(Rect.X + Rect.Width - 30, Rect.Y, 30, 30, 270, 90);

        //    GraphPath.AddArc(Rect.X + Rect.Width - 30, Rect.Y + Rect.Height - 30, 30, 30, 0, 90);
        //    GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - 30, 30, 30, 90, 90);
        //    this.Region = new Region(GraphPath);
        //}
        //protected override void OnMouseDown(MouseEventArgs mevent)
        //{
        //    base.OnMouseDown(mevent);
        //    this.BackColor = Color.Red;
        //}

        //protected override void OnDragLeave(EventArgs e)
        //{
        // is there a current drop-target node?
        //if (_dropTargetNode != null)
        //{
        //    // remove highlighting from drop target node
        //    HighlightNode(_dropTargetNode, false);
        //    SetInsertMark(_dropTargetNode, DragDropPosition.Default);
        //}

        //// clear the drop target node
        //_dropTargetNode = null;
        //_dropEffect = DragDropEffects.None;
        //_dropPosition = DragDropPosition.Default;


        //    base.OnDragLeave(e);
        //}
    }

}

