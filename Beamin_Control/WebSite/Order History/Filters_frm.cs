﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Order_History
{
    public partial class Filters_frm : Form
    {
        public Filters_frm()
        {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
