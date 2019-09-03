namespace Subway.Forms {
  partial class SubwayField {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.currentTime = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.schedule = new System.Windows.Forms.Button();
      this.live = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // currentTime
      // 
      this.currentTime.AutoSize = true;
      this.currentTime.Location = new System.Drawing.Point(520, 4);
      this.currentTime.Name = "currentTime";
      this.currentTime.Size = new System.Drawing.Size(36, 17);
      this.currentTime.TabIndex = 0;
      this.currentTime.Text = "NaN";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(1025, 441);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 35);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1100, 400);
      this.panel1.TabIndex = 6;
      // 
      // schedule
      // 
      this.schedule.Location = new System.Drawing.Point(0, 441);
      this.schedule.Name = "schedule";
      this.schedule.Size = new System.Drawing.Size(77, 26);
      this.schedule.TabIndex = 8;
      this.schedule.Text = "Schedule";
      this.schedule.UseVisualStyleBackColor = true;
      this.schedule.Click += new System.EventHandler(this.schedule_Click);
      // 
      // live
      // 
      this.live.Location = new System.Drawing.Point(83, 441);
      this.live.Name = "live";
      this.live.Size = new System.Drawing.Size(77, 26);
      this.live.TabIndex = 9;
      this.live.Text = "Live";
      this.live.UseVisualStyleBackColor = true;
      this.live.Click += new System.EventHandler(this.live_Click);
      // 
      // SubwayField
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1102, 473);
      this.Controls.Add(this.live);
      this.Controls.Add(this.schedule);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.currentTime);
      this.Name = "SubwayField";
      this.Text = "SubwayField";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.Label currentTime;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button schedule;
    private System.Windows.Forms.Button live;
  }
}