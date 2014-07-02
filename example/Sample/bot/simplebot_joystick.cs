using System;
using Moonmile.BrickPiNet;

namespace Sample
{
    class simplebot_joystick
    {
        BPiMotor motor1, motor2;
        BotPiJoystick js;

        public void main()
        {
            BPi.Setup();
            BPi.AutoUpdate = true;
            this.motor1 = new BPiMotor() { Port = BrickPi.PORT_B, Enabled = true };
            this.motor2 = new BPiMotor() { Port = BrickPi.PORT_C, Enabled = true };

            BotPi.SetupJoystick();
            this.js = new BotPiJoystick(); 
            this.js.OnChanged += OnJoystickChanged;
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
            var k = Console.ReadKey();
        }

        void OnJoystickChanged( object sender, EventJsArgs e )
        {
            Console.WriteLine("joy: {0} {1} {2}", e.ev.type, e.ev.number, e.ev.value);
        }
    }
}
