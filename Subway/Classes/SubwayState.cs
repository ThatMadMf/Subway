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

    public List<Station> Stations => _stations;
    public List<Train> Trains => _trains;
    public CustomTime CurrentTime => _currentTime;

    public SubwayState(int h, int m, List<Train> trains, List<Station> stations) {
      _currentTime = new CustomTime {
        hours = h,
        minutes = m
      };
      _trains = trains;
      _stations = stations;
      checkNames();
      foreach (var train in _trains) {
        train.makeSchedule(_stations);
      }
      foreach (var station in _stations) {
        station.makeSchedule(_trains);
      }
      foreach (var s in _stations) {
        s.validate();
      }
      foreach (var t in _trains) {
        t.validate();
      }
    }

    public void Next(SubwayField subwayField) {
      _currentTime = _currentTime + 1;
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

    void checkNames() {
      for(int i = 0; i < _trains.Count - 1; i++) {
        for(int j = i + 1; j < Trains.Count; j++) {
          if(_trains[i].Number == _trains[j].Number) {
            throw new Exception("Train's number error");
          }
        }
      }
      for (int i = 0; i < _stations.Count - 1; i++) {
        for (int j = i + 1; j < _stations.Count; j++) {
          if (_stations[i].Name == _stations[j].Name) {
            throw new Exception("Station's name error");
          }
        }
      }
    }
  }
}
