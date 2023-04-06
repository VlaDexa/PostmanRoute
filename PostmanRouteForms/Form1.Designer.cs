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
			Capacity = new TextBox();
			Start = new Button();
			label1 = new Label();
			SuspendLayout();
			// 
			// Capacity
			// 
			Capacity.Location = new Point(154, 22);
			Capacity.Name = "Capacity";
			Capacity.Size = new Size(150, 31);
			Capacity.TabIndex = 0;
			// 
			// Start
			// 
			Start.Location = new Point(347, 404);
			Start.Name = "Start";
			Start.Size = new Size(112, 34);
			Start.TabIndex = 1;
			Start.Text = "Старт";
			Start.UseVisualStyleBackColor = true;
			Start.Click += Start_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(31, 25);
			label1.Name = "label1";
			label1.Size = new Size(117, 25);
			label1.TabIndex = 2;
			label1.Text = "Вместимость";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(label1);
			Controls.Add(Start);
			Controls.Add(Capacity);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox Capacity;
		private Button Start;
		private Label label1;
	}
}