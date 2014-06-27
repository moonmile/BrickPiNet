using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonmile.BrickPiNet;

namespace Sample
{
    class simplebot_psp
    {
        BPiMotor motor1, motor2;
        BPiSensor jb;
        int speed = 0;

        public void main()
        {
            this.speed = 200;
            BPi.Setup();
            BPi.AutoUpdate = true;
            this.motor1 = new BPiMotor() { Port = BrickPi.PORT_B, Enabled = true };
            this.motor2 = new BPiMotor() { Port = BrickPi.PORT_C, Enabled = true };
            this.jb = new BPiSensor() { 
                Port = BrickPi.PORT_1, SensorType = BrickPi.TYPE_SENSOR_I2C };

            BPi.Timeout = 3000;
            this.Go();
        }

        void move_bot(int sp1, int sp2)
        {
            this.motor1.Speed = sp1;
            this.motor2.Speed = sp2;
        }
        void Go()
        {
            while (true)
            {
                // Get data of joystick button's
                jb.Update();
                if (jb.JoyStick.Cross == true) // stop
                    break;
                int sp1 = jb.JoyStick.LeftJoyX + jb.JoyStick.LeftJoyY;
                int sp2 = jb.JoyStick.RightJoyX + jb.JoyStick.RightJoyY;
                // move robot 
                move_bot(sp1 * 2, sp2 * 2);
            }
        }
    }
}
