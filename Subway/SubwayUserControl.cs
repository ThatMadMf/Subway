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
  partial class SubwayUserControl : UserControl {

    public SubwayUserControl() {
      InitializeComponent();
    }

    public void render(List<Station> stations, CustomTime currentTime) {
      dataGridView1.ColumnCount = 10;
      dataGridView1.RowCount = 9;
      for (int i = 0; i < stations.Count; i++) {
        var s = stations[i].Schedule;
        dataGridView1.Rows[i].HeaderCell.Value = stations[i].Name;
        int added = 0;
        for (int j = 0; added < 10 && j < s.Count; j++) {
          if (s[j].ArrivalTime <= currentTime && s[j].ArrivalTime + stations[i].HaltTime >= currentTime) {
            dataGridView1.Rows[i].Cells[added].Value =
              (s[j].SubwayUnit as Train).Number + " on stantion " + (s[j].ArrivalTime + stations[i].HaltTime - currentTime).ToString();
            added++;
          } else if (s[j].ArrivalTime > currentTime) {
            dataGridView1.Rows[i].Cells[added].Value =
              (s[j].SubwayUnit as Train).Number + " arrives in " + (s[j].ArrivalTime - currentTime).ToString();
            added++;
          }
        }
      }
    }
  }
}
