using RoboSub.Sensors.Pressure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pololu.Jrk;

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

            Jrk jrk = null;
            var deviceList = Jrk.getConnectedDevices();
            if (deviceList.Count > 0)
            {
                Console.WriteLine("Connected to USB port " + deviceList[0].serialNumber);
                jrk = new Jrk(deviceList[0]);
            }
            else
            {
                Console.WriteLine("Can't find any motor");
            }
            
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Depth: {0:0.00} feet  ", pSensor.getDepth());
                Console.WriteLine("Pressure: {0:0.00} psi  ", pSensor.Psi);
                if (deviceList.Count > 0)
                {
                    if (pSensor.getDepth() > 0.4)
                    {
                        jrk.setTarget(2548);
                    }
                    else
                    {
                        jrk.setTarget(2048);
                    }
                }
            }
            
            
            
            
            
        }
    }
}
