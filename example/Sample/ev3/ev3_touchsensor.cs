using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonmile.BrickPiNet;

namespace Sample
{
    public class ev3_touchsensor
    {
        BPiTouch touch;
        public void main()
        {
            BPi.Setup();
            this.touch = new BPiTouch() { Port = BrickPi.PORT_4 };
            while (true)
            {
                if (this.touch.IsTouched == true)
                {
                    Console.WriteLine("Touched!");
                }
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
