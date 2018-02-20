using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DANT2a {
  public interface IAddForm {
    TextBox NameTbx {
      get;
    }
  }

  public interface IHeadsUp {
    CheckedListBox AlarmCLB {
      get;
    }

    CheckedListBox TimerCLB {
      get;
    }

    CheckedListBox ReminderCLB {
      get;
    }
  }

  public partial class HeadsUp : Form, IHeadsUp {
    //interface schiesse
    public CheckedListBox AlarmCLB {
      get { return this.clbAlarms; }
      set { this.clbAlarms = AlarmCLB;  }
    }

    public CheckedListBox TimerCLB {
      get { return this.clbTimers; }
      set { this.clbTimers = TimerCLB; }
    }

    public CheckedListBox ReminderCLB {
      get { return this.clbReminders; }
      set { this.clbReminders = ReminderCLB; }
    }

    //active lists - should these be private w/getters & setters?
    public List<EntryType.Alarm> activeAlarms =
      new List<EntryType.Alarm>();
    public List<EntryType.Timer> activeTimers = 
      new List<EntryType.Timer>();
    public List<EntryType.Reminder> activeReminders = 
      new List<EntryType.Reminder>();           

    //HeadsUp form constructor
    public HeadsUp() {
      InitializeComponent();
    }

    public void AddActiveAlarm(EntryType.Alarm newAl) {
      activeAlarms.Add(newAl);

      //trigger display update
      Display.updateDisplay(EntryType.Entries.Alarm);
    }

    public void AddActiveTimer(EntryType.Timer newTm) {
      activeTimers.Add(newTm);

      //display update
      Display.updateDisplay(EntryType.Entries.Timer);
    }

    public void AddActiveReminder(EntryType.Reminder newRe) {
      activeReminders.Add(newRe);

      //display, etc
      Display.updateDisplay(EntryType.Entries.Reminder);
    }

    //misc methods
    private void BtnAddAny_Click(object sender, EventArgs e) {
      AddWut newOne = new AddWut();
      newOne.Show();
    }

    private void BtnDbgSave_Click(object sender, EventArgs e) {
      //construct & deconstructGlob() need to be moved to EntryType
      EntryType.AllEntries theGlob = EntryType.ConstructGlob(activeAlarms, 
        activeTimers, activeReminders);

        try {
          FileIO.WriteActivesXML<EntryType.AllEntries>(FileIO.saveDataLoc, 
            theGlob);
        } catch (Exception ex) {
          Debug.ShowException("Save: " + ex.Message);
        }

        MessageBox.Show("Alarms/Timers/Reminders Saved", "Save Successful", 
          MessageBoxButtons.OK);
    }

    private void BtnDbgLoad_Click(object sender, EventArgs e) {
      try {
        EntryType.deconstructGlob(FileIO.ReadActivesXML<EntryType.AllEntries>(
          FileIO.saveDataLoc));
      } catch (Exception ex) {
        Debug.ShowException("Load: " + ex.Message);
      }

      Display.updateDisplay(EntryType.Entries.Alarm);
      Display.updateDisplay(EntryType.Entries.Timer);
      Display.updateDisplay(EntryType.Entries.Reminder);

    }

    //is this really the best place for this?
    private void BtnResetTimer_Click(object sender, EventArgs e) {
      if (clbTimers.SelectedIndices.Count == 0) {
        MessageBox.Show("You must first select timer(s) to reset!", 
          Properties.Resources.NoTimerSelectedError, MessageBoxButtons.OK,
          MessageBoxIcon.Error);
      } else {
        foreach (int idx in clbTimers.SelectedIndices) {
          activeTimers[idx].Remaining = activeTimers[idx].Duration;
        }
      }

      Display.updateDisplay(EntryType.Entries.Timer);
    }

    //not sure at this point if it would be useful to have an option to 
    //select just one type; we'll keep it generic for now
    private Boolean AnythingRunning() {
      foreach (EntryType.Alarm al in activeAlarms) {
        if (al.Running) {
          return true;
        }
      }
      foreach (EntryType.Timer tm in activeTimers) {
        if (tm.Running) {
          return true;
        }
      }
      foreach (EntryType.Reminder rm in activeReminders) {
        if (rm.Running) {
          return true;
        }
      }

      return false;
    }

    //alright, let's get down to the meat of things here.  or the tofu,
    //at least
    private void TmrGreenwichAtomic_Tick(object sender, EventArgs e) {
      if (Debug.tickDebugging) {
        Debug.ShowDbgOut("_Tick():");
      }

      if (!AnythingRunning()) {
        if (Debug.tickDebugging) {
          Debug.ShowDbgOut("  --> anythingRunning() sez false; disabling tmr");
        }

        tmrGreenwichAtomic.Enabled = false;
        return;
      }

      if (Debug.tickDebugging) {
        Debug.ShowDbgOut("  -> anythingRunning() == true");
      }

      //tick code now (obviously) resides in Utility.*Tick()
      Utility.alarmTick(activeAlarms);
      Utility.timerTick(activeTimers);
      Utility.reminderTick(activeReminders);
    }

    //put this in a more logical location, verify that other methods are
    //grouped reasonably, as well
    private void AlarmCLB_ItemCheck(Object sender, ItemCheckEventArgs e) {
      if (!activeAlarms.ElementAt(e.Index).Running &&
          activeAlarms.ElementAt(e.Index).IsPast()) {
        MessageBox.Show("Alarm cannot be in the past!", "Alarm Already Passed",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
        AlarmCLB.SetItemCheckState(e.Index, CheckState.Unchecked);
        return;
      }

      activeAlarms.ElementAt(e.Index).Running = 
        activeAlarms.ElementAt(e.Index).ToggleRunning();
      if (activeAlarms.ElementAt(e.Index).Running) {
        if (!tmrGreenwichAtomic.Enabled) {
          if (Debug.tickDebugging) {
            Debug.ShowDbgOut("Starting Greenwich Atomic");
          }

          tmrGreenwichAtomic.Enabled = true;
          tmrGreenwichAtomic.Start();
        }
      }
    }

    private void ReminderCLB_ItemCheck(Object sender, ItemCheckEventArgs e) {
      if (activeReminders.ElementAt(e.Index).ActiveAt.CompareTo(
            DateTime.Now) <= 0) {
        MessageBox.Show("Reminder cannot be in the past!", 
          "Reminder Already Passed", MessageBoxButtons.OK, 
          MessageBoxIcon.Error);
        ReminderCLB.SetItemCheckState(e.Index, CheckState.Unchecked);
        return;
      }

      activeReminders.ElementAt(e.Index).Running = true;
        //activeReminders.ElementAt(e.Index).ToggleRunning();
      if (activeReminders.ElementAt(e.Index).Running  && 
          !tmrGreenwichAtomic.Enabled) {
        if (Debug.tickDebugging) {
          Debug.ShowDbgOut("Starting Greenwich Atomic");
        }

        tmrGreenwichAtomic.Enabled = true;
        tmrGreenwichAtomic.Start();
      }
    }

    private void timerCLB_ItemCheck(Object sender, ItemCheckEventArgs e) {
      activeTimers.ElementAt(e.Index).Running = true;
      //if (activeTimers.ElementAt(e.Index).Running) {
        if (!tmrGreenwichAtomic.Enabled) {
          if (Debug.tickDebugging) {
            Debug.ShowDbgOut("Starting Greenwich Atomic");
          }
          tmrGreenwichAtomic.Enabled = true;
          tmrGreenwichAtomic.Start();
        }
      //}

      //UpdateDisplay(EntryType.Entries.Timer);
    }

    private void BtnDbgWipe_Click(object sender, EventArgs e) {
      //confirm wiping the old one, first
      if (File.Exists(FileIO.saveDataLoc)) {
        if (MessageBox.Show("Do you want to delete the save file?", 
              "Confirm savefile deletion!", MessageBoxButtons.YesNo) ==
              DialogResult.Yes) {
          //hose it
          try {
            File.Delete(FileIO.saveDataLoc);
          } catch (Exception) {
            MessageBox.Show("Exception trying to delete!", "Can't delete!",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
          }

          activeAlarms.Clear(); activeTimers.Clear(); activeReminders.Clear();
          AlarmCLB.Items.Clear(); TimerCLB.Items.Clear();
          ReminderCLB.Items.Clear();
        } else {
          MessageBox.Show("Letting savefile live.  Maybe it was never there" +
            " to begin with...  Do you think that's air you're breathing?",
            "Not killing existing savefile", MessageBoxButtons.OK, 
            MessageBoxIcon.Information);
        }

        MessageBox.Show("Alarms/Timers/Reminders Wiped", "Wipe Successful", 
          MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void BtnEditAlarm_Click(object sender, EventArgs e) {
      if (AlarmCLB.SelectedIndex != -1) {
        EditEntry editEntry = new EditEntry();
        editEntry.Show();
      } else {
        //nothing selected, error between floor & keyboard
        MessageBox.Show("You must select an entry to edit!", "Select Entry",
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void BtnEditReminder_Click(object sender, EventArgs e) {
      if (ReminderCLB.SelectedIndex != -1) {
        EditEntry editEntry = new EditEntry();
        editEntry.Show();
      } else {
        MessageBox.Show("You must select an entry to edit!", "Select Entry",
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void BtnEditTimer_Click(object sender, EventArgs e) {
      if (TimerCLB.SelectedIndex != -1) {
        EditEntry editEntry = new EditEntry();
        editEntry.Show();
      } else {
        MessageBox.Show("You must select an entry to edit!", "Select Entry",
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    //there's a better way to handle the *SelectedChange() methods here;
    //one method should be able to handle everything based
    private void AlarmSelectedChange(object sender, EventArgs e) {
      if ((TimerCLB.SelectedIndex != -1) || 
          (ReminderCLB.SelectedIndex != -1)) {
        TimerCLB.ClearSelected(); ReminderCLB.ClearSelected();
      }
    }

    private void ReminderSelectedChange(object sender, EventArgs e) {
      if ((AlarmCLB.SelectedIndex != -1) ||
          (TimerCLB.SelectedIndex != -1)) {
        AlarmCLB.ClearSelected(); TimerCLB.ClearSelected();
      }
    }

    private void TimerSelectedChange(object sender, EventArgs e) {
      if ((AlarmCLB.SelectedIndex != -1) ||
          (ReminderCLB.SelectedIndex != -1)) {
        AlarmCLB.ClearSelected(); ReminderCLB.ClearSelected();
      }
    }
  }
}
