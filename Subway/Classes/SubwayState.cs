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
   public class SubwayState {
    CustomTime _currentTime;

    public CustomTime CurrentTime => _currentTime;

    public string CurrentTimeString {
      get {
        string h, m;
        h = _currentTime.hours < 10 ? "0" + _currentTime.hours.ToString() : _currentTime.hours.ToString();
        m = _currentTime.minutes < 10 ? "0" + _currentTime.minutes.ToString() : _currentTime.minutes.ToString();
        return h + ": " + m;
      }
    }

    public SubwayState() {
      _currentTime = new CustomTime {
        hours = 8,
        minutes = 0
      };
    }

    public void Next(SubwayField subwayField) {
      ChangeTime();
      setLabel(subwayField);
    }

    public void setLabel(SubwayField subwayField) {
      subwayField.currentTime.Invoke(new Action(() => {
        subwayField.currentTime.Text = CurrentTimeString;
      }));
    }

    private void ChangeTime() {
      if (_currentTime.minutes + 1 < 60) {
        _currentTime.minutes++;
      } else {
        if (_currentTime.hours + 1 < 24) {
          _currentTime.hours++;
          _currentTime.minutes = 0;
        } else {
          _currentTime.hours = 0;
          _currentTime.minutes = 0;
        }
      }
    }
  }
}
