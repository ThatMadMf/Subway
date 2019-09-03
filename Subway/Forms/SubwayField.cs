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
    bool _schedule;
    bool _live;
    SettingsUserControl settingsUserControl;
    ScheduleUserControl scheduleUserControl;

    public SubwayField() {
      InitializeComponent();
      
      List<Train> trains = new List<Train>();
      _schedule = false;
      _live = false;

      settingsUserControl = new SettingsUserControl();
      panel1.Controls.Add(settingsUserControl);
      settingsUserControl.SubwayEvent += SettingsUserControl_SubwayEvent;
    }

    private void SettingsUserControl_SubwayEvent(object sender, object e) {
      panel1.Controls.Clear();
      subway = e as SubwayState;
      scheduleUserControl = new ScheduleUserControl(subway.getSchedule());
      panel1.Controls.Add(scheduleUserControl);
      _schedule = true;
      Thread thread = new Thread(() => Call());
      thread.Start();
    }

     void Test(SubwayUserControl control) {
      while (_live) {
        if (panel1.InvokeRequired) {
          panel1.Invoke(new MethodInvoker(delegate {control.render(subway.getStates(), subway.CurrentTime); })); 
        } else {
          control.render(subway.getStates(), subway.CurrentTime);
        }
        Thread.Sleep(1000);
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

    private void schedule_Click(object sender, EventArgs e) {
      panel1.Controls.Clear();
      panel1.Controls.Add(scheduleUserControl);
      _schedule = true;
      _live = false;
    }

    private void live_Click(object sender, EventArgs e) {
      _schedule = false;
      _live = true;
      var control = new SubwayUserControl();
      if (panel1.InvokeRequired) {
        panel1.Invoke(new MethodInvoker(delegate { panel1.Controls.Clear(); }));
        panel1.Invoke(new MethodInvoker(delegate { panel1.Controls.Add(control); }));
      } else {
        panel1.Controls.Clear();
        panel1.Controls.Add(control);
      }
      Thread thread = new Thread(() => Test(control));
      thread.Start();
    }
  }
}
