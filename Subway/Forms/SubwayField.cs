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
      subway = new SubwayState();
      Thread.Sleep(2000);
      Thread thread = new Thread(() => Call());
      thread.Start();
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
  }
}
