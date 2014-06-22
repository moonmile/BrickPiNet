using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrickPiNet;

namespace Sample
{
    class Program2
    {
        void main()
        {
            int speed = 200;
            var bpi = new BPi();
            // initialize 
            bpi.Setup();
            bpi.AutoUpdate = true;
            var motor1 = new BPiMotor() { Port = BrickPi.PORT_B, Enabled = true };
            var motor2 = new BPiMotor() { Port = BrickPi.PORT_C, Enabled = true };
            bpi.Motors.Add(motor1);
            bpi.Motors.Add(motor2);
            bpi.Timeout = 3000;

            Console.WriteLine("start");
            bool loop = true;
            while (loop)
            {
                var k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.W:
                        motor1.Speed = speed;
                        motor2.Speed = speed;
                        break;
                    case ConsoleKey.A:
                        motor1.Speed = speed;
                        motor2.Speed = -speed;
                        break;
                    case ConsoleKey.D:
                        motor1.Speed = -speed;
                        motor2.Speed = speed;
                        break;
                    case ConsoleKey.S:
                        motor1.Speed = -speed;
                        motor2.Speed = -speed;
                        break;
                    case ConsoleKey.X:
                        motor1.Speed = 0;
                        motor2.Speed = 0;
                        break;
                    case ConsoleKey.Q:
                        loop = false;
                        break;
                }
                // bpi.Update();
            }
        }
        static void Main(string[] args)
        {
            var pro = new Program2();
            pro.main();
        }
    }
}
