using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANT2a {
  class Display {
    private static HeadsUp mainForm =
      (HeadsUp)Application.OpenForms[0];

    public static void updateDisplay(EntryType.Entries eType) {
      List<EntryType.Alarm> activeAlarms = new List<EntryType.Alarm>();
      List<EntryType.Timer> activeTimers = new List<EntryType.Timer>();
      List<EntryType.Reminder> activeReminders = new List<EntryType.Reminder>();

      activeAlarms = mainForm.activeAlarms;
      activeTimers = mainForm.activeTimers;
      activeReminders = mainForm.activeReminders;

      switch (eType) {
        case EntryType.Entries.Alarm:
          mainForm.alarmCLB.Items.Clear();

          //swap this gross for loop out for a foreach like is done for
          //timer entries immediately below
          //or better yet, modularize
          for (int cntr2 = 0; cntr2 < activeAlarms.Count; cntr2++) {
            //switch the above to a 'for' loop & remove cntr++ below
            EntryType.Alarm al = activeAlarms[cntr2];

            if (al.Running) {
              if (!al.isPast()) {
                updateEntry(EntryType.Entries.Alarm, cntr2);
              } else {
                if (Debug.tickDebugging && Debug.alarmDebugging) {
                  Debug.showDbgOut("Toggling alarm #" + cntr2.ToString());
                }

                al.toggleRunning();
              }
            } else {
              mainForm.alarmCLB.Items.Add(al.ActiveAt + " - " + al.Name, false);
            }
          }
          break;

        case EntryType.Entries.Timer:
          mainForm.timerCLB.Items.Clear();

          foreach (EntryType.Timer tm in activeTimers) {
            if (tm.Running && (tm.Remaining > new TimeSpan(0))) {
              //clbTimers.Items.Add(tm.Remaining + " - " + tm.Name, true);
              updateEntry(EntryType.Entries.Timer,
                activeTimers.IndexOf(tm));
            } else if (tm.Running && (tm.Remaining <= new TimeSpan(0))) {
              tm.ringRingNeo();
            } else {
              mainForm.timerCLB.Items.Add(tm.Remaining + " - " + tm.Name, false);
            }
          }
          break;

        case EntryType.Entries.Reminder:
          mainForm.reminderCLB.Items.Clear();

          foreach (EntryType.Reminder rm in activeReminders) {
            if (rm.Running && (!rm.checkInterval())) {
              updateEntry(EntryType.Entries.Reminder,
                activeReminders.IndexOf(rm));
            } else if (!rm.Running) {
              mainForm.reminderCLB.Items.Add(rm.ActiveAt + " - " + rm.Name, false);
            }
          }
          break;
      }

    }

    //display update methods - this (and the related ToString() methods,
    //are going to almost certainly be replacing the above update*() method
    //at least where it contains the switch/case logic
    public static void updateEntry(EntryType.Entries whichType, int curr) {
      switch (whichType) {
        case EntryType.Entries.Alarm:
          mainForm.alarmCLB.Items.Add(mainForm.activeAlarms[curr].ToString(), true);
          mainForm.alarmCLB.Show();
          break;
        case EntryType.Entries.Timer:
          mainForm.timerCLB.Items.Add(mainForm.activeTimers[curr].ToString(), true);
          mainForm.timerCLB.Show();
          break;
        case EntryType.Entries.Reminder:
          mainForm.reminderCLB.Items.Add(mainForm.activeReminders[curr].ToString(), true);
          mainForm.reminderCLB.Show();
          break;
        default:
          //ouah
          break;
      }
    }
  }
}
