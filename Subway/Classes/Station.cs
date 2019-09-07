using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Classes {
  class Station : SubwayUnit {

    string _name;
    int _distanceToStation;
    int _haltTime;
    List<Schedule> _schedule;


    public string Name => _name;
    public int DistanceToStation => _distanceToStation;
    public int HaltTime => _haltTime;
    public List<Schedule> Schedule => _schedule;


    public Station(string name, int distanceToStation, int haltTime) {
      _name = name;
      _distanceToStation = distanceToStation;
      _haltTime = haltTime;
      _schedule = new List<Schedule>();
    }

    public override void makeSchedule<SubwayUnit>(List<SubwayUnit> subwayUnits) {
      List<Train> trains = new List<Train>();
      subwayUnits.ForEach(x => trains.Add(x as Train));
      foreach (var t in trains) {
        List<Schedule> temp = new List<Schedule>();
        for (int i = 0; i < t.Schedule.Count; i++) {
          if ((t.Schedule[i].SubwayUnit as Station).Name == _name) {
            temp.Add(new Schedule(t, t.Schedule[i].ArrivalTime));
          }
        }
        _schedule.AddRange(temp);
      }
      _schedule = _schedule.OrderBy(o => o.ArrivalTime).ToList();
    }
    public override void validate() {
      CustomTime time = new CustomTime { minutes = 0, hours = 8 };
      while (time < _schedule[_schedule.Count - 1].ArrivalTime) {
        var temp = _schedule.FindAll(x => x.ArrivalTime <= time && x.ArrivalTime + _haltTime > time);
        time = time + 1;
        if(temp.Count > 1) {
          throw new Exception("Station validate error");
        }
      }
    }
  }
}
