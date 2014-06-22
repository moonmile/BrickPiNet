using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace BrickPiNet
{
    public class BPi
    {
        public ObservableCollection<BPiMotor> Motors;
        public bool AutoUpdate { get; set; }

        private int _timeout = 3000;
        public int Timeout
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
            this.Motors = new ObservableCollection<BPiMotor>();
            this.Motors.CollectionChanged += Motors_CollectionChanged;
            this.AutoUpdate = false;
        }
        public void Setup()
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
            // var m = sender as BPiMotor;
            switch ( e.Action ) {
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

        void it_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (this.AutoUpdate == true) 
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
}
