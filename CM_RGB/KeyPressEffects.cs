using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CM_RGB
{
    class KeyPressEffects
    {

        public KeyPressEffects()
        {
        }

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys key);

        [DllImport("SDKDLL.dll")]
        public static extern void SetLedColor(int row, int col, byte r, byte g, byte b);

        [DllImport("SDKDLL.dll")]
        public static extern void SetFullLedColor(byte r, byte g, byte b);

        bool someChange = false;

        private List<Point> keys_ = new List<Point>();
        private List<int> timeAlive_ = new List<int>();

        public byte primaryRED = 255;
        public byte primaryGREEN = 0;
        public byte primaryBLUE = 0;
        public Color TempColor;
        public byte secondaryRED = 0;
        public byte secondaryGREEN = 255;
        public byte secondaryBLUE = 255;

        private void addOrUpdateKey(int x, int y)
        {
            for (int i = 0; i < keys_.Count; i++)
            {
                if (keys_[i].X == x && keys_[i].Y == y)
                {
                    timeAlive_[i] = 5;
                    someChange = true;
                }

            }
            if (someChange == false)
            {
                keys_.Add(new Point(x, y));
                timeAlive_.Add(5);
            }
            someChange = false;
        }


        public void keyPress()
        {

            for (int i = 0; i < keys_.Count; i++)
            {
                timeAlive_[i]--;

                if (timeAlive_[i] <= 0)
                {

                    SetLedColor(keys_[i].Y, keys_[i].X, secondaryRED, secondaryGREEN, secondaryBLUE);

                    timeAlive_.RemoveAt(i);
                    keys_.RemoveAt(i);
                }

            }


            //A
            if (GetAsyncKeyState(Keys.A) != 0)
            {
                addOrUpdateKey(1, 3);
            }

            //S
            if (GetAsyncKeyState(Keys.S) != 0)
            {
                addOrUpdateKey(2, 3);
            }

            //D
            if (GetAsyncKeyState(Keys.D) != 0)
            {
                addOrUpdateKey(3, 3);
            }

            //F
            if (GetAsyncKeyState(Keys.F) != 0)
            {
                addOrUpdateKey(4, 3);
            }

            //G
            if (GetAsyncKeyState(Keys.G) != 0)
            {
                addOrUpdateKey(5, 3);
            }

            //H
            if (GetAsyncKeyState(Keys.H) != 0)
            {
                addOrUpdateKey(6, 3);
            }

            //J
            if (GetAsyncKeyState(Keys.J) != 0)
            {
                addOrUpdateKey(7, 3);
            }

            //K
            if (GetAsyncKeyState(Keys.K) != 0)
            {
                addOrUpdateKey(8, 3);
            }

            //L
            if (GetAsyncKeyState(Keys.L) != 0)
            {
                addOrUpdateKey(9, 3);
            }

            //Q
            if (GetAsyncKeyState(Keys.Q) != 0)
            {
                addOrUpdateKey(1, 2);
            }

            //W
            if (GetAsyncKeyState(Keys.W) != 0)
            {
                addOrUpdateKey(2, 2);
            }

            //E
            if (GetAsyncKeyState(Keys.E) != 0)
            {
                addOrUpdateKey(3, 2);
            }

            //R
            if (GetAsyncKeyState(Keys.R) != 0)
            {
                addOrUpdateKey(4, 2);
            }

            //T
            if (GetAsyncKeyState(Keys.T) != 0)
            {
                addOrUpdateKey(5, 2);
            }

            //Y
            if (GetAsyncKeyState(Keys.Y) != 0)
            {
                addOrUpdateKey(6, 2);
            }

            //U
            if (GetAsyncKeyState(Keys.U) != 0)
            {
                addOrUpdateKey(7, 2);
            }

            //I
            if (GetAsyncKeyState(Keys.I) != 0)
            {
                addOrUpdateKey(8, 2);
            }

            //O
            if (GetAsyncKeyState(Keys.O) != 0)
            {
                addOrUpdateKey(9, 2);
            }

            //P
            if (GetAsyncKeyState(Keys.P) != 0)
            {
                addOrUpdateKey(10, 2);
            }

            //Z
            if (GetAsyncKeyState(Keys.Z) != 0)
            {
                addOrUpdateKey(2, 4);
            }

            //X
            if (GetAsyncKeyState(Keys.X) != 0)
            {
                addOrUpdateKey(3, 4);
            }

            //C
            if (GetAsyncKeyState(Keys.C) != 0)
            {
                addOrUpdateKey(4, 4);
            }

            //V
            if (GetAsyncKeyState(Keys.V) != 0)
            {
                addOrUpdateKey(5, 4);
            }

            //B
            if (GetAsyncKeyState(Keys.B) != 0)
            {
                addOrUpdateKey(6, 4);
            }

            //N
            if (GetAsyncKeyState(Keys.N) != 0)
            {
                addOrUpdateKey(7, 4);
            }

            //M
            if (GetAsyncKeyState(Keys.M) != 0)
            {
                addOrUpdateKey(8, 4);
            }

            //0
            if (GetAsyncKeyState(Keys.D0) != 0)
            {
                addOrUpdateKey(10, 1);
            }

            //1
            if (GetAsyncKeyState(Keys.D1) != 0)
            {
                addOrUpdateKey(1, 1);
            }

            //2
            if (GetAsyncKeyState(Keys.D2) != 0)
            {
                addOrUpdateKey(2, 1);
            }

            //3
            if (GetAsyncKeyState(Keys.D3) != 0)
            {
                addOrUpdateKey(3, 1);
            }

            //4
            if (GetAsyncKeyState(Keys.D4) != 0)
            {
                addOrUpdateKey(4, 1);
            }

            //5
            if (GetAsyncKeyState(Keys.D5) != 0)
            {
                addOrUpdateKey(5, 1);
            }

            //6
            if (GetAsyncKeyState(Keys.D6) != 0)
            {
                addOrUpdateKey(6, 1);
            }

            //7
            if (GetAsyncKeyState(Keys.D7) != 0)
            {
                addOrUpdateKey(7, 1);
            }

            //8
            if (GetAsyncKeyState(Keys.D8) != 0)
            {
                addOrUpdateKey(8, 1);
            }

            //9
            if (GetAsyncKeyState(Keys.D9) != 0)
            {
                addOrUpdateKey(9, 1);
            }

            //Control Keys
            if (GetAsyncKeyState(Keys.ControlKey) != 0)
            {
                addOrUpdateKey(0, 5);
                addOrUpdateKey(14, 5);
            }

            //Windows Keys
            if (GetAsyncKeyState(Keys.LWin) != 0 || GetAsyncKeyState(Keys.RWin) != 0)
            {
                addOrUpdateKey(1, 5);
                addOrUpdateKey(11, 5);
            }

            //Spacebar
            if (GetAsyncKeyState(Keys.Space) != 0)
            {
                addOrUpdateKey(6, 5);
            }

            //Alt Key
            if (GetAsyncKeyState(Keys.Menu) != 0)
            {
                addOrUpdateKey(2, 5);
                addOrUpdateKey(10, 5);
            }

            //Shift Keys
            if (GetAsyncKeyState(Keys.ShiftKey) != 0)
            {
                addOrUpdateKey(0, 4);
                addOrUpdateKey(14, 4);
            }

            //Escape Key
            if (GetAsyncKeyState(Keys.Escape) != 0)
            {
                addOrUpdateKey(0, 0);
            }

            //Tab Key
            if (GetAsyncKeyState(Keys.Tab) != 0)
            {
                addOrUpdateKey(0, 2);
            }

            //F1
            if (GetAsyncKeyState(Keys.F1) != 0)
            {
                addOrUpdateKey(1, 0);
            }

            //F2
            if (GetAsyncKeyState(Keys.F2) != 0)
            {
                addOrUpdateKey(2, 0);
            }

            //F3
            if (GetAsyncKeyState(Keys.F3) != 0)
            {
                addOrUpdateKey(3, 0);
            }

            //F4
            if (GetAsyncKeyState(Keys.F4) != 0)
            {
                addOrUpdateKey(4, 0);
            }

            //F5
            if (GetAsyncKeyState(Keys.F5) != 0)
            {
                addOrUpdateKey(6, 0);
            }

            //F6
            if (GetAsyncKeyState(Keys.F6) != 0)
            {
                addOrUpdateKey(7, 0);
            }

            //F7
            if (GetAsyncKeyState(Keys.F7) != 0)
            {
                addOrUpdateKey(8, 0);
            }

            //F8
            if (GetAsyncKeyState(Keys.F8) != 0)
            {
                addOrUpdateKey(9, 0);
            }

            //F9
            if (GetAsyncKeyState(Keys.F9) != 0)
            {
                addOrUpdateKey(11, 0);
            }

            //F10
            if (GetAsyncKeyState(Keys.F10) != 0)
            {
                addOrUpdateKey(12, 0);
            }

            //F11
            if (GetAsyncKeyState(Keys.F11) != 0)
            {
                addOrUpdateKey(13, 0);
            }

            //F12
            if (GetAsyncKeyState(Keys.F12) != 0)
            {
                addOrUpdateKey(14, 0);
            }

            //Enter
            if (GetAsyncKeyState(Keys.Enter) != 0)
            {
                addOrUpdateKey(14, 3);
                addOrUpdateKey(21, 4);
            }

            //`
            if (GetAsyncKeyState(Keys.Oem3) != 0)
            {
                addOrUpdateKey(0, 1);
            }

            //-
            if (GetAsyncKeyState(Keys.OemMinus) != 0)
            {
                addOrUpdateKey(11, 1);
            }

            //=
            if (GetAsyncKeyState(Keys.Oemplus) != 0)
            {
                addOrUpdateKey(12, 1);
            }

            //{
            if (GetAsyncKeyState(Keys.OemOpenBrackets) != 0)
            {
                addOrUpdateKey(11, 2);
            }

            //}
            if (GetAsyncKeyState(Keys.OemCloseBrackets) != 0)
            {
                addOrUpdateKey(12, 2);
            }

            //;
            if (GetAsyncKeyState(Keys.OemSemicolon) != 0)
            {
                addOrUpdateKey(10, 3);
            }

            //'
            if (GetAsyncKeyState(Keys.OemQuotes) != 0)
            {
                addOrUpdateKey(11, 3);
            }

            //,
            if (GetAsyncKeyState(Keys.Oemcomma) != 0)
            {
                addOrUpdateKey(9, 4);
            }

            //.
            if (GetAsyncKeyState(Keys.OemPeriod) != 0)
            {
                addOrUpdateKey(10, 4);
            }

            //Forward Slash
            if (GetAsyncKeyState(Keys.OemQuestion) != 0)
            {
                addOrUpdateKey(11, 4);
            }

            //Back Slash
            if (GetAsyncKeyState(Keys.Oem5) != 0)
            {
                addOrUpdateKey(14, 2);
            }

            //Backspace
            if (GetAsyncKeyState(Keys.Back) != 0)
            {
                addOrUpdateKey(14, 1);
            }

            //Print Screen
            if (GetAsyncKeyState(Keys.PrintScreen) != 0)
            {
                addOrUpdateKey(15, 0);
            }

            //Pause
            if (GetAsyncKeyState(Keys.Pause) != 0)
            {
                addOrUpdateKey(17, 0);
            }

            //Insert
            if (GetAsyncKeyState(Keys.Insert) != 0)
            {
                addOrUpdateKey(15, 1);
            }

            //Home
            if (GetAsyncKeyState(Keys.Home) != 0)
            {
                addOrUpdateKey(16, 1);
            }

            //Page Up
            if (GetAsyncKeyState(Keys.PageUp) != 0)
            {
                addOrUpdateKey(17, 1);
            }

            //Page Down
            if (GetAsyncKeyState(Keys.PageDown) != 0)
            {
                addOrUpdateKey(17, 2);
            }

            //Delete
            if (GetAsyncKeyState(Keys.Delete) != 0)
            {
                addOrUpdateKey(15, 2);
            }

            //End
            if (GetAsyncKeyState(Keys.End) != 0)
            {
                addOrUpdateKey(16, 2);
            }

            //Up Arrow
            if (GetAsyncKeyState(Keys.Up) != 0)
            {
                addOrUpdateKey(16, 4);
            }

            //Down Arrow
            if (GetAsyncKeyState(Keys.Down) != 0)
            {
                addOrUpdateKey(16, 5);
            }

            //Left Arrow
            if (GetAsyncKeyState(Keys.Left) != 0)
            {
                addOrUpdateKey(15, 5);
            }

            //Right Arrow
            if (GetAsyncKeyState(Keys.Right) != 0)
            {
                addOrUpdateKey(17, 5);
            }

            //NumPad0
            if (GetAsyncKeyState(Keys.NumPad0) != 0)
            {
                addOrUpdateKey(18, 5);
            }

            //NumPad1
            if (GetAsyncKeyState(Keys.NumPad1) != 0)
            {
                addOrUpdateKey(18, 4);
            }

            //NumPad2
            if (GetAsyncKeyState(Keys.NumPad2) != 0)
            {
                addOrUpdateKey(19, 4);
            }

            //NumPad3
            if (GetAsyncKeyState(Keys.NumPad3) != 0)
            {
                addOrUpdateKey(20, 4);
            }

            //NumPad4
            if (GetAsyncKeyState(Keys.NumPad4) != 0)
            {
                addOrUpdateKey(18, 3);
            }

            //NumPad5
            if (GetAsyncKeyState(Keys.NumPad5) != 0)
            {
                addOrUpdateKey(19, 3);
            }

            //NumPad6
            if (GetAsyncKeyState(Keys.NumPad6) != 0)
            {
                addOrUpdateKey(20, 3);
            }

            //NumPad7
            if (GetAsyncKeyState(Keys.NumPad7) != 0)
            {
                addOrUpdateKey(18, 2);
            }

            //NumPad8
            if (GetAsyncKeyState(Keys.NumPad8) != 0)
            {
                addOrUpdateKey(19, 2);
            }

            //NumPad9
            if (GetAsyncKeyState(Keys.NumPad9) != 0)
            {
                addOrUpdateKey(20, 2);
            }

            //Divide
            if (GetAsyncKeyState(Keys.Divide) != 0)
            {
                addOrUpdateKey(19, 1);
            }

            //Multiply
            if (GetAsyncKeyState(Keys.Multiply) != 0)
            {
                addOrUpdateKey(20, 1);
            }

            //Subtract
            if (GetAsyncKeyState(Keys.Subtract) != 0)
            {
                addOrUpdateKey(21, 1);
            }

            //Addition
            if (GetAsyncKeyState(Keys.Add) != 0)
            {
                addOrUpdateKey(21, 2);
            }

            //Decimal
            if (GetAsyncKeyState(Keys.Decimal) != 0)
            {
                addOrUpdateKey(20, 5);
            }

            for (int i = 0; i < keys_.Count; i++)
            {
                SetLedColor(keys_[i].Y, keys_[i].X, primaryRED, primaryGREEN, primaryBLUE);
            }

        }




    }
}
