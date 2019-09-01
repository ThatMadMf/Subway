using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Classes {
  class Train : SubwayUnit {

    int _number;
    Schedule _closestStation;
    CustomTime _startTime;
    bool _onTheWay;
    List<Schedule> _completeSchedule;

    public int Number => _number;
    public CustomTime StrartTime => _startTime;

    public Train(int number, int h, int m) {
      _startTime = new CustomTime {
        hours = h,
        minutes = m
      };
      _number = number;
    }
  }
}
