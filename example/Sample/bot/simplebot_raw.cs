﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moonmile.BrickPiNet;
namespace Sample
{
    class Program
    {
        int arm1 = BrickPi.PORT_A;
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
        /*
        void armUp()
        {
            BrickPi.SetMotorSpeed(arm1, 100);
        }
        void armDown()
        {
            BrickPi.SetMotorSpeed(arm1, -100);
        }
        */
        public void main()
        {
            int res;

            res = BrickPi.Setup();
            Console.WriteLine("BrickPiSetup: {0}", res);
            if (res != 0) return;

            this.arm1 = BrickPi.PORT_A;
            this.motor1 = BrickPi.PORT_B;
            this.motor2 = BrickPi.PORT_C;
            BrickPi.SetMotorEnable(arm1, true);
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
                        //case ConsoleKey.F:
                        //    armUp(); break;
                        //case ConsoleKey.G:
                        //    armDown(); break;

                    }
                    BrickPi.UpdateValues();
                    System.Threading.Thread.Sleep(10);
                }
            }
        }
    }
}
