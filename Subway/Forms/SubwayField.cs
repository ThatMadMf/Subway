using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Subway.Classes;
using System.Threading;

namespace Subway.Forms {
  public partial class SubwayField : Form {

    SubwayState subway;

    public SubwayField() {
      InitializeComponent();
    }

    public void Test() {
      List<Station> stations = new List<Station>();
      List<Train> trains = new List<Train>();

      stations.Add(new Station("Pushkina", 10, 5));
      stations.Add(new Station("Shevch", 5, 5));
      stations.Add(new Station("Univ", 20, 5));
      stations.Add(new Station("Narbut", 10, 10));
      stations.Add(new Station("Hmeln", 30, 10));
      stations.Add(new Station("Stalin", 5, 10));
      stations.Add(new Station("Lenin", 20, 20));

      trains.Add(new Train(13, 8, 0));
      trains.Add(new Train(666, 8, 15));
      trains.Add(new Train(69, 8, 30));

      subway = new SubwayState(8, 0, trains, stations);
      //Thread thread = new Thread(() => Call());
      //thread.Start();
      subway.makeSchedule();
    }

    void Call() {
      while (subway.CurrentTime.hours != 7) {
        subway.Next(this);
        Thread.Sleep(1000);
      }
    }

    private void button1_Click(object sender, EventArgs e) {
      Application.Exit();
    }

    private void button2_Click(object sender, EventArgs e) {
      Test();
    }
  }
}
