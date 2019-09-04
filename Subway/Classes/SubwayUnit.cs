using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Classes {
  abstract class SubwayUnit {

    internal CustomTime ChangeTime(CustomTime currentTime, int time ) {
      if (currentTime.minutes + time < 60) {
        currentTime.minutes += time;
      } else {
        if (currentTime.hours + 1 < 24) {
          currentTime.hours++;
          currentTime.minutes = currentTime.minutes + time - 60;
        } else {
          currentTime.hours = 0;
          currentTime.minutes = currentTime.minutes + time - 60;
        }
      }
      return currentTime;
    }

    abstract public void makeSchedule<T>(List<T> types) where T : class;
  }
}
