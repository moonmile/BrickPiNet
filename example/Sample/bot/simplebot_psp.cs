using System;
using Moonmile.BrickPiNet;

namespace Sample
{
#if false
    class simplebot_psp
    {
        BPiMotor motor1, motor2;
        BPiJoystick jsk;

        public void main()
        {
            BPi.Setup();
            BPi.AutoUpdate = true;
            this.motor1 = new BPiMotor() { Port = BrickPi.PORT_B, Enabled = true };
            this.motor2 = new BPiMotor() { Port = BrickPi.PORT_C, Enabled = true };
            this.jsk = new BPiJoystick() {  Port = BrickPi.PORT_1 };

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
                jsk.Update();
                if (jsk.Buttons.Cross == true) // stop
                    break;
                int sp1 = jsk.Buttons.LeftJoyX + jsk.Buttons.LeftJoyY;
                int sp2 = jsk.Buttons.RightJoyX + jsk.Buttons.RightJoyY;
                // move robot 
                move_bot(sp1 * 2, sp2 * 2);
            }
        }
    }
#endif
}
