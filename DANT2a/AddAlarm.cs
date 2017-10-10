using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANT2a
{
  public partial class AddAlarm : Form
  {

    //constructor(s)
    public AddAlarm()
    {
      InitializeComponent();

      //init
      this.tbxName.ForeColor = SystemColors.InactiveCaption;
      this.tbxName.Text = Properties.Resources.InactiveNameTbx;
    }

    private void btnAddAlarm_Click(object sender, EventArgs e)
    {
      //problems?
      if (this.tbxName.Text.Equals(Properties.Resources.InactiveNameTbx)) {
        MessageBox.Show("No user text!", "You must set an alarm name!",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }

    //usability methods
    private void tbxName_Enter(object sender, EventArgs e)
    {
      this.tbxName.Text = "";
      this.tbxName.ForeColor = SystemColors.ActiveCaption;
    }

    private void tbxName_Leave(object sender, EventArgs e)
    {
      if (this.tbxName.Text.Equals("")) {
        this.tbxName.Text = Properties.Resources.InactiveNameTbx;
        this.tbxName.ForeColor = SystemColors.InactiveCaption;
      }
    }
  }
}
