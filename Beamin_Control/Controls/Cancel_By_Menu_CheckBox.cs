using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.Controls
{
    public  class Cancel_By_Menu_CheckBox:CheckBox
    {

        public int foodSeq;
        public string foodName;
        public string Check_Type;

        public Cancel_By_Menu_CheckBox(int _foodSeq , string _foodName, string  _Check_Type )
        {
            foodSeq = _foodSeq;
            foodName = _foodName;
            Check_Type = _Check_Type;
            this.Text = _foodName;
        }
    }
}
