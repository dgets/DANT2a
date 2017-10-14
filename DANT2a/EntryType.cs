using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DANT2a {
  public class EntryType {
    public enum Entries { Alarm, Timer, Reminder, All };

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
      public Alarm(String n, DateTime act, String sb) {
        Name = n;
        ActiveAt = act;
        SoundBite = sb;
        Running = false;
      }

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

      public Boolean isPast() {
        DateTime nao = DateTime.Now;

        if (activeAt.Date <= nao) {
          return true;
        } else {
          return false;
        }
      }
      
    }

    public partial class Timer
    {
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

    public partial class Reminder
    {
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
