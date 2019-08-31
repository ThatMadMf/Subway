using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Subway.Forms;
using Subway.Classes;

namespace Subway {

  public struct CustomTime {
    public int hours;
    public int minutes;
  }
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new SubwayField());
    }
  }
}
