using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaHelper
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            BackColor = Color.FromArgb(20, 30, 42);
            Font = new Font("Roboto", 10, FontStyle.Regular);
            Icon = new Icon(@"D://helper.ico");
        }
    }
}
