using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CM_RGB
{
    public partial class appSettings : Form
    {
        public appSettings()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            //Possibly use a switch here
            switch (index)
            {
                case 0:

                    Properties.Settings.Default.LOCKEFFECT = "OFF";
                    break;
                case 1:

                    Properties.Settings.Default.LOCKEFFECT = "LBL";
                    break;
                case 2:

                    Properties.Settings.Default.LOCKEFFECT = "ALTL";
                    break;
                case 3:

                    Properties.Settings.Default.LOCKEFFECT = "SLBL";
                    break;
                case 4:

                    Properties.Settings.Default.LOCKEFFECT = "SPRL";
                    break;
                case 5:

                    Properties.Settings.Default.LOCKEFFECT = "WIPE";
                    break;
                case 6:

                    Properties.Settings.Default.LOCKEFFECT = "BRTH";
                    break;
                case 7:

                    Properties.Settings.Default.LOCKEFFECT = "RAND";
                    break;
                case 8:

                    Properties.Settings.Default.LOCKEFFECT = "RLINE";
                    break;
                case 9:

                    Properties.Settings.Default.LOCKEFFECT = "RSQR";
                    break;
                case 10:

                    Properties.Settings.Default.LOCKEFFECT = "RPATH";
                    break;
                case 11:

                    Properties.Settings.Default.LOCKEFFECT = "BALL";
                    break;
                case 12:

                    Properties.Settings.Default.LOCKEFFECT = "CCYCL";
                    break;
                case 13:

                    Properties.Settings.Default.LOCKEFFECT = "VRAIN";
                    break;
                case 14:

                    Properties.Settings.Default.LOCKEFFECT = "HRAIN";
                    break;
                case 15:

                    Properties.Settings.Default.LOCKEFFECT = "HRAINFRAMED";
                    break;
                case 16:

                    Properties.Settings.Default.LOCKEFFECT = "KEYP";
                    break;
                case 17:

                    Properties.Settings.Default.LOCKEFFECT = "TRAIL";
                    break;
            }
            Properties.Settings.Default.Save();
        }
    }
}
