using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboSub.Sensors.Pressure
{
    class ArduinoPressureSensor : IPressureSensor //Implements PressureSensor interface
    {

        public const decimal PSI_PER_FOOT = 0.433M;


        private static SerialPort serialPort1;

        private float depth;

        private float psi_instance;


        private float calibratedPsi = 14.7F;

        private String depthStr;

        public float Depth
        {
            get
            { return depth; }
        }


        public float Psi
        {
            get
            { return psi_instance; }
        }

        public ArduinoPressureSensor()
        {
            System.ComponentModel.IContainer components = new System.ComponentModel.Container();
            serialPort1 = new System.IO.Ports.SerialPort(components);
            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 9600;

            serialPort1.Open();
            if (!serialPort1.IsOpen)
            {
                Console.WriteLine("Arudino Serial Failed to Open");
                return;
            }

            // this turns on !
            serialPort1.DtrEnable = true;

            // callback for text coming back from the arduino
            serialPort1.DataReceived += OnReceived;

        }


        public void calibrate()
        {
            calibratedPsi = psi_instance;
        }

        public float getDepth()
        {
            return depth;
        }

        

        private void OnReceived(object sender, SerialDataReceivedEventArgs c)
        {
            try
            {
                // get serial data from arduino
                string line = serialPort1.ReadLine();
                // Console.WriteLine(line);
                if (line.StartsWith("value:") )
                {
                    int num = Convert.ToInt32(line.Substring(7, 3));

                    //Console.WriteLine("this {0}", num);

                    float psi = adcValToPsi(num);
                    psi_instance = psi;

                    depth = psiToDepth(psi);
                }
            }
            catch (Exception exc) {
                Console.Write(exc.Message);
            }
        }

        private float psiToDepth(float psi)
        {
            return (psi - calibratedPsi) * (float)PSI_PER_FOOT; 
        }

        private float adcValToPsi(int val)
        {
            float num = (val * (float)(0.0048828125)); // 1024/5 convert to volts
            //Console.WriteLine(num);
            num -= 1; // subtract a volt because pressure sensor is 1-5v
            //Console.WriteLine(num);
            float psi = num * (float)(3.75); // 15PSI/4volts Final PSI
            //Console.WriteLine(psi);
            return psi;
        }
    }
}
