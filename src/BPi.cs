using System;
using System.Text;
using System.Runtime.InteropServices;
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
            System.Threading.Thread.Sleep(10);
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

        private Button _JoyStick = new Button();
        public Button JoyStick
        {
            get { return _JoyStick; }
        }
        public void Update()
        {
            BrickPi.UpdateValues();
            BrickPi.ButtonUpdate(this.Port);
            _JoyStick.L1 = BrickPi.GetButtonL1() == 0;
            _JoyStick.L2 = BrickPi.GetButtonL2() == 0;
            _JoyStick.R1 = BrickPi.GetButtonR1() == 0;
            _JoyStick.R2 = BrickPi.GetButtonR2() == 0;
            _JoyStick.A = BrickPi.GetButtonA() == 0;
            _JoyStick.B = BrickPi.GetButtonB() == 0;
            _JoyStick.C = BrickPi.GetButtonC() == 0;
            _JoyStick.D = BrickPi.GetButtonD() == 0;
            _JoyStick.Triangle = BrickPi.GetButtonTri() == 0;
            _JoyStick.Square = BrickPi.GetButtonSqr() == 0;
            _JoyStick.Circle = BrickPi.GetButtonCir() == 0;
            _JoyStick.Cross = BrickPi.GetButtonCro() == 0;
            _JoyStick.LeftJoyButton = BrickPi.GetButtonLjb() == 0;
            _JoyStick.RightJoyButton = BrickPi.GetButtonRjb() == 0;
            _JoyStick.LeftJoyX = BrickPi.GetButtonLjx();
            _JoyStick.LeftJoyY = BrickPi.GetButtonLjy();
            _JoyStick.RightJoyX = BrickPi.GetButtonRjx();
            _JoyStick.RightJoyY = BrickPi.GetButtonRjy();
        }

        public class Button {
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
}
