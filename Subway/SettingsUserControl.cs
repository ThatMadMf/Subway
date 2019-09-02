using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Subway.Classes;

namespace Subway {
  public partial class SettingsUserControl : UserControl {
    public SettingsUserControl() {
      InitializeComponent();
      for (int i = 0; i < 9; i++) {
        TextBox textBox1 = new TextBox {
          Location = new Point(10, 30 + (i + 1) * 30),
          Text = "Station No " + i,
          Name = "stationName" + i
        };
        TextBox textBox2 = new TextBox {
          Location = new Point(110, 30 + (i + 1) * 30),
          Text = "10",
          Name = "stationDistance" + i
        };
        TextBox textBox3 = new TextBox {
          Location = new Point(210, 30 + (i + 1) * 30),
          Text = "5",
          Name = "stationHalt" + i
        };
        Controls.AddRange(new Control[] { textBox1, textBox2, textBox3 });
      }
      for (int i = 0; i < 3; i++) {
        TextBox textBox1 = new TextBox {
          Location = new Point(405, 30 + (i + 1) * 30),
          Text = "69" + i,
          Name = "trainNumber" + i
        };
        TextBox textBox2 = new TextBox {
          Location = new Point(505, 30 + (i + 1) * 30),
          Text = "8",
          Name = "trainTimeH" + i,
          Height = 20,
          Width = 50
        };
        TextBox textBox3 = new TextBox {
          Location = new Point(555, 30 + (i + 1) * 30),
          Text = (30 + (i + 1) * 5).ToString(),
          Name = "trainTimeM" + i,
          Height = 20,
          Width = 50
        };
        Controls.AddRange(new Control[] { textBox1, textBox2, textBox3 });
      }
    }

    public event EventHandler<Object> SubwayEvent;


    private void start_Click(object sender, EventArgs e) {
      try {
        List<Train> trains = new List<Train>();
        List<Station> stations = new List<Station>();
        for (int i = 0; i < 9; i++) {
          string name = this.Controls.Find($"stationName{i}", false)[0].Text;
          string dist = this.Controls.Find($"stationDistance{i}", false)[0].Text;
          string halt = this.Controls.Find($"stationHalt{i}", false)[0].Text;
          stations.Add(new Station(name, Convert.ToInt32(dist), Convert.ToInt32(halt)));
        }
        for (int i = 0; i < 3; i++) {
          string num = this.Controls.Find($"trainNumber{i}", false)[0].Text;
          string h = this.Controls.Find($"trainTimeH{i}", false)[0].Text;
          string m = this.Controls.Find($"trainTImeM{i}", false)[0].Text;
          trains.Add(new Train(Convert.ToInt32(num), Convert.ToInt32(h), Convert.ToInt32(m)));
        }
        var handler = SubwayEvent;
        if (handler != null) {
          handler(this, new SubwayState(8, 0, trains, stations));
        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }


    }
  }
}
