using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Moonmile.BrickPiNet
{
    public class BPi
    {
        protected internal static ObservableCollection<BPiMotor> Motors;
        protected internal static ObservableCollection<BPiSensor> Sensers;
        public static bool AutoUpdate { get; set; }

        private static int _timeout = 3000;
        public static int Timeout
        {
            get { return _timeout; }
            set
            {
                if (_timeout != value)
                {
                    _timeout = value;
                    BrickPi.SetTimeout(value);
                    BrickPi.InitTimeout();
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public BPi()
        {
            BPi.Motors = new ObservableCollection<BPiMotor>();
            BPi.Motors.CollectionChanged += Motors_CollectionChanged;
            BPi.Sensers = new ObservableCollection<BPiSensor>();
            BPi.Sensers.CollectionChanged += Sensers_CollectionChanged;
            BPi.AutoUpdate = false;
        }

        public static void Setup()
        {
            int res = BrickPi.Setup();
            if (res != 0)
            {
                Console.WriteLine("");
                throw new Exception(string.Format("Error: BrickPi.Setup: {0}", res ));
            }
        }

        void Motors_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (BPiMotor it in e.NewItems)
                    {
                        it.PropertyChanged += it_PropertyChanged;
                        BrickPi.SetMotorEnable(it.Port, it.Enabled);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (BPiMotor it in e.OldItems)
                    {
                        it.PropertyChanged -= it_PropertyChanged;
                        BrickPi.SetMotorEnable(it.Port, false);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
            }
            int res = BrickPi.SetupSensors();
            if (res != 0)
            {
                Console.WriteLine("");
                throw new Exception(string.Format("Error: BrickPi.SetupSensors: {0}", res));
            }
        }
        void Sensers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (BPiSensor it in e.NewItems)
                    {
                        it.PropertyChanged += it_PropertyChanged;
                        BrickPi.SetSensorType(it.Port, it.SensorType);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (BPiSensor it in e.OldItems)
                    {
                        it.PropertyChanged -= it_PropertyChanged;
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
            }
            int res = BrickPi.SetupSensors();
            if (res != 0)
            {
                Console.WriteLine("");
                throw new Exception(string.Format("Error: BrickPi.SetupSensors: {0}", res));
            }
        }

        void it_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (BPi.AutoUpdate == true) 
                Update();
        }

        /// <summary>
        /// call UpdateValues
        /// </summary>
        public void Update()
        {
            BrickPi.UpdateValues();
            // System.Threading.Thread.Sleep(10);
        }
    }
    public class BPiMotor : BindableBase
    {
        public BPiMotor()
        {
            BPi.Motors.Add(this);
        }

        public int Port { get; set; }

        private bool _enabled = false;
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                BrickPi.SetMotorEnable(this.Port, value);
                this.SetProperty(ref this._enabled, value);
            }
        }

        private int _speed = 0;
        public int Speed
        {
            get { return _speed; }
            set
            {
                BrickPi.SetMotorSpeed(this.Port, value);
                this.SetProperty(ref this._speed, value );
            }
        }
    }
    public class BPiSensor : BindableBase
    {
        public BPiSensor()
        {
            BPi.Sensers.Add(this);
        }
        public int Port { get; set; }

        private int _sensorType = 0;
        public int SensorType
        {
            get { return _sensorType; }
            set
            {
                BrickPi.SetSensorType(this.Port, value);
                this.SetProperty(ref this._sensorType, value);
            }
        }
        public virtual void Update()
        {
            BrickPi.UpdateValues();
        }
    }

    public class BPiJoystick : BPiSensor 
    {
        private Btns _Buttons = new Btns();
        public Btns Buttons
        {
            get { return this._Buttons; }
        }

        public BPiJoystick()
            : base()
        {
            base.SensorType = BrickPi.TYPE_SENSOR_I2C;
        }

        public override void Update()
        {
            base.Update();
            BrickPi.ButtonUpdate(this.Port);
            _Buttons.L1 = BrickPi.GetButtonL1() == 0;
            _Buttons.L2 = BrickPi.GetButtonL2() == 0;
            _Buttons.R1 = BrickPi.GetButtonR1() == 0;
            _Buttons.R2 = BrickPi.GetButtonR2() == 0;
            _Buttons.A = BrickPi.GetButtonA() == 0;
            _Buttons.B = BrickPi.GetButtonB() == 0;
            _Buttons.C = BrickPi.GetButtonC() == 0;
            _Buttons.D = BrickPi.GetButtonD() == 0;
            _Buttons.Triangle = BrickPi.GetButtonTri() == 0;
            _Buttons.Square = BrickPi.GetButtonSqr() == 0;
            _Buttons.Circle = BrickPi.GetButtonCir() == 0;
            _Buttons.Cross = BrickPi.GetButtonCro() == 0;
            _Buttons.LeftJoyButton = BrickPi.GetButtonLjb() == 0;
            _Buttons.RightJoyButton = BrickPi.GetButtonRjb() == 0;
            _Buttons.LeftJoyX = BrickPi.GetButtonLjx();
            _Buttons.LeftJoyY = BrickPi.GetButtonLjy();
            _Buttons.RightJoyX = BrickPi.GetButtonRjx();
            _Buttons.RightJoyY = BrickPi.GetButtonRjy();
        }

        public class Btns {
            public bool L1 { get; set; }
            public bool L2 { get; set; }
            public bool R1 { get; set; }
            public bool R2 { get; set; }
            public bool A { get; set; }
            public bool B { get; set; }
            public bool C { get; set; }
            public bool D { get; set; }
            public bool Triangle { get; set; }
            public bool Square { get; set; }
            public bool Circle { get; set; }
            public bool Cross { get; set; }
            public bool LeftJoyButton { get; set; }
            public bool RightJoyButton { get; set; }
            public int LeftJoyX { get; set; }
            public int LeftJoyY { get; set; }
            public int RightJoyX { get; set; }
            public int RightJoyY { get; set; }
        }
    }

    public class BPiTouch : BPiSensor
    {
        public BPiTouch()
            : base()
        {
            base.SensorType = BrickPi.TYPE_SENSOR_EV3_TOUCH_0;
        }
        public bool IsTouched
        {
            get
            {
                this.Update();
                if (BrickPi.GetSensor(this.Port) > 1020)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
    public class BPiColor : BPiSensor
    {
        public BPiColor()
            : base()
        {
            base.SensorType = BrickPi.TYPE_SENSOR_EV3_COLOR_M3;
        }
        public int RowValue
        {
            get
            {
                this.Update();
                return BrickPi.GetSensor(this.Port);
            }
        }
    }
    public class BPiGyro : BPiSensor
    {
        public BPiGyro()
            : base()
        {
            base.SensorType = BrickPi.TYPE_SENSOR_EV3_GYRO_M3;
        }
        public int RowValue
        {
            get
            {
                this.Update();
                return BrickPi.GetSensor(this.Port);
            }
        }
    }
}
