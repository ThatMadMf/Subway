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
      this.pause = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
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
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.Location = new System.Drawing.Point(1015, 429);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 32);
      this.button1.TabIndex = 1;
      this.button1.Text = "Exit";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.AutoSize = true;
      this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.panel1.Location = new System.Drawing.Point(12, 21);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(0, 0);
      this.panel1.TabIndex = 6;
      this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
      // 
      // schedule
      // 
      this.schedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.schedule.Location = new System.Drawing.Point(7, 425);
      this.schedule.Name = "schedule";
      this.schedule.Size = new System.Drawing.Size(93, 36);
      this.schedule.TabIndex = 8;
      this.schedule.Text = "Schedule";
      this.schedule.UseVisualStyleBackColor = true;
      this.schedule.Click += new System.EventHandler(this.schedule_Click);
      // 
      // live
      // 
      this.live.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.live.Location = new System.Drawing.Point(106, 425);
      this.live.Name = "live";
      this.live.Size = new System.Drawing.Size(77, 36);
      this.live.TabIndex = 9;
      this.live.Text = "Live";
      this.live.UseVisualStyleBackColor = true;
      this.live.Click += new System.EventHandler(this.live_Click);
      // 
      // pause
      // 
      this.pause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pause.Location = new System.Drawing.Point(523, 427);
      this.pause.Name = "pause";
      this.pause.Size = new System.Drawing.Size(75, 34);
      this.pause.TabIndex = 10;
      this.pause.Text = "Pause";
      this.pause.UseVisualStyleBackColor = true;
      this.pause.Click += new System.EventHandler(this.pause_Click);
      // 
      // button2
      // 
      this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button2.Location = new System.Drawing.Point(189, 425);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(112, 36);
      this.button2.TabIndex = 11;
      this.button2.Text = "New Subway";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // SubwayField
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1102, 473);
      this.ControlBox = false;
      this.Controls.Add(this.button2);
      this.Controls.Add(this.pause);
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
    private System.Windows.Forms.Button pause;
    private System.Windows.Forms.Button button2;
  }
}