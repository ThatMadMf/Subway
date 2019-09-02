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

    public void render(List<List<State>> passStates, CustomTime currentTime) {
      var states = passStates;
      dataGridView1.ColumnCount = 10;
      dataGridView1.RowCount = 3;
      for (int j = 0; j < passStates.Count; j++) {
        var t = passStates[j];
        for (int i = 0; i < t.Count; i++) {
          dataGridView1.Columns[i].HeaderText = t[i].Station.Name;
          if (i == 0) {
            dataGridView1.Rows[j].Cells[0].Value = t[i].StringState + " " + (t[i].UpTo - currentTime).ToString();
          } else {
            dataGridView1.Rows[j].Cells[i].Value = t[i].From - currentTime;
          }
        }
      }
    }

  }
}
