#include "tick.h"
#include "BrickPi.h"

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
void SetTimeout(int time) {
	BrickPi.Timeout = time;
}
int GetTimeout() {
	return BrickPi.Timeout;
}
