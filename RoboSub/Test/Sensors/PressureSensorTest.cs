using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboSub.Tasks;
using RoboSub.Sensors.Pressure;


namespace Test
{
    [TestClass]
    public class PressureSensorTest
    {
        [TestMethod]
        public void TestPressureDepth()
        {

            IPressureSensor pSensor = new ArduinoPressureSensor();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(pSensor.getDepth());
                Console.WriteLine("Pressure: {0} psi  ", pSensor.Psi);
                System.Threading.Thread.Sleep(300);
            }
            
        }
    }
}
 