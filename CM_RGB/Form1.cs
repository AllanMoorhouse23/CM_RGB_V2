using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Drawing.Imaging;

namespace CM_RGB
{
    public partial class Form1 : Form
    {
        bool pcHasControl = false;

        string effectCode = "OFF";
        string lockeffect;
        string temp;

        Color color1;
        Color color2;
        bool colorMode;
        bool direction;
        int speed;


        public const int MAX_LED_ROW = 6;
        public const int MAX_LED_COLUMN = 22;

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys key);

        [DllImport("SDKDLL.dll")]
        public static extern bool EnableLedControl(bool bEnable);

        [DllImport("SDKDLL.dll")]
        public static extern void SetLedColor(int row, int col, byte r, byte g, byte b);

        [DllImport("SDKDLL.dll")]
        public static extern void SetFullLedColor(byte r, byte g, byte b);

        [DllImport("SDKDLL.dll")]
        public static extern bool IsDevicePlug();

        [DllImport("SDKDLL.dll")]
        public static extern uint GetRamUsage();

        [DllImport("SDKDLL.dll")]
        public static extern void SetControlDevice(DEVICE_INDEX devIndex);

        private static SessionSwitchEventHandler sseh;
        private bool state = false;

        public enum DEVICE_INDEX
        {
            DEV_MKeys_L = 0, DEV_MKeys_S = 1, DEV_MKeys_L_White = 2, DEV_MKeys_M_White = 3, DEV_MMouse_L = 4
                    , DEV_MMouse_S = 5, DEV_MKeys_M = 6, DEV_MKeys_S_White = 7,
        };

        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "OFF";
            SetControlDevice(DEVICE_INDEX.DEV_MKeys_L);

            lockeffect = Properties.Settings.Default.LOCKEFFECT;
            Console.WriteLine("Lockscreen Setting: " + Properties.Settings.Default.LOCKEFFECT + " Lockscreen Variable: " + lockeffect);

