using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DANT2a {
  public class EntryType {
    public enum Entries { Alarm, Timer, Reminder, All };

    private static HeadsUp mainForm = (HeadsUp)Application.OpenForms[0];

    [Serializable]
    public partial class Entry {
      //I guess we could put a DateTime & TimeSpan in here in order to
      //save more duplicate code when writing the extending classes, but
      //I just hate the waste of the unused fields :P
      private String name;
      private String soundBite;
      private Boolean running;

      //getters & setters
      public String Name {
        get { return name; }
        set { name = value; }
      }

      public String SoundBite {
        get { return soundBite; }
        set { soundBite = value; }
      }

      public Boolean Running {
        get { return running; }
        set { running = value; }
      }

      //methods
      public Boolean toggleRunning() {
        Debug.showDbgOut("toggleRunning(): toggling from " + running);
        running = !running;
        return running; //not sure if I'll ever use this, but why not...
      }

      public void ringRingNeo() {
        //be sure to add something to change the display in the applicable
        //CLB to reflect ringing/rung status
        //don't forget about the audio schitt, either
        this.toggleRunning();
        Debug.showDbgOut("ringRingNeo()");
        MessageBox.Show("Ring ring, Neo. . .", "Time Up!", 
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    [Serializable]
    public partial class Alarm : Entry {
      private DateTime activeAt;

      public DateTime ActiveAt {
        get { return activeAt; }
        set { activeAt = value; }
      }

      public Alarm() {
        this.Running = false;
      }
 
      public TimeSpan getInterval() {
        return (activeAt - DateTime.Now);
      }

      public Boolean isPast() {
        Debug.showDbgOut("activeAt.Date: " + activeAt.ToString() +
            "\nDateTime.Now: " + DateTime.Now.ToString());

        if (activeAt.CompareTo(DateTime.Now) <= 0) {
          Debug.showDbgOut("isPast() = true");
          return true;
        } else {
          Debug.showDbgOut("isPast() = false");
          return false;
        }
      }

      public override String ToString() {
        if (!Running) {
          return (activeAt + " - " + Name);
        } else {
          return (Name + " - " + activeAt + " - " + getInterval());
        }
      }
    }

    [Serializable]
    public partial class Timer : Entry {
      private TimeSpan duration;
      private DateTime lastTime;  //is this really necessary?
      private TimeSpan remaining;

      [XmlIgnore]
      public TimeSpan Duration {
        get { return duration; }
        set { duration = value; }
      }

      [XmlIgnore]
      public TimeSpan Remaining {
        get { return remaining;  }
        set { remaining = value; }
      }

      [XmlElement("Duration")]
      public long DurationTicks {
        get { return duration.Ticks; }
        set { duration = new TimeSpan(value); }
      }

      [XmlElement("Remaining")]
      public long RemainingTicks {
        get { return remaining.Ticks; }
        set { remaining = new TimeSpan(value); }
      }

      //methods
      public Boolean countDown() {
        //would this have less drift if I set 'nao' above the next 2 lines?
        if (lastTime.Equals(default(DateTime))) {
          remaining = duration;
        } else {
          remaining = remaining - (DateTime.Now - lastTime);
        }
        lastTime = DateTime.Now;
        if (Debug.timerDebugging) {
          Debug.showDbgOut("countDown-> remaining: " + remaining.ToString() +
            //"\n         -> isPast(): " + isPast().ToString() +
            "\n         -> duration:  " + duration.ToString() +
            "\n         -> lastTime:  " + lastTime.ToString());
        }

        if (duration.TotalSeconds <= 1) {
          return true;
        } else {
          return false;
        }
      }

      /*public Boolean isPast() {
        if (remaining.CompareTo(TimeSpan.MinValue) <= 0) {
          return true;
        }

        return false;
      }*/

      public override String ToString() {
        if (!Running) {
          return (duration + " - " + Name);
        } else {
          return (Name + " - " + remaining + " - ");
        }
      }
    }

    [Serializable]
    public partial class Reminder : Entry {
      private DateTime activeAt;
      private String reminder;

      public DateTime ActiveAt {
        get { return activeAt; }
        set { activeAt = value; }
      }

      public String Msg {
        get { return reminder; }
        set { reminder = value; }
      }

      public Boolean checkInterval() {
        if (((DateTime.Now) - activeAt).TotalSeconds > 1) {
          return true;
        } else {
          return false;
        }
      }

      public override String ToString() {
        if (!Running) {
          return (activeAt + " - " + Name);
        } else {
          return (Name + " - " + activeAt + " - " + 
            (DateTime.Now - activeAt).ToString());
        }
      }
    }

    [Serializable]
    public partial class AllEntries {
      private List<EntryType.Alarm> als;
      private List<EntryType.Timer> tms;
      private List<EntryType.Reminder> rms;

      public List<EntryType.Alarm> Als {
        get { return als; }
        set { als = value; }
      }

      public List<EntryType.Timer> Tms {
        get { return tms; }
        set { tms = value; }
      }

      public List<EntryType.Reminder> Rms {
        get { return rms; }
        set { rms = value; }
      }
    }

    public static EntryType.AllEntries constructGlob(List<Alarm> aAls, List<Timer> aTms,
                                               List<Reminder> aRms) {
      EntryType.AllEntries newGlob = new EntryType.AllEntries();

      newGlob.Als = aAls; newGlob.Tms = aTms;
      newGlob.Rms = aRms;

      return newGlob;
    }

    public static void deconstructGlob(EntryType.AllEntries readGlob) {
      mainForm.activeAlarms = readGlob.Als; mainForm.activeTimers = readGlob.Tms;
      mainForm.activeReminders = readGlob.Rms;
    }
  }
}
