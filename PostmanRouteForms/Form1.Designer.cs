namespace PostmanRouteForms
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Capacity = new System.Windows.Forms.TextBox();
			this.Start = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.LeftToDeliverLabel = new System.Windows.Forms.Label();
			this.LeftToDeliver = new System.Windows.Forms.Label();
			this.LeftInBagLabel = new System.Windows.Forms.Label();
			this.LeftInBag = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Capacity
			// 
			this.Capacity.Location = new System.Drawing.Point(108, 13);
			this.Capacity.Margin = new System.Windows.Forms.Padding(2);
			this.Capacity.Name = "Capacity";
			this.Capacity.Size = new System.Drawing.Size(106, 23);
			this.Capacity.TabIndex = 0;
			// 
			// Start
			// 
			this.Start.Location = new System.Drawing.Point(339, 412);
			this.Start.Margin = new System.Windows.Forms.Padding(2);
			this.Start.Name = "Start";
			this.Start.Size = new System.Drawing.Size(78, 28);
			this.Start.TabIndex = 1;
			this.Start.Text = "Старт";
			this.Start.UseVisualStyleBackColor = true;
			this.Start.Click += new System.EventHandler(this.Start_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 15);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Вместимость";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(421, 412);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(78, 28);
			this.button1.TabIndex = 3;
			this.button1.Text = "Сброс";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Reset_Click);
			// 
			// LeftToDeliverLabel
			// 
			this.LeftToDeliverLabel.AutoSize = true;
			this.LeftToDeliverLabel.Location = new System.Drawing.Point(347, 15);
			this.LeftToDeliverLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.LeftToDeliverLabel.Name = "LeftToDeliverLabel";
			this.LeftToDeliverLabel.Size = new System.Drawing.Size(152, 15);
			this.LeftToDeliverLabel.TabIndex = 4;
			this.LeftToDeliverLabel.Text = "Осталось принести писем";
			this.LeftToDeliverLabel.Visible = false;
			// 
			// LeftToDeliver
			// 
			this.LeftToDeliver.AutoSize = true;
			this.LeftToDeliver.Location = new System.Drawing.Point(503, 15);
			this.LeftToDeliver.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.LeftToDeliver.Name = "LeftToDeliver";
			this.LeftToDeliver.Size = new System.Drawing.Size(0, 15);
			this.LeftToDeliver.TabIndex = 5;
			// 
			// LeftInBagLabel
			// 
			this.LeftInBagLabel.AutoSize = true;
			this.LeftInBagLabel.Location = new System.Drawing.Point(575, 15);
			this.LeftInBagLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.LeftInBagLabel.Name = "LeftInBagLabel";
			this.LeftInBagLabel.Size = new System.Drawing.Size(89, 15);
			this.LeftInBagLabel.TabIndex = 6;
			this.LeftInBagLabel.Text = "Писем в сумке";
			this.LeftInBagLabel.Visible = false;
			// 
			// LeftInBag
			// 
			this.LeftInBag.AutoSize = true;
			this.LeftInBag.Location = new System.Drawing.Point(668, 15);
			this.LeftInBag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.LeftInBag.Name = "LeftInBag";
			this.LeftInBag.Size = new System.Drawing.Size(0, 15);
			this.LeftInBag.TabIndex = 7;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(845, 451);
			this.Controls.Add(this.LeftInBag);
			this.Controls.Add(this.LeftInBagLabel);
			this.Controls.Add(this.LeftToDeliver);
			this.Controls.Add(this.LeftToDeliverLabel);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Start);
			this.Controls.Add(this.Capacity);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TextBox Capacity;
		private Button Start;
		private Label label1;
		private Button button1;
		private Label LeftToDeliverLabel;
		private Label LeftToDeliver;
		private Label LeftInBagLabel;
		private Label LeftInBag;
	}
}