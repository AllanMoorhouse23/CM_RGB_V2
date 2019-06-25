using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CM_RGB
{
    class Effects_Set_2
    {

        public Effects_Set_2()
        {

        }
        private int frame = 0;

        [DllImport("SDKDLL.dll")]
        public static extern void SetLedColor(int row, int col, byte r, byte g, byte b);

        Random random = new Random();
        private byte[] red_ = new byte[22] { 255, 255, 255, 255, 165, 90, 0, 0, 0, 0, 0, 0, 0, 90, 165, 255, 255, 255, 255, 255, 255, 255 };
        private byte[] green_ = new byte[22] { 0, 90, 165, 255, 255, 255, 255, 255, 255, 255, 165, 90, 0, 0, 0, 0, 0, 0, 0, 90, 165, 255 };
        private byte[] blue_ = new byte[22] { 0, 0, 0, 0, 0, 0, 0, 90, 165, 255, 255, 255, 255, 255, 255, 255, 165, 90, 0, 0, 0, 0 };
        private string[] colorTo_ = new string[22] { "yellow", "yellow", "yellow", "green", "green", "green", "aqua", "aqua", "aqua", "blue", "blue", "blue", "pink", "pink", "pink", "red", "red", "red", "yellow", "yellow", "yellow", "green" };

        public void effectRainbow()
        {

            for (int i = 0; i < 22; i++)
            {
                if (colorTo_[i] == "yellow")
                {
                    green_[i] += 15;
                }
                else if (colorTo_[i] == "green")
                {
                    red_[i] -= 15;
                }
                else if (colorTo_[i] == "aqua")
                {
                    blue_[i] += 15;
                }
                else if (colorTo_[i] == "blue")
                {
                    green_[i] -= 15;
                }
                else if (colorTo_[i] == "pink")
                {
                    red_[i] += 15;
                }
                else if (colorTo_[i] == "red")
                {
                    blue_[i] -= 15;
                }

                if (red_[i] == 255 && green_[i] == 0 && blue_[i] == 255)
                {
                    colorTo_[i] = "red";
                }
                else if (red_[i] == 255 && green_[i] == 0 && blue_[i] == 0)
                {
                    colorTo_[i] = "yellow";
                }
                else if (red_[i] == 255 && green_[i] == 255 && blue_[i] == 0)
                {
                    colorTo_[i] = "green";
                }
                else if (red_[i] == 0 && green_[i] == 255 && blue_[i] == 0)
                {
                    colorTo_[i] = "aqua";
                }
                else if (red_[i] == 0 && green_[i] == 255 && blue_[i] == 255)
                {
                    colorTo_[i] = "blue";
                }
                else if (red_[i] == 0 && green_[i] == 0 && blue_[i] == 255)
                {
                    colorTo_[i] = "pink";
                }
                //Loop through each row
                for (int j = 0; j < 6; j++)
                {
                    SetLedColor(j, i, red_[i], green_[i], blue_[i]);
                }
            }
        }




        public void effectVerticalRain()
        {
            
            switch (frame)
            {
                case 1:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 255, 0, 0);
                        SetLedColor(1, i, 255, 90, 0);
                        SetLedColor(2, i, 255, 165, 0);
                        SetLedColor(3, i, 255, 255, 0);
                        SetLedColor(4, i, 165, 255, 0);
                        SetLedColor(5, i, 90, 255, 0);
                    }
                    break;
                case 2:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 255, 90, 0);
                        SetLedColor(1, i, 255, 165, 0);
                        SetLedColor(2, i, 255, 255, 0);
                        SetLedColor(3, i, 165, 255, 0);
                        SetLedColor(4, i, 90, 255, 0);
                        SetLedColor(5, i, 0, 255, 0);
                    }
                    break;
                case 3:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 255, 165, 0);
                        SetLedColor(1, i, 255, 255, 0);
                        SetLedColor(2, i, 165, 255, 0);
                        SetLedColor(3, i, 90, 255, 0);
                        SetLedColor(4, i, 0, 255, 0);
                        SetLedColor(5, i, 0, 255, 90);
                    }
                    break;
                case 4:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 255, 255, 0);
                        SetLedColor(1, i, 165, 255, 0);
                        SetLedColor(2, i, 90, 255, 0);
                        SetLedColor(3, i, 0, 255, 0);
                        SetLedColor(4, i, 0, 255, 90);
                        SetLedColor(5, i, 0, 255, 165);
                    }
                    break;
                case 5:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 165, 255, 0);
                        SetLedColor(1, i, 90, 255, 0);
                        SetLedColor(2, i, 0, 255, 0);
                        SetLedColor(3, i, 0, 255, 90);
                        SetLedColor(4, i, 0, 255, 165);
                        SetLedColor(5, i, 0, 255, 255);
                    }
                    break;
                case 6:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 90, 255, 0);
                        SetLedColor(1, i, 0, 255, 0);
                        SetLedColor(2, i, 0, 255, 90);
                        SetLedColor(3, i, 0, 255, 165);
                        SetLedColor(4, i, 0, 255, 255);
                        SetLedColor(5, i, 0, 165, 255);
                    }
                    break;
                case 7:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 0, 255, 0);
                        SetLedColor(1, i, 0, 255, 90);
                        SetLedColor(2, i, 0, 255, 165);
                        SetLedColor(3, i, 0, 255, 255);
                        SetLedColor(4, i, 0, 165, 255);
                        SetLedColor(5, i, 0, 90, 255);
                    }
                    break;
                case 8:
                    for (int i = 0; i < 22; i++)
                    {

                        SetLedColor(0, i, 0, 255, 90);
                        SetLedColor(1, i, 0, 255, 165);
                        SetLedColor(2, i, 0, 255, 255);
                        SetLedColor(3, i, 0, 165, 255);
                        SetLedColor(4, i, 0, 90, 255);
                        SetLedColor(5, i, 0, 0, 255);
                    }
                    break;
                case 9:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 0, 255, 165);
                        SetLedColor(1, i, 0, 255, 255);
                        SetLedColor(2, i, 0, 165, 255);
                        SetLedColor(3, i, 0, 90, 255);
                        SetLedColor(4, i, 0, 0, 255);
                        SetLedColor(5, i, 90, 0, 255);
                    }
                    break;
                case 10:
                    for (int i = 0; i < 22; i++)
                    {

                        SetLedColor(0, i, 0, 255, 255);
                        SetLedColor(1, i, 0, 165, 255);
                        SetLedColor(2, i, 0, 90, 255);
                        SetLedColor(3, i, 0, 0, 255);
                        SetLedColor(4, i, 90, 0, 255);
                        SetLedColor(5, i, 165, 0, 255);
                    }
                    break;
                case 11:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 0, 165, 255);
                        SetLedColor(1, i, 0, 90, 255);
                        SetLedColor(2, i, 0, 0, 255);
                        SetLedColor(3, i, 90, 0, 255);
                        SetLedColor(4, i, 165, 0, 255);
                        SetLedColor(5, i, 255, 0, 255);
                    }
                    break;
                case 12:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 0, 90, 255);
                        SetLedColor(1, i, 0, 0, 255);
                        SetLedColor(2, i, 90, 0, 255);
                        SetLedColor(3, i, 165, 0, 255);
                        SetLedColor(4, i, 255, 0, 255);
                        SetLedColor(5, i, 255, 0, 165);
                    }
                    break;
                case 13:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 0, 0, 255);
                        SetLedColor(1, i, 90, 0, 255);
                        SetLedColor(2, i, 165, 0, 255);
                        SetLedColor(3, i, 255, 0, 255);
                        SetLedColor(4, i, 255, 0, 165);
                        SetLedColor(5, i, 255, 0, 90);
                    }
                    break;
                case 14:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 90, 0, 255);
                        SetLedColor(1, i, 165, 0, 255);
                        SetLedColor(2, i, 255, 0, 255);
                        SetLedColor(3, i, 255, 0, 165);
                        SetLedColor(4, i, 255, 0, 90);
                        SetLedColor(5, i, 255, 0, 0);
                    }
                    break;
                case 15:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 165, 0, 255);
                        SetLedColor(1, i, 255, 0, 255);
                        SetLedColor(2, i, 255, 0, 165);
                        SetLedColor(3, i, 255, 0, 90);
                        SetLedColor(4, i, 255, 0, 0);
                        SetLedColor(5, i, 255, 90, 0);
                    }
                    break;
                case 16:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 255, 0, 255);
                        SetLedColor(1, i, 255, 0, 165);
                        SetLedColor(2, i, 255, 0, 90);
                        SetLedColor(3, i, 255, 0, 0);
                        SetLedColor(4, i, 255, 90, 0);
                        SetLedColor(5, i, 255, 165, 0);
                    }
                    break;
                case 17:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 255, 0, 165);
                        SetLedColor(1, i, 255, 0, 90);
                        SetLedColor(2, i, 255, 0, 0);
                        SetLedColor(3, i, 255, 90, 0);
                        SetLedColor(4, i, 255, 165, 0);
                        SetLedColor(5, i, 255, 255, 0);
                    }
                    break;
                case 18:
                    for (int i = 0; i < 22; i++)
                    {
                        SetLedColor(0, i, 255, 0, 90);
                        SetLedColor(1, i, 255, 0, 0);
                        SetLedColor(2, i, 255, 90, 0);
                        SetLedColor(3, i, 255, 165, 0);
                        SetLedColor(4, i, 255, 255, 0);
                        SetLedColor(5, i, 165, 255, 0);
                    }
                    frame = 0;
                    break;
            }
            frame++;

                
        }


        public void lightning()
        {
            

        }

        public void rainbowFramed()
        {

            switch (frame)
            {
                case 1:
                    for (int i = 0; i < 6; i++)
                    {
                        SetLedColor(i, 0, 255, 0, 0);
                        SetLedColor(i, 1, 255, 90, 0);
                        SetLedColor(i, 2, 255, 165, 0);
                        SetLedColor(i, 3, 255, 255, 0);
                        SetLedColor(i, 4, 165, 255, 0);
                        SetLedColor(i, 5, 90, 255, 0);
                        SetLedColor(i, 6, 0, 255, 0);
                        SetLedColor(i, 7, 0, 255, 90);
                        SetLedColor(i, 8, 0, 255, 165);
                        SetLedColor(i, 9, 0, 255, 255);
                        SetLedColor(i, 10, 0, 165, 255);
                        SetLedColor(i, 11, 0, 90, 255);
                        SetLedColor(i, 12, 0, 0, 255);
                        SetLedColor(i, 13, 90, 0, 255);
                        SetLedColor(i, 14, 165, 0, 255);
                        SetLedColor(i, 15, 255, 0, 255);
                        SetLedColor(i, 16, 255, 0, 165);
                        SetLedColor(i, 17, 255, 0, 90);
                        SetLedColor(i, 18, 255, 0, 0);
                        SetLedColor(i, 19, 255, 90, 0);
                        SetLedColor(i, 20, 255, 165, 0);
                        SetLedColor(i, 21, 255, 255, 0);         
                    }
                    break;
                case 2:
                    for (int i = 0; i < 6; i++)
                    {
                        
                        SetLedColor(i, 0, 255, 90, 0);
                        SetLedColor(i, 1, 255, 165, 0);
                        SetLedColor(i, 2, 255, 255, 0);
                        SetLedColor(i, 3, 165, 255, 0);
                        SetLedColor(i, 4, 90, 255, 0);
                        SetLedColor(i, 5, 0, 255, 0);
                        SetLedColor(i, 6, 0, 255, 90);
                        SetLedColor(i, 7, 0, 255, 165);
                        SetLedColor(i, 8, 0, 255, 255);
                        SetLedColor(i, 9,  0, 165, 255);
                        SetLedColor(i, 10, 0, 90, 255);
                        SetLedColor(i, 11, 0, 0, 255);
                        SetLedColor(i, 12, 90, 0, 255);
                        SetLedColor(i, 13, 165, 0, 255);
                        SetLedColor(i, 14, 255, 0, 255);
                        SetLedColor(i, 15, 255, 0, 165);
                        SetLedColor(i, 16, 255, 0, 90);
                        SetLedColor(i, 17, 255, 0, 0);
                        SetLedColor(i, 18, 255, 90, 0);
                        SetLedColor(i, 19, 255, 165, 0);
                        SetLedColor(i, 20, 255, 255, 0);
                        SetLedColor(i, 21, 165, 255, 0);
                    }
                    break;
                case 3:
                    for (int i = 0; i < 6; i++)
                    {
                        
                        SetLedColor(i, 0, 255, 165, 0);
                        SetLedColor(i, 1, 255, 255, 0);
                        SetLedColor(i, 2, 165, 255, 0);
                        SetLedColor(i, 3, 90, 255, 0);
                        SetLedColor(i, 4, 0, 255, 0);
                        SetLedColor(i, 5, 0, 255, 90);
                        SetLedColor(i, 6, 0, 255, 165);
                        SetLedColor(i, 7, 0, 255, 255);
                        SetLedColor(i, 8, 0, 165, 255);
                        SetLedColor(i, 9,  0, 90, 255);
                        SetLedColor(i, 10, 0, 0, 255);
                        SetLedColor(i, 11, 90, 0, 255);
                        SetLedColor(i, 12, 165, 0, 255);
                        SetLedColor(i, 13, 255, 0, 255);
                        SetLedColor(i, 14, 255, 0, 165);
                        SetLedColor(i, 15, 255, 0, 90);
                        SetLedColor(i, 16, 255, 0, 0);
                        SetLedColor(i, 17, 255, 90, 0);
                        SetLedColor(i, 18, 255, 165, 0);
                        SetLedColor(i, 19, 255, 255, 0);
                        SetLedColor(i, 20, 165, 255, 0);
                        SetLedColor(i, 21, 90, 255, 0);
                   
                    }
                    break;
                case 4:
                    for (int i = 0; i < 6; i++)
                    {

                        SetLedColor(i, 0, 255, 255, 0);
                        SetLedColor(i, 1, 165, 255, 0);
                        SetLedColor(i, 2, 90, 255, 0);
                        SetLedColor(i, 3, 0, 255, 0);
                        SetLedColor(i, 4, 0, 255, 90);
                        SetLedColor(i, 5, 0, 255, 165);
                        SetLedColor(i, 6, 0, 255, 255);
                        SetLedColor(i, 7, 0, 165, 255);
                        SetLedColor(i, 8, 0, 90, 255);
                        SetLedColor(i, 9, 0, 0, 255);
                        SetLedColor(i, 10, 90, 0, 255);
                        SetLedColor(i, 11, 165, 0, 255);
                        SetLedColor(i, 12, 255, 0, 255);
                        SetLedColor(i, 13, 255, 0, 165);
                        SetLedColor(i, 14, 255, 0, 90);
                        SetLedColor(i, 15, 255, 0, 0);
                        SetLedColor(i, 16, 255, 90, 0);
                        SetLedColor(i, 17, 255, 165, 0);
                        SetLedColor(i, 18, 255, 255, 0);
                        SetLedColor(i, 19, 165, 255, 0);
                        SetLedColor(i, 20, 90, 255, 0);
                        SetLedColor(i, 21, 0, 255, 0);
                    }
                    break;
                case 5:
                    for (int i = 0; i < 6; i++)
                    {

                        SetLedColor(i, 0, 165, 255, 0);
                        SetLedColor(i, 1, 90, 255, 0);
                        SetLedColor(i, 2, 0, 255, 0);
                        SetLedColor(i, 3, 0, 255, 90);
                        SetLedColor(i, 4, 0, 255, 165);
                        SetLedColor(i, 5, 0, 255, 255);
                        SetLedColor(i, 6, 0, 165, 255);
                        SetLedColor(i, 7, 0, 90, 255);
                        SetLedColor(i, 8, 0, 0, 255);
                        SetLedColor(i, 9, 90, 0, 255);
                        SetLedColor(i, 10, 165, 0, 255);
                        SetLedColor(i, 11, 255, 0, 255);
                        SetLedColor(i, 12, 255, 0, 165);
                        SetLedColor(i, 13, 255, 0, 90);
                        SetLedColor(i, 14, 255, 0, 0);
                        SetLedColor(i, 15, 255, 90, 0);
                        SetLedColor(i, 16, 255, 165, 0);
                        SetLedColor(i, 17, 255, 255, 0);
                        SetLedColor(i, 18, 165, 255, 0);
                        SetLedColor(i, 19, 90, 255, 0);
                        SetLedColor(i, 20, 0, 255, 0);
                        SetLedColor(i, 21, 0, 255, 90);
                    }
                    break;
                case 6:
                    for (int i = 0; i < 6; i++)
                    {
                        
                        SetLedColor(i, 0, 90, 255, 0);
                        SetLedColor(i, 1, 0, 255, 0);
                        SetLedColor(i, 2, 0, 255, 90);
                        SetLedColor(i, 3, 0, 255, 165);
                        SetLedColor(i, 4, 0, 255, 255);
                        SetLedColor(i, 5, 0, 165, 255);
                        SetLedColor(i, 6, 0, 90, 255);
                        SetLedColor(i, 7, 0, 0, 255);
                        SetLedColor(i, 8, 90, 0, 255);
                        SetLedColor(i, 9,  165, 0, 255);
                        SetLedColor(i, 10, 255, 0, 255);
                        SetLedColor(i, 11, 255, 0, 165);
                        SetLedColor(i, 12, 255, 0, 90);
                        SetLedColor(i, 13, 255, 0, 0);
                        SetLedColor(i, 14, 255, 90, 0);
                        SetLedColor(i, 15, 255, 165, 0);
                        SetLedColor(i, 16, 255, 255, 0);
                        SetLedColor(i, 17, 165, 255, 0);
                        SetLedColor(i, 18, 90, 255, 0);
                        SetLedColor(i, 19, 0, 255, 0);
                        SetLedColor(i, 20, 0, 255, 90);
                        SetLedColor(i, 21, 0, 255, 165);
                    }
                    break;
                case 7:
                    for (int i = 0; i < 6; i++)
                    {
                        
                        SetLedColor(i, 0, 0, 255, 0);
                        SetLedColor(i, 1, 0, 255, 90);
                        SetLedColor(i, 2, 0, 255, 165);
                        SetLedColor(i, 3, 0, 255, 255);
                        SetLedColor(i, 4, 0, 165, 255);
                        SetLedColor(i, 5, 0, 90, 255);
                        SetLedColor(i, 6, 0, 0, 255);
                        SetLedColor(i, 7, 90, 0, 255);
                        SetLedColor(i, 8, 165, 0, 255);
                        SetLedColor(i, 9,  255, 0, 255);
                        SetLedColor(i, 10, 255, 0, 165);
                        SetLedColor(i, 11, 255, 0, 90);
                        SetLedColor(i, 12, 255, 0, 0);
                        SetLedColor(i, 13, 255, 90, 0);
                        SetLedColor(i, 14, 255, 165, 0);
                        SetLedColor(i, 15, 255, 255, 0);
                        SetLedColor(i, 16, 165, 255, 0);
                        SetLedColor(i, 17, 90, 255, 0);
                        SetLedColor(i, 18, 0, 255, 0);
                        SetLedColor(i, 19, 0, 255, 90);
                        SetLedColor(i, 20, 0, 255, 165);
                        SetLedColor(i, 21, 0, 255, 255);
                    }
                    break;
                case 8:
                    for (int i = 0; i < 6; i++)
                    {
                        
                        SetLedColor(i, 0, 0, 255, 90);
                        SetLedColor(i, 1, 0, 255, 165);
                        SetLedColor(i, 2, 0, 255, 255);
                        SetLedColor(i, 3, 0, 165, 255);
                        SetLedColor(i, 4, 0, 90, 255);
                        SetLedColor(i, 5, 0, 0, 255);
                        SetLedColor(i, 6, 90, 0, 255);
                        SetLedColor(i, 7, 165, 0, 255);
                        SetLedColor(i, 8, 255, 0, 255);
                        SetLedColor(i, 9,  255, 0, 165);
                        SetLedColor(i, 10, 255, 0, 90);
                        SetLedColor(i, 11, 255, 0, 0);
                        SetLedColor(i, 12, 255, 90, 0);
                        SetLedColor(i, 13, 255, 165, 0);
                        SetLedColor(i, 14, 255, 255, 0);
                        SetLedColor(i, 15, 165, 255, 0);
                        SetLedColor(i, 16, 90, 255, 0);
                        SetLedColor(i, 17, 0, 255, 0);
                        SetLedColor(i, 18, 0, 255, 90);
                        SetLedColor(i, 19, 0, 255, 165);
                        SetLedColor(i, 20, 0, 255, 255);
                        SetLedColor(i, 21, 0, 165, 255);
                    }
                    break;
                case 9:
                    for (int i = 0; i < 6; i++)
                    {
                        
                        SetLedColor(i, 0, 0, 255, 165);
                        SetLedColor(i, 1, 0, 255, 255);
                        SetLedColor(i, 2, 0, 165, 255);
                        SetLedColor(i, 3, 0, 90, 255);
                        SetLedColor(i, 4, 0, 0, 255);
                        SetLedColor(i, 5, 90, 0, 255);
                        SetLedColor(i, 6, 165, 0, 255);
                        SetLedColor(i, 7, 255, 0, 255);
                        SetLedColor(i, 8, 255, 0, 165);
                        SetLedColor(i, 9,  255, 0, 90);
                        SetLedColor(i, 10, 255, 0, 0);
                        SetLedColor(i, 11, 255, 90, 0);
                        SetLedColor(i, 12, 255, 165, 0);
                        SetLedColor(i, 13, 255, 255, 0);
                        SetLedColor(i, 14, 165, 255, 0);
                        SetLedColor(i, 15, 90, 255, 0);
                        SetLedColor(i, 16, 0, 255, 0);
                        SetLedColor(i, 17, 0, 255, 90);
                        SetLedColor(i, 18, 0, 255, 165);
                        SetLedColor(i, 19, 0, 255, 255);
                        SetLedColor(i, 20, 0, 165, 255);
                        SetLedColor(i, 21, 0, 90, 255);
                    }
                    break;
                case 10:
                    for (int i = 0; i < 6; i++)
                    {

                        SetLedColor(i, 0, 0, 255, 255);
                        SetLedColor(i, 1, 0, 165, 255);
                        SetLedColor(i, 2, 0, 90, 255);
                        SetLedColor(i, 3, 0, 0, 255);
                        SetLedColor(i, 4, 90, 0, 255);
                        SetLedColor(i, 5, 165, 0, 255);
                        SetLedColor(i, 6, 255, 0, 255);
                        SetLedColor(i, 7, 255, 0, 165);
                        SetLedColor(i, 8, 255, 0, 90);
                        SetLedColor(i, 9, 255, 0, 0);
                        SetLedColor(i, 10, 255, 90, 0);
                        SetLedColor(i, 11, 255, 165, 0);
                        SetLedColor(i, 12, 255, 255, 0);
                        SetLedColor(i, 13, 165, 255, 0);
                        SetLedColor(i, 14, 90, 255, 0);
                        SetLedColor(i, 15, 0, 255, 0);
                        SetLedColor(i, 16, 0, 255, 90);
                        SetLedColor(i, 17, 0, 255, 165);
                        SetLedColor(i, 18, 0, 255, 255);
                        SetLedColor(i, 19, 0, 165, 255);
                        SetLedColor(i, 20, 0, 90, 255);
                        SetLedColor(i, 21, 0, 0, 255);
                    }
                    break;
                case 11:
                    for (int i = 0; i < 6; i++)
                    {

                        SetLedColor(i, 0, 0, 165, 255);
                        SetLedColor(i, 1, 0, 90, 255);
                        SetLedColor(i, 2, 0, 0, 255);
                        SetLedColor(i, 3, 90, 0, 255);
                        SetLedColor(i, 4, 165, 0, 255);
                        SetLedColor(i, 5, 255, 0, 255);
                        SetLedColor(i, 6, 255, 0, 165);
                        SetLedColor(i, 7, 255, 0, 90);
                        SetLedColor(i, 8, 255, 0, 0);
                        SetLedColor(i, 9, 255, 90, 0);
                        SetLedColor(i, 10, 255, 165, 0);
                        SetLedColor(i, 11, 255, 255, 0);
                        SetLedColor(i, 12, 165, 255, 0);
                        SetLedColor(i, 13, 90, 255, 0);
                        SetLedColor(i, 14, 0, 255, 0);
                        SetLedColor(i, 15, 0, 255, 90);
                        SetLedColor(i, 16, 0, 255, 165);
                        SetLedColor(i, 17, 0, 255, 255);
                        SetLedColor(i, 18, 0, 165, 255);
                        SetLedColor(i, 19, 0, 90, 255);
                        SetLedColor(i, 20, 0, 0, 255);
                        SetLedColor(i, 21, 90, 0, 255);
                    }
                    break;
                case 12:
                    for (int i = 0; i < 6; i++)
                    {
                        SetLedColor(i, 0, 0, 90, 255);
                        SetLedColor(i, 1, 0, 0, 255);
                        SetLedColor(i, 2, 90, 0, 255);
                        SetLedColor(i, 3, 165, 0, 255);
                        SetLedColor(i, 4, 255, 0, 255);
                        SetLedColor(i, 5, 255, 0, 165);
                        SetLedColor(i, 6, 255, 0, 90);
                        SetLedColor(i, 7, 255, 0, 0);
                        SetLedColor(i, 8, 255, 90, 0);
                        SetLedColor(i, 9,  255, 165, 0);
                        SetLedColor(i, 10, 255, 255, 0);
                        SetLedColor(i, 11, 165, 255, 0);
                        SetLedColor(i, 12, 90, 255, 0);
                        SetLedColor(i, 13, 0, 255, 0);
                        SetLedColor(i, 14, 0, 255, 90);
                        SetLedColor(i, 15, 0, 255, 165);
                        SetLedColor(i, 16, 0, 255, 255);
                        SetLedColor(i, 17, 0, 165, 255);
                        SetLedColor(i, 18, 0, 90, 255);
                        SetLedColor(i, 19, 0, 0, 255);
                        SetLedColor(i, 20, 90, 0, 255);
                        SetLedColor(i, 21, 165, 0, 255);
                    }
                    break;
                case 13:
                    for (int i = 0; i < 6; i++)
                    {
                        
                        SetLedColor(i, 0, 0, 0, 255);
                        SetLedColor(i, 1, 90, 0, 255);
                        SetLedColor(i, 2, 165, 0, 255);
                        SetLedColor(i, 3, 255, 0, 255);
                        SetLedColor(i, 4, 255, 0, 165);
                        SetLedColor(i, 5, 255, 0, 90);
                        SetLedColor(i, 6, 255, 0, 0);
                        SetLedColor(i, 7, 255, 90, 0);
                        SetLedColor(i, 8, 255, 165, 0);
                        SetLedColor(i, 9,  255, 255, 0);
                        SetLedColor(i, 10, 165, 255, 0);
                        SetLedColor(i, 11, 90, 255, 0);
                        SetLedColor(i, 12, 0, 255, 0);
                        SetLedColor(i, 13, 0, 255, 90);
                        SetLedColor(i, 14, 0, 255, 165);
                        SetLedColor(i, 15, 0, 255, 255);
                        SetLedColor(i, 16, 0, 165, 255);
                        SetLedColor(i, 17, 0, 90, 255);
                        SetLedColor(i, 18, 0, 0, 255);
                        SetLedColor(i, 19, 90, 0, 255);
                        SetLedColor(i, 20, 165, 0, 255);
                        SetLedColor(i, 21, 255, 0, 255);
                    }
                    break;
                case 14:
                    for (int i = 0; i < 6; i++)
                    {
                        
                        SetLedColor(i, 0, 90, 0, 255);
                        SetLedColor(i, 1, 165, 0, 255);
                        SetLedColor(i, 2, 255, 0, 255);
                        SetLedColor(i, 3, 255, 0, 165);
                        SetLedColor(i, 4, 255, 0, 90);
                        SetLedColor(i, 5, 255, 0, 0);
                        SetLedColor(i, 6, 255, 90, 0);
                        SetLedColor(i, 7, 255, 165, 0);
                        SetLedColor(i, 8, 255, 255, 0);
                        SetLedColor(i, 9,  165, 255, 0);
                        SetLedColor(i, 10, 90, 255, 0);
                        SetLedColor(i, 11, 0, 255, 0);
                        SetLedColor(i, 12, 0, 255, 90);
                        SetLedColor(i, 13, 0, 255, 165);
                        SetLedColor(i, 14, 0, 255, 255);
                        SetLedColor(i, 15, 0, 165, 255);
                        SetLedColor(i, 16, 0, 90, 255);
                        SetLedColor(i, 17, 0, 0, 255);
                        SetLedColor(i, 18, 90, 0, 255);
                        SetLedColor(i, 19, 165, 0, 255);
                        SetLedColor(i, 20, 255, 0, 255);
                        SetLedColor(i, 21, 255, 0, 165);
                    }
                    break;
                case 15:
                    for (int i = 0; i < 6; i++)
                    {
                        
                        SetLedColor(i, 0, 165, 0, 255);
                        SetLedColor(i, 1, 255, 0, 255);
                        SetLedColor(i, 2, 255, 0, 165);
                        SetLedColor(i, 3, 255, 0, 90);
                        SetLedColor(i, 4, 255, 0, 0);
                        SetLedColor(i, 5, 255, 90, 0);
                        SetLedColor(i, 6, 255, 165, 0);
                        SetLedColor(i, 7, 255, 255, 0);
                        SetLedColor(i, 8, 165, 255, 0);
                        SetLedColor(i, 9,  90, 255, 0);
                        SetLedColor(i, 10, 0, 255, 0);
                        SetLedColor(i, 11, 0, 255, 90);
                        SetLedColor(i, 12, 0, 255, 165);
                        SetLedColor(i, 13, 0, 255, 255);
                        SetLedColor(i, 14, 0, 165, 255);
                        SetLedColor(i, 15, 0, 90, 255);
                        SetLedColor(i, 16, 0, 0, 255);
                        SetLedColor(i, 17, 90, 0, 255);
                        SetLedColor(i, 18, 165, 0, 255);
                        SetLedColor(i, 19, 255, 0, 255);
                        SetLedColor(i, 20, 255, 0, 165);
                        SetLedColor(i, 21, 255, 0, 90);
                    }
                    break;
                case 16:
                    for (int i = 0; i < 6; i++)
                    {
                        
                        SetLedColor(i, 0, 255, 0, 255);
                        SetLedColor(i, 1, 255, 0, 165);
                        SetLedColor(i, 2, 255, 0, 90);
                        SetLedColor(i, 3, 255, 0, 0);
                        SetLedColor(i, 4, 255, 90, 0);
                        SetLedColor(i, 5, 255, 165, 0);
                        SetLedColor(i, 6, 255, 255, 0);
                        SetLedColor(i, 7, 165, 255, 0);
                        SetLedColor(i, 8, 90, 255, 0);
                        SetLedColor(i, 9,  0, 255, 0);
                        SetLedColor(i, 10, 0, 255, 90);
                        SetLedColor(i, 11, 0, 255, 165);
                        SetLedColor(i, 12, 0, 255, 255);
                        SetLedColor(i, 13, 0, 165, 255);
                        SetLedColor(i, 14, 0, 90, 255);
                        SetLedColor(i, 15, 0, 0, 255);
                        SetLedColor(i, 16, 90, 0, 255);
                        SetLedColor(i, 17, 165, 0, 255);
                        SetLedColor(i, 18, 255, 0, 255);
                        SetLedColor(i, 19, 255, 0, 165);
                        SetLedColor(i, 20, 255, 0, 90);
                        SetLedColor(i, 21, 255, 0, 0);
                    }
                    break;
                case 17:
                    for (int i = 0; i < 6; i++)
                    {
                        
                        SetLedColor(i, 0, 255, 0, 165);
                        SetLedColor(i, 1, 255, 0, 90);
                        SetLedColor(i, 2, 255, 0, 0);
                        SetLedColor(i, 3, 255, 90, 0);
                        SetLedColor(i, 4, 255, 165, 0);
                        SetLedColor(i, 5, 255, 255, 0);
                        SetLedColor(i, 6, 165, 255, 0);
                        SetLedColor(i, 7, 90, 255, 0);
                        SetLedColor(i, 8, 0, 255, 0);
                        SetLedColor(i, 9,  0, 255, 90);
                        SetLedColor(i, 10, 0, 255, 165);
                        SetLedColor(i, 11, 0, 255, 255);
                        SetLedColor(i, 12, 0, 165, 255);
                        SetLedColor(i, 13, 0, 90, 255);
                        SetLedColor(i, 14, 0, 0, 255);
                        SetLedColor(i, 15, 90, 0, 255);
                        SetLedColor(i, 16, 165, 0, 255);
                        SetLedColor(i, 17, 255, 0, 255);
                        SetLedColor(i, 18, 255, 0, 165);
                        SetLedColor(i, 19, 255, 0, 90);
                        SetLedColor(i, 20, 255, 0, 0);
                        SetLedColor(i, 21, 255, 90, 0);
                    }
                    break;
                case 18:
                    for (int i = 0; i < 6; i++)
                    {
                        
                        SetLedColor(i, 0, 255, 0, 90);
                        SetLedColor(i, 1, 255, 0, 0);
                        SetLedColor(i, 2, 255, 90, 0);
                        SetLedColor(i, 3, 255, 165, 0);
                        SetLedColor(i, 4, 255, 255, 0);
                        SetLedColor(i, 5, 165, 255, 0);
                        SetLedColor(i, 6, 90, 255, 0);
                        SetLedColor(i, 7, 0, 255, 0);
                        SetLedColor(i, 8, 0, 255, 90);
                        SetLedColor(i, 9,  0, 255, 165);
                        SetLedColor(i, 10, 0, 255, 255);
                        SetLedColor(i, 11, 0, 165, 255);
                        SetLedColor(i, 12, 0, 90, 255);
                        SetLedColor(i, 13, 0, 0, 255);
                        SetLedColor(i, 14, 90, 0, 255);
                        SetLedColor(i, 15, 165, 0, 255);
                        SetLedColor(i, 16, 255, 0, 255);
                        SetLedColor(i, 17, 255, 0, 165);
                        SetLedColor(i, 18, 255, 0, 90);
                        SetLedColor(i, 19, 255, 0, 0);
                        SetLedColor(i, 20, 255, 90, 0);
                        SetLedColor(i, 21, 255, 165, 0);
                    }
                    frame = 0;
                    break; 
            }
            frame++;

        }

        public Color background;
        public int[] Xpos = new int[6];

        public void setupTrails() {
            background = Color.FromArgb(0, 0, 0);
            if (Properties.Settings.Default.TRAIL_DIRECTION == true)
            {
                for (int i = 0; i < Xpos.Length; i++)
                {
                    Xpos[i] = random.Next(-26, 0);
                }
            }
            else {
                for (int i = 0; i < Xpos.Length; i++)
                {
                    Xpos[i] = random.Next(23, 50);
                }
            }
           
                trailOBJ = new trail[9];
                for (int i = 0; i < trailOBJ.Length; i++)
                {
                    trailOBJ[i] = new trail(Properties.Settings.Default.TRAIL_COLOR1, Properties.Settings.Default.TRAIL_COLOR2);
                }
            
            


            /*
            trailColor = new Color[9];

            

            int foregroundRed = color1.R;
            int foregroundGreen = color1.G;
            int foregroundBlue = color1.B;

            int backgroundRed = color2.R;
            int backgroundGreen = color2.G;
            int backgroundBlue = color2.B;

            trailColor[0] = Color.FromArgb(foregroundRed, foregroundGreen, foregroundBlue);

            for (int i = 1; i <= 8; i++) {
                int redAver = foregroundRed + (int)((backgroundRed - foregroundRed) * i / 8);
                int greenAver = foregroundGreen + (int)((backgroundGreen - foregroundGreen) * i / 8);
                int blueAver = foregroundBlue + (int)((backgroundBlue - foregroundBlue) * i / 8);
                trailColor[i] = Color.FromArgb(redAver, greenAver, blueAver);

            }


            for (int i = 0; i < trailColor.Length; i++) {
                Console.WriteLine("Color "+ i + ": " + trailColor[i].ToString());
            }
            */

        }
        Color[] trailColor;
        trail[] trailOBJ;


        public void trails() {

            
            for (int i = 0; i < Xpos.Length; i++)
            {
                //Prints out 
                SetLedColor(i, Xpos[i], trailOBJ[i].trailColor[0].R, trailOBJ[i].trailColor[0].G, trailOBJ[i].trailColor[0].B);
                SetLedColor(i, Xpos[i] - 1, trailOBJ[i].trailColor[1].R, trailOBJ[i].trailColor[1].G, trailOBJ[i].trailColor[1].B);
                SetLedColor(i, Xpos[i] - 2, trailOBJ[i].trailColor[2].R, trailOBJ[i].trailColor[2].G, trailOBJ[i].trailColor[2].B);
                SetLedColor(i, Xpos[i] - 3, trailOBJ[i].trailColor[3].R, trailOBJ[i].trailColor[3].G, trailOBJ[i].trailColor[3].B);
                SetLedColor(i, Xpos[i] - 4, trailOBJ[i].trailColor[4].R, trailOBJ[i].trailColor[4].G, trailOBJ[i].trailColor[4].B);
                SetLedColor(i, Xpos[i] - 5, trailOBJ[i].trailColor[5].R, trailOBJ[i].trailColor[5].G, trailOBJ[i].trailColor[5].B);
                SetLedColor(i, Xpos[i] - 6, trailOBJ[i].trailColor[6].R, trailOBJ[i].trailColor[6].G, trailOBJ[i].trailColor[6].B);
                SetLedColor(i, Xpos[i] - 7, trailOBJ[i].trailColor[7].R, trailOBJ[i].trailColor[7].G, trailOBJ[i].trailColor[7].B);
                SetLedColor(i, Xpos[i] - 8, trailOBJ[i].trailColor[8].R, trailOBJ[i].trailColor[8].G, trailOBJ[i].trailColor[8].B);
                Xpos[i]++;

                if (Xpos[i] == 30) {
                    Xpos[i] = random.Next(-26, 0);
                   
                }

            }


        }


        public void trailsReverse()
        {


            for (int i = 0; i < Xpos.Length; i++)
            {
                //Prints out 
                SetLedColor(i, Xpos[i], trailOBJ[i].trailColor[0].R, trailOBJ[i].trailColor[0].G, trailOBJ[i].trailColor[0].B);
                SetLedColor(i, Xpos[i] + 1, trailOBJ[i].trailColor[1].R, trailOBJ[i].trailColor[1].G, trailOBJ[i].trailColor[1].B);
                SetLedColor(i, Xpos[i] + 2, trailOBJ[i].trailColor[2].R, trailOBJ[i].trailColor[2].G, trailOBJ[i].trailColor[2].B);
                SetLedColor(i, Xpos[i] + 3, trailOBJ[i].trailColor[3].R, trailOBJ[i].trailColor[3].G, trailOBJ[i].trailColor[3].B);
                SetLedColor(i, Xpos[i] + 4, trailOBJ[i].trailColor[4].R, trailOBJ[i].trailColor[4].G, trailOBJ[i].trailColor[4].B);
                SetLedColor(i, Xpos[i] + 5, trailOBJ[i].trailColor[5].R, trailOBJ[i].trailColor[5].G, trailOBJ[i].trailColor[5].B);
                SetLedColor(i, Xpos[i] + 6, trailOBJ[i].trailColor[6].R, trailOBJ[i].trailColor[6].G, trailOBJ[i].trailColor[6].B);
                SetLedColor(i, Xpos[i] + 7, trailOBJ[i].trailColor[7].R, trailOBJ[i].trailColor[7].G, trailOBJ[i].trailColor[7].B);
                SetLedColor(i, Xpos[i] + 8, trailOBJ[i].trailColor[8].R, trailOBJ[i].trailColor[8].G, trailOBJ[i].trailColor[8].B);
                Xpos[i]--;

                if (Xpos[i] == -8)
                {
                    Xpos[i] = random.Next(23, 50);

                }

            }


        }


        public void rain()
        {





        }



    }
}
