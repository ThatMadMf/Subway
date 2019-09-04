using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subway.Forms;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Subway.Classes {
  class SubwayState {

    CustomTime _currentTime;
    List<Train> _trains;
    List<Station> _stations;
    List<List<State>> _globalSchedule;

    public List<Station> Stations => _stations;
    public List<Train> Trains => _trains;
    public CustomTime CurrentTime => _currentTime;
    public List<List<State>> GlobalSchedule => _globalSchedule;
    public SubwayState GetIt => this;

    public SubwayState(int h, int m, List<Train> trains, List<Station> stations) {
      _currentTime = new CustomTime {
        hours = h,
        minutes = m
      };
      _trains = trains;
      _stations = stations;
      _globalSchedule = new List<List<State>>(3);
    }

    public void Next(SubwayField subwayField) {
      _currentTime = ChangeTime(_currentTime);
      setLabel(subwayField);
    }

    public void setLabel(SubwayField subwayField) {
      try {
        subwayField.currentTime.Invoke(new Action(() => {
          subwayField.currentTime.Text = _currentTime.ToString();
        }));
      } catch (Exception e) {
        Console.Write(e.Message);
      }
    }

    public Label setSingleLabel(Label label, Train train) {
      try {
        label.Invoke(new Action(() => {
          label.Text = getState(train);
        }));
      } catch (Exception e) {
        Console.Write(e.Message);
      }
      return label;
    }


    public string getState(Train train) {
      int index = _globalSchedule.IndexOf(_globalSchedule.Find(x => x[0].Train.Number == train.Number));
      var v = _globalSchedule[index].Find(x => x.From <= _currentTime && x.UpTo >= _currentTime);
      if (v != null) {
        string state = v.StringState == "ontheway" ? "On the way to " : v.StringState;
        return  state + " " + v.Station.Name;
      } else {
        return "Train is not on the way yet";
      }
    }

    public CustomTime ChangeTime(CustomTime time) {
      if (time.minutes + 1 < 60) {
        time.minutes++;
      } else {
        if (time.hours + 1 < 24) {
          time.hours++;
          time.minutes = 0;
        } else {
          time.hours = 0;
          time.minutes = 0;
        }
      }
      return time;
    }
  }
}
