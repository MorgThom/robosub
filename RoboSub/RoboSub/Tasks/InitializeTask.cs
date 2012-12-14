using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboSub.Tasks
{
    /// <summary>
    /// Task for doing various initialization tasks like going to depth.
    /// </summary>
    class InitializeTask : ICourseTask //Implement CourseTask
    {



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

        public void start()
        {
            // MotorActions.GoToDepth(INIT_DEPTH);
            throw new NotImplementedException();
        }

        public bool isDone()
        {
            throw new NotImplementedException();
        }
    }
}
