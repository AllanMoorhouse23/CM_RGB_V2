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

namespace CM_RGB
{
    public partial class settingsStandard : Form
    {

        Color color1;
        Color color2;
        bool colorMode;
        bool direction;
        int speed;

        string effectCode;

        public settingsStandard(string[] args)
        {
            InitializeComponent();

            RetrieveSettings(args[1]);

            effectCode = args[1];

            if (args.Length > 0) {
                this.Text = "Effect - " + args[0];
            }
            
        }

        private void RetrieveSettings(string effect) {

            if (effect == "LBL")
            {
                //Retrieve direction settings
                direction = Properties.Settings.Default.LBL_DIRECTION;
                //Retrieve speed value
                speed = Properties.Settings.Default.LBL_SPEED;
                //Retrieve color mode settings
                colorMode = Properties.Settings.Default.LBL_COLORMODE;
                //Retrieve custom colors
                color1 = Properties.Settings.Default.LBL_COLOR1;
                color2 = Properties.Settings.Default.LBL_COLOR2;

            } else if (effect == "ALTL") {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                direction = Properties.Settings.Default.ALTL_DIRECTION;
                speed = Properties.Settings.Default.ALTL_SPEED;
                colorMode = Properties.Settings.Default.ALTL_COLORMODE;
                color1 = Properties.Settings.Default.ALTL_COLOR1;
                color2 = Properties.Settings.Default.ALTL_COLOR2;

            } else if (effect == "SLBL") {

                direction = Properties.Settings.Default.SLBL_DIRECTION;
                speed = Properties.Settings.Default.SLBL_SPEED;
                colorMode = Properties.Settings.Default.SLBL_COLORMODE;
                color1 = Properties.Settings.Default.SLBL_COLOR1;
                color2 = Properties.Settings.Default.SLBL_COLOR2;

            }
            else if (effect == "SPRL")
            {

                direction = Properties.Settings.Default.SPRL_DIRECTION;
                speed = Properties.Settings.Default.SPRL_SPEED;
                colorMode = Properties.Settings.Default.SPRL_COLORMODE;
                color1 = Properties.Settings.Default.SPRL_COLOR1;
                color2 = Properties.Settings.Default.SPRL_COLOR2;

            }
            else if (effect == "WIPE")
            {

                direction = Properties.Settings.Default.WIPE_DIRECTION;
                speed = Properties.Settings.Default.WIPE_SPEED;
                colorMode = Properties.Settings.Default.WIPE_COLORMODE;
                color1 = Properties.Settings.Default.WIPE_COLOR1;
                color2 = Properties.Settings.Default.WIPE_COLOR2;

            }
            else if (effect == "BRTH")
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                direction = Properties.Settings.Default.BRTH_DIRECTION;
                speed = Properties.Settings.Default.BRTH_SPEED;
                colorMode = Properties.Settings.Default.BRTH_COLORMODE;
                color1 = Properties.Settings.Default.BRTH_COLOR1;
                color2 = Properties.Settings.Default.BRTH_COLOR2;

            }
            else if (effect == "RAND")
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                direction = Properties.Settings.Default.RAND_DIRECTION;
                speed = Properties.Settings.Default.RAND_SPEED;
                colorMode = Properties.Settings.Default.RAND_COLORMODE;
                color1 = Properties.Settings.Default.RAND_COLOR1;
                color2 = Properties.Settings.Default.RAND_COLOR2;

            }
            else if (effect == "RLINE")
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                direction = Properties.Settings.Default.RLINE_DIRECTION;
                speed = Properties.Settings.Default.RLINE_SPEED;
                colorMode = Properties.Settings.Default.RLINE_COLORMODE;
                color1 = Properties.Settings.Default.RLINE_COLOR1;
                color2 = Properties.Settings.Default.RLINE_COLOR2;

            }
            else if (effect == "RSQR")
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                direction = Properties.Settings.Default.RSQR_DIRECTION;
                speed = Properties.Settings.Default.RSQR_SPEED;
                colorMode = Properties.Settings.Default.RSQR_COLORMODE;
                color1 = Properties.Settings.Default.RSQR_COLOR1;
                color2 = Properties.Settings.Default.RSQR_COLOR2;

            }
            else if (effect == "RPATH")
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                direction = Properties.Settings.Default.RPATH_DIRECTION;
                speed = Properties.Settings.Default.RPATH_SPEED;
                colorMode = Properties.Settings.Default.RPATH_COLORMODE;
                color1 = Properties.Settings.Default.RPATH_COLOR1;
                color2 = Properties.Settings.Default.RPATH_COLOR2;

            }
            else if (effect == "BALL")
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                direction = Properties.Settings.Default.BALL_DIRECTION;
                speed = Properties.Settings.Default.BALL_SPEED;
                colorMode = Properties.Settings.Default.BALL_COLORMODE;
                color1 = Properties.Settings.Default.BALL_COLOR1;
                color2 = Properties.Settings.Default.BALL_COLOR2;

            }
            else if (effect == "CCYCL")
            {

                direction = Properties.Settings.Default.CCYCL_DIRECTION;
                speed = Properties.Settings.Default.CCYCL_SPEED;
                colorMode = Properties.Settings.Default.CCYCL_COLORMODE;
                color1 = Properties.Settings.Default.CCYCL_COLOR1;
                color2 = Properties.Settings.Default.CCYCL_COLOR2;

            }
            else if (effect == "VRAIN")
            {

                direction = Properties.Settings.Default.VRAIN_DIRECTION;
                speed = Properties.Settings.Default.VRAIN_SPEED;
                colorMode = Properties.Settings.Default.VRAIN_COLORMODE;
                color1 = Properties.Settings.Default.VRAIN_COLOR1;
                color2 = Properties.Settings.Default.VRAIN_COLOR2;

            }
            else if (effect == "HRAIN")
            {

                direction = Properties.Settings.Default.HRAIN_DIRECTION;
                speed = Properties.Settings.Default.HRAIN_SPEED;
                colorMode = Properties.Settings.Default.HRAIN_COLORMODE;
                color1 = Properties.Settings.Default.HRAIN_COLOR1;
                color2 = Properties.Settings.Default.HRAIN_COLOR2;

            }
            else if (effect == "KEYP")
            {

                direction = Properties.Settings.Default.KEYP_DIRECTION;
                speed = Properties.Settings.Default.KEYP_SPEED;
                colorMode = Properties.Settings.Default.KEYP_COLORMODE;
                color1 = Properties.Settings.Default.KEYP_COLOR1;
                color2 = Properties.Settings.Default.KEYP_COLOR2;

            } else if (effect == "TRAIL") {
                direction = Properties.Settings.Default.TRAIL_DIRECTION;
                speed = Properties.Settings.Default.TRAIL_SPEED;
                colorMode = Properties.Settings.Default.TRAIL_COLORMODE;
                color1 = Properties.Settings.Default.TRAIL_COLOR1;
                color2 = Properties.Settings.Default.TRAIL_COLOR2;
            }


            RestoreSettings();
        }

        private void RestoreSettings() {
            
            //Restore direction settings
            if (direction == true)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

            //Restore speed value
            trackBar1.Value = speed;

            //Restore color mode settings
            if (colorMode == true)
            {
                radioButton4.Checked = true;
                radioButton3.Checked = false;
            }
            else
            {
                radioButton4.Checked = false;
                radioButton3.Checked = true;
            }

            //Restore custom colors
            panel4.BackColor = color1;
            panel6.BackColor = color2;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            lblValue.Text = trackBar1.Value + "MS";
        }





        /// <summary>
        /// Saves the current settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            


            if (effectCode == "LBL")
            {

                //Direction
                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.LBL_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.LBL_DIRECTION = false;
                }

                //Speed
                Properties.Settings.Default.LBL_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.LBL_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.LBL_COLORMODE = false;
                }

                //Custom color
                Properties.Settings.Default.LBL_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.LBL_COLOR2 = panel6.BackColor;


            }
            else if (effectCode == "ALTL")
            {

                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.ALTL_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.ALTL_DIRECTION = false;
                }

                Properties.Settings.Default.ALTL_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.ALTL_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.ALTL_COLORMODE = false;
                }

                Properties.Settings.Default.ALTL_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.ALTL_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "SLBL")
            {

                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.SLBL_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.SLBL_DIRECTION = false;
                }


                Properties.Settings.Default.SLBL_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.SLBL_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.SLBL_COLORMODE = false;
                }

                Properties.Settings.Default.SLBL_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.SLBL_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "SPRL")
            {

                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.SPRL_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.SPRL_DIRECTION = false;
                }


                Properties.Settings.Default.SPRL_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.SPRL_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.SPRL_COLORMODE = false;
                }

                Properties.Settings.Default.SPRL_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.SPRL_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "WIPE")
            {

                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.WIPE_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.WIPE_DIRECTION = false;
                }


                Properties.Settings.Default.WIPE_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.WIPE_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.WIPE_COLORMODE = false;
                }

                Properties.Settings.Default.WIPE_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.WIPE_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "BRTH")
            {

                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.BRTH_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.BRTH_DIRECTION = false;
                }


                Properties.Settings.Default.BRTH_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.BRTH_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.BRTH_COLORMODE = false;
                }

                Properties.Settings.Default.BRTH_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.BRTH_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "RAND")
            {

                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.RAND_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.RAND_DIRECTION = false;
                }

                Properties.Settings.Default.RAND_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.RAND_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.RAND_COLORMODE = false;
                }

                Properties.Settings.Default.RAND_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.RAND_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "RLINE")
            {
                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.RLINE_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.RLINE_DIRECTION = false;
                }

                Properties.Settings.Default.RLINE_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.RLINE_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.RLINE_COLORMODE = false;
                }

                Properties.Settings.Default.RLINE_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.RLINE_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "RSQR")
            {
                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.RSQR_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.RSQR_DIRECTION = false;
                }

                Properties.Settings.Default.RSQR_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.RSQR_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.RSQR_COLORMODE = false;
                }

                Properties.Settings.Default.RSQR_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.RSQR_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "RPATH")
            {
                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.RPATH_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.RPATH_DIRECTION = false;
                }

                Properties.Settings.Default.RPATH_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.RPATH_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.RPATH_COLORMODE = false;
                }

                Properties.Settings.Default.RPATH_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.RPATH_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "BALL")
            {
                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.BALL_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.BALL_DIRECTION = false;
                }

                Properties.Settings.Default.BALL_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.BALL_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.BALL_COLORMODE = false;
                }

                Properties.Settings.Default.BALL_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.BALL_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "CCYCL")
            {
                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.CCYCL_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.CCYCL_DIRECTION = false;
                }

                Properties.Settings.Default.CCYCL_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.CCYCL_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.CCYCL_COLORMODE = false;
                }

                Properties.Settings.Default.CCYCL_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.CCYCL_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "VRAIN")
            {
                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.VRAIN_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.VRAIN_DIRECTION = false;
                }

                Properties.Settings.Default.VRAIN_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.VRAIN_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.VRAIN_COLORMODE = false;
                }

                Properties.Settings.Default.VRAIN_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.VRAIN_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "HRAIN")
            {
                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.HRAIN_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.HRAIN_DIRECTION = false;
                }

                Properties.Settings.Default.HRAIN_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.HRAIN_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.HRAIN_COLORMODE = false;
                }

                Properties.Settings.Default.HRAIN_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.HRAIN_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "KEYP")
            {
                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.KEYP_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.KEYP_DIRECTION = false;
                }

                Properties.Settings.Default.KEYP_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.KEYP_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.KEYP_COLORMODE = false;
                }

                Properties.Settings.Default.KEYP_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.KEYP_COLOR2 = panel6.BackColor;

            }
            else if (effectCode == "TRAIL")
            {
                if (radioButton1.Checked == true)
                {
                    Properties.Settings.Default.TRAIL_DIRECTION = true;
                }
                else
                {
                    Properties.Settings.Default.TRAIL_DIRECTION = false;
                }

                Properties.Settings.Default.TRAIL_SPEED = trackBar1.Value;

                //Color mode
                if (radioButton4.Checked == true)
                {
                    Properties.Settings.Default.TRAIL_COLORMODE = true;
                }
                else
                {
                    Properties.Settings.Default.TRAIL_COLORMODE = false;
                }

                Properties.Settings.Default.TRAIL_COLOR1 = panel4.BackColor;
                Properties.Settings.Default.TRAIL_COLOR2 = panel6.BackColor;

            }












            //Save and close
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel4.BackColor = colorDialog1.Color;
            }
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel6.BackColor = colorDialog1.Color;
            }
        }
    }
}
