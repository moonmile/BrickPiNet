using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrickPiNet;
namespace Sample
{
    class sample
    {
        int motor1 = BrickPi.PORT_B;
        int motor2 = BrickPi.PORT_C;
        int speed = 200;

        // Move Foward
        void fwd()
        {
            BrickPi.SetMotorSpeed(motor1, speed);
            BrickPi.SetMotorSpeed(motor2, speed);
        }
        // Move Left
        void left()
        {
            BrickPi.SetMotorSpeed(motor1, speed);
            BrickPi.SetMotorSpeed(motor2, -speed);
        }
        // Move Right
        void right()
        {
            BrickPi.SetMotorSpeed(motor1, -speed);
            BrickPi.SetMotorSpeed(motor2, speed);
        }
        // Move Backword
        void back()
        {
            BrickPi.SetMotorSpeed(motor1, -speed);
            BrickPi.SetMotorSpeed(motor2, -speed);
        }
        // Stop
        void stop()
        {
            BrickPi.SetMotorSpeed(motor1, 0);
            BrickPi.SetMotorSpeed(motor2, 0);
        }

        void main()
        {
            int res;

            res = BrickPi.Setup();
            Console.WriteLine("BrickPiSetup: {0}", res);
            if (res != 0) return;

            this.motor1 = BrickPi.PORT_B;
            this.motor2 = BrickPi.PORT_C;
            BrickPi.SetMotorEnable(motor1, true);
            BrickPi.SetMotorEnable(motor2, true);
            res = BrickPi.SetupSensors();
            Console.WriteLine("BrickPiSetupSensors: {0}", res);
            BrickPi.SetTimeout(3000);
            BrickPi.InitTimeout();
            if ( res == 0)
            {
                bool loop = true;
                while( loop )
                {
                    var key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.W:
                            fwd(); break;
                        case ConsoleKey.A:
                            left(); break;
                        case ConsoleKey.D:
                            right(); break;
                        case ConsoleKey.S:
                            back(); break;
                        case ConsoleKey.X:
                            stop(); break;
                        case ConsoleKey.Q:
                            loop = false;
                            break;
                    }
                    BrickPi.UpdateValues();
                    System.Threading.Thread.Sleep(10);
                }
            }
        }

        static void Main(string[] args)
        {
            var pro = new sample();
            pro.main();
        }
    }
}
