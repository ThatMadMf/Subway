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

    public SubwayState(int h, int m, List<Train> trains, List<Station> stations) {
      _currentTime = new CustomTime {
        hours = h,
        minutes = m
      };
      _trains = trains;
      _stations = stations;
      _globalSchedule = new List<List<State>>(3);
    }

    public string CurrentTimeString {
      get {
        string h, m;
        h = _currentTime.hours < 10 ? "0" + _currentTime.hours.ToString() : _currentTime.hours.ToString();
        m = _currentTime.minutes < 10 ? "0" + _currentTime.minutes.ToString() : _currentTime.minutes.ToString();
        return h + ": " + m;
      }
    }

    public void makeSchedule() {
      CustomTime endTime = new CustomTime {
        hours = 0,
        minutes = 0
      };
      int count = 0;
      foreach (Train train in _trains) {
        _globalSchedule.Add(new List<State>());
        endTime = train.StrartTime;
        int i = 0;
        int j = 1;
        do {
          State halt = new State(train, _stations[i], endTime, _stations[i].HaltTime, "halt");
          State ontheway = new State(train, _stations[j], halt.UpTo, _stations[j].DistanceToStation, "ontheway");
          _globalSchedule[count].Add(halt);
          _globalSchedule[count].Add(ontheway);
          endTime = ontheway.UpTo;
          i = (i + 1) == _stations.Count ? 0 : i + 1;
          j = (j + 1) == _stations.Count ? 0 : j + 1;
        } while (endTime.hours >= 8);
        count++;
      }
      Console.Write("F");
    }

    public void Next(SubwayField subwayField) {
      ChangeTime(_currentTime);
      setLabel(subwayField);
    }

    public void setLabel(SubwayField subwayField) {
      subwayField.currentTime.Invoke(new Action(() => {
        subwayField.currentTime.Text = CurrentTimeString;
      }));
    }

    public void ChangeTime(CustomTime time) {
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
    }
  }
}
