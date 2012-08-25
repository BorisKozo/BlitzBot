namespace BejeweledBlitzBot
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.WindowNameTextBox = new System.Windows.Forms.TextBox();
      this.WindowNameLabel = new System.Windows.Forms.Label();
      this.WindowNameStatusLabel = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.GridXSelector = new System.Windows.Forms.NumericUpDown();
      this.GridYSelector = new System.Windows.Forms.NumericUpDown();
      this.CroppedImage = new System.Windows.Forms.PictureBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.OffsetYSelector = new System.Windows.Forms.NumericUpDown();
      this.WidthSelector = new System.Windows.Forms.NumericUpDown();
      this.HeightSelector = new System.Windows.Forms.NumericUpDown();
      this.OffsetXSelector = new System.Windows.Forms.NumericUpDown();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.ColorBoard = new System.Windows.Forms.PictureBox();
      this.button1 = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.GridXSelector)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.GridYSelector)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.CroppedImage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.OffsetYSelector)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.WidthSelector)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.HeightSelector)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.OffsetXSelector)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ColorBoard)).BeginInit();
      this.SuspendLayout();
      // 
      // WindowNameTextBox
      // 
      this.WindowNameTextBox.Location = new System.Drawing.Point(91, 12);
      this.WindowNameTextBox.Name = "WindowNameTextBox";
      this.WindowNameTextBox.Size = new System.Drawing.Size(318, 20);
      this.WindowNameTextBox.TabIndex = 0;
      this.WindowNameTextBox.Text = "Bejeweled Blitz on Facebook - Google Chrome";
      this.WindowNameTextBox.TextChanged += new System.EventHandler(this.WindowNameTextBox_TextChanged);
      // 
      // WindowNameLabel
      // 
      this.WindowNameLabel.AutoSize = true;
      this.WindowNameLabel.Location = new System.Drawing.Point(8, 15);
      this.WindowNameLabel.Name = "WindowNameLabel";
      this.WindowNameLabel.Size = new System.Drawing.Size(77, 13);
      this.WindowNameLabel.TabIndex = 1;
      this.WindowNameLabel.Text = "Window Name";
      // 
      // WindowNameStatusLabel
      // 
      this.WindowNameStatusLabel.AutoSize = true;
      this.WindowNameStatusLabel.Location = new System.Drawing.Point(415, 15);
      this.WindowNameStatusLabel.Name = "WindowNameStatusLabel";
      this.WindowNameStatusLabel.Size = new System.Drawing.Size(27, 13);
      this.WindowNameStatusLabel.TabIndex = 2;
      this.WindowNameStatusLabel.Text = "N/A";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.GridXSelector);
      this.groupBox1.Controls.Add(this.GridYSelector);
      this.groupBox1.Controls.Add(this.CroppedImage);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.OffsetYSelector);
      this.groupBox1.Controls.Add(this.WidthSelector);
      this.groupBox1.Controls.Add(this.HeightSelector);
      this.groupBox1.Controls.Add(this.OffsetXSelector);
      this.groupBox1.Location = new System.Drawing.Point(12, 38);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(430, 400);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Screen Configuration";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(244, 47);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(33, 13);
      this.label5.TabIndex = 12;
      this.label5.Text = "GridY";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(244, 21);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(33, 13);
      this.label6.TabIndex = 11;
      this.label6.Text = "GridX";
      // 
      // GridXSelector
      // 
      this.GridXSelector.Location = new System.Drawing.Point(283, 19);
      this.GridXSelector.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
      this.GridXSelector.Name = "GridXSelector";
      this.GridXSelector.Size = new System.Drawing.Size(50, 20);
      this.GridXSelector.TabIndex = 10;
      this.GridXSelector.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
      // 
      // GridYSelector
      // 
      this.GridYSelector.Location = new System.Drawing.Point(283, 45);
      this.GridYSelector.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
      this.GridYSelector.Name = "GridYSelector";
      this.GridYSelector.Size = new System.Drawing.Size(50, 20);
      this.GridYSelector.TabIndex = 9;
      this.GridYSelector.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
      // 
      // CroppedImage
      // 
      this.CroppedImage.Location = new System.Drawing.Point(9, 71);
      this.CroppedImage.Name = "CroppedImage";
      this.CroppedImage.Size = new System.Drawing.Size(320, 320);
      this.CroppedImage.TabIndex = 8;
      this.CroppedImage.TabStop = false;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(124, 47);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(38, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Height";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(124, 21);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(35, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Width";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 47);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(45, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Offset Y";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 21);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(45, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Offset X";
      // 
      // OffsetYSelector
      // 
      this.OffsetYSelector.Location = new System.Drawing.Point(57, 45);
      this.OffsetYSelector.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
      this.OffsetYSelector.Name = "OffsetYSelector";
      this.OffsetYSelector.Size = new System.Drawing.Size(61, 20);
      this.OffsetYSelector.TabIndex = 3;
      this.OffsetYSelector.Value = new decimal(new int[] {
            458,
            0,
            0,
            0});
      // 
      // WidthSelector
      // 
      this.WidthSelector.Location = new System.Drawing.Point(175, 19);
      this.WidthSelector.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
      this.WidthSelector.Name = "WidthSelector";
      this.WidthSelector.Size = new System.Drawing.Size(61, 20);
      this.WidthSelector.TabIndex = 2;
      this.WidthSelector.Value = new decimal(new int[] {
            320,
            0,
            0,
            0});
      // 
      // HeightSelector
      // 
      this.HeightSelector.Location = new System.Drawing.Point(175, 45);
      this.HeightSelector.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
      this.HeightSelector.Name = "HeightSelector";
      this.HeightSelector.Size = new System.Drawing.Size(61, 20);
      this.HeightSelector.TabIndex = 1;
      this.HeightSelector.Value = new decimal(new int[] {
            320,
            0,
            0,
            0});
      // 
      // OffsetXSelector
      // 
      this.OffsetXSelector.Location = new System.Drawing.Point(57, 19);
      this.OffsetXSelector.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
      this.OffsetXSelector.Name = "OffsetXSelector";
      this.OffsetXSelector.Size = new System.Drawing.Size(61, 20);
      this.OffsetXSelector.TabIndex = 0;
      this.OffsetXSelector.Value = new decimal(new int[] {
            190,
            0,
            0,
            0});
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 10;
      // 
      // ColorBoard
      // 
      this.ColorBoard.Location = new System.Drawing.Point(21, 444);
      this.ColorBoard.Name = "ColorBoard";
      this.ColorBoard.Size = new System.Drawing.Size(320, 320);
      this.ColorBoard.TabIndex = 5;
      this.ColorBoard.TabStop = false;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(336, 71);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 13;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(483, 776);
      this.Controls.Add(this.ColorBoard);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.WindowNameStatusLabel);
      this.Controls.Add(this.WindowNameLabel);
      this.Controls.Add(this.WindowNameTextBox);
      this.Name = "MainForm";
      this.Text = "BlitzBot";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.GridXSelector)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.GridYSelector)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.CroppedImage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.OffsetYSelector)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.WidthSelector)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.HeightSelector)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.OffsetXSelector)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ColorBoard)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox WindowNameTextBox;
    private System.Windows.Forms.Label WindowNameLabel;
    private System.Windows.Forms.Label WindowNameStatusLabel;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.PictureBox CroppedImage;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown OffsetYSelector;
    private System.Windows.Forms.NumericUpDown WidthSelector;
    private System.Windows.Forms.NumericUpDown HeightSelector;
    private System.Windows.Forms.NumericUpDown OffsetXSelector;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.NumericUpDown GridXSelector;
    private System.Windows.Forms.NumericUpDown GridYSelector;
    private System.Windows.Forms.PictureBox ColorBoard;
    private System.Windows.Forms.Button button1;
  }
}

