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
      makeSchedule();
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

    public List<List<State>> getStates() {
      List<List<State>> result = new List<List<State>>();
      for(int i = 0; i < _globalSchedule.Count; i++) {
        List<State> query = _globalSchedule[i].FindAll(x => x.From >= _currentTime || x.From>= CurrentTime && x.UpTo <= CurrentTime).GetRange(0, 10);
        result.Add(query);
      }
      return result;
    }

    public List<List<State>> getSchedule() {
      List<List<State>> result = new List<List<State>>();
      foreach(var s in _stations) {
        List<State> temp = new List<State>();
        foreach(var t in _globalSchedule) {
          temp.AddRange(t.FindAll(x => x.Station.Name == s.Name && x.StringState == "halt"));
        }
        temp = temp.OrderBy(o => o.From).ToList();
        result.Add(temp);
      }
      return result;
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
