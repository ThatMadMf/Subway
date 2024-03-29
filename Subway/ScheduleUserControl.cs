﻿using System;
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

    public ScheduleUserControl(List<Station>stations) {
      InitializeComponent();
      dataGridView1.ColumnCount = stations[0].Schedule.Count;
      dataGridView1.RowCount = 9;
      dataGridView1.RowHeadersWidth = 150;
      for (int i = 0; i < stations.Count; i++) {
        var s = stations[i].Schedule;
        dataGridView1.Rows[i].HeaderCell.Value = stations[i].Name;
        for (int j = 0; j < s.Count; j++) {
          dataGridView1.Rows[i].Cells[j].Value = s[j].ArrivalTime;
        }
      }

    }
  }
}
