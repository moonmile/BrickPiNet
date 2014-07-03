using System;
using Moonmile.BrickPiNet;

namespace Sample
{
    class simplebot_joystick
    {
        BPiMotor motor1, motor2;
        BPiJoystick js;

        public void main()
        {
            BPi.Setup();
            BPi.AutoUpdate = true;
            this.motor1 = new BPiMotor() { Port = BrickPi.PORT_B, Enabled = true };
            this.motor2 = new BPiMotor() { Port = BrickPi.PORT_C, Enabled = true };

            js = new BPiJoystick();
            js.OnJoystickChanged += js_OnJoystickChanged;
            js.Setup();

            BPi.Timeout = 3000;
            this.Go();
        }

        void js_OnJoystickChanged(object sender, JoystickEventArgs e)
        {
            int ly = e.Joystick.LeftAxisY;
            int ry = e.Joystick.RightAxisY;
            Console.WriteLine("joystick {0} {1}");
        }

        void move_bot(int sp1, int sp2)
        {
            this.motor1.Speed = sp1;
            this.motor2.Speed = sp2;
        }
        void Go()
        {
            var k = Console.ReadKey();
        }
    }
}
