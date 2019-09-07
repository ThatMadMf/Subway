using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway {
  public struct CustomTime : IComparable<CustomTime> {
    public int hours;
    public int minutes;

    public int CompareTo (CustomTime time) {
      if((hours * 60 + minutes) > (time.hours*60 + time.minutes)) {
        return 1;
      }
      if ((hours * 60 + minutes) == (time.hours * 60 + time.minutes)) {
        return 0;
      }
      return -1;
    }

    public static bool operator > (CustomTime time1, CustomTime time2) =>
      (time1.hours * 60 + time1.minutes) > (time2.hours * 60 + time2.minutes);

    public static bool operator < (CustomTime time1, CustomTime time2) =>
      time2 > time1;

    public static bool operator >= (CustomTime time1, CustomTime time2) =>
      (time1.hours * 60 + time1.minutes) >= (time2.hours * 60 + time2.minutes);

    public static bool operator <= (CustomTime time1, CustomTime time2) =>
      time2 >= time1;

    public static CustomTime operator - (CustomTime time1, CustomTime time2) {
      if(time1.minutes >= time2.minutes) {
        return new CustomTime { hours = time1.hours - time2.hours, minutes = time1.minutes - time2.minutes };
      } else {
        return new CustomTime { hours = time1.hours - time2.hours - 1, minutes = time1.minutes - time2.minutes + 60 };
      }
    }

    public static CustomTime operator + (CustomTime time, int m) {
      if(time.minutes + m < 60) {
        return new CustomTime { hours = time.hours, minutes = time.minutes + m };
      } else {
        return new CustomTime { hours = time.hours + 1, minutes = time.minutes + m - 60 };
      }
    }

    public static bool operator == (CustomTime time1, CustomTime time2) {
      if(time1.hours == time2.hours && time1.minutes == time2.minutes) {
        return true;
      }
      return false;
    }
    public static bool operator != (CustomTime time1, CustomTime time2) {
      return !(time1 == time2);
    }
      

    public override string ToString() {
      int hours = this.hours >= 24 ? this.hours - 24 : this.hours;
      int minutes = this.minutes;
      string h, m;
      h = hours < 10 ? "0" + hours.ToString() : hours.ToString();
      m = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
      return h + ": " + m;
    }
  }
}
