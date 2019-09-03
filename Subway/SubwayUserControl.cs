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
      dataGridView1.RowCount = 9;
      for (int i = 0; i < passStates.Count; i++) {
        var t = passStates[i];
        dataGridView1.Rows[i].HeaderCell.Value = t[0].Station.Name;
        for (int j = 0; j < 10 && j < t.Count; j++) {
          if (t[j].UpTo >= currentTime && t[j].From <= currentTime) {
            dataGridView1.Rows[i].Cells[j].Value = t[j].Train.Number + t[j].StringState + "\n" + (t[j].From + t[j].Station.HaltTime - currentTime).ToString();
          } else {
            dataGridView1.Rows[i].Cells[j].Value = t[j].Train.Number + "arrives in\n" + (t[j].From - currentTime).ToString();
          }

        }
      }
    }

  }
}
