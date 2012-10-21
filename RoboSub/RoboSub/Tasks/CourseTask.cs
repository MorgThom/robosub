using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboSub.Tasks
{

    public enum CourseTaskStatus { NotDone, Done_Success, Done_Failure };

    /// <summary>
    /// Interface for which all tasks should implement
    /// </summary>s
    public interface CourseTask
    {

        

        CourseTaskStatus Status
        {
            get;
            set;
        }

        int Timeout
        {
            get;
            set;
        }


        
        

        void start();

        bool isDone();

        //void setStatus(CourseTaskStatus status);

        
    }
}
