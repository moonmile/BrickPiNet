module sampleFs
open System
open BrickPiNet 

let motor1 = BrickPi.PORT_B
let motor2 = BrickPi.PORT_C
let speed = 200

let fwd() = 
    BrickPi.SetMotorSpeed( motor1, speed )
    BrickPi.SetMotorSpeed( motor2, speed )
let left() = 
    BrickPi.SetMotorSpeed( motor1, speed )
    BrickPi.SetMotorSpeed( motor2, -speed )
let right() = 
    BrickPi.SetMotorSpeed( motor1, -speed )
    BrickPi.SetMotorSpeed( motor2, speed )
let back() = 
    BrickPi.SetMotorSpeed( motor1, -speed )
    BrickPi.SetMotorSpeed( motor2, -speed )
let stop() = 
    BrickPi.SetMotorSpeed( motor1, 0 )
    BrickPi.SetMotorSpeed( motor2, 0 )

// main
let res = BrickPi.Setup()
Console.WriteLine("BrickPiSetup: {0}", res)
if res <> 0 then exit(0)

BrickPi.SetMotorEnable( motor1, true )
BrickPi.SetMotorEnable( motor2, true )
let rets = BrickPi.SetupSensors()
Console.WriteLine("SetupSensors: {0}", res)
if res <> 0 then exit(0)
BrickPi.SetTimeout(3000)
BrickPi.InitTimeout()

let mutable loop = true
while loop do
    let key = Console.ReadKey()
    match key.Key with
        | ConsoleKey.W -> fwd() 
        | ConsoleKey.A -> left()
        | ConsoleKey.D -> right()
        | ConsoleKey.X -> stop()
        | ConsoleKey.Q -> loop <- false
        | _ -> ()
    BrickPi.UpdateValues()
    System.Threading.Thread.Sleep(10);

