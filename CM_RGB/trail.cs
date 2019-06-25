using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_RGB
{
    class trail
    {
        public int x;
        public int y;
        public Color backgroundColor = new Color();
        public Color foregroundColor = new Color();
        public string direction;
        public Color[] trailColor;
        Random random = new Random();

        public trail(Color colorFore, Color colorBack) {
            foregroundColor = colorFore;
            backgroundColor = colorBack;
            interpolateColors();
        }

      


        private void interpolateColors() {
            trailColor = new Color[9];



            int foregroundRed = foregroundColor.R;
            int foregroundGreen = foregroundColor.G;
            int foregroundBlue = foregroundColor.B;

            int backgroundRed = backgroundColor.R;
            int backgroundGreen = backgroundColor.G;
            int backgroundBlue = backgroundColor.B;

            trailColor[0] = Color.FromArgb(foregroundRed, foregroundGreen, foregroundBlue);

            for (int i = 1; i <= 8; i++)
            {
                int redAver = foregroundRed + (int)((backgroundRed - foregroundRed) * i / 8);
                int greenAver = foregroundGreen + (int)((backgroundGreen - foregroundGreen) * i / 8);
                int blueAver = foregroundBlue + (int)((backgroundBlue - foregroundBlue) * i / 8);
                trailColor[i] = Color.FromArgb(redAver, greenAver, blueAver);

            }

            for (int i = 0; i < trailColor.Length; i++)
            {
                Console.WriteLine("Color " + i + ": " + trailColor[i].ToString());
            }

        }




    }
}