            sseh = new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.SessionSwitch += sseh;

        }

        /// <summary>
        /// Detect when a session switch occurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {

            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                //If no effect was running then enable
                if (pcHasControl == false && lockeffect != "OFF")
                {
                    EnableLedControl(true);
                    pcHasControl = true;
                    tmrAnimation.Start();
                }
                else if(lockeffect == "OFF"){
                    EnableLedControl(false);
                    pcHasControl = false;
                }
                
                temp = effectCode;
                effectCode = lockeffect;
                retrieveSettings();

            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                effectCode = temp;
                if (effectCode == "OFF")
                {
                    EnableLedControl(false);
                    pcHasControl = false;
                }
                else {
                    EnableLedControl(true);
                    pcHasControl = true;
                    retrieveSettings();
                }

            }

        }



        Effects_Set_1 _effects_set_1 = new Effects_Set_1();
        Effects_Set_2 _effects_set_2 = new Effects_Set_2();
        KeyPressEffects _effects_KeyPress_1 = new KeyPressEffects();
        /// <summary>
        /// Settings button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            int switchedIndex = comboBox1.SelectedIndex;

            string[] args = new string[] { "OFF", "OFF" }; ;

            switch (switchedIndex) {
                case 0:
                    break;
                case 1:
                    args = new string[] { "LINE BY LINE", "LBL" };
                    effectCode = "LBL";
                    break;
                case 2:
                    args = new string[] { "ALTERNATING LINES", "ALTL" };
                    effectCode = "ALTL";
                    break;
                case 3:
                    args = new string[] { "SNAKE LINE BY LINE", "SLBL" };
                    effectCode = "SLBL";
                    break;
                case 4:
                    args = new string[] { "SPIRAL", "SPRL" };
                    effectCode = "SPRL";
                    break;
                case 5:
                    args = new string[] { "WIPE", "WIPE" };
                    effectCode = "WIPE";
                    break;
                case 6:
                    args = new string[] { "BREATHING", "BRTH" };
                    effectCode = "BRTH";
                    break;
                case 7:
                    args = new string[] { "RANDOM", "RAND" };
                    effectCode = "RAND";
                    break;
                case 8:
                    args = new string[] { "RANDOM LINES", "RLINE" };
                    effectCode = "RLINE";
                    break;
                case 9:
                    args = new string[] { "RANDOM SQUARES", "RSQR" };
                    effectCode = "RSQR";
                    break;
                case 10:
                    args = new string[] { "RANDOM PATHS", "RPATH" };
                    effectCode = "RPATH";
                    break;
                case 11:
                    args = new string[] { "BALL", "BALL" };
                    effectCode = "BALL";
                    break;
                case 12:
                    args = new string[] { "COLOR CYCLE", "CCYCL" };
                    effectCode = "CCYCL";
                    break;
                case 13:
                    args = new string[] { "VERTICAL RAINBOW", "VRAIN" };
                    effectCode = "VRAIN";
                    break;
                case 14:
                    args = new string[] { "HORRIZONTAL RAINBOW", "HRAIN" };
                    effectCode = "HRAIN";
                    break;
                case 15:
                    args = new string[] { "HORRIZONTAL RAINBOW", "HRAIN" };
                    effectCode = "HRAINFRAMED";
                    break;
                case 16:
                    args = new string[] { "KEYPRESS", "KEYP" };
                    effectCode = "KEYP";
                    break;
                case 17:
                    args = new string[] { "TRAILS", "TRAIL" };
                    effectCode = "TRAIL";
                    break;
            }

            //Prevent settings from being opened
            if (switchedIndex == 0)
            {
            

            }else {
                settingsStandard settingsStandard = new settingsStandard(args);
                settingsStandard.Show();
                settingsStandard.FormClosed += formClosed;
            }
        }



        



        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Console.WriteLine("Index: " + comboBox1.SelectedIndex + " Value: " + comboBox1.SelectedItem);
            int index = comboBox1.SelectedIndex;
            if (index == 0)
            {
                effectCode = "OFF";
                //TURN OFF THE EFFECT BY HANDING CONTROL BACK TO THE KEYBOARD
                if (pcHasControl == true)
                {
                    pcHasControl = false;
                    tmrAnimation.Stop();
                    EnableLedControl(false);
                }
            }
            else
            {

                if(pcHasControl == false)
                {
                    pcHasControl = true;
                    tmrAnimation.Start();
                    EnableLedControl(true);
                }

                //Possibly use a switch here
                switch (index)
                {
                    case 0:

                        break;
                    case 1:

                       
                        effectCode = "LBL";
                        
                        break;
                    case 2:
                       
                        effectCode = "ALTL";
                        break;
                    case 3:
                       
                        effectCode = "SLBL";
                        break;
                    case 4:
                        
                        effectCode = "SPRL";
                        break;
                    case 5:
                        
                        effectCode = "WIPE";
                        break;
                    case 6:
                        
                        effectCode = "BRTH";
                        break;
                    case 7:
                        
                        effectCode = "RAND";
                        break;
                    case 8:
                       
                        effectCode = "RLINE";
                        break;
                    case 9:
                        
                        effectCode = "RSQR";
                        break;
                    case 10:
                        
                        effectCode = "RPATH";
                        break;
                    case 11:
                        
                        effectCode = "BALL";
                        break;
                    case 12:
                       
                        effectCode = "CCYCL";
                        break;
                    case 13:
                        
                        effectCode = "VRAIN";
                        break;
                    case 14:
                       
                        effectCode = "HRAIN";
                        break;
                    case 15:
                        
                        effectCode = "HRAINFRAMED";
                        break;
                    case 16:

                        effectCode = "KEYP";
                        break;
                    case 17:
                        effectCode = "TRAIL";
                        break;
                }
            }
            Console.WriteLine("Effect code: " + effectCode);
            Console.WriteLine("PC has control: " + pcHasControl);
            retrieveSettings();
        }


        private void retrieveSettings() {
            SetFullLedColor(0, 0, 0);
            //Reload the settings
            switch (effectCode)
            {
                case "LBL":
                    //Retrieve direction settings
                    direction = Properties.Settings.Default.LBL_DIRECTION;
                    //Retrieve speed value
                    speed = Properties.Settings.Default.LBL_SPEED;
                    tmrAnimation.Interval = speed;
                    //Retrieve color mode settings
                    colorMode = Properties.Settings.Default.LBL_COLORMODE;
                    //Retrieve custom colors
                    color1 = Properties.Settings.Default.LBL_COLOR1;
                    color2 = Properties.Settings.Default.LBL_COLOR2;
                    //Resets the effects
                    if (direction == false)
                    {
                        _effects_set_1.pos_x = 22;
                        _effects_set_1.pos_y = 5;
                    }
                    else
                    {
                        _effects_set_1.pos_x = 0;
                        _effects_set_1.pos_y = 0;
                    }
                    break;
                case "ALTL":
                    direction = Properties.Settings.Default.ALTL_DIRECTION;
                    speed = Properties.Settings.Default.ALTL_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.ALTL_COLORMODE;
                    color1 = Properties.Settings.Default.ALTL_COLOR1;
                    color2 = Properties.Settings.Default.ALTL_COLOR2;
                    break;
                case "SLBL":
                    direction = Properties.Settings.Default.SLBL_DIRECTION;
                    speed = Properties.Settings.Default.SLBL_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.SLBL_COLORMODE;
                    color1 = Properties.Settings.Default.SLBL_COLOR1;
                    color2 = Properties.Settings.Default.SLBL_COLOR2;
                    if (direction == false)
                    {
                        _effects_set_1.pos_x = 22;
                        _effects_set_1.pos_y = 5;
                        _effects_set_1.counter = 0;
                    }
                    else
                    {
                        _effects_set_1.pos_x = 0;
                        _effects_set_1.pos_y = 0;
                        _effects_set_1.counter = 0;
                    }
                    break;
                case "SPRL":
                    direction = Properties.Settings.Default.SPRL_DIRECTION;
                    speed = Properties.Settings.Default.SPRL_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.SPRL_COLORMODE;
                    color1 = Properties.Settings.Default.SPRL_COLOR1;
                    color2 = Properties.Settings.Default.SPRL_COLOR2;
                    if (direction == false)
                    {
                        _effects_set_1.pos_x = 2;
                        _effects_set_1.pos_y = 3;
                        _effects_set_1.counter = 0;
                    }
                    else
                    {
                        _effects_set_1.pos_x = 0;
                        _effects_set_1.pos_y = 0;
                        _effects_set_1.counter = 0;
                    }
                    effectCode = "SPRL";
                    break;
                case "WIPE":
                    direction = Properties.Settings.Default.WIPE_DIRECTION;
                    speed = Properties.Settings.Default.WIPE_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.WIPE_COLORMODE;
                    color1 = Properties.Settings.Default.WIPE_COLOR1;
                    color2 = Properties.Settings.Default.WIPE_COLOR2;
                    if (direction == false)
                    {
                        _effects_set_1.pos_x = 22;
                        _effects_set_1.pos_y = 0;
                    }
                    else
                    {
                        _effects_set_1.pos_x = 0;
                        _effects_set_1.pos_y = 0;
                    }
                    effectCode = "WIPE";
                    break;
                case "BRTH":
                    direction = Properties.Settings.Default.BRTH_DIRECTION;
                    speed = Properties.Settings.Default.BRTH_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.BRTH_COLORMODE;
                    color1 = Properties.Settings.Default.BRTH_COLOR1;
                    color2 = Properties.Settings.Default.BRTH_COLOR2;
                    break;
                case "RAND":
                    direction = Properties.Settings.Default.RAND_DIRECTION;
                    speed = Properties.Settings.Default.RAND_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.RAND_COLORMODE;
                    color1 = Properties.Settings.Default.RAND_COLOR1;
                    color2 = Properties.Settings.Default.RAND_COLOR2;
                    break;
                case "RLINE":
                    direction = Properties.Settings.Default.RLINE_DIRECTION;
                    speed = Properties.Settings.Default.RLINE_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.RLINE_COLORMODE;
                    color1 = Properties.Settings.Default.RLINE_COLOR1;
                    color2 = Properties.Settings.Default.RLINE_COLOR2;
                    break;
                case "RSQR":
                    direction = Properties.Settings.Default.RSQR_DIRECTION;
                    speed = Properties.Settings.Default.RSQR_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.RSQR_COLORMODE;
                    color1 = Properties.Settings.Default.RSQR_COLOR1;
                    color2 = Properties.Settings.Default.RSQR_COLOR2;
                    break;
                case "RPATH":
                    direction = Properties.Settings.Default.RPATH_DIRECTION;
                    speed = Properties.Settings.Default.RPATH_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.RPATH_COLORMODE;
                    color1 = Properties.Settings.Default.RPATH_COLOR1;
                    color2 = Properties.Settings.Default.RPATH_COLOR2;
                    break;
                case "BALL":
                    direction = Properties.Settings.Default.BALL_DIRECTION;
                    speed = Properties.Settings.Default.BALL_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.BALL_COLORMODE;
                    color1 = Properties.Settings.Default.BALL_COLOR1;
                    color2 = Properties.Settings.Default.BALL_COLOR2;
                    break;
                case "CCYCL":
                    direction = Properties.Settings.Default.CCYCL_DIRECTION;
                    speed = Properties.Settings.Default.CCYCL_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.CCYCL_COLORMODE;
                    color1 = Properties.Settings.Default.CCYCL_COLOR1;
                    color2 = Properties.Settings.Default.CCYCL_COLOR2;
                    break;
                case "VRAIN":
                    direction = Properties.Settings.Default.VRAIN_DIRECTION;
                    speed = Properties.Settings.Default.VRAIN_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.VRAIN_COLORMODE;
                    color1 = Properties.Settings.Default.VRAIN_COLOR1;
                    color2 = Properties.Settings.Default.VRAIN_COLOR2;                  
                    break;
                case "HRAIN":
                    direction = Properties.Settings.Default.HRAIN_DIRECTION;
                    speed = Properties.Settings.Default.HRAIN_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.HRAIN_COLORMODE;
                    color1 = Properties.Settings.Default.HRAIN_COLOR1;
                    color2 = Properties.Settings.Default.HRAIN_COLOR2;
                    break;
                case "HRAINFRAMED":
                    direction = Properties.Settings.Default.HRAIN_DIRECTION;
                    speed = Properties.Settings.Default.HRAIN_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.HRAIN_COLORMODE;
                    color1 = Properties.Settings.Default.HRAIN_COLOR1;
                    color2 = Properties.Settings.Default.HRAIN_COLOR2;
                    break;
                case "KEYP":
                    direction = Properties.Settings.Default.KEYP_DIRECTION;
                    speed = Properties.Settings.Default.KEYP_SPEED;
                    tmrAnimation.Interval = speed;
                    colorMode = Properties.Settings.Default.KEYP_COLORMODE;
                    color1 = Properties.Settings.Default.KEYP_COLOR1;
                    color2 = Properties.Settings.Default.KEYP_COLOR2;
                    break;
                case "TRAIL":
                    tmrAnimation.Interval = Properties.Settings.Default.TRAIL_SPEED;

                    _effects_set_2.setupTrails();
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                button1.Enabled = false;
            }
            else {
                button1.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            EnableLedControl(false);
           // SystemEvents.SessionSwitch -= sseh;
            tmrAnimation.Stop();
        }

        private void tmrAnimation_Tick(object sender, EventArgs e)
        {
            switch (effectCode)
            {
                case "LBL":
                    _effects_set_1.LineByLine(direction, colorMode, color1, color2);
                    break;
                case "ALTL":
                    _effects_set_1.effectAltLines(colorMode, color1, color2);
                    break;
                case "SLBL":
                    _effects_set_1.effectSnakeLineByLine(direction, colorMode, color1, color2);
                    break;
                case "SPRL":
                    _effects_set_1.effectSpiral(direction, colorMode, color1, color2);
                    break;
                case "WIPE":
                    _effects_set_1.effectWipe(direction, colorMode, color1, color2);
                    break;
                case "BRTH":
                    _effects_set_1.effectBreathing();
                    break;
                case "RAND":
                    _effects_set_1.effectRandom();
                    break;
                case "RLINE":
                    _effects_set_1.effectRandomLines(colorMode, color1, color2);
                    break;
                case "RSQR":
                    _effects_set_1.effectRandomSquares();
                    break;
                case "RPATH":
                    _effects_set_1.effectRandomSelectedLine(colorMode, color1, color2);
                    break;
                case "BALL":
                    _effects_set_1.effectBall(colorMode, color1, color2);
                    break;
                case "CCYCL":
                    _effects_set_1.effectColorCycle();
                    break;
                case "VRAIN":
                    _effects_set_2.effectVerticalRain();
                    break;
                case "HRAIN":
                    _effects_set_2.effectRainbow();
                    break;
                case "HRAINFRAMED":
                    _effects_set_2.rainbowFramed();
                    break;
                case "KEYP":
                    _effects_KeyPress_1.keyPress();
                    break;
                case "TRAIL":
                    if (Properties.Settings.Default.TRAIL_DIRECTION == true)
                    {
                        _effects_set_2.trails();
                     
                    }
                    else {
                        _effects_set_2.trailsReverse();
                   
                    }
                    break;
            }
        }


        /// <summary>
        /// Settings form closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formClosed(object sender, FormClosedEventArgs e)
        {
            if (sender.GetType().Name == "settingsStandard")
            {
                Console.WriteLine(sender.GetType().Name);
                retrieveSettings();
            }
            else if (sender.GetType().Name == "appSettings")
            {
                Console.WriteLine(sender.GetType().Name);
                //refesh lockscreen effect
                lockeffect = Properties.Settings.Default.LOCKEFFECT;
                
                Console.WriteLine("Lockscreen Setting: " + Properties.Settings.Default.LOCKEFFECT + " Lockscreen Variable: " + lockeffect);
            }
            else
            {
                Console.WriteLine("SHEIT SOMETHING WENT WRONG");
            }
        }


      
        /// <summary>
        /// Opens the app settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            appSettings appSettings = new appSettings();
            appSettings.Show();
            appSettings.FormClosed += formClosed;
        }
    }
}
