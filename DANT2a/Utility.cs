using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANT2a {
  public class Utility {
    private static HeadsUp mainForm = (HeadsUp)Application.OpenForms[0];

    public static void fixInvalids() {
      List<EntryType.Alarm> activeAlarms = new List<EntryType.Alarm>();
      List<EntryType.Timer> activeTimers = new List<EntryType.Timer>();
      List<EntryType.Reminder> activeReminders = new List<EntryType.Reminder>();

      String ouahful = "You have at least one ";
      String ouahful2 = "";
      Boolean al = false; Boolean tm = false; Boolean rm = false; //Array, eh? :-?
      Boolean multiple = false;
      DialogResult result = new DialogResult();

      foreach (EntryType.Alarm currentAlarm in activeAlarms) {
        if (currentAlarm.IsPast()) {
          //invalid due to negative time difference
          al = true;
          break;
          //MessageBox.Show("At least one alarm is invalid due to being in the past.");
          //load EditEntry window should probably go here; it'd also be damn handy
          //to be able to go immediately to editing a particular entry, too, at this
          //point
        }
      }
      foreach (EntryType.Timer currentTimer in activeTimers) {
        if (currentTimer.Remaining.CompareTo(new TimeSpan(0)) < 0) {
          tm = true;
          break;
        }
      }
      foreach (EntryType.Reminder currentReminder in activeReminders) {
        if (currentReminder.IsPast()) {
          rm = true;
          break;
        }
      }

      if (al && tm && rm) {
        ouahful += "alarm, reminder, and timer ";
        multiple = true;
      } else if (al && tm) {
        ouahful += "alarm, and at least one timer ";
        multiple = true;
      } else if (al && rm) {
        ouahful += "alarm, and at least one reminder ";
        multiple = true;
      } else if (tm && rm) {
        ouahful += "timer, and at least one reminder ";
        multiple = true;
      } else if (al) {
        ouahful += "alarm ";
      } else if (tm) {
        ouahful += "timer ";
      } else if (rm) {
        ouahful += "reminder ";
      }
      ouahful += "with settings that need to be corrected.";
      ouahful2 = "Invalid Entr";
      if (multiple) {
        ouahful2 += "ies";
      } else {
        ouahful2 += "y";
      }

      result = MessageBox.Show(ouahful, ouahful2, MessageBoxButtons.OKCancel,
        MessageBoxIcon.Error);
      if (result == DialogResult.OK) {
        //open our edit window; eventually have this open right to the
        //entries in question
      } else {
        //scold the user, mayhaps, and then stf(y)
      }
    }


  }
}
