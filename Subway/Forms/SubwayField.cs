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
    bool _setting;
    bool _schedule;
    bool _live;
    SettingsUserControl settingsUserControl;
    ScheduleUserControl scheduleUserControl;
    SubwayUserControl subwayUserControl;

    public SubwayField() {
      InitializeComponent();
      
      List<Train> trains = new List<Train>();
      _schedule = false;
      _live = false;

      settingsUserControl = new SettingsUserControl();
      subwayUserControl = new SubwayUserControl();
      _setting = true;
      panel1.Controls.Add(settingsUserControl);
      settingsUserControl.SubwayEvent += SettingsUserControl_SubwayEvent;
    }

    private void SettingsUserControl_SubwayEvent(object sender, object e) {
      panel1.Controls.Clear();
      subway = e as SubwayState;
      Console.Write(subway.Stations[0].Schedule);
      scheduleUserControl = new ScheduleUserControl(subway.Stations);
      panel1.Controls.Add(scheduleUserControl);
      _schedule = true;
      Thread thread = new Thread(() => Call(subwayUserControl));
      thread.Start();
      _setting = false;
    }

    void Call(SubwayUserControl control) {
      while (subway.CurrentTime.hours != 7) {
        subway.Next(this);
        if (_live) {
          if (panel1.InvokeRequired) {
            panel1.Invoke(new MethodInvoker(delegate { control.render(subway.Stations, subway.CurrentTime); }));
          } else {
            control.render(subway.Stations, subway.CurrentTime);
          }
        }
        Thread.Sleep(1000);
      }
    }

    private void button1_Click(object sender, EventArgs e) {
      Environment.Exit(200);
    }

    private void schedule_Click(object sender, EventArgs e) {
      if (!_setting) {
        panel1.Controls.Clear();
        panel1.Controls.Add(scheduleUserControl);
        _schedule = true;
        _live = false;
      }
    }

    private void live_Click(object sender, EventArgs e) {
      if (!_setting) {
        _schedule = false;
        _live = true;
        if (panel1.InvokeRequired) {
          panel1.Invoke(new MethodInvoker(delegate { panel1.Controls.Clear(); }));
          panel1.Invoke(new MethodInvoker(delegate { panel1.Controls.Add(subwayUserControl); }));
        } else {
          panel1.Controls.Clear();
          panel1.Controls.Add(subwayUserControl);
        }
      }
    }

    private void panel1_Resize(object sender, EventArgs e) {
      //subwayUserControl.Size = panel1.Size;
      //if(scheduleUserControl != null) {
      //  scheduleUserControl.Size = panel1.Size;
      //}
    }
  }
}
