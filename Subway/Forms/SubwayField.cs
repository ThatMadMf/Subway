using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Subway.Classes;
using System.Threading;

namespace Subway.Forms {
  public partial class SubwayField : Form {

    SubwayState subway;
    bool _settings;
    bool _schedule;
    bool _live;

    public SubwayField() {
      InitializeComponent();
      
      List<Train> trains = new List<Train>();
      _settings = true;
      _schedule = false;
      _live = false;

      SettingsUserControl settingsUserControl = new SettingsUserControl();
      panel1.Controls.Add(settingsUserControl);
      settingsUserControl.SubwayEvent += SettingsUserControl_SubwayEvent;
    }

    private void SettingsUserControl_SubwayEvent(object sender, object e) {
      panel1.Controls.Clear();
      SubwayState subwayState = e as SubwayState;
      ScheduleUserControl scheduleUserControl = new ScheduleUserControl(subwayState.getSchedule());
      panel1.Controls.Add(scheduleUserControl);
    }

    //public void createSubway(List<Train> trains, List<Station> stations) {

    //}

    public void Test() {
      while (true) {
        var control = new SubwayUserControl();
        if (panel1.InvokeRequired) {
          panel1.Invoke(new MethodInvoker(delegate { panel1.Controls.Clear(); })); 
          panel1.Invoke(new MethodInvoker(delegate { panel1.Controls.Add(control); }));
        } else {
          panel1.Controls.Clear();
          panel1.Controls.Add(control);
        }
        Thread.Sleep(3000);
      }
    }

    void Call() {
      while (subway.CurrentTime.hours != 7) {
        subway.Next(this);
        Thread.Sleep(1000);
      }
    }

    private void button1_Click(object sender, EventArgs e) {
      Environment.Exit(200);
    }

    private void button2_Click(object sender, EventArgs e) {
    }

    private void settings_Click(object sender, EventArgs e) {
      _settings = true;
      _schedule = false;
      _live = false;
    }

    private void schedule_Click(object sender, EventArgs e) {
      _settings = false;
      _schedule = true;
      _live = false;
    }

    private void live_Click(object sender, EventArgs e) {
      _settings = false;
      _schedule = false;
      _live = true;
    }
  }
}
