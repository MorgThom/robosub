using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboSub.Tasks;

namespace RoboSub.Tasks
{
    /// <summary>
    /// Task for going through the enterance gate
    /// </summary>
    class EnterGateTask : CourseTask
    {

        private int distance = 0;
        private bool done = false;

        // Timeout for Task
        private int timeout = -1;
        public int Timeout
        {
           get 
           { return timeout; }
           set 
           { timeout = value; }
        }

        // Completion Status
        private CourseTaskStatus status = CourseTaskStatus.NotDone;
        public CourseTaskStatus Status
        {
            get
            { return status; }
            set
            { status = value; }
        }



        public EnterGateTask(int distance)
        {
            this.distance = distance;
        }

        public void start()
        {
            // move forward untill distance
            // done = true;
            System.Threading.Thread.Sleep(2000);
            //throw new NotImplementedException();
        }

        public bool isDone()
        {
            return status != CourseTaskStatus.NotDone;
        }


    }
}
