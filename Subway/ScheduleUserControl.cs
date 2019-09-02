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
  partial class ScheduleUserControl : UserControl {
    List<List<State>> states;

    public ScheduleUserControl(List<List<State>> passStates) {
      InitializeComponent();
      states = passStates;
      dataGridView1.ColumnCount = passStates[0].Count;
      dataGridView1.RowCount = 9;
      for (int i = 0; i < passStates.Count; i++) {
        var s = passStates[i];
        dataGridView1.Rows[i].HeaderCell.Value = s[0].Station.Name;
        for (int j = 0; j < s.Count; j++) {
          dataGridView1.Rows[i].Cells[j].Value = s[j].From;
        }
      }

    }
  }
}
