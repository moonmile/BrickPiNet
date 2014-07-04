#include <stdio.h>
#include <math.h>
#include <time.h>
#include <linux/i2c-dev.h>
#include <fcntl.h>

#include <stdlib.h>
#include <unistd.h>
#include <linux/input.h>
#include <linux/joystick.h>

#include "tick.h"
#include <wiringPi.h>
#include "BrickPi.h"

#define MAX_ANALOG_RANGE (32767)
#define MIN_ANALOG_RANGE (-32767)
#define ANALOG_RANGE (MAX_ANALOG_RANGE - MIN_ANALOG_RANGE)

#define MAX_MOTOR_SPEED (300)

// grobal valiable.


// function prototype.


// main.
int main()
{
    int result;
    int motor1, motor2;
    int fd_j;
    char inp;
    int *axis;
    struct js_event js;
    int speedL , speedR;
    int i;

    speedL = 0;
    speedR = 0;
    axis = (int*)calloc(4, sizeof(int));
    for (i = 0; i < 4; i++)
        axis[i] = 0;

    // Open Joystick's file.
    if ((fd_j = open("/dev/input/js0", O_RDONLY)) < 0)
    {
        printf("Error in Opening Joystick.\n");
    }

    ClearTick();

    result = BrickPiSetup();
    if (result)    return 0;

    BrickPi.Address[0] = 1;
    BrickPi.Address[1] = 2;

    // select the ports to be used by the motors.
    motor1 = PORT_B;
    motor2 = PORT_C;
    // enable motors.
    BrickPi.MotorEnable[motor1] = 1;
    BrickPi.MotorEnable[motor2] = 1;

    // setup the properties of sensors for the BrickPi.
    result = BrickPiSetupSensors();
    // set timeout.
    BrickPi.Timeout = 3000;
    BrickPiSetTimeout();
    
    if (!result)
    {
        while(1)
        {
            // read joystick.
            if (read(fd_j, &js, sizeof(struct js_event)) == sizeof(struct js_event))
            {
                switch (js.type & ~JS_EVENT_INIT)
                {
                case JS_EVENT_AXIS:
                    axis[js.number] = js.value;
                    break;
                default:
                    break;
                }

                // axis values to speed.
                printf("axis[1]: %6d, axis[3]: %6d    ", axis[1], axis[3]);
                speedL = (int)((double)axis[1] / (double)ANALOG_RANGE * (double)MAX_MOTOR_SPEED * -1.0);
                speedR = (int)((double)axis[3] / (double)ANALOG_RANGE * (double)MAX_MOTOR_SPEED * -1.0);
                printf("SpeedL: %3d,   SpeedR: %3d\n", speedL, speedR);

                BrickPi.MotorSpeed[motor1] = speedL;
                BrickPi.MotorSpeed[motor2] = speedR;

                BrickPiUpdateValues();

            }

            // sleep for 10ms
            //usleep(10000);
            
        }
    }

    return 0;
}

