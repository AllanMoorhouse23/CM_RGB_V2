using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CM_RGB
{
    class Effects_Set_1
    {


        public Effects_Set_1()
        {


        }

        Random random = new Random();

        public int pos_x = 0;
        public int pos_y = 0;
        private int randomChance = 0;
        public byte red = 255;
        public byte green = 0;
        public byte blue = 0;
        public int counter = 0;
        private string colorTo = "yellow";
        private int randomPos = 0;
        private bool checkCon = false;
        private int[] chosenOrder = new int[3] { -1, -1, -1 };

        [DllImport("SDKDLL.dll")]
        public static extern void SetLedColor(int row, int col, byte r, byte g, byte b);

        [DllImport("SDKDLL.dll")]
        public static extern void SetFullLedColor(byte r, byte g, byte b);



        public bool useColor1 = true;
        /// <summary>
        /// Line By Line Effect
        /// </summary>
        public void LineByLine(bool direction, bool colorMode, Color color1, Color color2 )
        {
            //Normal direction
            if (direction == true)
            {
                if (pos_x > 21)
                {
                    pos_x = 0;
                    pos_y++;
                }
                else if (pos_y > 5)
                {
                    pos_y = 0;
                    pos_x = 0;
                }

                if (colorMode == true)
                {
                    SetLedColor(pos_y, pos_x, red, green, blue);
                }
                else {
                    if (useColor1 == true)
                    {
                        SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                    }
                    else {
                        SetLedColor(pos_y, pos_x, color2.R, color2.G, color2.B);  
                    }
                }

                pos_x++;

                if (pos_x == 21 && pos_y == 5)
                {
                    if (colorMode == true)
                    {
                        randomColor();
                    }
                    else {

                        if (useColor1 == true)
                        {
                            useColor1 = false;
                        }
                        else {
                            useColor1 = true;
                        }
                    }
                }

            }
            else {
                if (colorMode == true)
                {
                    SetLedColor(pos_y, pos_x, red, green, blue);
                }
                else
                {
                    if (useColor1 == true)
                    {
                        SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                    }
                    else
                    {
                        SetLedColor(pos_y, pos_x, color2.R, color2.G, color2.B);
                    }
                }
                
                //Reverse direction
                if (pos_x < 0)
                {
                    pos_x = 22;
                    pos_y--;
                }
                else if (pos_y < 0)
                {
                    pos_y = 5;
                    pos_x = 22;
                    if (colorMode == true)
                    {
                        randomColor();
                    }
                    else
                    {

                        if (useColor1 == true)
                        {
                            useColor1 = false;
                        }
                        else
                        {
                            useColor1 = true;
                        }
                    }
                    
                }

                
                pos_x--;
                
            }
        }


        /// <summary>
        /// Breathing Red Effect
        /// </summary>
        public void effectBreathing()
        {
            if (counter == 0)
            {
                red--;
            }
            else if (counter == 1)
            {
                red++;
            }
            if (red >= 255)
            {
                counter = 0;
            }
            else if (red <= 0)
            {
                counter = 1;
            }
            SetFullLedColor(red, green, blue);
        }


        /// <summary>
        /// Random Key Random Color Effect
        /// </summary>
        public void effectRandom()
        {
            pos_x = random.Next(0, 22);
            pos_y = random.Next(0, 6);
            randomColor();
            SetLedColor(pos_y, pos_x, red, green, blue);
        }


        /// <summary>
        /// Random Squares Effect
        /// </summary>
        public void effectRandomSquares()
        {

            pos_x = random.Next(0, 22);
            pos_y = random.Next(0, 6);

            //Center LED
            SetLedColor(pos_y, pos_x, red, green, blue);

            //Right
            SetLedColor(pos_y, (pos_x + 1), red, green, blue);
            //Left	
            SetLedColor(pos_y, (pos_x - 1), red, green, blue);
            //Up
            SetLedColor((pos_y - 1), pos_x, red, green, blue);
            //Down
            SetLedColor((pos_y + 1), pos_x, red, green, blue);

            //Top Left
            SetLedColor((pos_y - 1), (pos_x - 1), red, green, blue);
            //Top Right
            SetLedColor((pos_y - 1), (pos_x + 1), red, green, blue);
            //Bottom Left
            SetLedColor((pos_y + 1), (pos_x - 1), red, green, blue);
            //Bottom Right
            SetLedColor((pos_y + 1), (pos_x + 1), red, green, blue);

            randomColor();
        }


        /// <summary>
        /// Wipe Effect
        /// </summary>
        public void effectWipe(bool direction, bool colorMode, Color color1, Color color2)
        {
            if (direction == true)
            {
                for (int i = 0; i != 6; i++)
                {

                    if (colorMode == true)
                    {
                        SetLedColor(i, pos_x, red, green, blue);
                    }
                    else
                    {
                        if (useColor1 == true)
                        {
                            SetLedColor(i, pos_x, color1.R, color1.G, color1.B);
                        }
                        else
                        {
                            SetLedColor(i, pos_x, color2.R, color2.G, color2.B);
                        }
                    }
                }
                pos_x++;
                if (pos_x > 22)
                {
                    if (colorMode == true)
                    {
                        randomColor();
                    }
                    else
                    {

                        if (useColor1 == true)
                        {
                            useColor1 = false;
                        }
                        else
                        {
                            useColor1 = true;
                        }
                    }
                }
                if (pos_x > 22)
                {
                    pos_x = 0;
                }
            }
            else {
                for (int i = 0; i != 6; i++)
                {

                    if (colorMode == true)
                    {
                        SetLedColor(i, pos_x, red, green, blue);
                    }
                    else
                    {
                        if (useColor1 == true)
                        {
                            SetLedColor(i, pos_x, color1.R, color1.G, color1.B);
                        }
                        else
                        {
                            SetLedColor(i, pos_x, color2.R, color2.G, color2.B);
                        }
                    }
                }
                pos_x--;
                if (pos_x < 0)
                {
                    if (colorMode == true)
                    {
                        randomColor();
                    }
                    else
                    {

                        if (useColor1 == true)
                        {
                            useColor1 = false;
                        }
                        else
                        {
                            useColor1 = true;
                        }
                    }
                }
                if (pos_x < 0)
                {
                    pos_x = 22;
                }
            }
        }


        /// <summary>
        /// Random Lines Effects
        /// </summary>
        public void effectRandomLines(bool colorMode, Color color1, Color color2)
        {
            if (colorMode == true)
            {
                SetLedColor(pos_y, pos_x, red, green, blue);
            }
            else
            {
                SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
            }
            //Move in current direction
            switch (counter)
            {
                case 0:
                    pos_x++;
                    break;
                case 1:
                    pos_y++;
                    break;
                case 2:
                    pos_x--;
                    break;
                case 3:
                    pos_y--;
                    break;
            }
           
            if (colorMode == true)
            {
                SetLedColor(pos_y, pos_x, red, green, blue);
            }
            else
            {
                SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
            }
            //As line is moving along select randomly to change direction
            //Biased towards going in the same direction
            randomChance = random.Next(0, 20);
            switch (randomChance)
            {
                case 0:
                    counter = 0;
                    break;
                case 1:
                    counter = 1;
                    break;
                case 2:
                    counter = 2;
                    break;
                case 3:
                    counter = 3;
                    break;
            }
            //If the line goes out of bounds turn off all keys
            if (pos_x > 21 || pos_x < 0 || pos_y < 0 || pos_y > 5)
            {
                
                if (colorMode == true)
                {
                    SetFullLedColor(255, 255, 255);
                }
                else
                {
                    SetFullLedColor(color2.R, color2.G, color2.B);
                }
                //Set new random location on edge of keyboard
                randomChance = random.Next(0, 4);
                if (randomChance == 0)
                {
                    //Top
                    pos_x = random.Next(0, 22);
                    pos_y = 0;
                }
                else if (randomChance == 1)
                {
                    //Bottom
                    pos_x = random.Next(0, 22);
                    pos_y = 5;
                }
                else if (randomChance == 2)
                {
                    //Left
                    pos_x = 0;
                    pos_y = random.Next(0, 6);
                }
                else
                {
                    //Right
                    pos_x = 21;
                    pos_y = random.Next(0, 6);
                }
                if (colorMode == true)
                {
                    randomColor();
                }
                
            }
        }


        /// <summary>
        /// Snake Line By Line Effect
        /// </summary>
        public void effectSnakeLineByLine(bool direction, bool colorMode, Color color1, Color color2)
        {
            if (direction == true)
            {
               
                if (colorMode == true)
                {
                    SetLedColor(pos_y, pos_x, red, green, blue);
                }
                else
                {
                    if (useColor1 == true)
                    {
                        SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                    }
                    else
                    {
                        SetLedColor(pos_y, pos_x, color2.R, color2.G, color2.B);
                    }
                }
                switch (counter)
                {
                    case 0:
                        pos_x++;
                        break;
                    case 1:
                        pos_x--;
                        break;
                }
                switch (pos_x)
                {
                    case 21:
                        if (colorMode == true)
                        {
                            SetLedColor(pos_y, pos_x, red, green, blue);
                        }
                        else
                        {
                            if (useColor1 == true)
                            {
                                SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                            }
                            else
                            {
                                SetLedColor(pos_y, pos_x, color2.R, color2.G, color2.B);
                            }
                        }
                        pos_y++;
                        if (colorMode == true)
                        {
                            SetLedColor(pos_y, pos_x, red, green, blue);
                        }
                        else
                        {
                            if (useColor1 == true)
                            {
                                SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                            }
                            else
                            {
                                SetLedColor(pos_y, pos_x, color2.R, color2.G, color2.B);
                            }
                        }
                        counter = 1;
                        break;
                    case 0:
                        if (colorMode == true)
                        {
                            SetLedColor(pos_y, pos_x, red, green, blue);
                        }
                        else
                        {
                            if (useColor1 == true)
                            {
                                SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                            }
                            else
                            {
                                SetLedColor(pos_y, pos_x, color2.R, color2.G, color2.B);
                            }
                        }
                        pos_y++;
                        if (colorMode == true)
                        {
                            SetLedColor(pos_y, pos_x, red, green, blue);
                        }
                        else
                        {
                            if (useColor1 == true)
                            {
                                SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                            }
                            else
                            {
                                SetLedColor(pos_y, pos_x, color2.R, color2.G, color2.B);
                            }
                        }
                        counter = 0;
                        break;
                }
                if (pos_y > 5)
                {
                    pos_x = 0;
                    pos_y = 0;
                    counter = 0;
                    if (colorMode == true)
                    {
                        randomColor();
                    }
                    else
                    {

                        if (useColor1 == true)
                        {
                            useColor1 = false;
                        }
                        else
                        {
                            useColor1 = true;
                        }
                    }
                }
            }
            else {

            }
        }


        /// <summary>
        /// Spiral Effect
        /// </summary>
        public void effectSpiral(bool direction, bool colorMode, Color color1, Color color2)
        {
            if (direction == true)
            {

                //SetLedColor(pos_y, pos_x, red, green, blue);
                if (colorMode == true)
                {
                    SetLedColor(pos_y, pos_x, red, green, blue);
                }
                else
                {
                    if (useColor1 == true)
                    {
                        SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                    }
                    else
                    {
                        SetLedColor(pos_y, pos_x, color2.R, color2.G, color2.B);
                    }
                }
                //Move in current direction
                switch (counter)
                {
                    case 0:
                        pos_x++;
                        break;
                    case 1:
                        pos_y++;
                        break;
                    case 2:
                        pos_x--;
                        break;
                    case 3:
                        pos_y--;
                        break;
                }



                //Change direction at certain points
                if (pos_x == 21 && pos_y == 0)
                {
                    //Downwards
                    counter = 1;

                }
                else if (pos_x == 21 && pos_y == 5)
                {
                    //Left
                    counter = 2;

                }
                else if (pos_x == 0 && pos_y == 5)
                {
                    //Upwards
                    counter = 3;

                }
                else if (pos_x == 0 && pos_y == 1)
                {
                    //Right
                    counter = 0;

                }
                else if (pos_x == 20 && pos_y == 1)
                {
                    //Downward
                    counter = 1;

                }
                else if (pos_x == 20 && pos_y == 4)
                {
                    //Left
                    counter = 2;

                }
                else if (pos_x == 1 && pos_y == 4)
                {
                    //Upwards
                    counter = 3;

                }
                else if (pos_x == 1 && pos_y == 2)
                {
                    //Right
                    counter = 0;

                }
                else if (pos_x == 19 && pos_y == 2)
                {
                    //Downward
                    counter = 1;

                }
                else if (pos_x == 19 && pos_y == 3)
                {
                    //Left
                    counter = 2;

                }
                else if (pos_x == 2 && pos_y == 3)
                {
                   
                    if (colorMode == true)
                    {
                        SetLedColor(pos_y, pos_x, red, green, blue);
                    }
                    else
                    {
                        if (useColor1 == true)
                        {
                            SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                        }
                        else
                        {
                            SetLedColor(pos_y, pos_x, color2.R, color2.G, color2.B);
                        }
                    }
                    //Reset to start pos
                    counter = 0;
                    pos_x = 0;
                    pos_y = 0;
                    if (colorMode == true)
                    {
                        randomColor();
                    }
                    else
                    {

                        if (useColor1 == true)
                        {
                            useColor1 = false;
                        }
                        else
                        {
                            useColor1 = true;
                        }
                    }
                }
            }
            else {
                //REVERSE DIRECTION
                if (colorMode == true)
                {
                    SetLedColor(pos_y, pos_x, red, green, blue);
                }
                else
                {
                    if (useColor1 == true)
                    {
                        SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                    }
                    else
                    {
                        SetLedColor(pos_y, pos_x, color2.R, color2.G, color2.B);
                    }
                }
                //Move in current direction
                switch (counter)
                {
                    case 0:
                        pos_x++;
                        break;
                    case 1:
                        pos_y++;
                        break;
                    case 2:
                        pos_x--;
                        break;
                    case 3:
                        pos_y--;
                        break;
                }



                //Change direction at certain points
                if (pos_x == 21 && pos_y == 0)
                {
                    //Left
                    counter = 2;

                }
                else if (pos_x == 21 && pos_y == 5)
                {
                    //Up
                    counter = 3;

                }
                else if (pos_x == 0 && pos_y == 5)
                {
                    //Right
                    counter = 0;

                }
                else if (pos_x == 0 && pos_y == 1)
                {
                    //Down
                    counter = 1;

                }
                else if (pos_x == 20 && pos_y == 1)
                {
                    //Left
                    counter = 2;

                }
                else if (pos_x == 20 && pos_y == 4)
                {
                    //Up
                    counter = 3;

                }
                else if (pos_x == 1 && pos_y == 4)
                {
                    //Right
                    counter = 0;

                }
                else if (pos_x == 1 && pos_y == 2)
                {
                    //Down
                    counter = 1;

                }
                else if (pos_x == 19 && pos_y == 2)
                {
                    //Left
                    counter = 2;

                }
                else if (pos_x == 19 && pos_y == 3)
                {
                    //Up
                    counter = 3;

                }
                else if (pos_x == 0 && pos_y == 0)
                {
                    if (colorMode == true)
                    {
                        SetLedColor(pos_y, pos_x, red, green, blue);
                    }
                    else
                    {
                        if (useColor1 == true)
                        {
                            SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                        }
                        else
                        {
                            SetLedColor(pos_y, pos_x, color2.R, color2.G, color2.B);
                        }
                    }
                    //Reset to start pos
                    counter = 0;
                    pos_x = 2;
                    pos_y = 3;
                    if (colorMode == true)
                    {
                        randomColor();
                    }
                    else
                    {

                        if (useColor1 == true)
                        {
                            useColor1 = false;
                        }
                        else
                        {
                            useColor1 = true;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void effectRandomSelectedLine(bool colorMode, Color color1, Color color2)
        {

            if (colorMode == true)
            {
                SetLedColor(pos_y, pos_x, red, green, blue);
            }
            else
            {
                SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
            }

            //Move in current direction
            switch (counter)
            {
                case 0:
                    pos_x++;
                    break;
                case 1:
                    pos_y++;
                    break;
                case 2:
                    pos_x--;
                    break;
                case 3:
                    pos_y--;
                    break;
            }

            if (colorMode == true)
            {
                SetLedColor(pos_y, pos_x, red, green, blue);
            }
            else
            {
                SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
            }

            //If the line goes out of bounds turn off all keys
            if (pos_x > 21 || pos_x < 0 || pos_y < 0 || pos_y > 5)
            {
                if (colorMode == true)
                {
                    SetFullLedColor(255, 255, 255);
                }
                else
                {
                    SetFullLedColor(color2.R, color2.G, color2.B);
                }

                //Set new random location on edge of keyboard
                randomChance = random.Next(0, 4);

                if (randomChance == 0)
                {
                    //Top
                    pos_x = random.Next(0, 22);
                    pos_y = 0;
                    counter = 1;
                }
                else if (randomChance == 1)
                {
                    //Bottom
                    pos_x = random.Next(0, 22);
                    pos_y = 5;
                    counter = 3;
                }
                else if (randomChance == 2)
                {
                    //Left
                    pos_x = 0;
                    pos_y = random.Next(0, 6);
                    counter = 0;
                }
                else
                {
                    //Right
                    pos_x = 21;
                    pos_y = random.Next(0, 6);
                    counter = 2;
                }
                if (colorMode == true)
                {
                    randomColor();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void effectAltLines(bool colorMode, Color color1, Color color2)
        {

            if (counter == 0)
            {
                
                if (colorMode == true)
                {
                    SetLedColor(0, pos_x, red, green, blue);
                    SetLedColor(1, 22 - pos_x, red, green, blue);
                    SetLedColor(2, pos_x, red, green, blue);
                    SetLedColor(3, 22 - pos_x, red, green, blue);
                    SetLedColor(4, pos_x, red, green, blue);
                    SetLedColor(5, 22 - pos_x, red, green, blue);
                    pos_x++;
                }
                else
                {
                    if (useColor1 == true)
                    {
                        SetLedColor(0, pos_x, color1.R, color1.G, color1.B);
                        SetLedColor(1, 22 - pos_x, color1.R, color1.G, color1.B);
                        SetLedColor(2, pos_x, color1.R, color1.G, blue);
                        SetLedColor(3, 22 - pos_x, color1.R, color1.G, color1.B);
                        SetLedColor(4, pos_x, color1.R, color1.G, blue);
                        SetLedColor(5, 22 - pos_x, color1.R, color1.G, color1.B);
                        pos_x++;
                    }
                    else
                    {
                        SetLedColor(0, pos_x, color2.R, color2.G, color2.B);
                        SetLedColor(1, 22 - pos_x, color2.R, color2.G, color2.B);
                        SetLedColor(2, pos_x, color2.R, color2.G, color2.B);
                        SetLedColor(3, 22 - pos_x, color2.R, color2.G, color2.B);
                        SetLedColor(4, pos_x, color2.R, color2.G, color2.B);
                        SetLedColor(5, 22 - pos_x, color2.R, color2.G, color2.B);
                        pos_x++;
                    }
                }
            }
            else
            {

               

                if (colorMode == true)
                {
                    SetLedColor(0, 22 - pos_x, red, green, blue);
                    SetLedColor(1, pos_x, red, green, blue);
                    SetLedColor(2, 22 - pos_x, red, green, blue);
                    SetLedColor(3, pos_x, red, green, blue);
                    SetLedColor(4, 22 - pos_x, red, green, blue);
                    SetLedColor(5, pos_x, red, green, blue);
                    pos_x++;
                }
                else
                {
                    if (useColor1 == true)
                    {
                        SetLedColor(0, 22 - pos_x, color1.R, color1.G, color1.B);
                        SetLedColor(1, pos_x, color1.R, color1.G, color1.B);
                        SetLedColor(2, 22 - pos_x, color1.R, color1.G, color1.B);
                        SetLedColor(3, pos_x, color1.R, color1.G, color1.B);
                        SetLedColor(4, 22 - pos_x, color1.R, color1.G, color1.B);
                        SetLedColor(5, pos_x, color1.R, color1.G, color1.B);
                        pos_x++;
                    }
                    else
                    {
                        SetLedColor(0, 22 - pos_x, color2.R, color2.G, color2.B);
                        SetLedColor(1, pos_x, color2.R, color2.G, color2.B);
                        SetLedColor(2, 22 - pos_x, color2.R, color2.G, color2.B);
                        SetLedColor(3, pos_x, color2.R, color2.G, color2.B);
                        SetLedColor(4, 22 - pos_x, color2.R, color2.G, color2.B);
                        SetLedColor(5, pos_x, color2.R, color2.G, color2.B);
                        pos_x++;
                    }
                }


            }
            if (pos_x == 23)
            {
                if (counter == 1)
                {
                    counter = 0;
                }
                else
                {
                    counter = 1;
                }
                pos_x = 0;
                if (colorMode == true)
                {
                    randomColor();
                }
                else
                {

                    if (useColor1 == true)
                    {
                        useColor1 = false;
                    }
                    else
                    {
                        useColor1 = true;
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void effectBall(bool colorMode, Color color1, Color color2)
        {
            //Hit the top
            if (counter == 0 && pos_y == 0)
            {
                counter = 3;
                if (colorMode == true)
                {
                    randomColor();
                }
            }
            if (counter == 1 && pos_y == 0)
            {
                counter = 2;
                if (colorMode == true)
                {
                    randomColor();
                }
            }
            //Hit the left
            if (counter == 3 && pos_x == 0)
            {
                counter = 2;
                if (colorMode == true)
                {
                    randomColor();
                }
            }
            if (counter == 0 && pos_x == 0)
            {
                counter = 1;
                if (colorMode == true)
                {
                    randomColor();
                }
            }
            //Hit the bottom
            if (counter == 2 && pos_y == 5)
            {
                counter = 1;
                if (colorMode == true)
                {
                    randomColor();
                }
            }
            if (counter == 3 && pos_y == 5)
            {
                counter = 0;
                if (colorMode == true)
                {
                    randomColor();
                }
            }
            //Hit the right
            if (counter == 2 && pos_x == 21)
            {
                counter = 3;
                if (colorMode == true)
                {
                    randomColor();
                }
            }
            if (counter == 1 && pos_x == 21)
            {
                counter = 0;
                if (colorMode == true)
                {
                    randomColor();
                }
            }

            if (colorMode == true)
            {
                //Turn off trail
                SetLedColor(pos_y - 1, pos_x - 1, 100, 100, 100);
                SetLedColor(pos_y - 1, pos_x, 100, 100, 100);
                SetLedColor(pos_y - 1, pos_x + 1, 100, 100, 100);
                SetLedColor(pos_y, pos_x - 1, 100, 100, 100);
                SetLedColor(pos_y, pos_x + 1, 100, 100, 100);
                SetLedColor(pos_y + 1, pos_x - 1, 100, 100, 100);
                SetLedColor(pos_y + 1, pos_x, 100, 100, 100);
                SetLedColor(pos_y + 1, pos_x + 1, 100, 100, 100);
            }
            else
            {
                //Turn off trail
                SetLedColor(pos_y - 1, pos_x - 1, color2.R, color2.G, color2.B);
                SetLedColor(pos_y - 1, pos_x, color2.R, color2.G, color2.B);
                SetLedColor(pos_y - 1, pos_x + 1, color2.R, color2.G, color2.B);
                SetLedColor(pos_y, pos_x - 1, color2.R, color2.G, color2.B);
                SetLedColor(pos_y, pos_x + 1, color2.R, color2.G, color2.B);
                SetLedColor(pos_y + 1, pos_x - 1, color2.R, color2.G, color2.B);
                SetLedColor(pos_y + 1, pos_x, color2.R, color2.G, color2.B);
                SetLedColor(pos_y + 1, pos_x + 1, color2.R, color2.G, color2.B);
            }

            
            switch (counter)
            {
                case 0:
                    if (colorMode == true)
                    {
                        SetLedColor(pos_y, pos_x, red, green, blue);
                    }
                    else {
                        SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                    }
                    //Shift Up and to the Left
                    pos_x--;
                    pos_y--;
                    break;
                case 1:
                    if (colorMode == true)
                    {
                        SetLedColor(pos_y, pos_x, red, green, blue);
                    }
                    else
                    {
                        SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                    }
                    //Shift Up and to the Right
                    pos_x++;
                    pos_y--;
                    break;
                case 2:
                    if (colorMode == true)
                    {
                        SetLedColor(pos_y, pos_x, red, green, blue);
                    }
                    else
                    {
                        SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                    }
                    //Shift Down and to the Right
                    pos_x++;
                    pos_y++;
                    break;
                case 3:
                    if (colorMode == true)
                    {
                        SetLedColor(pos_y, pos_x, red, green, blue);
                    }
                    else
                    {
                        SetLedColor(pos_y, pos_x, color1.R, color1.G, color1.B);
                    }
                    //Shift Down and to the Left
                    pos_x--;
                    pos_y++;
                    break;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        public void effectColorCycle()
        {

            if (colorTo == "yellow")
            {
                green += 5;
            }
            else if (colorTo == "green")
            {
                red -= 5;
            }
            else if (colorTo == "aqua")
            {
                blue += 5;
            }
            else if (colorTo == "blue")
            {
                green -= 5;
            }
            else if (colorTo == "pink")
            {
                red += 5;
            }
            else if (colorTo == "red")
            {
                blue -= 5;
            }

            SetFullLedColor(red, green, blue);

            if (red == 255 && green == 0 && blue == 255)
            {
                colorTo = "red";
            }
            else if (red == 255 && green == 0 && blue == 0)
            {
                colorTo = "yellow";
            }
            else if (red == 255 && green == 255 && blue == 0)
            {
                colorTo = "green";
            }
            else if (red == 0 && green == 255 && blue == 0)
            {
                colorTo = "aqua";
            }
            else if (red == 0 && green == 255 && blue == 255)
            {
                colorTo = "blue";
            }
            else if (red == 0 && green == 0 && blue == 255)
            {
                colorTo = "pink";
            }

        }

        private void randomColor()
        {

            chosenOrder[0] = -1;
            chosenOrder[1] = -1;
            chosenOrder[2] = -1;

            randomPos = random.Next(0, 3);
            chosenOrder[randomPos] = 255;
            checkCon = false;

            while (checkCon == false)
            {
                randomPos = random.Next(0, 3);
                if (chosenOrder[randomPos] == -1)
                {
                    chosenOrder[randomPos] = 0;
                    checkCon = true;
                }
            }

            checkCon = false;

            while (checkCon == false)
            {
                randomPos = random.Next(0, 3);
                if (chosenOrder[randomPos] == -1)
                {
                    chosenOrder[randomPos] = random.Next(0, 256);
                    checkCon = true;
                }
            }

            red = Convert.ToByte(chosenOrder[0]);
            green = Convert.ToByte(chosenOrder[1]);
            blue = Convert.ToByte(chosenOrder[2]);



        }


    }
}
