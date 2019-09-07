using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Classes {
  class Train : SubwayUnit {

    int _number;
    CustomTime _startTime;
    List<Schedule> _schedule;
    int _loopDuration;

    public int LoopDuration => _loopDuration;
    public int Number => _number;
    public CustomTime StrartTime => _startTime;
    public List<Schedule> Schedule => _schedule;

    public Train(int number, int h, int m) {
      _startTime = new CustomTime {
        hours = h,
        minutes = m
      };
      _number = number;
      _schedule = new List<Schedule>();
    }

    public override void makeSchedule<SubwayUnit>(List<SubwayUnit> subwayUnits) {
      List<Station> stations = new List<Station>();
      subwayUnits.ForEach(x => stations.Add(x as Station));
      CustomTime endTime = _startTime;
      do {
        _loopDuration = 0;
        for (int i = 0; i < stations.Count; i++) {
          _schedule.Add(new Schedule(stations[i], endTime));
          endTime = endTime + stations[i].HaltTime + stations[i].DistanceToStation;
          _loopDuration += stations[i].HaltTime;
          _loopDuration += stations[i].DistanceToStation;
        }
      } while (endTime.hours < 24);
    }

    public override void validate() {
      for(int i = 0; i < _schedule.Count - 1; i++) {
        if (_schedule[i + 1].ArrivalTime - _schedule[i].ArrivalTime <= new CustomTime { hours = 0, minutes = 1}) {
          throw new Exception("Distance between stantions should be more than 1 minute");
        }
      }
    }
  }
}
