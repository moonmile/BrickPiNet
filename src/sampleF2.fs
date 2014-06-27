module sampleF2
open System
open BrickPiNet 

let speed = 200
// main
// let bpi = new BPi()
BPi.Setup()
BPi.AutoUpdate <- true
let motor1 = new BPiMotor( Port = BrickPi.PORT_B, Enabled = true )
let motor2 = new BPiMotor( Port = BrickPi.PORT_B, Enabled = true )
//bpi.Motors.Add(motor1)
//bpi.Motors.Add(motor2)
BPi.Timeout <- 3000 
Console.WriteLine("start")
let mutable loop = true
while loop do
    let key = Console.ReadKey()
    match key.Key with
        | ConsoleKey.W -> 
            motor1.Speed <- speed 
            motor2.Speed <- speed 
        | ConsoleKey.A -> 
            motor1.Speed <- speed 
            motor2.Speed <- -speed 
        | ConsoleKey.D -> 
            motor1.Speed <- -speed 
            motor2.Speed <- speed 
        | ConsoleKey.S -> 
            motor1.Speed <- -speed 
            motor2.Speed <- -speed 
        | ConsoleKey.X -> 
            motor1.Speed <- 0
            motor2.Speed <- 0
        | ConsoleKey.Q -> 
            loop <- false
        | _ -> ()
