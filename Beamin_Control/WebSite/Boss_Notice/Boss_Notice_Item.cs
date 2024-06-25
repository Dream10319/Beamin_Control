using System;
using System.Drawing;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Boss_Notice
{
    public partial class Boss_Notice_Item : UserControl
    {
        public Boss_Notice_Item()
        {
            InitializeComponent();
        }


        public bool _Display = false;
        private int Child_Index;

        Label alert;

        public bool Display
        {
            get {
                return _Display;
            }
            set {

                _Display = value;

                this.Invoke(new Action(() =>
                {
                    FlowLayoutPanel main_pn = (FlowLayoutPanel)this.Parent;


                    if ( value == true )
                    {

                        this.Upload_btn.Text = "Get out of app";
                        this.Margin  = new Padding(3, 3, 3, 20);

                        Child_Index = main_pn.Controls.GetChildIndex(this);
                        main_pn.Controls.SetChildIndex(this, 0);

                         alert =  new Label()
                        {
                            AutoSize = true,
                            Text = "Notice",
                            Name = "alert",
                            ForeColor  = Color.LawnGreen
                        } ;

                        this.flowLayoutPanel1.Controls.Add(alert);
                        this.flowLayoutPanel1.Controls.SetChildIndex(alert, 0);

                    }
                    else
                    {
                        this.Upload_btn.Text = "upload to app";
                        this.Margin = new Padding(3, 3, 3, 3);

                        if ( this.flowLayoutPanel1.Controls.Contains(alert))
                        {
                            this.flowLayoutPanel1.Controls.Remove(alert);
                        }

              

                    }
                }));

            
            }
        }
      
      

    
    }
}
