using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonmile.BrickPiNet;

namespace Sample
{
    public class simplebot_simple
    {
        BPiMotor motor1, motor2;
        int speed = 0;

        void fwd()
        {
            motor1.Speed = speed;
            motor2.Speed = speed;
        }
        void back()
        {
            motor1.Speed = -speed;
            motor2.Speed = -speed;
        }
        void left()
        {
            motor1.Speed = speed;
            motor2.Speed = -speed;
        }
        void right()
        {
            motor1.Speed = -speed;
            motor2.Speed = speed;
        }
        void stop()
        {
            motor1.Speed = 0;
            motor2.Speed = 0;
        }

        void Go()
        {
            while (true)
            {
                var k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.W: fwd(); break;
                    case ConsoleKey.B: back(); break;
                    case ConsoleKey.R: right(); break;
                    case ConsoleKey.L: left(); break;
                    case ConsoleKey.X: stop(); break;
                    case ConsoleKey.Q: return;
                }
            }
        }

        public void main()
        {
            this.speed = 200;
            BPi.Setup();
            BPi.AutoUpdate = true;
            this.motor1 = new BPiMotor() { Port = BrickPi.PORT_B, Enabled = true };
            this.motor2 = new BPiMotor() { Port = BrickPi.PORT_C, Enabled = true };
            BPi.Timeout = 3000;

            Console.WriteLine("simplebot_simple start");
            this.Go();
        }
    }
}
