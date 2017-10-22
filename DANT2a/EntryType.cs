using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANT2a {
  public class EntryType {
    public enum Entries { Alarm, Timer, Reminder, All };
    //we're going to need an actual array of the Alarm/Timer/Reminder
    //objects themselves, not goddamned strings
    /*public static string[] types = 
      new string[] { "Alarm", "Timer", "Reminder" };*/

    public partial class Alarm {
      private String name;
      private DateTime activeAt;
      private String soundBite;
      private Boolean running;

      //getters & setters
      public String Name {
        get { return name; }
        set { name = value; }
      }

      public DateTime ActiveAt {
        get { return activeAt; }
        set { activeAt = value; }
      }

      public String SoundBite {
        get { return soundBite; }
        set { soundBite = value; }
      }

      public Boolean Running {
        get { return running; }
        set { running = value; }
      }

      //constructors
      /*public Alarm(String n, DateTime act, String sb) {
        Name = n;
        ActiveAt = act;
        SoundBite = sb;
        Running = false;
      }*/

      public Alarm() {

        this.Running = false;
      }

      //methods
      public Boolean toggleRunning() {
        running = !running;
        return running;
      }

      //rename to 'getInterval' & return TimeSpan instead for more general
      //usage, mayhaps (public)
      private Boolean checkInterval() {
        DateTime nao = DateTime.Now;

        if ((activeAt - DateTime.Now).Duration().TotalSeconds <= 1) {
          return true;
        } else {
          return false;
        }
      }

      public TimeSpan getInterval() {
        return (activeAt - DateTime.Now);
      }

      public Boolean isPast() {
        DateTime nao = DateTime.Now;

        if (activeAt.Date <= nao) {
          return true;
        } else {
          return false;
        }
      }
      
      private void updateDisplay() {
        HeadsUp mommy = (HeadsUp) Form.ActiveForm;

        for (int cntr = 0; cntr < HeadsUp.activeAlarms.Count; cntr++) {
          if (HeadsUp.activeAlarms.ElementAt(cntr).running) {
            mommy.updateEntry(EntryType.Entries.Alarm, cntr);
          }
        }
      }

      public override String ToString() {
        if (!running) {
          return (activeAt + " - " + name);
        } else {
          return (name + " - " + activeAt + " - " + getInterval());
        }
        
          /*else if (!isPast()) {
          return (activeAt + " - " + name + " - " + getInterval());
        } else if (checkInterval()) {
          return (name + " Ring ring, Neo " + activeAt);
        } else {
          return (getInterval() + " -+=*" + name + "*=+- " +
            "Ring ring, Neo; alarm in past . . .");
        }*/
      }
    }

    public partial class Timer {
      private String name;
      private TimeSpan duration;
      //private TimeSpan currentCount;
      private Boolean running;
      private DateTime lastTime;  //is this really necessary?
      private TimeSpan remaining;
      private String soundBite;

      //getters & setters
      public String Name {
        get { return name; }
        set { name = value; }
      }

      public TimeSpan Duration {
        get { return duration; }
        set { duration = value; }
      }

      public Boolean Running {
        get { return running; }
        set { running = value; }
      }

      private String SoundBite {
        get { return soundBite; }
        set { soundBite = value; }
      }

      public TimeSpan Remaining {
        get { return remaining;  }
        set { remaining = value; }
      }

      //constructor(s)
      public Timer(String n, TimeSpan d, String sb) {
        this.Name = n;
        this.Duration = d;
        this.Running = false;
        this.SoundBite = sb;
      }

      public Timer() {
        this.Running = false;
      }

      //methods
      public Boolean countDown() {
        //would this have less drift if I set 'nao' above the next 2 lines?
        duration = duration - (DateTime.Now - lastTime);
        lastTime = DateTime.Now;

        if (duration.TotalSeconds <= 1) {
          return true;
        } else {
          return false;
        }
      }

      public Boolean toggleRunning() {
        running = !running;
        return running;
      }
    }

    public partial class Reminder {
      private String name;
      private DateTime activeAt;
      private Boolean running;
      private String reminder;
      private String soundBite;

      //getters & setters
      public String Name {
        get { return name; }
        set { name = value; }
      }

      public DateTime ActiveAt {
        get { return activeAt; }
        set { activeAt = value; }
      }

      public Boolean Running {
        get { return running; }
        set { running = value; }
      }

      public String Msg {
        get { return reminder; }
        set { reminder = value; }
      }

      public String SoundBite {
        get { return soundBite; }
        set { soundBite = value; }
      }

      //constructor(s)
      public Reminder(String n, DateTime aa, String msg, String sb) {
        this.Name = n;
        this.ActiveAt = aa;
        this.Running = false;
        this.Msg = msg;
        this.SoundBite = sb;
      }

      public Reminder() {
        this.Running = false;
      }

      //methods
      public Boolean toggleRunning() {
        running = !running;
        return running;
      }

      public Boolean checkInterval() {
        if (((DateTime.Now) - activeAt).TotalSeconds <= 1) {
          return true;
        } else {
          return false;
        }
      }
    }

  }

}
