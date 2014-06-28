using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonmile.BrickPiNet;

namespace Sample.ev3
{
    class ev3_gyrosensor
    {
        BPiGyro gyro;
        public void main()
        {
            BPi.Setup();
            this.gyro = new BPiGyro() { Port = BrickPi.PORT_4 };
            while (true)
            {
                int val = this.gyro.RowValue;
                Console.WriteLine("Result: {0} {1}",
                    0xFFFF & val,
                    val >> 16
                    );
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
