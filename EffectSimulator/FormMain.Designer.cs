namespace EffectSimulator
{
	partial class FormMain
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
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonColor = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.listBoxEffects = new System.Windows.Forms.ListBox();
			this.buttonFaster = new System.Windows.Forms.Button();
			this.buttonSlower = new System.Windows.Forms.Button();
			this.buttonForwards = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.buttonBack = new System.Windows.Forms.Button();
			this.buttonSet = new System.Windows.Forms.Button();
			this.textBoxLog = new System.Windows.Forms.TextBox();
			this.labelSpeed = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(268, 625);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 13);
			this.label3.TabIndex = 23;
			this.label3.Text = "Argument";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(268, 644);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(211, 20);
			this.textBox1.TabIndex = 22;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(265, 539);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 21;
			this.label2.Text = "Color";
			// 
			// buttonColor
			// 
			this.buttonColor.Location = new System.Drawing.Point(268, 555);
			this.buttonColor.Name = "buttonColor";
			this.buttonColor.Size = new System.Drawing.Size(75, 57);
			this.buttonColor.TabIndex = 20;
			this.buttonColor.UseVisualStyleBackColor = true;
			this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 539);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 19;
			this.label1.Text = "Effects:";
			// 
			// listBoxEffects
			// 
			this.listBoxEffects.FormattingEnabled = true;
			this.listBoxEffects.Location = new System.Drawing.Point(12, 552);
			this.listBoxEffects.Name = "listBoxEffects";
			this.listBoxEffects.Size = new System.Drawing.Size(237, 186);
			this.listBoxEffects.TabIndex = 18;
			this.listBoxEffects.SelectedIndexChanged += new System.EventHandler(this.listBoxEffects_SelectedIndexChanged);
			// 
			// buttonFaster
			// 
			this.buttonFaster.BackColor = System.Drawing.SystemColors.Control;
			this.buttonFaster.Location = new System.Drawing.Point(367, 676);
			this.buttonFaster.Name = "buttonFaster";
			this.buttonFaster.Size = new System.Drawing.Size(75, 23);
			this.buttonFaster.TabIndex = 17;
			this.buttonFaster.Text = "Faster";
			this.buttonFaster.UseVisualStyleBackColor = false;
			this.buttonFaster.Click += new System.EventHandler(this.buttonFaster_Click);
			// 
			// buttonSlower
			// 
			this.buttonSlower.BackColor = System.Drawing.SystemColors.Control;
			this.buttonSlower.Location = new System.Drawing.Point(285, 677);
			this.buttonSlower.Name = "buttonSlower";
			this.buttonSlower.Size = new System.Drawing.Size(75, 23);
			this.buttonSlower.TabIndex = 16;
			this.buttonSlower.Text = "Slower";
			this.buttonSlower.UseVisualStyleBackColor = false;
			this.buttonSlower.Click += new System.EventHandler(this.buttonSlower_Click);
			// 
			// buttonForwards
			// 
			this.buttonForwards.BackColor = System.Drawing.SystemColors.Control;
			this.buttonForwards.Location = new System.Drawing.Point(419, 706);
			this.buttonForwards.Name = "buttonForwards";
			this.buttonForwards.Size = new System.Drawing.Size(75, 23);
			this.buttonForwards.TabIndex = 15;
			this.buttonForwards.Text = "Forwards";
			this.buttonForwards.UseVisualStyleBackColor = false;
			this.buttonForwards.Click += new System.EventHandler(this.buttonForwards_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.BackColor = System.Drawing.SystemColors.Control;
			this.buttonStop.Location = new System.Drawing.Point(337, 705);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 14;
			this.buttonStop.Text = "Stopped";
			this.buttonStop.UseVisualStyleBackColor = false;
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// buttonBack
			// 
			this.buttonBack.BackColor = System.Drawing.SystemColors.Control;
			this.buttonBack.Location = new System.Drawing.Point(255, 706);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.Size = new System.Drawing.Size(75, 23);
			this.buttonBack.TabIndex = 13;
			this.buttonBack.Text = "Backwards";
			this.buttonBack.UseVisualStyleBackColor = false;
			this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
			// 
			// buttonSet
			// 
			this.buttonSet.BackColor = System.Drawing.SystemColors.Control;
			this.buttonSet.Location = new System.Drawing.Point(478, 641);
			this.buttonSet.Name = "buttonSet";
			this.buttonSet.Size = new System.Drawing.Size(40, 23);
			this.buttonSet.TabIndex = 24;
			this.buttonSet.Text = "Set";
			this.buttonSet.UseVisualStyleBackColor = false;
			this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
			// 
			// textBoxLog
			// 
			this.textBoxLog.Location = new System.Drawing.Point(524, 539);
			this.textBoxLog.Multiline = true;
			this.textBoxLog.Name = "textBoxLog";
			this.textBoxLog.ReadOnly = true;
			this.textBoxLog.Size = new System.Drawing.Size(561, 208);
			this.textBoxLog.TabIndex = 25;
			// 
			// labelSpeed
			// 
			this.labelSpeed.AutoSize = true;
			this.labelSpeed.ForeColor = System.Drawing.Color.White;
			this.labelSpeed.Location = new System.Drawing.Point(448, 676);
			this.labelSpeed.Name = "labelSpeed";
			this.labelSpeed.Size = new System.Drawing.Size(60, 13);
			this.labelSpeed.TabIndex = 26;
			this.labelSpeed.Text = "labelSpeed";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1234, 765);
			this.Controls.Add(this.labelSpeed);
			this.Controls.Add(this.textBoxLog);
			this.Controls.Add(this.buttonSet);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonColor);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBoxEffects);
			this.Controls.Add(this.buttonFaster);
			this.Controls.Add(this.buttonSlower);
			this.Controls.Add(this.buttonForwards);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonBack);
			this.Name = "FormMain";
			this.Text = "Tiki Tank Simulator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonColor;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listBoxEffects;
		private System.Windows.Forms.Button buttonFaster;
		private System.Windows.Forms.Button buttonSlower;
		private System.Windows.Forms.Button buttonForwards;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.Button buttonSet;
		private System.Windows.Forms.TextBox textBoxLog;
		private System.Windows.Forms.Label labelSpeed;
	}
}