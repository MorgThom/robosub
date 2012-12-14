using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboSub.Sensors.Pressure
{
    public interface IPressureSensor
    {

        void calibrate();


        float getDepth();





        float Psi { get;  }
    }
}
