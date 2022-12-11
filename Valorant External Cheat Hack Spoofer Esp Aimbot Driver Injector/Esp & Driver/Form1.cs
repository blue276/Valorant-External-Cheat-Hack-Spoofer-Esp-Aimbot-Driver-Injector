using iBaseult.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBaseult
{
	public class Form1 : Form
	{
		private static Random random;

		private int dx;

		private int df;

		private MoveInfo _mevent;

		public int xSize;

		public int ySize;

		private int msShootTime = 225;

		private DateTime lastShot = DateTime.Now;

		private int offsetY = 10;

		private bool isTriggerbot;

		private bool isAimbot;

		private bool isEsp;

		private bool TriggerRage;

		public bool isCircle;

		private bool isRecoil;

		private bool isBhop;

		private decimal PingX = new decimal(50);

		private decimal speed = decimal.One;

		private decimal speed3 = decimal.One;

		private decimal Bhop = new decimal(4);

		private decimal delayx = new decimal(100);

		public int fovX = 100;

		public int FovCircleRed = 1;

		public int FovCircleGreen = 1;

		public int FovCircleBlue = 1;

		public int FovCircleWidth = 1;

		public int fovY = 100;

		private bool isAimKey;

		private bool isHold = true;

		private int monitor;

		private int colorVariation = 25;

		private Form1.AimKey mainAimKey = Form1.AimKey.Alt;

		private Form1.Bhopkey Bhopxkey = Form1.Bhopkey.Alt;

		private Form1.ColorType color = Form1.ColorType.Purple;

		private float zoom = 1f;

		private Thread mainThread;

		private bool isRunning;

		private bool slowmove;

		private int antirecoilval;

		private IContainer components;

		public NumericUpDown CircleBlue;

		public NumericUpDown CircleGreen;

		public NumericUpDown CircleRed;

		public NumericUpDown CircleWidth;

		public CheckBox TriggerbotBtt;

		public Label label1;

		public Label label2;

		public Label label3;

		public RadioButton RedRadio;

		public RadioButton PurpleRadio;

		public Button ChangeMonitorBtt;

		public CheckBox AimKeyToggle;

		public CheckBox IsHoldToggle;

		public Button StartBtt;

		public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		public Label label4;

		public Label label5;

		public NumericUpDown FireRateNum;

		public Label label6;

		public Label label8;

		public Label label9;

		public RadioButton Customcolor;

		public Label label11;

		public NumericUpDown Redinput;

		public NumericUpDown Greeninput;

		public NumericUpDown Blueinput;

		public Label label12;

		public Label label13;

		public Label label14;

		public NumericUpDown Pingx;

		public Label label15;

		public Label label17;

		public NumericUpDown ScreenX2;

		public NumericUpDown ScreenY2;

		public Label label18;

		public Label ScreenY;

		public CheckBox CustomScreen;

		public ToolTip toolTip1;

		public CheckBox Bhopbox;

		public NumericUpDown Bhopinput;

		public Label label19;

		public Button TriggerKeyBtt;

		public System.Windows.Forms.ContextMenuStrip contextMenuStrip2;

		public Label label10;

		public Label label20;

		public Label label21;

		public Label label22;

		public Label label23;

		public Label label25;

		public CheckBox RecoilBtt;

		public CheckBox EspBtt;

		public CheckBox CircleBtt;

		public Label label7;

		public Label label27;

		public Label label26;

		public Label label28;

		public NumericUpDown Bdelay;

		public Label label30;

		public Label label31;

		public Label label32;

		public Label label29;

		public Label label36;

		public Label label37;

		public Label label38;

		public NumericUpDown ColB;

		public NumericUpDown ColG;

		public NumericUpDown ColR;

		public Label label39;

		public Label label41;

		public NumericUpDown ColY;

		public NumericUpDown ColX;

		public Label label42;

		public CheckBox AimbotBtt;

		public NumericUpDown Speed;

		public NumericUpDown FovXNum;

		public NumericUpDown FovYNum;

		public NumericUpDown offsetNum;

		public NumericUpDown Speed3;

		public NumericUpDown Delayx;

		public NumericUpDown SmoothX;

		public NumericUpDown rcs;

		public Button AimkeyBtt;

		public BackgroundWorker backgroundWorker1;

		public Label label48;

		public NumericUpDown ColWidth;

		public Label label49;

		public Label label50;

		private CheckBox TargetCheck;

		public NumericUpDown chanceval;

		public Label label24;

		public Label label51;

		public CheckBox Ragebot;

		public Label label52;

		public NumericUpDown Firerage;

		public Label label53;

		public NumericUpDown Rageoff;

		public Label label54;

		public NumericUpDown Ragey;

		public Label label55;

		public NumericUpDown Ragex;

		public Label label56;

		public NumericUpDown Ragehuman;

		public Label label57;

		public NumericUpDown Norecoilaimval;

		public Button button1;

		public Button button2;

		public Button button3;

		static Form1()
		{
			Form1.random = new Random();
		}

		public Form1()
		{
			int i;
			this.InitializeComponent();
			this.Text = Form1.Dice(6);
			this.isTriggerbot = this.GetKey<bool>("isTriggerbot");
			this.isAimbot = this.GetKey<bool>("isAimbot");
			this.isEsp = this.GetKey<bool>("isEsp");
			this.TriggerRage = this.GetKey<bool>("TriggerRage");
			this.isCircle = this.GetKey<bool>("isCircle");
			this.speed = this.GetKey<decimal>("speed");
			this.speed3 = this.GetKey<decimal>("speed3");
			this.delayx = this.GetKey<decimal>("delayx");
			this.Bhop = this.GetKey<decimal>("Bhop");
			this.fovX = this.GetKey<int>("fovX");
			this.FovCircleRed = this.GetKey<int>("FovCircleRed");
			this.isRunning = this.GetKey<bool>("isRunning");
			this.FovCircleGreen = this.GetKey<int>("FovCircleGreen");
			this.FovCircleBlue = this.GetKey<int>("FovCircleBlue");
			this.FovCircleWidth = this.GetKey<int>("FovCircleWidth");
			this.fovY = this.GetKey<int>("fovY");
			this.color = (Form1.ColorType)this.GetKey<int>("color");
			this.mainAimKey = (Form1.AimKey)this.GetKey<int>("mainAimKey");
			this.Bhopxkey = (Form1.Bhopkey)this.GetKey<int>("Bhopxkey");
			this.isAimKey = this.GetKey<bool>("isAimKey");
			this.isHold = this.GetKey<bool>("isHold");
			this.monitor = this.GetKey<int>("monitor");
			this.offsetY = this.GetKey<int>("offsetY");
			this.msShootTime = this.GetKey<int>("msShootTime");
			this.isRecoil = this.GetKey<bool>("isRecoil");
			this.isBhop = this.GetKey<bool>("isBhop");
			this.PingX = this.GetKey<decimal>("PingX");
			Form1.ColorType colorType = this.color;
			if (colorType == Form1.ColorType.Red)
			{
				this.RedRadio.Checked = true;
			}
			else if (colorType == Form1.ColorType.Purple)
			{
				this.PurpleRadio.Checked = true;
			}
			this.UpdateUI();
			this.IsHoldToggle.Checked = this.isHold;
			this.AimbotBtt.Checked = this.isAimbot;
			this.EspBtt.Checked = this.isEsp;
			this.Ragebot.Checked = this.TriggerRage;
			this.CircleBtt.Checked = this.isCircle;
			this.RecoilBtt.Checked = this.isRecoil;
			this.Bhopbox.Checked = this.isBhop;
			this.AimKeyToggle.Checked = this.isAimKey;
			this.Speed.Value = this.speed;
			this.Speed3.Value = this.speed3;
			this.Delayx.Value = this.delayx;
			this.Bhopinput.Value = this.Bhop;
			this.FovXNum.Value = this.fovX;
			this.CircleRed.Value = this.FovCircleRed;
			this.CircleGreen.Value = this.FovCircleGreen;
			this.CircleBlue.Value = this.FovCircleBlue;
			this.CircleWidth.Value = this.FovCircleWidth;
			this.FovYNum.Value = this.fovY;
			this.TriggerbotBtt.Checked = this.isTriggerbot;
			this.offsetNum.Value = this.offsetY;
			this.FireRateNum.Value = this.msShootTime;
			string[] names = Enum.GetNames(typeof(Form1.AimKey));
			for (i = 0; i < (int)names.Length; i++)
			{
				string text = names[i];
				this.contextMenuStrip1.Items.Add(text);
			}
			this.contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler((object o, ToolStripItemClickedEventArgs e) => {
				this.mainAimKey = (Form1.AimKey)Enum.Parse(typeof(Form1.AimKey), e.ClickedItem.ToString());
				this.SetKey("mainAimKey", (int)this.mainAimKey);
				this.UpdateUI();
			});
			names = Enum.GetNames(typeof(Form1.Bhopkey));
			for (i = 0; i < (int)names.Length; i++)
			{
				string text = names[i];
				this.contextMenuStrip2.Items.Add(text);
			}
			this.contextMenuStrip2.ItemClicked += new ToolStripItemClickedEventHandler((object o, ToolStripItemClickedEventArgs e) => {
				this.Bhopxkey = (Form1.Bhopkey)Enum.Parse(typeof(Form1.Bhopkey), e.ClickedItem.ToString());
				this.SetKey("Bhopxkey", (int)this.Bhopxkey);
				this.UpdateUI();
			});
			this.AutoSize = false;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Font = new System.Drawing.Font("Trebuchet MS", 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		}

		private void AimKeyDrop(object sender, EventArgs e)
		{
			if (this.AimkeyBtt.PointToScreen(new Point(this.AimkeyBtt.Left, this.AimkeyBtt.Bottom)).Y + this.contextMenuStrip1.Size.Height <= Screen.PrimaryScreen.WorkingArea.Height)
			{
				this.contextMenuStrip1.Show(this.AimkeyBtt, new Point(0, this.AimkeyBtt.Height));
				return;
			}
			System.Windows.Forms.ContextMenuStrip contextMenuStrip = this.contextMenuStrip1;
			Button aimkeyBtt = this.AimkeyBtt;
			System.Drawing.Size size = this.contextMenuStrip1.Size;
			contextMenuStrip.Show(aimkeyBtt, new Point(0, -size.Height));
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.Ragebot.Checked)
			{
				this.AimbotBtt.Enabled = true;
				this.Speed.Enabled = true;
				this.FovXNum.Enabled = true;
				this.FovYNum.Enabled = true;
				this.offsetNum.Enabled = true;
				this.TriggerbotBtt.Enabled = true;
				this.Pingx.Enabled = true;
				this.FireRateNum.Enabled = true;
				this.label7.Enabled = true;
				this.label14.Enabled = true;
				this.label1.Enabled = true;
				this.label2.Enabled = true;
				this.label3.Enabled = true;
				this.label4.Enabled = true;
				this.label5.Enabled = true;
				this.label15.Enabled = true;
			}
			else
			{
				this.AimbotBtt.Enabled = false;
				this.Speed.Enabled = false;
				this.FovXNum.Enabled = false;
				this.FovYNum.Enabled = false;
				this.offsetNum.Enabled = false;
				this.TriggerbotBtt.Enabled = false;
				this.Pingx.Enabled = false;
				this.FireRateNum.Enabled = false;
				this.label7.Enabled = false;
				this.label14.Enabled = false;
				this.label1.Enabled = false;
				this.label2.Enabled = false;
				this.label3.Enabled = false;
				this.label4.Enabled = false;
				this.label5.Enabled = false;
				this.label15.Enabled = false;
				this.speed = this.Ragehuman.Value;
				this.SetKey("speed", this.speed);
				this.fovX = (int)this.Ragex.Value;
				this.SetKey("fovX", this.fovX);
				this.fovY = (int)this.Ragey.Value;
				this.SetKey("fovY", this.fovY);
				this.msShootTime = (int)this.Firerage.Value;
				this.SetKey("msShootTime", this.msShootTime);
				this.offsetY = (int)this.Rageoff.Value;
				this.SetKey("offsetY", this.offsetY);
			}
			this.TriggerRage = this.Ragebot.Checked;
			this.SetKey("TriggerRage", this.TriggerRage);
		}

		private void CheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			this.isBhop = this.Bhopbox.Checked;
			this.SetKey("isBhop", this.isBhop);
		}

		private void checkBox2_CheckedChanged_2(object sender, EventArgs e)
		{
			this.isEsp = this.EspBtt.Checked;
			this.SetKey("isEsp", this.isEsp);
		}

		private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
		{
			if (this.CircleBtt.Checked && this.isRunning)
			{
				MessageBox.Show("Please Stop and Start the Cheat again for the Fov Circle!");
			}
			this.isCircle = this.CircleBtt.Checked;
			this.SetKey("isCircle", this.isCircle);
		}

		private void CircleBlue_ValueChanged(object sender, EventArgs e)
		{
			this.FovCircleBlue = (int)this.CircleBlue.Value;
			this.SetKey("FovCircleBlue", this.FovCircleBlue);
		}

		private void CircleGreen_ValueChanged(object sender, EventArgs e)
		{
			this.FovCircleGreen = (int)this.CircleGreen.Value;
			this.SetKey("FovCircleGreen", this.FovCircleGreen);
		}

		private void CircleRed_ValueChanged(object sender, EventArgs e)
		{
			this.FovCircleRed = (int)this.CircleRed.Value;
			this.SetKey("FovCircleRed", this.FovCircleRed);
		}

		private void CircleWidth_ValueChanged(object sender, EventArgs e)
		{
			this.FovCircleWidth = (int)this.CircleWidth.Value;
			this.SetKey("FovCircleWidth", this.FovCircleWidth);
		}

		private void ColWidth_ValueChanged(object sender, EventArgs e)
		{
		}

		private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
		}

		private void ContextMenuStrip2_Opening(object sender, CancelEventArgs e)
		{
		}

		public Screen CurrentScreen()
		{
			return Screen.AllScreens[this.monitor];
		}

		public static string Dice(int length)
		{
			return new string((
				from s in Enumerable.Repeat<string>("qwerasdfyxcv", length)
				select s[Form1.random.Next(s.Length)]).ToArray<char>());
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void FireRate_changed(object sender, EventArgs e)
		{
			this.msShootTime = (int)this.FireRateNum.Value;
			this.SetKey("msShootTime", this.msShootTime);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				Environment.Exit(0);
				base.Close();
			}
			catch
			{
			}
		}

		private void FovX_changed(object sender, EventArgs e)
		{
			this.fovX = (int)this.FovXNum.Value;
			this.SetKey("fovX", this.fovX);
		}

		private void FovY_changed(object sender, EventArgs e)
		{
			this.fovY = (int)this.FovYNum.Value;
			this.SetKey("fovY", this.fovY);
		}

		[DllImport("user32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern short GetAsyncKeyState(int vKey);

		public static int GetColor(Form1.ColorType color)
		{
			if (color == Form1.ColorType.Red)
			{
				return 10092544;
			}
			if (color != Form1.ColorType.Purple)
			{
				return 10626210;
			}
			return 11480751;
		}

		[DllImport("gdi32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

		private T GetKey<T>(string key)
		{
			return (T)Settings.Default[key];
		}

		[DllImport("USER32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern short GetKeyState(int nVirtKey);

		private static float GetScalingFactor()
		{
			IntPtr hdc = Graphics.FromHwnd(IntPtr.Zero).GetHdc();
			int deviceCaps = Form1.GetDeviceCaps(hdc, 10);
			return (float)Form1.GetDeviceCaps(hdc, 117) / (float)deviceCaps;
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
			this.AimbotBtt = new CheckBox();
			this.Speed = new NumericUpDown();
			this.FovXNum = new NumericUpDown();
			this.FovYNum = new NumericUpDown();
			this.offsetNum = new NumericUpDown();
			this.Speed3 = new NumericUpDown();
			this.Delayx = new NumericUpDown();
			this.SmoothX = new NumericUpDown();
			this.AimkeyBtt = new Button();
			this.rcs = new NumericUpDown();
			this.RecoilBtt = new CheckBox();
			this.TriggerbotBtt = new CheckBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.RedRadio = new RadioButton();
			this.PurpleRadio = new RadioButton();
			this.ChangeMonitorBtt = new Button();
			this.AimKeyToggle = new CheckBox();
			this.IsHoldToggle = new CheckBox();
			this.StartBtt = new Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.label4 = new Label();
			this.label5 = new Label();
			this.FireRateNum = new NumericUpDown();
			this.label6 = new Label();
			this.label8 = new Label();
			this.label9 = new Label();
			this.Customcolor = new RadioButton();
			this.label11 = new Label();
			this.Redinput = new NumericUpDown();
			this.Greeninput = new NumericUpDown();
			this.Blueinput = new NumericUpDown();
			this.label12 = new Label();
			this.label13 = new Label();
			this.label14 = new Label();
			this.Pingx = new NumericUpDown();
			this.label15 = new Label();
			this.label17 = new Label();
			this.ScreenX2 = new NumericUpDown();
			this.ScreenY2 = new NumericUpDown();
			this.label18 = new Label();
			this.ScreenY = new Label();
			this.CustomScreen = new CheckBox();
			this.toolTip1 = new ToolTip(this.components);
			this.Bhopbox = new CheckBox();
			this.Bhopinput = new NumericUpDown();
			this.TriggerKeyBtt = new Button();
			this.label10 = new Label();
			this.label20 = new Label();
			this.label21 = new Label();
			this.label22 = new Label();
			this.label25 = new Label();
			this.EspBtt = new CheckBox();
			this.CircleBtt = new CheckBox();
			this.label28 = new Label();
			this.Bdelay = new NumericUpDown();
			this.label30 = new Label();
			this.label31 = new Label();
			this.CircleBlue = new NumericUpDown();
			this.CircleGreen = new NumericUpDown();
			this.CircleRed = new NumericUpDown();
			this.label32 = new Label();
			this.label37 = new Label();
			this.label38 = new Label();
			this.ColB = new NumericUpDown();
			this.ColG = new NumericUpDown();
			this.ColR = new NumericUpDown();
			this.label39 = new Label();
			this.label41 = new Label();
			this.ColY = new NumericUpDown();
			this.ColX = new NumericUpDown();
			this.label42 = new Label();
			this.CircleWidth = new NumericUpDown();
			this.label48 = new Label();
			this.ColWidth = new NumericUpDown();
			this.label49 = new Label();
			this.TargetCheck = new CheckBox();
			this.chanceval = new NumericUpDown();
			this.label24 = new Label();
			this.Ragebot = new CheckBox();
			this.label52 = new Label();
			this.Firerage = new NumericUpDown();
			this.label53 = new Label();
			this.Rageoff = new NumericUpDown();
			this.label54 = new Label();
			this.Ragey = new NumericUpDown();
			this.label55 = new Label();
			this.Ragex = new NumericUpDown();
			this.label56 = new Label();
			this.Ragehuman = new NumericUpDown();
			this.label57 = new Label();
			this.Norecoilaimval = new NumericUpDown();
			this.label19 = new Label();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.label23 = new Label();
			this.label7 = new Label();
			this.label27 = new Label();
			this.label26 = new Label();
			this.label29 = new Label();
			this.label36 = new Label();
			this.backgroundWorker1 = new BackgroundWorker();
			this.label50 = new Label();
			this.label51 = new Label();
			this.button1 = new Button();
			this.button2 = new Button();
			this.button3 = new Button();
			((ISupportInitialize)this.Speed).BeginInit();
			((ISupportInitialize)this.FovXNum).BeginInit();
			((ISupportInitialize)this.FovYNum).BeginInit();
			((ISupportInitialize)this.offsetNum).BeginInit();
			((ISupportInitialize)this.Speed3).BeginInit();
			((ISupportInitialize)this.Delayx).BeginInit();
			((ISupportInitialize)this.SmoothX).BeginInit();
			((ISupportInitialize)this.rcs).BeginInit();
			((ISupportInitialize)this.FireRateNum).BeginInit();
			((ISupportInitialize)this.Redinput).BeginInit();
			((ISupportInitialize)this.Greeninput).BeginInit();
			((ISupportInitialize)this.Blueinput).BeginInit();
			((ISupportInitialize)this.Pingx).BeginInit();
			((ISupportInitialize)this.ScreenX2).BeginInit();
			((ISupportInitialize)this.ScreenY2).BeginInit();
			((ISupportInitialize)this.Bhopinput).BeginInit();
			((ISupportInitialize)this.Bdelay).BeginInit();
			((ISupportInitialize)this.CircleBlue).BeginInit();
			((ISupportInitialize)this.CircleGreen).BeginInit();
			((ISupportInitialize)this.CircleRed).BeginInit();
			((ISupportInitialize)this.ColB).BeginInit();
			((ISupportInitialize)this.ColG).BeginInit();
			((ISupportInitialize)this.ColR).BeginInit();
			((ISupportInitialize)this.ColY).BeginInit();
			((ISupportInitialize)this.ColX).BeginInit();
			((ISupportInitialize)this.CircleWidth).BeginInit();
			((ISupportInitialize)this.ColWidth).BeginInit();
			((ISupportInitialize)this.chanceval).BeginInit();
			((ISupportInitialize)this.Firerage).BeginInit();
			((ISupportInitialize)this.Rageoff).BeginInit();
			((ISupportInitialize)this.Ragey).BeginInit();
			((ISupportInitialize)this.Ragex).BeginInit();
			((ISupportInitialize)this.Ragehuman).BeginInit();
			((ISupportInitialize)this.Norecoilaimval).BeginInit();
			base.SuspendLayout();
			this.AimbotBtt.AutoSize = true;
			this.AimbotBtt.BackColor = Color.Crimson;
			this.AimbotBtt.Cursor = Cursors.Default;
			this.AimbotBtt.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.AimbotBtt.ForeColor = Color.White;
			this.AimbotBtt.Location = new Point(23, 51);
			this.AimbotBtt.Margin = new System.Windows.Forms.Padding(2);
			this.AimbotBtt.Name = "AimbotBtt";
			this.AimbotBtt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.AimbotBtt.Size = new System.Drawing.Size(75, 21);
			this.AimbotBtt.TabIndex = 0;
			this.AimbotBtt.TabStop = false;
			this.AimbotBtt.Text = "Aimbot";
			this.toolTip1.SetToolTip(this.AimbotBtt, "This feature aims automatically at your enemy");
			this.AimbotBtt.UseVisualStyleBackColor = false;
			this.AimbotBtt.CheckedChanged += new EventHandler(this.IsAimbot_changed);
			this.Speed.BackColor = SystemColors.Window;
			this.Speed.Cursor = Cursors.Default;
			this.Speed.DecimalPlaces = 2;
			this.Speed.ForeColor = SystemColors.WindowText;
			this.Speed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Speed.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
			this.Speed.InterceptArrowKeys = false;
			this.Speed.Location = new Point(435, 52);
			this.Speed.Margin = new System.Windows.Forms.Padding(2);
			this.Speed.Name = "Speed";
			this.Speed.Size = new System.Drawing.Size(45, 20);
			this.Speed.TabIndex = 3;
			this.Speed.TabStop = false;
			this.toolTip1.SetToolTip(this.Speed, "Change the Speed of your Aimbot while it is searching and aiming for your target.\r\n\r\nLower Values are more legit.");
			this.Speed.Value = new decimal(new int[] { 15, 0, 0, 131072 });
			this.Speed.ValueChanged += new EventHandler(this.Speed_changed);
			this.FovXNum.BackColor = SystemColors.Window;
			this.FovXNum.Cursor = Cursors.Default;
			this.FovXNum.ForeColor = SystemColors.WindowText;
			this.FovXNum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.FovXNum.InterceptArrowKeys = false;
			this.FovXNum.Location = new Point(435, 76);
			this.FovXNum.Margin = new System.Windows.Forms.Padding(2);
			this.FovXNum.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.FovXNum.Name = "FovXNum";
			this.FovXNum.Size = new System.Drawing.Size(45, 20);
			this.FovXNum.TabIndex = 5;
			this.FovXNum.TabStop = false;
			this.toolTip1.SetToolTip(this.FovXNum, "Your X Fov for Left and Right.\r\n\r\nHigher Value will increase the Fov.");
			this.FovXNum.Value = new decimal(new int[] { 350, 0, 0, 0 });
			this.FovXNum.ValueChanged += new EventHandler(this.FovX_changed);
			this.FovYNum.BackColor = SystemColors.Window;
			this.FovYNum.Cursor = Cursors.Default;
			this.FovYNum.ForeColor = SystemColors.WindowText;
			this.FovYNum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.FovYNum.InterceptArrowKeys = false;
			this.FovYNum.Location = new Point(435, 100);
			this.FovYNum.Margin = new System.Windows.Forms.Padding(2);
			this.FovYNum.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.FovYNum.Name = "FovYNum";
			this.FovYNum.Size = new System.Drawing.Size(45, 20);
			this.FovYNum.TabIndex = 7;
			this.FovYNum.TabStop = false;
			this.toolTip1.SetToolTip(this.FovYNum, "Your Y Fov for Up and Down.\r\n\r\nHigher Value will increase the Fov.\r\n");
			this.FovYNum.Value = new decimal(new int[] { 150, 0, 0, 0 });
			this.FovYNum.ValueChanged += new EventHandler(this.FovY_changed);
			this.offsetNum.BackColor = SystemColors.Window;
			this.offsetNum.Cursor = Cursors.Default;
			this.offsetNum.ForeColor = SystemColors.WindowText;
			this.offsetNum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.offsetNum.InterceptArrowKeys = false;
			this.offsetNum.Location = new Point(435, 124);
			this.offsetNum.Margin = new System.Windows.Forms.Padding(2);
			this.offsetNum.Minimum = new decimal(new int[] { 20, 0, 0, -2147483648 });
			this.offsetNum.Name = "offsetNum";
			this.offsetNum.Size = new System.Drawing.Size(45, 20);
			this.offsetNum.TabIndex = 16;
			this.offsetNum.TabStop = false;
			this.toolTip1.SetToolTip(this.offsetNum, "Will change the Aimspot.\r\n\r\n- Lower Value (Aims lower at your Body)\r\n- High Value (Aims higher at your Head)");
			this.offsetNum.Value = new decimal(new int[] { 15, 0, 0, 0 });
			this.offsetNum.ValueChanged += new EventHandler(this.OffsetY_changed);
			this.Speed3.BackColor = SystemColors.Window;
			this.Speed3.Cursor = Cursors.Default;
			this.Speed3.DecimalPlaces = 2;
			this.Speed3.ForeColor = SystemColors.WindowText;
			this.Speed3.ImeMode = System.Windows.Forms.ImeMode.On;
			this.Speed3.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
			this.Speed3.Location = new Point(435, 219);
			this.Speed3.Margin = new System.Windows.Forms.Padding(2);
			this.Speed3.Name = "Speed3";
			this.Speed3.Size = new System.Drawing.Size(45, 20);
			this.Speed3.TabIndex = 55;
			this.toolTip1.SetToolTip(this.Speed3, "Changes the Speed of your Aimbot as soon as you reach your Enemy with the Crosshair or the Smooth Aim Pixels.\r\nThis is like a second Fov on Lockon.\r\n\r\nLower Values are more legit.\r\n");
			this.Speed3.Value = new decimal(new int[] { 5, 0, 0, 131072 });
			this.Speed3.ValueChanged += new EventHandler(this.NumericUpDown1_ValueChanged_1);
			this.Delayx.BackColor = SystemColors.Window;
			this.Delayx.Cursor = Cursors.Default;
			this.Delayx.ForeColor = SystemColors.WindowText;
			this.Delayx.ImeMode = System.Windows.Forms.ImeMode.On;
			this.Delayx.Location = new Point(435, 267);
			this.Delayx.Margin = new System.Windows.Forms.Padding(2);
			this.Delayx.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.Delayx.Name = "Delayx";
			this.Delayx.Size = new System.Drawing.Size(45, 20);
			this.Delayx.TabIndex = 59;
			this.toolTip1.SetToolTip(this.Delayx, resources.GetString("Delayx.ToolTip"));
			this.Delayx.ValueChanged += new EventHandler(this.NumericUpDown1_ValueChanged_2);
			this.SmoothX.BackColor = SystemColors.Window;
			this.SmoothX.Cursor = Cursors.Default;
			this.SmoothX.ForeColor = SystemColors.WindowText;
			this.SmoothX.ImeMode = System.Windows.Forms.ImeMode.On;
			this.SmoothX.Location = new Point(435, 243);
			this.SmoothX.Margin = new System.Windows.Forms.Padding(2);
			this.SmoothX.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
			this.SmoothX.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.SmoothX.Name = "SmoothX";
			this.SmoothX.Size = new System.Drawing.Size(45, 20);
			this.SmoothX.TabIndex = 62;
			this.toolTip1.SetToolTip(this.SmoothX, resources.GetString("SmoothX.ToolTip"));
			this.SmoothX.Value = new decimal(new int[] { 120, 0, 0, 0 });
			this.AimkeyBtt.BackColor = Color.FromArgb(20, 20, 20);
			this.AimkeyBtt.FlatAppearance.BorderSize = 0;
			this.AimkeyBtt.FlatStyle = FlatStyle.Flat;
			this.AimkeyBtt.ForeColor = Color.FromArgb(255, 255, 192);
			this.AimkeyBtt.Location = new Point(23, 426);
			this.AimkeyBtt.Margin = new System.Windows.Forms.Padding(2);
			this.AimkeyBtt.Name = "AimkeyBtt";
			this.AimkeyBtt.Size = new System.Drawing.Size(82, 35);
			this.AimkeyBtt.TabIndex = 14;
			this.AimkeyBtt.Text = "Keybind";
			this.toolTip1.SetToolTip(this.AimkeyBtt, "Keybinding for Aimbot and Ragebot");
			this.AimkeyBtt.UseVisualStyleBackColor = false;
			this.AimkeyBtt.Click += new EventHandler(this.AimKeyDrop);
			this.rcs.BackColor = SystemColors.Window;
			this.rcs.Cursor = Cursors.Default;
			this.rcs.ForeColor = SystemColors.WindowText;
			this.rcs.Location = new Point(216, 427);
			this.rcs.Margin = new System.Windows.Forms.Padding(2);
			this.rcs.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
			this.rcs.Minimum = new decimal(new int[] { 10, 0, 0, -2147483648 });
			this.rcs.Name = "rcs";
			this.rcs.Size = new System.Drawing.Size(45, 20);
			this.rcs.TabIndex = 57;
			this.toolTip1.SetToolTip(this.rcs, resources.GetString("rcs.ToolTip"));
			this.RecoilBtt.AutoSize = true;
			this.RecoilBtt.BackColor = Color.Crimson;
			this.RecoilBtt.Cursor = Cursors.Default;
			this.RecoilBtt.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.RecoilBtt.ForeColor = Color.White;
			this.RecoilBtt.Location = new Point(23, 114);
			this.RecoilBtt.Margin = new System.Windows.Forms.Padding(2);
			this.RecoilBtt.Name = "RecoilBtt";
			this.RecoilBtt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.RecoilBtt.Size = new System.Drawing.Size(85, 21);
			this.RecoilBtt.TabIndex = 47;
			this.RecoilBtt.TabStop = false;
			this.RecoilBtt.Text = "NoRecoil";
			this.toolTip1.SetToolTip(this.RecoilBtt, "This feature will countermeasures against the recoil");
			this.RecoilBtt.UseVisualStyleBackColor = false;
			this.RecoilBtt.CheckedChanged += new EventHandler(this.Recoilcheckbox_CheckedChanged_1);
			this.TriggerbotBtt.AutoSize = true;
			this.TriggerbotBtt.BackColor = Color.Crimson;
			this.TriggerbotBtt.Cursor = Cursors.Default;
			this.TriggerbotBtt.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.TriggerbotBtt.ForeColor = Color.White;
			this.TriggerbotBtt.Location = new Point(23, 93);
			this.TriggerbotBtt.Margin = new System.Windows.Forms.Padding(2);
			this.TriggerbotBtt.Name = "TriggerbotBtt";
			this.TriggerbotBtt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TriggerbotBtt.Size = new System.Drawing.Size(92, 21);
			this.TriggerbotBtt.TabIndex = 1;
			this.TriggerbotBtt.Text = "Triggerbot";
			this.toolTip1.SetToolTip(this.TriggerbotBtt, "This feature will automatically shoot at your Enemy as soon as you aim at him.");
			this.TriggerbotBtt.UseVisualStyleBackColor = false;
			this.TriggerbotBtt.CheckedChanged += new EventHandler(this.IsTriggerbot_changed);
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Crimson;
			this.label1.Cursor = Cursors.Default;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label1.ForeColor = SystemColors.ButtonHighlight;
			this.label1.Location = new Point(493, 55);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Humanizer";
			this.toolTip1.SetToolTip(this.label1, "Change the Speed of your Aimbot while it is searching and aiming for your target.\r\n\r\nLower Values are more legit.\r\n");
			this.label2.AutoSize = true;
			this.label2.BackColor = Color.Crimson;
			this.label2.Cursor = Cursors.Default;
			this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label2.ForeColor = SystemColors.ButtonHighlight;
			this.label2.Location = new Point(493, 79);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "Aimbot Fov X";
			this.toolTip1.SetToolTip(this.label2, "Your X Fov for Left and Right.\r\n\r\nHigher Value will increase the Fov but may slow down your Aimbot Performance.\r\n");
			this.label3.AutoSize = true;
			this.label3.BackColor = Color.Crimson;
			this.label3.Cursor = Cursors.Default;
			this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label3.ForeColor = SystemColors.ButtonHighlight;
			this.label3.Location = new Point(493, 103);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 17);
			this.label3.TabIndex = 8;
			this.label3.Text = "Aimbot Fov Y";
			this.toolTip1.SetToolTip(this.label3, "Your Y Fov for Up and Down.\r\n\r\nHigher Value will increase the Fov but may slow down your Aimbot Performance.\r\n");
			this.RedRadio.AutoSize = true;
			this.RedRadio.BackColor = Color.Transparent;
			this.RedRadio.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.RedRadio.ForeColor = SystemColors.ButtonHighlight;
			this.RedRadio.Location = new Point(21, 288);
			this.RedRadio.Margin = new System.Windows.Forms.Padding(0);
			this.RedRadio.Name = "RedRadio";
			this.RedRadio.Size = new System.Drawing.Size(51, 21);
			this.RedRadio.TabIndex = 9;
			this.RedRadio.TabStop = true;
			this.RedRadio.Text = "Red";
			this.toolTip1.SetToolTip(this.RedRadio, "Enemy outline Color. Switch to the Color which your enemy has.");
			this.RedRadio.UseVisualStyleBackColor = false;
			this.RedRadio.CheckedChanged += new EventHandler(this.Red_changed);
			this.PurpleRadio.AutoSize = true;
			this.PurpleRadio.BackColor = Color.Transparent;
			this.PurpleRadio.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.PurpleRadio.ForeColor = SystemColors.ButtonHighlight;
			this.PurpleRadio.Location = new Point(72, 288);
			this.PurpleRadio.Margin = new System.Windows.Forms.Padding(0);
			this.PurpleRadio.Name = "PurpleRadio";
			this.PurpleRadio.Size = new System.Drawing.Size(66, 21);
			this.PurpleRadio.TabIndex = 10;
			this.PurpleRadio.TabStop = true;
			this.PurpleRadio.Text = "Purple";
			this.toolTip1.SetToolTip(this.PurpleRadio, "Enemy outline Color. Switch to the Color which your enemy has.");
			this.PurpleRadio.UseVisualStyleBackColor = false;
			this.PurpleRadio.CheckedChanged += new EventHandler(this.Purple_changed);
			this.ChangeMonitorBtt.BackColor = Color.FromArgb(20, 20, 20);
			this.ChangeMonitorBtt.FlatAppearance.BorderSize = 0;
			this.ChangeMonitorBtt.FlatStyle = FlatStyle.Flat;
			this.ChangeMonitorBtt.ForeColor = Color.FromArgb(255, 255, 192);
			this.ChangeMonitorBtt.Location = new Point(660, 384);
			this.ChangeMonitorBtt.Margin = new System.Windows.Forms.Padding(2);
			this.ChangeMonitorBtt.Name = "ChangeMonitorBtt";
			this.ChangeMonitorBtt.Size = new System.Drawing.Size(122, 40);
			this.ChangeMonitorBtt.TabIndex = 11;
			this.ChangeMonitorBtt.Text = "Change Screen";
			this.toolTip1.SetToolTip(this.ChangeMonitorBtt, "Change your Monitor");
			this.ChangeMonitorBtt.UseVisualStyleBackColor = false;
			this.ChangeMonitorBtt.Click += new EventHandler(this.MonitorChanged);
			this.AimKeyToggle.AutoSize = true;
			this.AimKeyToggle.BackColor = Color.Transparent;
			this.AimKeyToggle.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.AimKeyToggle.ForeColor = SystemColors.ButtonHighlight;
			this.AimKeyToggle.Location = new Point(660, 360);
			this.AimKeyToggle.Margin = new System.Windows.Forms.Padding(2);
			this.AimKeyToggle.Name = "AimKeyToggle";
			this.AimKeyToggle.Size = new System.Drawing.Size(74, 21);
			this.AimKeyToggle.TabIndex = 12;
			this.AimKeyToggle.Text = "AimKey";
			this.AimKeyToggle.TextAlign = ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.AimKeyToggle, "Enables the Aimkey Keybind");
			this.AimKeyToggle.UseVisualStyleBackColor = false;
			this.AimKeyToggle.Click += new EventHandler(this.IsAimKeyChanged);
			this.IsHoldToggle.AutoSize = true;
			this.IsHoldToggle.BackColor = Color.Transparent;
			this.IsHoldToggle.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.IsHoldToggle.ForeColor = Color.Snow;
			this.IsHoldToggle.Location = new Point(738, 360);
			this.IsHoldToggle.Margin = new System.Windows.Forms.Padding(2);
			this.IsHoldToggle.Name = "IsHoldToggle";
			this.IsHoldToggle.Size = new System.Drawing.Size(57, 21);
			this.IsHoldToggle.TabIndex = 13;
			this.IsHoldToggle.Text = "Hold";
			this.toolTip1.SetToolTip(this.IsHoldToggle, "Press and Hold the Aimkey for Triggerbot and Aimbot");
			this.IsHoldToggle.UseVisualStyleBackColor = false;
			this.IsHoldToggle.CheckedChanged += new EventHandler(this.IsHold_changed);
			this.StartBtt.BackColor = Color.Green;
			this.StartBtt.FlatAppearance.BorderSize = 0;
			this.StartBtt.FlatStyle = FlatStyle.Flat;
			this.StartBtt.ForeColor = Color.FromArgb(255, 255, 192);
			this.StartBtt.Location = new Point(838, 437);
			this.StartBtt.Margin = new System.Windows.Forms.Padding(2);
			this.StartBtt.Name = "StartBtt";
			this.StartBtt.Size = new System.Drawing.Size(73, 75);
			this.StartBtt.TabIndex = 15;
			this.StartBtt.Text = "Start";
			this.StartBtt.UseVisualStyleBackColor = false;
			this.StartBtt.Click += new EventHandler(this.Start_click);
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			this.contextMenuStrip1.Opening += new CancelEventHandler(this.ContextMenuStrip1_Opening);
			this.label4.AutoSize = true;
			this.label4.BackColor = Color.Crimson;
			this.label4.Cursor = Cursors.Default;
			this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label4.ForeColor = SystemColors.ButtonHighlight;
			this.label4.Location = new Point(493, 127);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 17);
			this.label4.TabIndex = 17;
			this.label4.Text = "Aimoffset";
			this.toolTip1.SetToolTip(this.label4, "Will change the Aimspot.\r\n\r\n- Lower Value (Aims lower at your Body)\r\n- High Value (Aims higher at your Head)");
			this.label5.AutoSize = true;
			this.label5.BackColor = Color.Crimson;
			this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label5.ForeColor = SystemColors.ButtonHighlight;
			this.label5.Location = new Point(265, 85);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 17);
			this.label5.TabIndex = 19;
			this.label5.Text = "Firerate";
			this.toolTip1.SetToolTip(this.label5, "Firerate of your Weapon in Triggerbotmode.\n\nHigher Value = Higher Delay = Slower Shooting\nLower Value = Lower Delay = Faster Shooting\n\n(If your Triggerbot is still slow increase the Prefire Values)");
			this.label5.Click += new EventHandler(this.Label5_Click);
			this.FireRateNum.Location = new Point(216, 83);
			this.FireRateNum.Margin = new System.Windows.Forms.Padding(2);
			this.FireRateNum.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.FireRateNum.Name = "FireRateNum";
			this.FireRateNum.Size = new System.Drawing.Size(45, 20);
			this.FireRateNum.TabIndex = 18;
			this.toolTip1.SetToolTip(this.FireRateNum, "Firerate of your Weapon in Triggerbotmode.\n\nHigher Value = Higher Delay = Slower Shooting\nLower Value = Lower Delay = Faster Shooting\n\n(If your Triggerbot is still slow increase the Prefire Values)");
			this.FireRateNum.Value = new decimal(new int[] { 40, 0, 0, 0 });
			this.FireRateNum.ValueChanged += new EventHandler(this.FireRate_changed);
			this.label6.AutoSize = true;
			this.label6.BackColor = Color.Transparent;
			this.label6.Cursor = Cursors.Default;
			this.label6.FlatStyle = FlatStyle.Flat;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label6.ForeColor = Color.FromArgb(192, 255, 255);
			this.label6.Location = new Point(18, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 20);
			this.label6.TabIndex = 20;
			this.label6.Text = "Movement:";
			this.label8.AutoSize = true;
			this.label8.BackColor = Color.Transparent;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label8.ForeColor = Color.FromArgb(192, 255, 255);
			this.label8.Location = new Point(17, 264);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 20);
			this.label8.TabIndex = 22;
			this.label8.Text = "Outlines:";
			this.label9.AutoSize = true;
			this.label9.BackColor = Color.Transparent;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label9.ForeColor = Color.FromArgb(192, 255, 255);
			this.label9.Location = new Point(19, 404);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(154, 20);
			this.label9.TabIndex = 23;
			this.label9.Text = "Aimbot / Ragebot:";
			this.Customcolor.AutoSize = true;
			this.Customcolor.BackColor = Color.Transparent;
			this.Customcolor.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.Customcolor.ForeColor = SystemColors.ButtonHighlight;
			this.Customcolor.Location = new Point(136, 287);
			this.Customcolor.Margin = new System.Windows.Forms.Padding(0);
			this.Customcolor.Name = "Customcolor";
			this.Customcolor.Size = new System.Drawing.Size(73, 22);
			this.Customcolor.TabIndex = 25;
			this.Customcolor.TabStop = true;
			this.Customcolor.Text = "Custom";
			this.toolTip1.SetToolTip(this.Customcolor, "Custom RGB Color if it doesn't detect the predefined one.");
			this.Customcolor.UseCompatibleTextRendering = true;
			this.Customcolor.UseVisualStyleBackColor = false;
			this.label11.AutoSize = true;
			this.label11.BackColor = Color.Crimson;
			this.label11.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label11.ForeColor = SystemColors.ButtonHighlight;
			this.label11.Location = new Point(77, 311);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(33, 17);
			this.label11.TabIndex = 27;
			this.label11.Text = "Red";
			this.toolTip1.SetToolTip(this.label11, "Custom RGB Color if it doesn't detect the predefined one.");
			this.Redinput.Location = new Point(21, 309);
			this.Redinput.Margin = new System.Windows.Forms.Padding(2);
			this.Redinput.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.Redinput.Name = "Redinput";
			this.Redinput.Size = new System.Drawing.Size(45, 20);
			this.Redinput.TabIndex = 28;
			this.toolTip1.SetToolTip(this.Redinput, "Custom RGB Color if it doesn't detect the predefined one.");
			this.Greeninput.Location = new Point(21, 333);
			this.Greeninput.Margin = new System.Windows.Forms.Padding(2);
			this.Greeninput.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.Greeninput.Name = "Greeninput";
			this.Greeninput.Size = new System.Drawing.Size(45, 20);
			this.Greeninput.TabIndex = 29;
			this.toolTip1.SetToolTip(this.Greeninput, "Custom RGB Color if it doesn't detect the predefined one.");
			this.Blueinput.Location = new Point(21, 357);
			this.Blueinput.Margin = new System.Windows.Forms.Padding(2);
			this.Blueinput.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.Blueinput.Name = "Blueinput";
			this.Blueinput.Size = new System.Drawing.Size(45, 20);
			this.Blueinput.TabIndex = 30;
			this.toolTip1.SetToolTip(this.Blueinput, "Custom RGB Color if it doesn't detect the predefined one.");
			this.label12.AutoSize = true;
			this.label12.BackColor = Color.Crimson;
			this.label12.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label12.ForeColor = SystemColors.ButtonHighlight;
			this.label12.Location = new Point(77, 335);
			this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(47, 17);
			this.label12.TabIndex = 31;
			this.label12.Text = "Green";
			this.toolTip1.SetToolTip(this.label12, "Custom RGB Color if it doesn't detect the predefined one.");
			this.label13.AutoSize = true;
			this.label13.BackColor = Color.Crimson;
			this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label13.ForeColor = SystemColors.ButtonHighlight;
			this.label13.Location = new Point(77, 359);
			this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(34, 17);
			this.label13.TabIndex = 32;
			this.label13.Text = "Blue";
			this.toolTip1.SetToolTip(this.label13, "Custom RGB Color if it doesn't detect the predefined one.");
			this.label14.AutoSize = true;
			this.label14.BackColor = Color.Transparent;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label14.ForeColor = Color.FromArgb(192, 255, 255);
			this.label14.Location = new Point(212, 28);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(163, 20);
			this.label14.TabIndex = 33;
			this.label14.Text = "Triggerbot Settings";
			this.Pingx.Location = new Point(216, 59);
			this.Pingx.Margin = new System.Windows.Forms.Padding(2);
			this.Pingx.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
			this.Pingx.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.Pingx.Name = "Pingx";
			this.Pingx.Size = new System.Drawing.Size(45, 20);
			this.Pingx.TabIndex = 34;
			this.toolTip1.SetToolTip(this.Pingx, resources.GetString("Pingx.ToolTip"));
			this.Pingx.Value = new decimal(new int[] { 15, 0, 0, 0 });
			this.label15.AutoSize = true;
			this.label15.BackColor = Color.Crimson;
			this.label15.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label15.ForeColor = SystemColors.ButtonHighlight;
			this.label15.Location = new Point(265, 61);
			this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(102, 17);
			this.label15.TabIndex = 35;
			this.label15.Text = "Trigger Fov X/Y";
			this.toolTip1.SetToolTip(this.label15, resources.GetString("label15.ToolTip"));
			this.label17.AutoSize = true;
			this.label17.BackColor = Color.Transparent;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label17.ForeColor = Color.FromArgb(192, 255, 255);
			this.label17.Location = new Point(18, 167);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(166, 20);
			this.label17.TabIndex = 38;
			this.label17.Text = "Custom Resolution:";
			this.ScreenX2.Location = new Point(22, 210);
			this.ScreenX2.Margin = new System.Windows.Forms.Padding(2);
			this.ScreenX2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.ScreenX2.Name = "ScreenX2";
			this.ScreenX2.Size = new System.Drawing.Size(61, 20);
			this.ScreenX2.TabIndex = 39;
			this.ScreenX2.Tag = "";
			this.toolTip1.SetToolTip(this.ScreenX2, "Screen Resoltuion X");
			this.ScreenY2.Location = new Point(22, 234);
			this.ScreenY2.Margin = new System.Windows.Forms.Padding(2);
			this.ScreenY2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.ScreenY2.Name = "ScreenY2";
			this.ScreenY2.Size = new System.Drawing.Size(61, 20);
			this.ScreenY2.TabIndex = 40;
			this.toolTip1.SetToolTip(this.ScreenY2, "Screen Resoltuion Y");
			this.label18.AutoSize = true;
			this.label18.BackColor = Color.Crimson;
			this.label18.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label18.ForeColor = SystemColors.ButtonHighlight;
			this.label18.Location = new Point(121, 212);
			this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(48, 17);
			this.label18.TabIndex = 41;
			this.label18.Text = "Pixel X";
			this.ScreenY.AutoSize = true;
			this.ScreenY.BackColor = Color.Crimson;
			this.ScreenY.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.ScreenY.ForeColor = SystemColors.ButtonHighlight;
			this.ScreenY.Location = new Point(121, 236);
			this.ScreenY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.ScreenY.Name = "ScreenY";
			this.ScreenY.Size = new System.Drawing.Size(47, 17);
			this.ScreenY.TabIndex = 42;
			this.ScreenY.Text = "Pixel Y";
			this.CustomScreen.AutoSize = true;
			this.CustomScreen.BackColor = Color.Black;
			this.CustomScreen.FlatStyle = FlatStyle.Flat;
			this.CustomScreen.ForeColor = SystemColors.ButtonHighlight;
			this.CustomScreen.Location = new Point(22, 189);
			this.CustomScreen.Margin = new System.Windows.Forms.Padding(2);
			this.CustomScreen.Name = "CustomScreen";
			this.CustomScreen.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CustomScreen.Size = new System.Drawing.Size(111, 17);
			this.CustomScreen.TabIndex = 44;
			this.CustomScreen.Text = "Custom Resolution";
			this.toolTip1.SetToolTip(this.CustomScreen, "You don't need this. Only if it doesn't detect your Screen Resolution.");
			this.CustomScreen.UseVisualStyleBackColor = false;
			this.toolTip1.AutoPopDelay = 15000;
			this.toolTip1.InitialDelay = 100;
			this.toolTip1.ReshowDelay = 100;
			this.Bhopbox.AllowDrop = true;
			this.Bhopbox.AutoSize = true;
			this.Bhopbox.BackColor = Color.Crimson;
			this.Bhopbox.Cursor = Cursors.Default;
			this.Bhopbox.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.Bhopbox.ForeColor = Color.White;
			this.Bhopbox.Location = new Point(23, 135);
			this.Bhopbox.Margin = new System.Windows.Forms.Padding(2);
			this.Bhopbox.Name = "Bhopbox";
			this.Bhopbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Bhopbox.Size = new System.Drawing.Size(60, 21);
			this.Bhopbox.TabIndex = 48;
			this.Bhopbox.Text = "Bhop";
			this.toolTip1.SetToolTip(this.Bhopbox, "This feature will let you jump to infinity<\r\n\r\nDefault Keybind is \"Middle Mouse\" (4)");
			this.Bhopbox.UseMnemonic = false;
			this.Bhopbox.UseVisualStyleBackColor = false;
			this.Bhopbox.CheckedChanged += new EventHandler(this.CheckBox2_CheckedChanged);
			this.Bhopinput.Location = new Point(215, 328);
			this.Bhopinput.Margin = new System.Windows.Forms.Padding(2);
			this.Bhopinput.Maximum = new decimal(new int[] { 254, 0, 0, 0 });
			this.Bhopinput.Name = "Bhopinput";
			this.Bhopinput.Size = new System.Drawing.Size(46, 20);
			this.Bhopinput.TabIndex = 49;
			this.toolTip1.SetToolTip(this.Bhopinput, "Keybind for Bhop - Default is \"Middle Mouse\" (4)\r\n\r\n(Spacebar does not work)\r\n\r\nKeybinds here: http://cherrytree.at/misc/vk.htm");
			this.Bhopinput.Value = new decimal(new int[] { 4, 0, 0, 0 });
			this.Bhopinput.ValueChanged += new EventHandler(this.NumericUpDown1_ValueChanged);
			this.TriggerKeyBtt.BackColor = Color.FromArgb(20, 20, 20);
			this.TriggerKeyBtt.FlatAppearance.BorderSize = 0;
			this.TriggerKeyBtt.FlatStyle = FlatStyle.Flat;
			this.TriggerKeyBtt.ForeColor = Color.FromArgb(255, 255, 192);
			this.TriggerKeyBtt.Location = new Point(22, 485);
			this.TriggerKeyBtt.Margin = new System.Windows.Forms.Padding(2);
			this.TriggerKeyBtt.Name = "TriggerKeyBtt";
			this.TriggerKeyBtt.Size = new System.Drawing.Size(82, 34);
			this.TriggerKeyBtt.TabIndex = 52;
			this.TriggerKeyBtt.Text = "Keybind";
			this.toolTip1.SetToolTip(this.TriggerKeyBtt, "Keybinding for Triggerbot");
			this.TriggerKeyBtt.UseVisualStyleBackColor = false;
			this.TriggerKeyBtt.Click += new EventHandler(this.TriggerKeyDrop);
			this.label10.AutoSize = true;
			this.label10.BackColor = Color.Crimson;
			this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label10.ForeColor = Color.White;
			this.label10.Location = new Point(265, 330);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(101, 17);
			this.label10.TabIndex = 54;
			this.label10.Text = "Bhop Keycode";
			this.toolTip1.SetToolTip(this.label10, "Keybind for Bhop - Default is \"Middle Mouse\" (4)\r\n\r\n(Spacebar does not work)\r\n\r\nKeybinds here: http://cherrytree.at/misc/vk.htm\r\n");
			this.label20.AutoSize = true;
			this.label20.BackColor = Color.Crimson;
			this.label20.Cursor = Cursors.Default;
			this.label20.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label20.ForeColor = SystemColors.ButtonHighlight;
			this.label20.Location = new Point(492, 222);
			this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(76, 17);
			this.label20.TabIndex = 56;
			this.label20.Text = "Humanizer";
			this.toolTip1.SetToolTip(this.label20, "Changes the Speed of your Aimbot as soon as you reach your Enemy with the Crosshair or the Smooth Aim Pixels.\r\nThis is like a second Fov on Lockon.\r\n\r\nLower Values are more legit.");
			this.label21.AutoSize = true;
			this.label21.BackColor = Color.Crimson;
			this.label21.Cursor = Cursors.Default;
			this.label21.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label21.ForeColor = SystemColors.ButtonHighlight;
			this.label21.Location = new Point(266, 429);
			this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(144, 17);
			this.label21.TabIndex = 58;
			this.label21.Text = "NoRecoil Standalone";
			this.toolTip1.SetToolTip(this.label21, resources.GetString("label21.ToolTip"));
			this.label22.AutoSize = true;
			this.label22.BackColor = Color.Crimson;
			this.label22.Cursor = Cursors.Default;
			this.label22.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label22.ForeColor = SystemColors.ButtonHighlight;
			this.label22.Location = new Point(493, 270);
			this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(44, 17);
			this.label22.TabIndex = 60;
			this.label22.Text = "Delay";
			this.toolTip1.SetToolTip(this.label22, resources.GetString("label22.ToolTip"));
			this.label25.AutoSize = true;
			this.label25.BackColor = Color.Crimson;
			this.label25.Cursor = Cursors.Default;
			this.label25.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label25.ForeColor = SystemColors.ButtonHighlight;
			this.label25.Location = new Point(492, 246);
			this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(88, 17);
			this.label25.TabIndex = 63;
			this.label25.Text = "Pixel Fov X/Y";
			this.toolTip1.SetToolTip(this.label25, resources.GetString("label25.ToolTip"));
			this.EspBtt.AllowDrop = true;
			this.EspBtt.AutoSize = true;
			this.EspBtt.BackColor = Color.Crimson;
			this.EspBtt.Cursor = Cursors.Help;
			this.EspBtt.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.EspBtt.ForeColor = Color.White;
			this.EspBtt.Location = new Point(654, 72);
			this.EspBtt.Margin = new System.Windows.Forms.Padding(2);
			this.EspBtt.Name = "EspBtt";
			this.EspBtt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EspBtt.Size = new System.Drawing.Size(88, 21);
			this.EspBtt.TabIndex = 69;
			this.EspBtt.Text = "Color ESP";
			this.toolTip1.SetToolTip(this.EspBtt, "THIS MIGHT SLOW DOWN YOUR AIMBOT!\r\n\r\nThis Feature will show you visible Enemies in an ESP Box\r\n\r\n(Only works on one Enemy at a time rn and needs some resources - Better disable this)");
			this.EspBtt.UseMnemonic = false;
			this.EspBtt.UseVisualStyleBackColor = false;
			this.EspBtt.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged_2);
			this.CircleBtt.AllowDrop = true;
			this.CircleBtt.AutoSize = true;
			this.CircleBtt.BackColor = Color.Crimson;
			this.CircleBtt.Cursor = Cursors.Default;
			this.CircleBtt.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.CircleBtt.ForeColor = Color.White;
			this.CircleBtt.Location = new Point(654, 51);
			this.CircleBtt.Margin = new System.Windows.Forms.Padding(2);
			this.CircleBtt.Name = "CircleBtt";
			this.CircleBtt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CircleBtt.Size = new System.Drawing.Size(94, 21);
			this.CircleBtt.TabIndex = 70;
			this.CircleBtt.Text = "FOV Circle";
			this.toolTip1.SetToolTip(this.CircleBtt, "This Feature shows your Fov in a Circle\r\n\r\n(refreshtime 5 seconds)");
			this.CircleBtt.UseMnemonic = false;
			this.CircleBtt.UseVisualStyleBackColor = false;
			this.CircleBtt.CheckedChanged += new EventHandler(this.checkBox3_CheckedChanged_1);
			this.label28.AutoSize = true;
			this.label28.BackColor = Color.Crimson;
			this.label28.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label28.ForeColor = Color.White;
			this.label28.Location = new Point(265, 354);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(81, 17);
			this.label28.TabIndex = 76;
			this.label28.Text = "Bhop Delay";
			this.toolTip1.SetToolTip(this.label28, "Delay for Bhop \r\n\r\n(Pressing each X ms your Spacebar to jump)\r\n");
			this.Bdelay.Location = new Point(215, 352);
			this.Bdelay.Margin = new System.Windows.Forms.Padding(2);
			this.Bdelay.Maximum = new decimal(new int[] { 254, 0, 0, 0 });
			this.Bdelay.Name = "Bdelay";
			this.Bdelay.Size = new System.Drawing.Size(46, 20);
			this.Bdelay.TabIndex = 75;
			this.toolTip1.SetToolTip(this.Bdelay, "Delay for Bhop \r\n\r\n(Pressing each X ms your Spacebar to jump)");
			this.Bdelay.Value = new decimal(new int[] { 20, 0, 0, 0 });
			this.label30.AutoSize = true;
			this.label30.BackColor = Color.Crimson;
			this.label30.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label30.ForeColor = SystemColors.ButtonHighlight;
			this.label30.Location = new Point(265, 265);
			this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(34, 17);
			this.label30.TabIndex = 85;
			this.label30.Text = "Blue";
			this.toolTip1.SetToolTip(this.label30, "Amount of Blue Color in your Circle\r\n\r\n");
			this.label31.AutoSize = true;
			this.label31.BackColor = Color.Crimson;
			this.label31.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label31.ForeColor = SystemColors.ButtonHighlight;
			this.label31.Location = new Point(265, 241);
			this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(47, 17);
			this.label31.TabIndex = 84;
			this.label31.Text = "Green";
			this.toolTip1.SetToolTip(this.label31, "Amount of Green Color in your Circle\r\n\r\n");
			this.CircleBlue.Location = new Point(216, 262);
			this.CircleBlue.Margin = new System.Windows.Forms.Padding(2);
			this.CircleBlue.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.CircleBlue.Name = "CircleBlue";
			this.CircleBlue.Size = new System.Drawing.Size(45, 20);
			this.CircleBlue.TabIndex = 83;
			this.toolTip1.SetToolTip(this.CircleBlue, "Amount of Blue Color in your Circle\r\n");
			this.CircleBlue.Value = new decimal(new int[] { 1, 0, 0, 0 });
			this.CircleGreen.Location = new Point(216, 238);
			this.CircleGreen.Margin = new System.Windows.Forms.Padding(2);
			this.CircleGreen.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.CircleGreen.Name = "CircleGreen";
			this.CircleGreen.Size = new System.Drawing.Size(45, 20);
			this.CircleGreen.TabIndex = 82;
			this.toolTip1.SetToolTip(this.CircleGreen, "Amount of Green Color in your Circle\r\n");
			this.CircleGreen.Value = new decimal(new int[] { 1, 0, 0, 0 });
			this.CircleGreen.ValueChanged += new EventHandler(this.CircleGreen_ValueChanged);
			this.CircleRed.Location = new Point(216, 214);
			this.CircleRed.Margin = new System.Windows.Forms.Padding(2);
			this.CircleRed.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.CircleRed.Name = "CircleRed";
			this.CircleRed.Size = new System.Drawing.Size(45, 20);
			this.CircleRed.TabIndex = 81;
			this.toolTip1.SetToolTip(this.CircleRed, "Amount of Red Color in your Circle");
			this.CircleRed.Value = new decimal(new int[] { 255, 0, 0, 0 });
			this.CircleRed.ValueChanged += new EventHandler(this.CircleRed_ValueChanged);
			this.label32.AutoSize = true;
			this.label32.BackColor = Color.Crimson;
			this.label32.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label32.ForeColor = SystemColors.ButtonHighlight;
			this.label32.Location = new Point(265, 217);
			this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(33, 17);
			this.label32.TabIndex = 80;
			this.label32.Text = "Red";
			this.toolTip1.SetToolTip(this.label32, "Amount of Red Color in your Circle\r\n");
			this.label37.AutoSize = true;
			this.label37.BackColor = Color.Crimson;
			this.label37.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label37.ForeColor = SystemColors.ButtonHighlight;
			this.label37.Location = new Point(696, 288);
			this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(34, 17);
			this.label37.TabIndex = 98;
			this.label37.Text = "Blue";
			this.toolTip1.SetToolTip(this.label37, "Amount of Blue Color in your Box\r\n");
			this.label38.AutoSize = true;
			this.label38.BackColor = Color.Crimson;
			this.label38.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label38.ForeColor = SystemColors.ButtonHighlight;
			this.label38.Location = new Point(696, 262);
			this.label38.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(47, 17);
			this.label38.TabIndex = 97;
			this.label38.Text = "Green";
			this.toolTip1.SetToolTip(this.label38, "Amount of Green Color in your Box\r\n");
			this.ColB.Location = new Point(654, 285);
			this.ColB.Margin = new System.Windows.Forms.Padding(2);
			this.ColB.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.ColB.Name = "ColB";
			this.ColB.Size = new System.Drawing.Size(38, 20);
			this.ColB.TabIndex = 96;
			this.toolTip1.SetToolTip(this.ColB, "Amount of Blue Color in your Box");
			this.ColG.Location = new Point(654, 261);
			this.ColG.Margin = new System.Windows.Forms.Padding(2);
			this.ColG.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.ColG.Name = "ColG";
			this.ColG.Size = new System.Drawing.Size(38, 20);
			this.ColG.TabIndex = 95;
			this.toolTip1.SetToolTip(this.ColG, "Amount of Green Color in your Box\r\n");
			this.ColR.Location = new Point(654, 237);
			this.ColR.Margin = new System.Windows.Forms.Padding(2);
			this.ColR.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.ColR.Name = "ColR";
			this.ColR.Size = new System.Drawing.Size(38, 20);
			this.ColR.TabIndex = 94;
			this.toolTip1.SetToolTip(this.ColR, "Amount of Red Color in your Box");
			this.ColR.Value = new decimal(new int[] { 255, 0, 0, 0 });
			this.label39.AutoSize = true;
			this.label39.BackColor = Color.Crimson;
			this.label39.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label39.ForeColor = SystemColors.ButtonHighlight;
			this.label39.Location = new Point(696, 240);
			this.label39.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(33, 17);
			this.label39.TabIndex = 93;
			this.label39.Text = "Red";
			this.toolTip1.SetToolTip(this.label39, "Amount of Red Color in your Box\r\n");
			this.label41.AutoSize = true;
			this.label41.BackColor = Color.Crimson;
			this.label41.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label41.ForeColor = SystemColors.ButtonHighlight;
			this.label41.Location = new Point(696, 216);
			this.label41.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(42, 17);
			this.label41.TabIndex = 103;
			this.label41.Text = "Size Y";
			this.toolTip1.SetToolTip(this.label41, "Size of your ESP Boxes in Y");
			this.ColY.Location = new Point(654, 213);
			this.ColY.Margin = new System.Windows.Forms.Padding(2);
			this.ColY.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.ColY.Name = "ColY";
			this.ColY.Size = new System.Drawing.Size(38, 20);
			this.ColY.TabIndex = 101;
			this.toolTip1.SetToolTip(this.ColY, "Size of your ESP Boxes in Y\r\n\r\n");
			this.ColY.Value = new decimal(new int[] { 160, 0, 0, 0 });
			this.ColX.Location = new Point(654, 189);
			this.ColX.Margin = new System.Windows.Forms.Padding(2);
			this.ColX.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.ColX.Name = "ColX";
			this.ColX.Size = new System.Drawing.Size(38, 20);
			this.ColX.TabIndex = 100;
			this.toolTip1.SetToolTip(this.ColX, "Size of your ESP Boxes in X\r\n");
			this.ColX.Value = new decimal(new int[] { 60, 0, 0, 0 });
			this.label42.AutoSize = true;
			this.label42.BackColor = Color.Crimson;
			this.label42.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label42.ForeColor = SystemColors.ButtonHighlight;
			this.label42.Location = new Point(696, 192);
			this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(43, 17);
			this.label42.TabIndex = 99;
			this.label42.Text = "Size X";
			this.toolTip1.SetToolTip(this.label42, "Size of your ESP Boxes in X\r\n\r\n");
			this.CircleWidth.Location = new Point(216, 190);
			this.CircleWidth.Margin = new System.Windows.Forms.Padding(2);
			this.CircleWidth.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.CircleWidth.Name = "CircleWidth";
			this.CircleWidth.Size = new System.Drawing.Size(45, 20);
			this.CircleWidth.TabIndex = 116;
			this.toolTip1.SetToolTip(this.CircleWidth, "Width of your Fov Circle");
			this.CircleWidth.Value = new decimal(new int[] { 1, 0, 0, 0 });
			this.CircleWidth.ValueChanged += new EventHandler(this.CircleWidth_ValueChanged);
			this.label48.AutoSize = true;
			this.label48.BackColor = Color.Crimson;
			this.label48.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label48.ForeColor = SystemColors.ButtonHighlight;
			this.label48.Location = new Point(265, 193);
			this.label48.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(46, 17);
			this.label48.TabIndex = 115;
			this.label48.Text = "Width";
			this.toolTip1.SetToolTip(this.label48, "Width of your Fov Circle\r\n");
			this.ColWidth.Location = new Point(654, 310);
			this.ColWidth.Margin = new System.Windows.Forms.Padding(2);
			this.ColWidth.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
			this.ColWidth.Name = "ColWidth";
			this.ColWidth.Size = new System.Drawing.Size(38, 20);
			this.ColWidth.TabIndex = 119;
			this.toolTip1.SetToolTip(this.ColWidth, "Amount of Width of your Box");
			this.ColWidth.Value = new decimal(new int[] { 2, 0, 0, 0 });
			this.ColWidth.ValueChanged += new EventHandler(this.ColWidth_ValueChanged);
			this.label49.AutoSize = true;
			this.label49.BackColor = Color.Crimson;
			this.label49.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label49.ForeColor = SystemColors.ButtonHighlight;
			this.label49.Location = new Point(696, 312);
			this.label49.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(46, 17);
			this.label49.TabIndex = 120;
			this.label49.Text = "Width";
			this.toolTip1.SetToolTip(this.label49, "Amount of Width of your Box\r\n");
			this.TargetCheck.AutoSize = true;
			this.TargetCheck.BackColor = Color.Crimson;
			this.TargetCheck.Cursor = Cursors.Help;
			this.TargetCheck.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.TargetCheck.ForeColor = SystemColors.ButtonHighlight;
			this.TargetCheck.Location = new Point(435, 197);
			this.TargetCheck.Name = "TargetCheck";
			this.TargetCheck.Size = new System.Drawing.Size(132, 21);
			this.TargetCheck.TabIndex = 123;
			this.TargetCheck.Text = "Enable / Disable";
			this.toolTip1.SetToolTip(this.TargetCheck, "THIS MIGHT SLOW DOWN YOUR AIMBOT!\r\n\r\nCheckbox to Enable - Disable the Target Aimbot\r\n\r\nWill Disable all Settings in \"Aimbot - Target\" and only use the \"Aimbot - Searching\" Settings.");
			this.TargetCheck.UseVisualStyleBackColor = false;
			this.chanceval.BackColor = SystemColors.Window;
			this.chanceval.Cursor = Cursors.Default;
			this.chanceval.ForeColor = SystemColors.WindowText;
			this.chanceval.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.chanceval.InterceptArrowKeys = false;
			this.chanceval.Location = new Point(435, 426);
			this.chanceval.Margin = new System.Windows.Forms.Padding(2);
			this.chanceval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.chanceval.Name = "chanceval";
			this.chanceval.Size = new System.Drawing.Size(45, 20);
			this.chanceval.TabIndex = 125;
			this.chanceval.TabStop = false;
			this.toolTip1.SetToolTip(this.chanceval, resources.GetString("chanceval.ToolTip"));
			this.chanceval.Value = new decimal(new int[] { 85, 0, 0, 0 });
			this.label24.AutoSize = true;
			this.label24.BackColor = Color.Crimson;
			this.label24.Cursor = Cursors.Default;
			this.label24.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label24.ForeColor = SystemColors.ButtonHighlight;
			this.label24.Location = new Point(493, 429);
			this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(74, 17);
			this.label24.TabIndex = 126;
			this.label24.Text = "Hitchance";
			this.toolTip1.SetToolTip(this.label24, resources.GetString("label24.ToolTip"));
			this.Ragebot.AutoSize = true;
			this.Ragebot.BackColor = Color.Crimson;
			this.Ragebot.Cursor = Cursors.Default;
			this.Ragebot.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.Ragebot.ForeColor = Color.White;
			this.Ragebot.Location = new Point(23, 72);
			this.Ragebot.Margin = new System.Windows.Forms.Padding(2);
			this.Ragebot.Name = "Ragebot";
			this.Ragebot.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Ragebot.Size = new System.Drawing.Size(84, 21);
			this.Ragebot.TabIndex = 128;
			this.Ragebot.TabStop = false;
			this.Ragebot.Text = "Ragebot";
			this.toolTip1.SetToolTip(this.Ragebot, "Simple Ragebot. Aims at your Enemy and auto shoots like Triggerbot.\r\n\r\nOnly works with Keybind!");
			this.Ragebot.UseVisualStyleBackColor = false;
			this.Ragebot.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
			this.label52.AutoSize = true;
			this.label52.BackColor = Color.Crimson;
			this.label52.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label52.ForeColor = SystemColors.ButtonHighlight;
			this.label52.Location = new Point(493, 453);
			this.label52.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(55, 17);
			this.label52.TabIndex = 130;
			this.label52.Text = "Firerate";
			this.toolTip1.SetToolTip(this.label52, "Firerate of your Weapon.\r\n\r\nHigher Value = Higher Delay = Slower Shooting\r\nLower Value = Lower Delay = Faster Shooting\r\n\r\n(If your Triggerbot is still slow increase the Prefire Values)");
			this.Firerage.Location = new Point(435, 450);
			this.Firerage.Margin = new System.Windows.Forms.Padding(2);
			this.Firerage.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.Firerage.Name = "Firerage";
			this.Firerage.Size = new System.Drawing.Size(45, 20);
			this.Firerage.TabIndex = 129;
			this.toolTip1.SetToolTip(this.Firerage, "Firerate of your Weapon.\r\n\r\nHigher Value = Higher Delay = Slower Shooting\r\nLower Value = Lower Delay = Faster Shooting\r\n\r\n(If your Triggerbot is still slow increase the Prefire Values)");
			this.Firerage.Value = new decimal(new int[] { 145, 0, 0, 0 });
			this.Firerage.ValueChanged += new EventHandler(this.numericUpDown1_ValueChanged_3);
			this.label53.AutoSize = true;
			this.label53.BackColor = Color.Crimson;
			this.label53.Cursor = Cursors.Default;
			this.label53.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label53.ForeColor = SystemColors.ButtonHighlight;
			this.label53.Location = new Point(493, 405);
			this.label53.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(68, 17);
			this.label53.TabIndex = 138;
			this.label53.Text = "Aimoffset";
			this.toolTip1.SetToolTip(this.label53, "Will change the Aimspot.\r\n\r\n- Lower Value (Aims lower at your Body)\r\n- High Value (Aims higher at your Head)");
			this.Rageoff.BackColor = SystemColors.Window;
			this.Rageoff.Cursor = Cursors.Default;
			this.Rageoff.ForeColor = SystemColors.WindowText;
			this.Rageoff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Rageoff.InterceptArrowKeys = false;
			this.Rageoff.Location = new Point(435, 402);
			this.Rageoff.Margin = new System.Windows.Forms.Padding(2);
			this.Rageoff.Minimum = new decimal(new int[] { 20, 0, 0, -2147483648 });
			this.Rageoff.Name = "Rageoff";
			this.Rageoff.Size = new System.Drawing.Size(45, 20);
			this.Rageoff.TabIndex = 137;
			this.Rageoff.TabStop = false;
			this.toolTip1.SetToolTip(this.Rageoff, "Will change the Aimspot.\r\n\r\n- Lower Value (Aims lower at your Body)\r\n- High Value (Aims higher at your Head)");
			this.Rageoff.Value = new decimal(new int[] { 15, 0, 0, 0 });
			this.Rageoff.ValueChanged += new EventHandler(this.Rageoff_ValueChanged);
			this.label54.AutoSize = true;
			this.label54.BackColor = Color.Crimson;
			this.label54.Cursor = Cursors.Default;
			this.label54.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label54.ForeColor = SystemColors.ButtonHighlight;
			this.label54.Location = new Point(493, 381);
			this.label54.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(103, 17);
			this.label54.TabIndex = 136;
			this.label54.Text = "Ragebot Fov Y";
			this.toolTip1.SetToolTip(this.label54, "Your Y Fov for Up and Down.\r\n\r\nHigher Value will increase the Fov but may slow down your Aimbot Performance.\r\n");
			this.Ragey.BackColor = SystemColors.Window;
			this.Ragey.Cursor = Cursors.Default;
			this.Ragey.ForeColor = SystemColors.WindowText;
			this.Ragey.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Ragey.InterceptArrowKeys = false;
			this.Ragey.Location = new Point(435, 378);
			this.Ragey.Margin = new System.Windows.Forms.Padding(2);
			this.Ragey.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.Ragey.Name = "Ragey";
			this.Ragey.Size = new System.Drawing.Size(45, 20);
			this.Ragey.TabIndex = 135;
			this.Ragey.TabStop = false;
			this.toolTip1.SetToolTip(this.Ragey, "Your Y Fov for Up and Down.\r\n\r\nHigher Value will increase the Fov.\r\n");
			this.Ragey.Value = new decimal(new int[] { 150, 0, 0, 0 });
			this.Ragey.ValueChanged += new EventHandler(this.Ragey_ValueChanged);
			this.label55.AutoSize = true;
			this.label55.BackColor = Color.Crimson;
			this.label55.Cursor = Cursors.Default;
			this.label55.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label55.ForeColor = SystemColors.ButtonHighlight;
			this.label55.Location = new Point(493, 357);
			this.label55.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(104, 17);
			this.label55.TabIndex = 134;
			this.label55.Text = "Ragebot Fov X";
			this.toolTip1.SetToolTip(this.label55, "Your X Fov for Left and Right.\r\n\r\nHigher Value will increase the Fov but may slow down your Aimbot Performance.");
			this.Ragex.BackColor = SystemColors.Window;
			this.Ragex.Cursor = Cursors.Default;
			this.Ragex.ForeColor = SystemColors.WindowText;
			this.Ragex.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Ragex.InterceptArrowKeys = false;
			this.Ragex.Location = new Point(435, 354);
			this.Ragex.Margin = new System.Windows.Forms.Padding(2);
			this.Ragex.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.Ragex.Name = "Ragex";
			this.Ragex.Size = new System.Drawing.Size(45, 20);
			this.Ragex.TabIndex = 133;
			this.Ragex.TabStop = false;
			this.toolTip1.SetToolTip(this.Ragex, "Your X Fov for Left and Right.\r\n\r\nHigher Value will increase the Fov.");
			this.Ragex.Value = new decimal(new int[] { 850, 0, 0, 0 });
			this.Ragex.ValueChanged += new EventHandler(this.Ragex_ValueChanged);
			this.label56.AutoSize = true;
			this.label56.BackColor = Color.Crimson;
			this.label56.Cursor = Cursors.Default;
			this.label56.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label56.ForeColor = SystemColors.ButtonHighlight;
			this.label56.Location = new Point(493, 333);
			this.label56.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(76, 17);
			this.label56.TabIndex = 132;
			this.label56.Text = "Humanizer";
			this.toolTip1.SetToolTip(this.label56, "Change the Speed of your Ragebot while it is searching and aiming for your target.\r\n\r\nLower Values are more legit.\r\n");
			this.Ragehuman.BackColor = SystemColors.Window;
			this.Ragehuman.Cursor = Cursors.Default;
			this.Ragehuman.DecimalPlaces = 2;
			this.Ragehuman.ForeColor = SystemColors.WindowText;
			this.Ragehuman.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Ragehuman.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
			this.Ragehuman.InterceptArrowKeys = false;
			this.Ragehuman.Location = new Point(435, 330);
			this.Ragehuman.Margin = new System.Windows.Forms.Padding(2);
			this.Ragehuman.Name = "Ragehuman";
			this.Ragehuman.Size = new System.Drawing.Size(45, 20);
			this.Ragehuman.TabIndex = 131;
			this.Ragehuman.TabStop = false;
			this.toolTip1.SetToolTip(this.Ragehuman, "Change the Speed of your Ragebot while it is searching and aiming for your target.\r\n\r\nLower Values are more legit.");
			this.Ragehuman.Value = new decimal(new int[] { 20, 0, 0, 131072 });
			this.Ragehuman.ValueChanged += new EventHandler(this.numericUpDown5_ValueChanged);
			this.label57.AutoSize = true;
			this.label57.BackColor = Color.Crimson;
			this.label57.Cursor = Cursors.Default;
			this.label57.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label57.ForeColor = SystemColors.ButtonHighlight;
			this.label57.Location = new Point(266, 453);
			this.label57.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(118, 17);
			this.label57.TabIndex = 140;
			this.label57.Text = "NoRecoil Aimbot";
			this.toolTip1.SetToolTip(this.label57, "change the strength of the NoRecoil while Aimbot is autoshooting.\r\n\r\n+ 1 = 1 pixel stronger recoilreduction\r\n-1 = 1 pixel less recoilreduction\r\n\r\n");
			this.Norecoilaimval.BackColor = SystemColors.Window;
			this.Norecoilaimval.Cursor = Cursors.Default;
			this.Norecoilaimval.ForeColor = SystemColors.WindowText;
			this.Norecoilaimval.Location = new Point(216, 451);
			this.Norecoilaimval.Margin = new System.Windows.Forms.Padding(2);
			this.Norecoilaimval.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
			this.Norecoilaimval.Minimum = new decimal(new int[] { 10, 0, 0, -2147483648 });
			this.Norecoilaimval.Name = "Norecoilaimval";
			this.Norecoilaimval.Size = new System.Drawing.Size(45, 20);
			this.Norecoilaimval.TabIndex = 139;
			this.toolTip1.SetToolTip(this.Norecoilaimval, "change the strength of the NoRecoil while Aimbot is autoshooting.\r\n\r\n+ 1 = 1 pixel stronger recoilreduction\r\n-1 = 1 pixel less recoilreduction\r\n");
			this.Norecoilaimval.Value = new decimal(new int[] { 1, 0, 0, 0 });
			this.label19.AutoSize = true;
			this.label19.BackColor = Color.Transparent;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label19.ForeColor = Color.FromArgb(192, 255, 255);
			this.label19.Location = new Point(19, 463);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(96, 20);
			this.label19.TabIndex = 53;
			this.label19.Text = "Triggerbot:";
			this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip2.Name = "contextMenuStrip1";
			this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
			this.contextMenuStrip2.Opening += new CancelEventHandler(this.ContextMenuStrip2_Opening);
			this.label23.AutoSize = true;
			this.label23.BackColor = Color.Transparent;
			this.label23.Cursor = Cursors.Default;
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label23.ForeColor = Color.FromArgb(192, 255, 255);
			this.label23.Location = new Point(431, 174);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(138, 20);
			this.label23.TabIndex = 61;
			this.label23.Text = "Aimbot - Target:";
			this.label7.AutoSize = true;
			this.label7.BackColor = Color.Transparent;
			this.label7.Cursor = Cursors.Default;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label7.ForeColor = Color.FromArgb(192, 255, 255);
			this.label7.Location = new Point(431, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(167, 20);
			this.label7.TabIndex = 72;
			this.label7.Text = "Aimbot - Searching:";
			this.label27.AutoSize = true;
			this.label27.BackColor = Color.Transparent;
			this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label27.ForeColor = Color.FromArgb(192, 255, 255);
			this.label27.Location = new Point(207, 404);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(86, 20);
			this.label27.TabIndex = 73;
			this.label27.Text = "NoRecoil:";
			this.label26.AutoSize = true;
			this.label26.BackColor = Color.Transparent;
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label26.ForeColor = Color.FromArgb(192, 255, 255);
			this.label26.Location = new Point(212, 304);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(56, 20);
			this.label26.TabIndex = 74;
			this.label26.Text = "Bhop:";
			this.label29.AutoSize = true;
			this.label29.BackColor = Color.Transparent;
			this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label29.ForeColor = Color.FromArgb(192, 255, 255);
			this.label29.Location = new Point(212, 167);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(100, 20);
			this.label29.TabIndex = 77;
			this.label29.Text = "FOV Circle:";
			this.label36.AutoSize = true;
			this.label36.BackColor = Color.Transparent;
			this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label36.ForeColor = Color.FromArgb(192, 255, 255);
			this.label36.Location = new Point(650, 167);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(96, 20);
			this.label36.TabIndex = 92;
			this.label36.Text = "Color ESP:";
			this.label50.AutoSize = true;
			this.label50.BackColor = Color.Transparent;
			this.label50.Cursor = Cursors.Default;
			this.label50.FlatStyle = FlatStyle.Flat;
			this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label50.ForeColor = Color.FromArgb(192, 255, 255);
			this.label50.Location = new Point(650, 28);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(72, 20);
			this.label50.TabIndex = 122;
			this.label50.Text = "Visuals:";
			this.label51.AutoSize = true;
			this.label51.BackColor = Color.Transparent;
			this.label51.Cursor = Cursors.Default;
			this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label51.ForeColor = Color.FromArgb(192, 255, 255);
			this.label51.Location = new Point(431, 304);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(83, 20);
			this.label51.TabIndex = 127;
			this.label51.Text = "Ragebot:";
			this.button1.BackColor = Color.Goldenrod;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = FlatStyle.Flat;
			this.button1.ForeColor = Color.FromArgb(255, 255, 192);
			this.button1.Location = new Point(838, 369);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(73, 71);
			this.button1.TabIndex = 141;
			this.button1.Text = "Hide";
			this.button1.UseVisualStyleBackColor = false;
			this.button2.BackColor = Color.Crimson;
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = FlatStyle.Flat;
			this.button2.ForeColor = Color.FromArgb(255, 255, 192);
			this.button2.Location = new Point(838, 302);
			this.button2.Margin = new System.Windows.Forms.Padding(2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(73, 69);
			this.button2.TabIndex = 142;
			this.button2.Text = "Close";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new EventHandler(this.button2_Click);
			this.button3.BackColor = Color.Crimson;
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatStyle = FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
			this.button3.ForeColor = Color.FromArgb(255, 255, 192);
			this.button3.Location = new Point(-2, 1);
			this.button3.Margin = new System.Windows.Forms.Padding(2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(935, 25);
			this.button3.TabIndex = 143;
			this.button3.Text = "Redesign by yougame @foooor";
			this.button3.UseVisualStyleBackColor = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			base.AutoScrollMargin = new System.Drawing.Size(1, 1);
			base.AutoScrollMinSize = new System.Drawing.Size(1, 1);
			this.BackColor = Color.FromArgb(30, 30, 30);
			this.BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(911, 531);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.label57);
			base.Controls.Add(this.Norecoilaimval);
			base.Controls.Add(this.label53);
			base.Controls.Add(this.Rageoff);
			base.Controls.Add(this.label54);
			base.Controls.Add(this.Ragey);
			base.Controls.Add(this.label55);
			base.Controls.Add(this.Ragex);
			base.Controls.Add(this.label56);
			base.Controls.Add(this.Ragehuman);
			base.Controls.Add(this.label52);
			base.Controls.Add(this.Firerage);
			base.Controls.Add(this.Ragebot);
			base.Controls.Add(this.label51);
			base.Controls.Add(this.label24);
			base.Controls.Add(this.chanceval);
			base.Controls.Add(this.TargetCheck);
			base.Controls.Add(this.label50);
			base.Controls.Add(this.label49);
			base.Controls.Add(this.ColWidth);
			base.Controls.Add(this.CircleWidth);
			base.Controls.Add(this.label48);
			base.Controls.Add(this.label41);
			base.Controls.Add(this.ColY);
			base.Controls.Add(this.ColX);
			base.Controls.Add(this.label42);
			base.Controls.Add(this.label37);
			base.Controls.Add(this.label38);
			base.Controls.Add(this.ColB);
			base.Controls.Add(this.ColG);
			base.Controls.Add(this.ColR);
			base.Controls.Add(this.label39);
			base.Controls.Add(this.label36);
			base.Controls.Add(this.label30);
			base.Controls.Add(this.label31);
			base.Controls.Add(this.CircleBlue);
			base.Controls.Add(this.CircleGreen);
			base.Controls.Add(this.CircleRed);
			base.Controls.Add(this.label32);
			base.Controls.Add(this.label29);
			base.Controls.Add(this.label28);
			base.Controls.Add(this.Bdelay);
			base.Controls.Add(this.label26);
			base.Controls.Add(this.label27);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.CircleBtt);
			base.Controls.Add(this.EspBtt);
			base.Controls.Add(this.label25);
			base.Controls.Add(this.SmoothX);
			base.Controls.Add(this.label23);
			base.Controls.Add(this.label22);
			base.Controls.Add(this.Delayx);
			base.Controls.Add(this.label21);
			base.Controls.Add(this.rcs);
			base.Controls.Add(this.label20);
			base.Controls.Add(this.Speed3);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label19);
			base.Controls.Add(this.TriggerKeyBtt);
			base.Controls.Add(this.Bhopinput);
			base.Controls.Add(this.Bhopbox);
			base.Controls.Add(this.RecoilBtt);
			base.Controls.Add(this.CustomScreen);
			base.Controls.Add(this.ScreenY);
			base.Controls.Add(this.label18);
			base.Controls.Add(this.ScreenY2);
			base.Controls.Add(this.ScreenX2);
			base.Controls.Add(this.label17);
			base.Controls.Add(this.label15);
			base.Controls.Add(this.Pingx);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.label13);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.Blueinput);
			base.Controls.Add(this.Greeninput);
			base.Controls.Add(this.Redinput);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.Customcolor);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.FireRateNum);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.offsetNum);
			base.Controls.Add(this.StartBtt);
			base.Controls.Add(this.AimkeyBtt);
			base.Controls.Add(this.IsHoldToggle);
			base.Controls.Add(this.AimKeyToggle);
			base.Controls.Add(this.ChangeMonitorBtt);
			base.Controls.Add(this.PurpleRadio);
			base.Controls.Add(this.RedRadio);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.FovYNum);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.FovXNum);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.Speed);
			base.Controls.Add(this.TriggerbotBtt);
			base.Controls.Add(this.AimbotBtt);
			this.DoubleBuffered = true;
			this.ForeColor = SystemColors.ControlDark;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(2);
			this.MaximumSize = new System.Drawing.Size(2000, 2000);
			this.MinimumSize = new System.Drawing.Size(200, 200);
			base.Name = "Form1";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.toolTip1.SetToolTip(this, "Custom RGB Color if it doesn't detect the predefined one.");
			base.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
			base.Load += new EventHandler(this.Main_load);
			((ISupportInitialize)this.Speed).EndInit();
			((ISupportInitialize)this.FovXNum).EndInit();
			((ISupportInitialize)this.FovYNum).EndInit();
			((ISupportInitialize)this.offsetNum).EndInit();
			((ISupportInitialize)this.Speed3).EndInit();
			((ISupportInitialize)this.Delayx).EndInit();
			((ISupportInitialize)this.SmoothX).EndInit();
			((ISupportInitialize)this.rcs).EndInit();
			((ISupportInitialize)this.FireRateNum).EndInit();
			((ISupportInitialize)this.Redinput).EndInit();
			((ISupportInitialize)this.Greeninput).EndInit();
			((ISupportInitialize)this.Blueinput).EndInit();
			((ISupportInitialize)this.Pingx).EndInit();
			((ISupportInitialize)this.ScreenX2).EndInit();
			((ISupportInitialize)this.ScreenY2).EndInit();
			((ISupportInitialize)this.Bhopinput).EndInit();
			((ISupportInitialize)this.Bdelay).EndInit();
			((ISupportInitialize)this.CircleBlue).EndInit();
			((ISupportInitialize)this.CircleGreen).EndInit();
			((ISupportInitialize)this.CircleRed).EndInit();
			((ISupportInitialize)this.ColB).EndInit();
			((ISupportInitialize)this.ColG).EndInit();
			((ISupportInitialize)this.ColR).EndInit();
			((ISupportInitialize)this.ColY).EndInit();
			((ISupportInitialize)this.ColX).EndInit();
			((ISupportInitialize)this.CircleWidth).EndInit();
			((ISupportInitialize)this.ColWidth).EndInit();
			((ISupportInitialize)this.chanceval).EndInit();
			((ISupportInitialize)this.Firerage).EndInit();
			((ISupportInitialize)this.Rageoff).EndInit();
			((ISupportInitialize)this.Ragey).EndInit();
			((ISupportInitialize)this.Ragex).EndInit();
			((ISupportInitialize)this.Ragehuman).EndInit();
			((ISupportInitialize)this.Norecoilaimval).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void IsAimbot_changed(object sender, EventArgs e)
		{
			if (!this.AimbotBtt.Checked)
			{
				this.Ragebot.Enabled = true;
				this.Ragex.Enabled = true;
				this.Ragey.Enabled = true;
				this.Rageoff.Enabled = true;
				this.Ragehuman.Enabled = true;
				this.chanceval.Enabled = true;
				this.Firerage.Enabled = true;
				this.label51.Enabled = true;
				this.label52.Enabled = true;
				this.label53.Enabled = true;
				this.label24.Enabled = true;
				this.label54.Enabled = true;
				this.label55.Enabled = true;
				this.label56.Enabled = true;
			}
			else
			{
				this.Ragebot.Enabled = false;
				this.Ragex.Enabled = false;
				this.Ragey.Enabled = false;
				this.Rageoff.Enabled = false;
				this.Ragehuman.Enabled = false;
				this.chanceval.Enabled = false;
				this.Firerage.Enabled = false;
				this.label51.Enabled = false;
				this.label52.Enabled = false;
				this.label53.Enabled = false;
				this.label24.Enabled = false;
				this.label54.Enabled = false;
				this.label55.Enabled = false;
				this.label56.Enabled = false;
				this.speed = this.Speed.Value;
				this.SetKey("speed", this.speed);
				this.fovX = (int)this.FovXNum.Value;
				this.SetKey("fovX", this.fovX);
				this.fovY = (int)this.FovYNum.Value;
				this.SetKey("fovY", this.fovY);
				this.offsetY = (int)this.offsetNum.Value;
				this.SetKey("offsetY", this.offsetY);
			}
			this.isAimbot = this.AimbotBtt.Checked;
			this.SetKey("isAimbot", this.isAimbot);
		}

		private void IsAimKeyChanged(object sender, EventArgs e)
		{
			this.isAimKey = this.AimKeyToggle.Checked;
			this.SetKey("isAimKey", this.isAimKey);
		}

		private void IsHold_changed(object sender, EventArgs e)
		{
			this.isHold = this.IsHoldToggle.Checked;
			this.SetKey("isHold", this.isHold);
		}

		private void IsTriggerbot_changed(object sender, EventArgs e)
		{
			if (this.TriggerbotBtt.Checked)
			{
				this.msShootTime = (int)this.FireRateNum.Value;
				this.SetKey("msShootTime", this.msShootTime);
			}
			this.isTriggerbot = this.TriggerbotBtt.Checked;
			this.SetKey("isTriggerbot", this.isTriggerbot);
		}

		private void Label5_Click(object sender, EventArgs e)
		{
		}

		private void Main_load(object sender, EventArgs e)
		{
			this.mainThread = new Thread(() => {
				this.xNoRecoil();
				this.xBhop();
				this.xDice();
				this.xAimbot();
				this.xUpdate();
			});
			this.mainThread.Start();
		}

		private void MonitorChanged(object sender, EventArgs e)
		{
			this.monitor++;
			if (this.monitor >= (int)Screen.AllScreens.Length)
			{
				this.monitor = 0;
			}
			this.SetKey("monitor", this.monitor);
			this.UpdateUI();
		}

		[DllImport("user32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern void mouse_event(int dwFlags, int dx, int dy, uint dwData, UIntPtr dwInformation);

		public void Move(int x, int y, bool lm = false)
		{
			if (lm)
			{
				if (DateTime.Now.Subtract(this.lastShot).TotalMilliseconds >= (double)this.msShootTime)
				{
					this.lastShot = DateTime.Now;
				}
				else
				{
					lm = false;
				}
			}
			MoveInfo moveInfo = new MoveInfo()
			{
				MovementSettings = InternCaseMoveSettings.LeftUp | InternCaseMoveSettings.MoveNoCoalesce,
				xAmount = x,
				yAmount = y
			};
			this._mevent = moveInfo;
			if (lm)
			{
				moveInfo = new MoveInfo()
				{
					MovementSettings = InternCaseMoveSettings.LeftDown | InternCaseMoveSettings.MoveNoCoalesce
				};
				this._mevent = moveInfo;
			}
			CaseExecute.ExecuteMovementCase(this._mevent);
		}

		private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			this.Bhop = this.Bhopinput.Value;
			this.SetKey("Bhop", this.Bhop);
		}

		private void NumericUpDown1_ValueChanged_1(object sender, EventArgs e)
		{
			this.speed3 = this.Speed3.Value;
			this.SetKey("speed3", this.speed3);
		}

		private void NumericUpDown1_ValueChanged_2(object sender, EventArgs e)
		{
			this.delayx = this.Delayx.Value;
			this.SetKey("delayx", this.delayx);
		}

		private void numericUpDown1_ValueChanged_3(object sender, EventArgs e)
		{
			this.msShootTime = (int)this.Firerage.Value;
			this.SetKey("msShootTime", this.msShootTime);
		}

		private void numericUpDown5_ValueChanged(object sender, EventArgs e)
		{
			this.speed = this.Ragehuman.Value;
			this.SetKey("speed", this.speed);
		}

		private void OffsetY_changed(object sender, EventArgs e)
		{
			this.offsetY = (int)this.offsetNum.Value;
			this.SetKey("offsetY", this.offsetY);
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			this.mainThread.Abort();
			Settings.Default.Save();
			base.OnHandleDestroyed(e);
		}

		public unsafe Point[] PixelSearch(Rectangle rect, Color PixelColor, int ShadeVariation)
		{
			Point[] pointArray;
			ArrayList arrayList = new ArrayList();
			using (Bitmap tile = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb))
			{
				if (this.monitor >= (int)Screen.AllScreens.Length)
				{
					this.monitor = 0;
					this.UpdateUI();
				}
				Rectangle bounds = Screen.AllScreens[this.monitor].Bounds;
				int left = bounds.Left;
				bounds = Screen.AllScreens[this.monitor].Bounds;
				int top = bounds.Top;
				using (Graphics g = Graphics.FromImage(tile))
				{
					g.CopyFromScreen(rect.X + left, rect.Y + top, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
				}
				BitmapData bitmapData = tile.LockBits(new Rectangle(0, 0, tile.Width, tile.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
				int[] array = new int[] { PixelColor.B, PixelColor.G, PixelColor.R };
				for (int i = 0; i < bitmapData.Height; i++)
				{
					byte* ptr = (byte*)((void*)bitmapData.Scan0 + i * bitmapData.Stride);
					for (int j = 0; j < bitmapData.Width; j++)
					{
						if (*(ptr + j * 3) >= array[0] - ShadeVariation & *(ptr + j * 3) <= array[0] + ShadeVariation && *(ptr + j * 3 + 1) >= array[1] - ShadeVariation & *(ptr + j * 3 + 1) <= array[1] + ShadeVariation && *(ptr + j * 3 + 2) >= array[2] - ShadeVariation & *(ptr + j * 3 + 2) <= array[2] + ShadeVariation)
						{
							arrayList.Add(new Point(j + rect.X, i + rect.Y));
						}
					}
				}
				pointArray = (Point[])arrayList.ToArray(typeof(Point));
			}
			return pointArray;
		}

		private void Purple_changed(object sender, EventArgs e)
		{
			this.color = Form1.ColorType.Purple;
			this.SetKey("color", (int)this.color);
		}

		private void Rageoff_ValueChanged(object sender, EventArgs e)
		{
			this.offsetY = (int)this.Rageoff.Value;
			this.SetKey("offsetY", this.offsetY);
		}

		private void Ragex_ValueChanged(object sender, EventArgs e)
		{
			this.fovX = (int)this.Ragex.Value;
			this.SetKey("fovX", this.fovX);
		}

		private void Ragey_ValueChanged(object sender, EventArgs e)
		{
			this.fovY = (int)this.Ragey.Value;
			this.SetKey("fovY", this.fovY);
		}

		private void Recoilcheckbox_CheckedChanged_1(object sender, EventArgs e)
		{
			this.isRecoil = this.RecoilBtt.Checked;
			this.SetKey("isRecoil", this.isRecoil);
		}

		private void Red_changed(object sender, EventArgs e)
		{
			this.color = Form1.ColorType.Red;
			this.SetKey("color", (int)this.color);
		}

		private void SetKey(string key, bool o)
		{
			Settings.Default[key] = o;
			Settings.Default.Save();
		}

		private void SetKey(string key, int o)
		{
			Settings.Default[key] = o;
			Settings.Default.Save();
		}

		private void SetKey(string key, decimal o)
		{
			Settings.Default[key] = o;
			Settings.Default.Save();
		}

		private void Speed_changed(object sender, EventArgs e)
		{
			this.speed = this.Speed.Value;
			this.SetKey("speed", this.speed);
		}

		private void Start_click(object sender, EventArgs e)
		{
			FormOverlay formoverlay = new FormOverlay();
			if (this.isRunning)
			{
				try
				{
					formoverlay.Close();
					((FormOverlay)Application.OpenForms["FormOverlay"]).Close();
					this.CircleBtt.Checked = false;
				}
				catch
				{
				}
			}
			this.isRunning = !this.isRunning;
			this.UpdateUI();
			if (this.CircleBtt.Checked)
			{
				try
				{
					formoverlay.Show();
				}
				catch
				{
				}
			}
		}

		private void TriggerKeyDrop(object sender, EventArgs e)
		{
			if (this.TriggerKeyBtt.PointToScreen(new Point(this.TriggerKeyBtt.Left, this.TriggerKeyBtt.Bottom)).Y + this.contextMenuStrip2.Size.Height <= Screen.PrimaryScreen.WorkingArea.Height)
			{
				this.contextMenuStrip2.Show(this.TriggerKeyBtt, new Point(0, this.TriggerKeyBtt.Height));
				return;
			}
			System.Windows.Forms.ContextMenuStrip contextMenuStrip = this.contextMenuStrip2;
			Button triggerKeyBtt = this.TriggerKeyBtt;
			System.Drawing.Size size = this.contextMenuStrip2.Size;
			contextMenuStrip.Show(triggerKeyBtt, new Point(0, -size.Height));
		}

		private void UpdateDisplayInformation()
		{
			try
			{
				if (!this.CustomScreen.Checked)
				{
					this.zoom = Form1.GetScalingFactor();
					Screen screen = this.CurrentScreen();
					bool primary = screen.Primary;
					this.xSize = (int)((float)screen.Bounds.Width * (primary ? this.zoom : 1f));
					this.ySize = (int)((float)screen.Bounds.Height * (primary ? this.zoom : 1f));
				}
				else
				{
					int x = int.Parse(this.ScreenX2.Text);
					int y = int.Parse(this.ScreenY2.Text);
					this.xSize = x;
					this.ySize = y;
				}
			}
			catch
			{
				MessageBox.Show("Failure Code - 8 - There might be an issue with the Scren Detection!");
			}
		}

		private void UpdateUI()
		{
			this.StartBtt.Text = (this.isRunning ? "Stop" : "Start");
			this.UpdateDisplayInformation();
			this.ChangeMonitorBtt.Text = string.Concat(new string[] { "Monitor [", this.monitor.ToString(), "] ", this.xSize.ToString(), "x", this.ySize.ToString() });
			this.AimkeyBtt.Text = Enum.GetName(typeof(Form1.AimKey), this.mainAimKey);
			this.TriggerKeyBtt.Text = Enum.GetName(typeof(Form1.Bhopkey), this.Bhopxkey);
		}

		private async void xAimbot()
		{
			Form1.<xAimbot>d__5 variable = new Form1.<xAimbot>d__5();
			variable.<>4__this = this;
			variable.<>t__builder = AsyncVoidMethodBuilder.Create();
			variable.<>1__state = -1;
			variable.<>t__builder.Start<Form1.<xAimbot>d__5>(ref variable);
		}

		private async void xBhop()
		{
			Form1.<xBhop>d__7 variable = new Form1.<xBhop>d__7();
			variable.<>4__this = this;
			variable.<>t__builder = AsyncVoidMethodBuilder.Create();
			variable.<>1__state = -1;
			variable.<>t__builder.Start<Form1.<xBhop>d__7>(ref variable);
		}

		private async void xDice()
		{
			Form1.<xDice>d__12 variable = new Form1.<xDice>d__12();
			variable.<>4__this = this;
			variable.<>t__builder = AsyncVoidMethodBuilder.Create();
			variable.<>1__state = -1;
			variable.<>t__builder.Start<Form1.<xDice>d__12>(ref variable);
		}

		private async void xNoRecoil()
		{
			Form1.<xNoRecoil>d__6 variable = new Form1.<xNoRecoil>d__6();
			variable.<>4__this = this;
			variable.<>t__builder = AsyncVoidMethodBuilder.Create();
			variable.<>1__state = -1;
			variable.<>t__builder.Start<Form1.<xNoRecoil>d__6>(ref variable);
		}

		private async void xUpdate()
		{
			Form1.<xUpdate>d__13 variable = new Form1.<xUpdate>d__13();
			variable.<>4__this = this;
			variable.<>t__builder = AsyncVoidMethodBuilder.Create();
			variable.<>1__state = -1;
			variable.<>t__builder.Start<Form1.<xUpdate>d__13>(ref variable);
		}

		private enum AimKey
		{
			LeftMouse = 1,
			RightMouse = 2,
			X1Mouse = 5,
			X2Button = 6,
			Capslock = 20,
			Numpad0 = 96,
			Numlock = 144,
			Shift = 160,
			Ctrl = 162,
			Alt = 164
		}

		private enum Bhopkey
		{
			LeftMouse = 1,
			RightMouse = 2,
			X1Mouse = 5,
			X2Button = 6,
			Capslock = 20,
			Numpad0 = 96,
			Numlock = 144,
			Shift = 160,
			Ctrl = 162,
			Alt = 164
		}

		public enum ColorType
		{
			Red,
			Purple
		}

		public enum DeviceCap
		{
			VERTRES = 10,
			DESKTOPVERTRES = 117
		}

		public class DirectBitmap : IDisposable
		{
			private int[] bits;

			public Bitmap Bitmap
			{
				get;
				private set;
			}

			protected GCHandle BitsHandle
			{
				get;
				private set;
			}

			public bool Disposed
			{
				get;
				private set;
			}

			public int Height
			{
				get;
				private set;
			}

			public int Width
			{
				get;
				private set;
			}

			public DirectBitmap(int width, int height)
			{
				this.Width = width;
				this.Height = height;
				this.SetBits(new int[width * height]);
				this.BitsHandle = GCHandle.Alloc(this.GetBits(), GCHandleType.Pinned);
				GCHandle bitsHandle = this.BitsHandle;
				this.Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, bitsHandle.AddrOfPinnedObject());
			}

			public int[] GetBits()
			{
				return this.bits;
			}

			public Color GetPixel(int x, int y)
			{
				int index = x + y * this.Width;
				return Color.FromArgb(this.GetBits()[index]);
			}

			private void SetBits(int[] value)
			{
				this.bits = value;
			}

			public void SetPixel(int x, int y, Color colour)
			{
				int index = x + y * this.Width;
				int col = colour.ToArgb();
				this.GetBits()[index] = col;
			}

			void System.IDisposable.Dispose()
			{
				if (this.Disposed)
				{
					return;
				}
				this.Disposed = true;
				this.Bitmap.Dispose();
				this.BitsHandle.Free();
			}
		}
	}
}