using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.IO;

namespace Moonmile.BrickPiNet
{
    public class BPiJoystickData
    {
        int Axis0 { get; set; }
        int Axis1 { get; set; }
        int Axis2 { get; set; }
        int Axis3 { get; set; }
        int Axis4 { get; set; }
        int Axis5 { get; set; }

        int Axis23 { get; set; }
        int Axis24 { get; set; }
        int Axis25 { get; set; }
        int Axis26 { get; set; }

        bool Button0 { get; set; }
        bool Button1 { get; set; }
        bool Button2 { get; set; }
        bool Button3 { get; set; }
        bool Button4 { get; set; }
        bool Button5 { get; set; }
        bool Button6 { get; set; }
        bool Button7 { get; set; }
        bool Button8 { get; set; }
        bool Button9 { get; set; }
        bool Button10 { get; set; }
        bool Button11 { get; set; }
        bool Button12 { get; set; }
        bool Button13 { get; set; }
        bool Button14 { get; set; }
        bool Button15 { get; set; }

        public bool SELECT { get { return Button0; } }
        public bool LeftStick { get { return Button1; } }
        public bool RightStick { get { return Button2; } }
        public bool START { get { return Button3; } }
        public bool Up { get { return Button4; } }
        public bool Right { get { return Button5; } }
        public bool Down { get { return Button6; } }
        public bool Left { get { return Button7; } }
        public bool L2 { get { return Button8; } }
        public bool R2 { get { return Button9; } }
        public bool L1 { get { return Button10; } }
        public bool R1 { get { return Button11; } }
        public bool Triangle { get { return Button12; } }
        public bool Circle { get { return Button13; } }
        public bool Cross { get { return Button14; } }
        public bool Square { get { return Button15; } }

        public int LeftAxisX { get { return Axis0; } }
        public int LeftAxisY { get { return Axis1; } }
        public int RightAxisX { get { return Axis2; } }
        public int RightAxisY { get { return Axis3; } }

        public override string ToString()
        {
            return string.Format("Axis {0} {1} {2} {3} {4} {5} ",
                Axis0, Axis1, Axis2, Axis3, Axis4, Axis5) +
                string.Format("{0} ", Axis23) +
                string.Format("{0} ", Axis24) +
                string.Format("{0} ", Axis25) +
                string.Format("{0} ", Axis26) +
                "Btn " +
                string.Format("{0} ", Button0 ? 1 : 0) +
                string.Format("{0} ", Button1 ? 1 : 0) +
                string.Format("{0} ", Button2 ? 1 : 0) +
                string.Format("{0} ", Button3 ? 1 : 0) +
                string.Format("{0} ", Button4 ? 1 : 0) +
                string.Format("{0} ", Button5 ? 1 : 0) +
                string.Format("{0} ", Button6 ? 1 : 0) +
                string.Format("{0} ", Button7 ? 1 : 0) +
                string.Format("{0} ", Button8 ? 1 : 0) +
                string.Format("{0} ", Button9 ? 1 : 0) +
                string.Format("{0} ", Button10 ? 1 : 0) +
                string.Format("{0} ", Button11 ? 1 : 0) +
                string.Format("{0} ", Button12 ? 1 : 0) +
                string.Format("{0} ", Button13 ? 1 : 0) +
                string.Format("{0} ", Button14 ? 1 : 0) +
                string.Format("{0} ", Button15 ? 1 : 0) +
                "";
        }

        public enum TYPE : byte { AXIS = 0x02, BUTTON = 0x01 }
        public enum STATUS : byte { PRESSED = 0x01, RELEASED = 0x00 }

        public static bool IsAxis(byte type)
        {
            return (type & (byte)TYPE.AXIS) != 0;
        }
        public static bool IsButton(byte type)
        {
            return (type & (byte)TYPE.BUTTON) != 0;
        }

