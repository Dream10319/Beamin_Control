using System;
using System.Drawing;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Boss_Notice
{
    public partial class New_Boss_Notice_frm : Form
    {

        public  void Apply_Language()
        {
            this.checkBox1.Text = Program.Language.De[23000];
            this.label1.Text = Program.Language.De[23001];
            this.label2.Text = Program.Language.De[23002];
            this.button1.Text = Program.Language.De[23003];

            this.button2.Text = $"{Program.Language.De[23004]} ({this.Images_list.Controls.Count} {Program.Language.De[23005]} 3)";


        }

        public New_Boss_Notice_frm()
        {
            InitializeComponent();
            this.Images_list.ControlAdded += Images_list_ControlChanged;
            this.Images_list.ControlRemoved += Images_list_ControlChanged;
        }

        private void button1_Click( object sender, EventArgs e )
        {
            if(Images_list.Controls.Count > 0 || !string.IsNullOrEmpty (this.textBox1.Text) )
            {
                this.DialogResult = DialogResult.OK;

            }

        }

        private  void button2_Click( object sender, EventArgs e )
        {

            OpenFileDialog of = new OpenFileDialog()
            {
                Filter = "Images|*.PNG;*.JPG;*.GIF",
            };

            if(of.ShowDialog () == DialogResult.OK )
            {
             


                PictureBox px = new PictureBox();
                px.LoadAsync(of.FileName);
                px.WaitOnLoad = true;
                

                px.SizeMode = PictureBoxSizeMode.StretchImage;
                px.Size = new Size(Images_list.Height, Images_list.Height);


                Button delete_btn = new Button() { AutoSize = true, Text = "X", ForeColor = Color.Red 
                    , FlatStyle = FlatStyle.Flat, AutoSizeMode = AutoSizeMode.GrowAndShrink, Cursor = Cursors.Hand  };
                delete_btn.BackColor = Color.Transparent;

                delete_btn.Click += ( ss, ee ) => { this.Images_list.Controls.Remove(px); }; 
                px.Controls.Add(delete_btn );
                delete_btn.Location = new Point(px.Width - (delete_btn.Width + 3 )  , 0);


                this.Images_list.Controls.Add(px);
            }

        }

        private void Images_list_ControlChanged( object sender, ControlEventArgs e )
        {
            if(this.Images_list.Controls.Count < 3 )
            {
                this.button2.Enabled = true;
            }
            else
            {
                this.button2.Enabled = false;
            }

            this.button2.Text =$"{Program.Language.De[23004]} ({this.Images_list.Controls.Count} {Program.Language.De[23005]} 3)";
        }

        private void New_Boss_Notice_frm_Load(object sender, EventArgs e)
        {

        }
    }
}
