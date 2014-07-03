using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Moonmile.BrickPiNet
{
    public class EventJsArgs : EventArgs
    {
        public int type { get; set; }
        public js_event ev { get; set; }
    }
    public class BotPiJoystick
    {
        public event Action<object, EventJsArgs> OnChanged;
        protected Task _task;

        protected int[] axis = new int[4];

        /// <summary>
        /// Initalize and open /dev/input/js0
        /// </summary>
        public void Init()
        {
            for (int i = 0; i < axis.Length; i++) { axis[i] = 0; }

            this._task = new Task(Read);
Console.WriteLine("joystick.Task.Start");
            this._task.Start();
        }

        public void Read()
        {
Console.WriteLine("joystick.Read.Start");
            int type = 0;
            js_event ev = new js_event();
            while (true)
            {
                bool ischanged = false;
Console.WriteLine("joystick.Read.Joystick start");
                int ret = BotPi.ReadJoystick(ref type, ref ev);
Console.WriteLine("joystick.Read.Joystick end: {0} {1} {2} {3}", ret,
		ev.type & ~BotPi.JS_EVENT_INIT , ev.number, ev.value );
                switch (ev.type & ~BotPi.JS_EVENT_INIT)
                {
                    case BotPi.JS_EVENT_AXIS :
                        if (axis[ev.number] != ev.value)
                        {
                            ischanged = true;
                            axis[ev.number] = ev.value;
                        }
                        break;
                }
                
                if ( ischanged == true && this.OnChanged != null)
                {
                    this.OnChanged(this, new EventJsArgs() { type = type, ev = ev });
                }
            }
        }
    }
}