        public void SetValue(byte type, byte num, int val)
        {
            if (IsAxis(type))
            {
                switch (num)
                {
                    case 0: this.Axis0 = val; break;
                    case 1: this.Axis1 = val; break;
                    case 2: this.Axis2 = val; break;
                    case 3: this.Axis3 = val; break;
                    case 4: this.Axis4 = val; break;
                    case 5: this.Axis5 = val; break;

                    case 23: this.Axis23 = val; break;
                    case 24: this.Axis24 = val; break;
                    case 25: this.Axis25 = val; break;
                    case 26: this.Axis26 = val; break;
                }
            }
            else if (IsButton(type))
            {
                switch (num)
                {
                    case 0: this.Button0 = val != 0; break;
                    case 1: this.Button1 = val != 0; break;
                    case 2: this.Button2 = val != 0; break;
                    case 3: this.Button3 = val != 0; break;
                    case 4: this.Button4 = val != 0; break;
                    case 5: this.Button5 = val != 0; break;
                    case 6: this.Button6 = val != 0; break;
                    case 7: this.Button7 = val != 0; break;
                    case 8: this.Button8 = val != 0; break;
                    case 9: this.Button9 = val != 0; break;
                    case 10: this.Button10 = val != 0; break;
                    case 11: this.Button11 = val != 0; break;
                    case 12: this.Button12 = val != 0; break;
                    case 13: this.Button13 = val != 0; break;
                    case 14: this.Button14 = val != 0; break;
                    case 15: this.Button15 = val != 0; break;
                }
            }
        }
        public int GetAxisValue(byte num)
        {
            switch (num)
            {
                case 0: return this.Axis0;
                case 1: return this.Axis1;
                case 2: return this.Axis2;
                case 3: return this.Axis3;
                case 4: return this.Axis4;
                case 5: return this.Axis5;

                case 23: return this.Axis23;
                case 24: return this.Axis24;
                case 25: return this.Axis25;
                case 26: return this.Axis26;
                default: return 0;
            }
        }
        public bool GetButtonValue(byte num)
        {
            switch (num)
            {
                case 0: return this.Button0;
                case 1: return this.Button1;
                case 2: return this.Button2;
                case 3: return this.Button3;
                case 4: return this.Button4;
                case 5: return this.Button5;
                case 6: return this.Button6;
                case 7: return this.Button7;
                case 8: return this.Button8;
                case 9: return this.Button9;
                case 10: return this.Button10;
                case 11: return this.Button11;
                case 12: return this.Button12;
                case 13: return this.Button13;
                case 14: return this.Button14;
                case 15: return this.Button15;
                default: return false;
            }
        }
    }
    public struct js_event
    {
        public UInt32 time;    /* event timestamp in milliseconds */
        public Int16 value;    /* value */
        public byte type;      /* event type */
        public byte number;    /* axis/button number */
        public override string ToString()
        {
            return string.Format("time:{0} val:{1} type:{2} num:{3}", time, value, type, number);
        }
    }
    public class JoystickEventArgs : EventArgs
    {
        public BPiJoystickData Joystick { get; set; }
        public js_event Raw { get; set; }
    }

    public class BPiJoystick
    {
        public BPiJoystickData Joystick { get; set; }
        protected int _port = 0;
        public int Port { get { return _port; } }
        protected BinaryReader _br;
        Task _task;
        public bool IsLoop { get; set; }
        
        public event Action<object, JoystickEventArgs> OnJoystickChanged;


        public BPiJoystick(int port = 0)
        {
            this._port = port;
            this.IsLoop = false;
            this.Joystick = new BPiJoystickData();
        }
        public void Setup()
        {
            try
            {
                var fs = File.OpenRead(string.Format("/dev/input/js{0}", _port));
                this._br = new BinaryReader(fs);
                this._task = new Task(OnLoop);
                this.IsLoop = true;
            }
            catch
            {
                throw new Exception(string.Format("Error: Cannot open /dev/input/js{0}", _port));
            }
            this._task.Start();
        }

        protected void OnLoop()
        {
            while (this.IsLoop)
            {
                js_event js;
                js.time = _br.ReadUInt32();
                js.value = _br.ReadInt16();
                js.type = _br.ReadByte();
                js.number = _br.ReadByte();
                // Console.WriteLine(js.ToString());

                bool changed = false;
                if (BPiJoystickData.IsAxis(js.type))
                {
                    if (this.Joystick.GetAxisValue(js.number) != js.value)
                    {
                        Joystick.SetValue(js.type, js.number, js.value);
                        changed = true;
                    }
                }
                else if (BPiJoystickData.IsButton(js.type))
                {
                    if (Joystick.GetButtonValue(js.number) != (js.value != 0))
                    {
                        Joystick.SetValue(js.type, js.number, js.value);
                        changed = true;
                    }
                }
                // filter
                if (BPiJoystickData.IsAxis(js.type) && js.number >= 6) changed = false;
                if (BPiJoystickData.IsButton(js.type) && js.number >= 16) changed = false;

                // raise value change event
                if (changed)
                {
                    if (OnJoystickChanged != null)
                    {
                        OnJoystickChanged(this, new JoystickEventArgs()
                        {
                            Joystick = this.Joystick,
                            Raw = js
                        });
                    }
                    // Console.Write("{0} {1} {2} ", js.type, js.number, js.value );
                    // Console.WriteLine(j.ToString());
                }
            }
            this._br.Close();
        }
    }
}
