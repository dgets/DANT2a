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
          mainForm.AlarmCLB.Items.Clear();

          //swap this gross for loop out for a foreach like is done for
          //timer entries immediately below
          //or better yet, modularize
          for (int cntr2 = 0; cntr2 < activeAlarms.Count; cntr2++) {
            //switch the above to a 'for' loop & remove cntr++ below
            EntryType.Alarm al = activeAlarms[cntr2];

            if (al.Running) {
              if (!al.IsPast()) {
                updateEntry(EntryType.Entries.Alarm, cntr2);
              } else {
                if (Debug.tickDebugging && Debug.alarmDebugging) {
                  Debug.ShowDbgOut("Toggling alarm #" + cntr2.ToString());
                }

                al.ToggleRunning();
              }
            } else {
              mainForm.AlarmCLB.Items.Add(al.ActiveAt + " - " + al.Name, false);
            }
          }
          break;

        case EntryType.Entries.Timer:
          mainForm.TimerCLB.Items.Clear();

          foreach (EntryType.Timer tm in activeTimers) {
            if (tm.Running && (tm.Remaining > new TimeSpan(0))) {
              //clbTimers.Items.Add(tm.Remaining + " - " + tm.Name, true);
              updateEntry(EntryType.Entries.Timer,
                activeTimers.IndexOf(tm));
            } else if (tm.Running && (tm.Remaining <= new TimeSpan(0))) {
              tm.RingRingNeo();
            } else {
              mainForm.TimerCLB.Items.Add(tm.Remaining + " - " + tm.Name, false);
            }
          }
          break;

        case EntryType.Entries.Reminder:
          mainForm.ReminderCLB.Items.Clear();

          foreach (EntryType.Reminder rm in activeReminders) {
            if (rm.Running && (!rm.CheckInterval())) {
              updateEntry(EntryType.Entries.Reminder,
                activeReminders.IndexOf(rm));
            } else if (!rm.Running) {
              mainForm.ReminderCLB.Items.Add(rm.ActiveAt + " - " + rm.Name, false);
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
          mainForm.AlarmCLB.Items.Add(mainForm.activeAlarms[curr].ToString(), true);
          mainForm.AlarmCLB.Show();
          break;
        case EntryType.Entries.Timer:
          mainForm.TimerCLB.Items.Add(mainForm.activeTimers[curr].ToString(), true);
          mainForm.TimerCLB.Show();
          break;
        case EntryType.Entries.Reminder:
          mainForm.ReminderCLB.Items.Add(mainForm.activeReminders[curr].ToString(), true);
          mainForm.ReminderCLB.Show();
          break;
        default:
          //ouah
          break;
      }
    }
  }
}
