using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Classes {
  class State {

    string _state;
    Train _train;
    Station _station;
    CustomTime _from;
    CustomTime _upTo;

    public string StringState => _state;
    public Train Train => _train;
    public Station Station => _station;
    public CustomTime From => _from;
    public CustomTime UpTo => _upTo;

    public State(Train train, Station station, CustomTime currentTime, int durationTime, string state) {
      _train = train;
      _station = station;
      _from = currentTime;
      _upTo = (currentTime + durationTime);
      _state = state;
    }
  }
}
