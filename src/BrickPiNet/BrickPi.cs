using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Moonmile.BrickPiNet
{
    public class BrickPi
    {
        public const int PORT_A = 0;
        public const int PORT_B = 1;
        public const int PORT_C = 2;
        public const int PORT_D = 3;

        public const int PORT_1 = 0;
        public const int PORT_2 = 1;
        public const int PORT_3 = 2;
        public const int PORT_4 = 3;

        public const int MASK_D0_M = 0x01;
        public const int MASK_D1_M = 0x02;
        public const int MASK_9V = 0x04;
        public const int MASK_D0_S = 0x08;
        public const int MASK_D1_S = 0x10;

        public const int BYTE_MSG_TYPE = 0; // MSG_TYPE is the first byte.
        public const int MSG_TYPE_CHANGE_ADDR = 1; // Change the UART address.
        public const int MSG_TYPE_SENSOR_TYPE = 2; // Change/set the sensor type.
        public const int MSG_TYPE_VALUES = 3; // Set the motor speed and direction, and return the sesnors and encoders.
        public const int MSG_TYPE_E_STOP = 4; // Float motors immidately
        public const int MSG_TYPE_TIMEOUT_SETTINGS = 5; // Set the timeout

        // New UART address (MSG_TYPE_CHANGE_ADDR)
        public const int BYTE_NEW_ADDRESS = 1;

        // Sensor setup (MSG_TYPE_SENSOR_TYPE)
        public const int BYTE_SENSOR_1_TYPE = 1;
        public const int BYTE_SENSOR_2_TYPE = 2;

        // Timeout setup (MSG_TYPE_TIMEOUT_SETTINGS)
        public const int BYTE_TIMEOUT = 1;

        public const int TYPE_MOTOR_PWM = 0;
        public const int TYPE_MOTOR_SPEED = 1;
        public const int TYPE_MOTOR_POSITION = 2;

        public const int TYPE_SENSOR_RAW = 0; // - 31
        public const int TYPE_SENSOR_LIGHT_OFF = 0;
        public const int TYPE_SENSOR_LIGHT_ON = (MASK_D0_M | MASK_D0_S);
        public const int TYPE_SENSOR_TOUCH = 32;
        public const int TYPE_SENSOR_ULTRASONIC_CONT = 33;
        public const int TYPE_SENSOR_ULTRASONIC_SS = 34;
        public const int TYPE_SENSOR_RCX_LIGHT = 35;// tested minimally
        public const int TYPE_SENSOR_COLOR_FULL = 36;
        public const int TYPE_SENSOR_COLOR_RED = 37;
        public const int TYPE_SENSOR_COLOR_GREEN = 38;
        public const int TYPE_SENSOR_COLOR_BLUE = 39;
        public const int TYPE_SENSOR_COLOR_NONE = 40;
        public const int TYPE_SENSOR_I2C = 41;
        public const int TYPE_SENSOR_I2C_9V = 42;

        public const int TYPE_SENSOR_EV3_US_M0 = 43;
        public const int TYPE_SENSOR_EV3_US_M1 = 44;
        public const int TYPE_SENSOR_EV3_US_M2 = 45;
        public const int TYPE_SENSOR_EV3_US_M3 = 46;
        public const int TYPE_SENSOR_EV3_US_M4 = 47;
        public const int TYPE_SENSOR_EV3_US_M5 = 48;
        public const int TYPE_SENSOR_EV3_US_M6 = 49;

        public const int TYPE_SENSOR_EV3_COLOR_M0 = 50;
        public const int TYPE_SENSOR_EV3_COLOR_M1 = 51;
        public const int TYPE_SENSOR_EV3_COLOR_M2 = 52;
        public const int TYPE_SENSOR_EV3_COLOR_M3 = 53;
        public const int TYPE_SENSOR_EV3_COLOR_M4 = 54;
        public const int TYPE_SENSOR_EV3_COLOR_M5 = 55;

        public const int TYPE_SENSOR_EV3_GYRO_M0 = 56;
        public const int TYPE_SENSOR_EV3_GYRO_M1 = 57;
        public const int TYPE_SENSOR_EV3_GYRO_M2 = 58;
        public const int TYPE_SENSOR_EV3_GYRO_M3 = 59;
        public const int TYPE_SENSOR_EV3_GYRO_M4 = 60;

        public const int TYPE_SENSOR_EV3_INFRARED_M0 = 61;
        public const int TYPE_SENSOR_EV3_INFRARED_M1 = 62;
        public const int TYPE_SENSOR_EV3_INFRARED_M2 = 63;
        public const int TYPE_SENSOR_EV3_INFRARED_M3 = 64;
        public const int TYPE_SENSOR_EV3_INFRARED_M4 = 65;
        public const int TYPE_SENSOR_EV3_INFRARED_M5 = 66;

        public const int TYPE_SENSOR_EV3_TOUCH_0 = 66;
        

        public const int BIT_I2C_MID = 0x01;    // Do one of those funny clock pulses between writing and reading. defined for each device.
        public const int BIT_I2C_SAME = 0x02;   // The transmit data, and the number of bytes to read and write isn't going to change. defined for each device.

        public const int INDEX_RED = 0;
        public const int INDEX_GREEN = 1;
        public const int INDEX_BLUE = 2;
        public const int INDEX_BLANK = 3;

        [DllImport("libbrickpinet", EntryPoint = "BrickPiSetup")]
        public static extern int Setup();
        [DllImport("libbrickpinet", EntryPoint = "BrickPiSetupSensors")]
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
        public static extern int GetMotorEnable(int motor);
        [DllImport("libbrickpinet")]
        public static extern void SetTimeout(int time);
        [DllImport("libbrickpinet")]
        public static extern int GetTimeout();

        [DllImport("libbrickpinet")]
        public static extern int GetSensor(int port);
        [DllImport("libbrickpinet")]
        public static extern void SetSensorType(int port, int type);
        [DllImport("libbrickpinet")]
        public static extern int GetSensorType(int port);

        // for Joypad buttons
        [DllImport("libbrickpinet")]
        public static extern void ButtonInit();
        [DllImport("libbrickpinet")]
        public static extern void ButtonUpdate(int port);
        [DllImport("libbrickpinet")]
        public static extern int GetButtonL1();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonL2();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonR1();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonR2();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonA();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonB();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonC();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonD();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonTri();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonSqr();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonCir();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonCro();

        [DllImport("libbrickpinet")]
        public static extern int GetButtonLjb();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonRjb();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonLjx();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonLjy();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonRjx();
        [DllImport("libbrickpinet")]
        public static extern int GetButtonRjy();
    }

//#define JS_EVENT_BUTTON		0x01	/* button pressed/released */
//#define JS_EVENT_AXIS		0x02	/* joystick moved */
//#define JS_EVENT_INIT		0x80	/* initial state of device */

//struct js_event {
//    __u32 time;	/* event timestamp in milliseconds */
//    __s16 value;	/* value */
//    __u8 type;	/* event type */
//    __u8 number;	/* axis/button number */
//};

    public struct js_event 
    {
        public UInt32 time;    /* event timestamp in milliseconds */
        public Int16 value;    /* value */
        public byte type;      /* event type */
        public byte number;    /* axis/button number */
    }
    public class BotPi
    {
        public const int JS_EVENT_BUTTON = 0x01;
        public const int JS_EVENT_AXIS = 0x02;
        public const int JS_EVENT_INIT = 0x80;

        [DllImport("libbrickpinet")]
        public static extern int SetupJoystick();
        [DllImport("libbrickpinet")]
        public static extern int ReadJoystick(ref int type, ref js_event ev );

[DllImport("libc.so.6")]
public static extern int open( string name, int flags );
[DllImport("libc.so.6")]
public static extern int read( int fd, byte[] buffer, int length );
    }
}
