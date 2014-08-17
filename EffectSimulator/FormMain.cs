using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Media;

using TikiTankCommon;

namespace EffectSimulator
{
	public enum Tank
	{
		Forward,
		Stopped,
		Backward
	}

	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();

			textBoxLog.AppendText("Tiki Tank Simulator... Log output goes heres!\n\n");

			Output.Flushed += Output_Flushed;
			Output.AutoFlush = true;

			Console.SetOut(Output);
			Console.SetError(Output);

			DefaultButtonBackground = buttonStop.BackColor;

			listBoxEffects.Sorted = true;
			LoadEffects();
			listBoxEffects.SelectedIndex = 0;

			_timer.Interval = 50;
			_timer.Tick += _timer_Tick;
			_timer.Start();

			_timerTick.Interval = 100;
			_timerTick.Tick += _timerTick_Tick;

			Color = Color.Black;
			Tank = Tank.Stopped;
			Speed = 100;
		}

		void Output_Flushed(object sender, EventArgs args)
		{
			textBoxLog.AppendText(Output.GetStringBuilder().ToString());
			Output.GetStringBuilder().Clear();
		}

		void _timerTick_Tick(object sender, EventArgs e)
		{
			Effect.Tick();
		}

		void _timer_Tick(object sender, EventArgs e)
		{
			if (Effect.WouldUpdate())
			{
				if (Effect is IBarrelEffect)
					Effect.FrameUpdate(BarrelPixels);
				if (Effect is ITreadEffect)
					Effect.FrameUpdate(TreadPixels);
				if (Effect is IPanelEffect)
					Effect.FrameUpdate(PanelPixels);

				Invalidate();
			}
		}

		Dictionary<string, IEffect> effects = new Dictionary<string, IEffect>();

		Color DefaultButtonBackground;

		public StringWriterExt Output = new StringWriterExt();

		public IEffect Effect { get; set; }
		public Color Color { get; set; }
		public string Argument { get; set; }

		int _speed = 0;
		public int Speed
		{
			get
			{
				return _speed;
			}
			set
			{

				_speed = value;
				labelSpeed.Text = _speed.ToString();

				if(Tank != EffectSimulator.Tank.Stopped)
					_timerTick.Stop();
				
				_timerTick.Interval = _speed;

				if (Tank != EffectSimulator.Tank.Stopped)
					_timerTick.Start();
			}
		}

		public Color[] TreadPixels = new Color[480];
		public Color[] BarrelPixels = new Color[77];
		public Color[] PanelPixels = new Color[10];

		Timer _timer = new Timer();
		Timer _timerTick = new Timer();

		Tank _tank;
		public Tank Tank
		{
			get { return _tank; }
			set
			{
				_tank = value;

				buttonStop.BackColor = DefaultButtonBackground;
				buttonForwards.BackColor = DefaultButtonBackground;
				buttonBack.BackColor = DefaultButtonBackground;

				switch(_tank)
				{
					case Tank.Stopped:
						_timerTick.Stop();
						buttonStop.BackColor = Color.LightBlue;
						Effect.Argument = "0";
						break;
					case Tank.Forward:
						_timerTick.Start();
						buttonForwards.BackColor = Color.LightBlue;
						Effect.Argument = "1";
						break;
					case Tank.Backward:
						_timerTick.Start();
						buttonBack.BackColor = Color.LightBlue;
						Effect.Argument = "-1";
						break;
				}
			}
		}

		private void LoadEffects()
		{
			var ass = Assembly.GetAssembly(typeof(IEffect));
			foreach (var t in ass.GetExportedTypes())
			{
				if (t.IsClass && t.GetInterfaces().Contains(typeof(IEffect)) && t != typeof(IEffect))
				{
					effects[t.Name] = (IEffect)t.GetConstructor(new Type[0]).Invoke(new object[0]);
					listBoxEffects.Items.Add(t.Name);
				}
			}
		}

		private void buttonColor_Click(object sender, EventArgs e)
		{
			var dialog = new ColorDialog();
			if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				return;

			buttonColor.BackColor = dialog.Color;
			Color = dialog.Color;
			Effect.Color = Color;
		}

		private void buttonSlower_Click(object sender, EventArgs e)
		{
			Speed += 30;
		}

		private void buttonFaster_Click(object sender, EventArgs e)
		{
			Speed -= 30;
		}

		private void buttonBack_Click(object sender, EventArgs e)
		{
			Tank = EffectSimulator.Tank.Backward;
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			Tank = EffectSimulator.Tank.Stopped;
		}

		private void buttonForwards_Click(object sender, EventArgs e)
		{
			Tank = EffectSimulator.Tank.Forward;
		}

		private void buttonSet_Click(object sender, EventArgs e)
		{

		}

		private void ClearPixels()
		{
			for (int i = 0; i < TreadPixels.Length; i++)
				BarrelPixels[i] = Color.Black;
			
			for (int i = 0; i < BarrelPixels.Length; i++)
				BarrelPixels[i] = Color.Black;

			for (int i = 0; i < PanelPixels.Length; i++)
				BarrelPixels[i] = Color.Black;
		}

		private void listBoxEffects_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Effect is IBarrelEffect)
				Effect.Deactivate(BarrelPixels);
			if (Effect is ITreadEffect)
				Effect.Deactivate(TreadPixels);
			if (Effect is IPanelEffect)
				Effect.Deactivate(PanelPixels);

			Effect = effects[(string)listBoxEffects.SelectedItem];

			if (Effect.IsSensorDriven)
				_timer.Interval = 10 * Speed;
			else
				_timer.Interval = 10;

			if (Effect is IBarrelEffect)
				Effect.Activate(BarrelPixels);
			if (Effect is ITreadEffect)
				Effect.Activate(TreadPixels);
			if (Effect is IPanelEffect)
				Effect.Activate(PanelPixels);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			Graphics g = e.Graphics;
			var brush = new SolidBrush(Color.Black);
			var pen = new Pen(Color.DarkGray, 1);

			int size = 5;

			// Display barrel

			Point start = new Point(13, 50);

			g.DrawRectangle(pen, 12, 40, ((size + 1) * BarrelPixels.Length) + 1, 45);

			for (int i = 0; i < BarrelPixels.Length; i++)
			{
				brush.Color = BarrelPixels[i];
				g.FillRectangle(brush, start.X + ((size + 1) * i), start.Y, size, size);
				g.FillRectangle(brush, start.X + ((size + 1) * i), start.Y+20, size, size);
			}

			// Display treads

			brush.Color = Color.BlueViolet;
			start = new Point(13, 150);
			size = 5;

			g.DrawRectangle(pen, 
				start.X - 2, 
				start.Y - 2, 
				((size + 1) * 200) + 10, 
				((size + 1) * 40)  + 10);

			int x = 0;

			for (int i = 0; i < 200; i++, x++)
			{
				brush.Color = TreadPixels[x];
				//brush.Color = Color.White;
				g.FillRectangle(brush, start.X + ((size + 1) * i), start.Y, size, size);
			}

			start = new Point(13 + ((size + 1) * 200), 150);

			for (int i = 0; i < 40; i++, x++)
			{
				brush.Color = TreadPixels[x];
				//brush.Color = Color.White;
				g.FillRectangle(brush, start.X, start.Y + ((size + 1) * i), size, size);
			}

			start = new Point(13+size+1, start.Y + ((size + 1) * 40));

			x += 200;
			for (int i = 0; i < 200; i++, x--)
			{
				brush.Color = TreadPixels[x];
				//brush.Color = Color.BlueViolet;
				g.FillRectangle(brush, start.X + ((size + 1) * i), start.Y, size, size);
			}

			x += 200;

			start = new Point(13, 150+size+1);

			x += 39;
			for (int i = 0; i < 40; i++, x--)
			{
				brush.Color = TreadPixels[x];
				//brush.Color = Color.LightPink;
				g.FillRectangle(brush, start.X, start.Y + ((size + 1) * i), size, size);
			}

			// Display Panels

			pen = new Pen(Color.AliceBlue, 5);
			start = new Point(13, 450);
			size = 40;

			for(int i = 0; i < PanelPixels.Length; i++)
			{
				pen.Color = PanelPixels[i];
				g.DrawRectangle(pen, start.X + ((size + 10) * i), start.Y, size, size);
			}
		}
	}
}
