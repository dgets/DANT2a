using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANT2a {
  class FriendlyForms {

    //'constants'
    private static Color inactive = SystemColors.InactiveCaption;
    private static Color active = SystemColors.WindowText; 
    //or SystemColors.WindowText?
    private static String inactiveName = Properties.Resources.InactiveNameTbx;
    private static String inactiveReminder = 
      Properties.Resources.InactiveReminderTbx;

    public partial class Usability {

      private IAddForm addAlarmFormTbx;
      public Usability(IAddForm addAlarmFormTbx) {
        this.addAlarmFormTbx = addAlarmFormTbx;
      }

      public static void nameWipe(TextBox tbx) {
        //AddAlarm.getNameTbx();
        tbx.ForeColor = inactive;

        if (tbx.Text.Length < 3) {
          tbx.Text = inactiveName;
        }
      }

      //we should probably put the name_Click() logic here, too, but I'm
      //not really sure why it's different from name_Enter's in the first 
      //place :-?(beep)
      public static void nameEnter(TextBox tbx) {
        tbx.ForeColor = active;

        if ((tbx.Text.Equals(inactiveName)) || (tbx.Text.Length < 3)) {
          tbx.Text = "";
        }
      }
    }
  }
}
