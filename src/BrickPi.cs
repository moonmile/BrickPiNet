using System;
using System.Text;
using System.Runtime.InteropServices;

namespace BrickPiNet
{
    public class BrickPi
    {
        [DllImport("libbrickpinet", EntryPoint="BrickPiSetup")]
        public static extern int Setup();
        [DllImport("libbrickpinet",EntryPoint="BrickPiSetupSensors")]
        public static extern int SetupSensors();
        [DllImport("libbrickpinet", EntryPoint = "BrickPiUpdateValues")]
        public static extern void UpdateValues();
        [DllImport("libbrickpinet", EntryPoint = "BrickPiSetTimeout")]
        public static extern void InitTimeout();

        [DllImport("libbrickpinet")]
        public static extern void SetMotorSpeed(int motor, int speed);
        [DllImport("libbrickpinet")]
        public static extern int GetMotorSpeed(int motor);
        [DllImport("libbrickpinet")]
        public static extern void SetMotorEnable(int motor, int b);
        public static void SetMotorEnable(int motor, bool b) { SetMotorEnable(motor, b ? 1 : 0); }
        [DllImport("libbrickpinet")]
        public static extern int GetMotorEnable(int motor );
        [DllImport("libbrickpinet")]
        public static extern void SetTimeout(int time);
        [DllImport("libbrickpinet")]
        public static extern int GetTimeout();

        public const int PORT_A = 0;
        public const int PORT_B = 1;
        public const int PORT_C = 2;
        public const int PORT_D = 3;
    }
}
