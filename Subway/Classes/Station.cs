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

    
    public string Name => _name;
    public int DistanceToStation => _distanceToStation;
    public int HaltTime => _haltTime;


    public Station(string name, int distanceToStation, int haltTime) {
      _name = name;
      _distanceToStation = distanceToStation;
      _haltTime = haltTime;
      // _schedules = new List<Schedule>();
    }

    public Station GetStation => this;

    //public void MakeAutoShedule(CustomTime customTime, int periodicity, Train train) {
    //  while (customTime.hours < 21) {
    //    _schedules.Add(new Schedule(train, customTime));
    //    customTime = this.ChangeTime(customTime, periodicity);
    //  }
    //  Console.Write(_schedules);
    //}
  }
}
