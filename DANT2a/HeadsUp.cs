﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANT2a {
  public partial class HeadsUp : Form {

    //active lists
    public List<Alarm> activeAlarms = new List<Alarm>();
    public List<Timer> activeTimers = new List<Timer>();
    public List<Reminder> activeReminders = new List<Reminder>();           

    //debugging flags
    public const Boolean generalDebugging = true;
    public const Boolean alarmDebugging = true;
    public const Boolean timerDebugging = true;
    public const Boolean tickDebugging = true;
    public const Boolean fileIODebugging = true;

    //classes
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
        this.Name = n;
        this.ActiveAt = act;
        this.SoundBite = sb;
        this.Running = false;
      }

      //methods
      public Boolean toggleRunning() {
        running = !running;
        return running;
      }

      private Boolean checkInterval() {
        DateTime nao = DateTime.Now;
        
        if ((activeAt - DateTime.Now).Duration().TotalSeconds <= 1) {
          return true;
        } else {
          return false;
        }
      }

      private Boolean isPast()
      {
        DateTime nao = DateTime.Now;

        if (activeAt.Date <= nao) {
          return true;
        } else {
          return false;
        }
      }
    }

    public partial class Timer {
      private String name;
      private TimeSpan duration;
      //private TimeSpan currentCount;
      private Boolean running;
      private DateTime lastTime;
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

      //constructor(s)
      public Timer(String n, TimeSpan d, String sb) {
        this.Name = n;
        this.Duration = d;
        this.Running = false;
        this.SoundBite = sb;
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

    //HeadsUp form constructor
    public HeadsUp() {
      InitializeComponent();
    }

    private void btnAddAny_Click(object sender, EventArgs e) {
      AddWut newOne = new AddWut();
      newOne.Show();
    }

    public void addAlToList(Alarm newAlarm) {
      activeAlarms.Add(newAlarm);
    }

    public void addTmToList(Timer newTimer) {
      activeTimers.Add(newTimer);
    }

    public void addRmToList(Reminder newReminder) {
      activeReminders.Add(newReminder);
    }
  }
}
