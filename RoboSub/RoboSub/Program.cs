using RoboSub.Sensors.Pressure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboSub
{
    class Program
    {
        static void Main(string[] args)
        {

            IPressureSensor pSensor = new ArduinoPressureSensor();
            System.Threading.Thread.Sleep(2000);
            pSensor.calibrate();

            Console.WriteLine("RoboSub Console Output");

            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Depth: {0:0.00} feet  ", pSensor.getDepth());
                Console.WriteLine("Pressure: {0:0.00} psi  ", pSensor.Psi);

            }
            
            
            
            
            
        }
    }
}
