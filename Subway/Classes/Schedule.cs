using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Classes {
  class Schedule {
    SubwayUnit _subwayUnit;
    CustomTime _arrivalTime;

    public SubwayUnit SubwayUnit => _subwayUnit;
    public CustomTime ArrivalTime => _arrivalTime;

    public Schedule(SubwayUnit subwayUnit, CustomTime arrivalTime) {
      _subwayUnit = subwayUnit;
      _arrivalTime = arrivalTime;
    }
  }
}
