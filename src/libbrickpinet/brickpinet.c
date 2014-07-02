/*
 * BrickPi Interface for .NET 
 */
#include <linux/joystick.h>
#include "tick.h"
#include "BrickPi.h"

void SetTimeout(int time) {
	BrickPi.Timeout = time;
}
int GetTimeout() {
	return BrickPi.Timeout;
}
/*
  Motors
*/
void SetMotorSpeed(int motor, int speed) {
	BrickPi.MotorSpeed[motor] = speed;
}
int GetMotorSpeed(int motor) {
	return BrickPi.MotorSpeed[motor];
}
void SetMotorEnable(int motor, int b) {
	BrickPi.MotorEnable[motor] = b == 0 ? 0 : 1;
}
int GetMotorEnable(int motor) {
	return BrickPi.MotorEnable[motor] == 0 ? 0 : 1;
}

void SetEncoderOffset( int port, int value ) {
	BrickPi.EncoderOffset[port] = value;
}
int GetEncoderOffset( int port ) {
	return BrickPi.EncoderOffset[port];
}
void SetEncoder( int port, int value ) {
	BrickPi.Encoder[port] = value;
}
int GetEncoder( int port ) {
	return  BrickPi.Encoder[port];
}

/*
  Sensors
*/
void SetSensor( int port, int value ) {
	BrickPi.Sensor[port] = value;
}
int GetSensor( int port ) {
	return  BrickPi.Sensor[port];
}
void SetSensorType( int port, int value ) {
	BrickPi.SensorType[port] = value;
	BrickPi.SensorI2CSpeed[port] = 6; //  I2C_SPEED		;
	BrickPi.SensorI2CDevices[port] = 1;
	BrickPi.SensorSettings[port][0] = 0;
	BrickPi.SensorI2CAddr[port][0] = 0x02;	//address for writing
}
int GetSensorType( int port ) {
	return  BrickPi.SensorType[port];
}

//Store the button's of the MINDSENSORS PSP Controller
static struct button _btn;

void ButtonInit() {
	_btn = init_psp(_btn);
}
void ButtonUpdate( int port ) {
	_btn = upd(_btn, port);
}
int GetButtonL1() { return (int)_btn.l1; }
int GetButtonL2() { return (int) _btn.l2; }
int GetButtonR1() { return (int) _btn.r1; }
int GetButtonR2() { return (int) _btn.r2; }
int GetButtonA() { return (int) _btn.a; }
int GetButtonB() { return (int) _btn.b; }
int GetButtonC() { return (int) _btn.c; }
int GetButtonD() { return (int) _btn.d; }
int GetButtonTri() { return (int) _btn.tri; }
int GetButtonSqr() { return (int) _btn.sqr; }
int GetButtonCir() { return (int) _btn.cir; }
int GetButtonCro() { return (int) _btn.cro; }
int GetButtonLjb() { return (int) _btn.ljb; }
int GetButtonRjb() { return (int) _btn.rjb; }
int GetButtonLjx() { return _btn.ljx; }
int GetButtonLjy() { return _btn.ljy; }
int GetButtonRjx() { return _btn.rjx; }
int GetButtonRjy() { return _btn.rjy; }

static int js_axis[4];
static int js_fd;

int SetupJoystick()
{
	js_fd = open("/dev/input/js0", O_RDONLY);
	return js_fd;
}
int ReadJoystick(int *type, struct js_event *js) 
{

}