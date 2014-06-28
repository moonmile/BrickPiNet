using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class Menu
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Usage();
                return;
            }
            else
            {
                switch (args[0])
                {
                    case "raw": new Program().main(); break;
                    case "simple": new simplebot_simple().main(); break;
                    case "speed": new simplebot_speed().main(); break;
                    case "psp": new simplebot_psp().main(); break;
                    case "ev3color": new ev3.ev3_colorsensor().main(); break;
                    case "ev3gyro": new ev3.ev3_gyrosensor().main(); break;
                    case "ev3touch": new ev3.ev3_touchsensor().main(); break;
                    default:
			Console.WriteLine("arguments error");
                        Usage();
                        break;
                }
            }
        }
        public static void Usage()
        {
            Console.WriteLine(@"
Usage sample.exe [menu]
 menu is
  raw    : simplebot_raw
  simple : simplebot_simple
  speed  : simplebot_speed
  psp    : simplebot_php
  ev3color : ev3_colorsensor
  ev3gyro  : ev3_gyrosensor
  ev3touch : ev3_touchsensor
"
                );

        }
    }
}
