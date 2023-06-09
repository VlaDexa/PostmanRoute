namespace PostmanRouteForms
{
	enum CellStatus
	{
		None, PostOffice, PostBox, PostMan
	}

	public partial class Form1 : Form
	{
		int click = 0;
		readonly CellStatus[,] cells = new CellStatus[9, 9];
		readonly Panel[,] panels = new Panel[9, 9];

		public Form1()
		{
			InitializeComponent();
			var size_x = 35;
			var size_y = size_x;
			// Place 9x9 panels on the form
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					// Create a new button
					Panel button = new()
					{
						AccessibleName = $"{i} {j}",
						// Set the button's size
						Size = new Size(size_x, size_y),
						// Set the button's location
						Location = new Point(Width / 2 - size_x * 9 / 2 + size_x * j, Height / 2 - size_x * 9 / 2 - 20 + size_y * i),
						BackColor = Color.White,
						BorderStyle = BorderStyle.FixedSingle,
						// Set the button's name
						Name = $"button{i}{j}"
					};
					button.Click += Panel_Click;
					panels[i, j] = button;
					// Set the button's text
					// Add the button to the grid
					Controls.Add(button);
				}
			}
		}

		private void UpdatePanelColors()
		{
			for (var i = 0; i < 9; i++)
			{
				for (var j = 0; j < 9; j++)
				{
					panels[i, j].BackColor = cells[i, j] switch
					{
						CellStatus.None => Color.White,
						CellStatus.PostOffice => Color.Blue,
						CellStatus.PostBox => Color.Red,
						CellStatus.PostMan => Color.Green,
						_ => Color.Yellow
					};
					panels[i, j].Refresh();
				}
			}
		}

		private void Panel_Click(object sender, EventArgs e)
		{
			// On first click place postoffice, on the next ones place postboxes
			var panel = (Panel)sender;

			// panel.AccessibleName = "y x"
			var coords = panel.AccessibleName!.Split(' ');

			var x = int.Parse(coords[0]);
			var y = int.Parse(coords[1]);

			cells[x, y] = click++ == 0 ? CellStatus.PostOffice : CellStatus.PostBox;
			UpdatePanelColors();
		}

		private void Reset()
		{
			Start.Enabled = true;
			Capacity.Enabled = true;
			Capacity.Text = "";
			LeftToDeliverLabel.Visible = false;
			LeftInBagLabel.Visible = false;
			LeftToDeliver.Visible = false;
			LeftToDeliver.Text = "";
			LeftInBag.Visible = false;
			LeftInBag.Text = "";
			for (var i = 0; i < 9; i++) for (var j = 0; j < 9; j++) cells[i, j] = CellStatus.None;
			UpdatePanelColors();
			click = 0;
		}

		private void Start_Click(object sender, EventArgs e)
		{
			// cells shoul have at least one postoffice and a postbox
			// Capacity should have a number bigger than 0

			// if true, disable sender
			var button = (Button)sender;

			var hasPostOffice = false;
			var hasPostBox = false;

			for (var i = 0; i < 9; i++)
			{
				for (var j = 0; j < 9; j++)
				{
					if (cells[i, j] == CellStatus.PostBox)
					{
						hasPostBox = true;
					}
					else if (cells[i, j] == CellStatus.PostOffice)
					{
						hasPostOffice = true;
					}
				}
			}

			var isCapacityOk = uint.TryParse(Capacity.Text, out uint res) && res > 0;

			if (!isCapacityOk) MessageBox.Show("������������ ����������� �����");
			else if (!hasPostOffice) MessageBox.Show("��������� ��������� �����");
			else if (!hasPostBox) MessageBox.Show("��������� ���� �� ���� ����� ��� ��������");

			if (isCapacityOk && hasPostBox && hasPostOffice) {
				UpdatePanelColors();
				button.Enabled = false;
				button.Refresh();
				Capacity.Enabled = false;
				Capacity.Refresh();
				LeftToDeliverLabel.Visible = true;
				LeftInBagLabel.Visible = true;
				LeftInBagLabel.Refresh();
				LeftToDeliverLabel.Refresh();
				LeftInBag.Visible = true;
				LeftToDeliver.Visible = true;
				var solver = new MyGraph(cells);
				var path = solver.GetPaths(res);

				foreach (var (x, y, leftToDeliver, inBagLetters) in path)
				{
					var prevState = cells[y, x];
					cells[y, x] = CellStatus.PostMan;
					UpdatePanelColors();
					LeftInBag.Text = inBagLetters.ToString();
					LeftInBag.Refresh();
					LeftToDeliver.Text = leftToDeliver.ToString();
					LeftToDeliver.Refresh();
					Thread.Sleep(500);
					cells[y, x] = prevState;
				}
				UpdatePanelColors();
				MessageBox.Show("Done");
			}
		}

		private void Reset_Click(object sender, EventArgs e)
		{
			Reset();
		}
	}
}