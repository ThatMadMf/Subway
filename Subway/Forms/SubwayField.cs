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
    bool _pause;
    SettingsUserControl settingsUserControl;
    ScheduleUserControl scheduleUserControl;
    SubwayUserControl subwayUserControl;
    ManualResetEvent manual;

    public SubwayField() {
      InitializeComponent();
      
      List<Train> trains = new List<Train>();
      _schedule = false;
      _live = false;
      manual = new ManualResetEvent(true);
      _pause = false;

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
      manual = new ManualResetEvent(true);
      pause.Text = "Pause";
      _pause = false;
      _setting = false;
      Thread thread = new Thread(() => Call(subwayUserControl));
      thread.Start();
    }

    void Call(SubwayUserControl control) {
      Station lastStation = subway.Stations[subway.Stations.Count - 1];
      CustomTime lastTime = lastStation.Schedule[lastStation.Schedule.Count - 1].ArrivalTime;
      while (subway.CurrentTime <= lastTime + lastStation.HaltTime && _setting != true) {
        manual.WaitOne();
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

    private void pause_Click(object sender, EventArgs e) {
      if(!_setting) {
        if(_pause == false) {
          manual.Reset();
          _pause = true;
          pause.Text = "Resume";
        } else {
          manual.Set();
          _pause = false;
          pause.Text = "Pause";
        }
      }
    }

    private void button2_Click(object sender, EventArgs e) {
      panel1.Controls.Clear();
      panel1.Controls.Add(settingsUserControl);
      _setting = true;
    }
  }
}
