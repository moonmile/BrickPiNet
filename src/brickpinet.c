/*
 * BrickPi Interface for .NET 
 */
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
}
int GetSensorType( int port ) {
	return  BrickPi.SensorType[port];
}

