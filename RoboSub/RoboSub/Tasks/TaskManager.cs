using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboSub.Tasks;

namespace RoboSub.Tasks
{
    /// <summary>
    /// Manages different Tasks or obsticles of the course. Like enter the gate, or find bouys
    /// </summary>
    public class TaskManager
    {
        
        private List<ICourseTask> taskList = new List<ICourseTask>();

        public TaskManager()
        {

        }

        public void addTask(ICourseTask task) 
        {
            taskList.Add(task);

        }

        /// <summary>
        /// Start Task manager and execute tasks in order, with optional timeouts
        /// </summary>
        public void start()
        {
            foreach (ICourseTask courseTask in taskList)
            {
                Task task = Task.Factory.StartNew(() => courseTask.start());
                if (courseTask.Timeout > 0)
                {
                    task.Wait(courseTask.Timeout); //Wait for Timeout. 
                }
                else
                {
                    task.Wait(); //Wait for task to finish 
                }


                if (task.IsCompleted)
                {   //task ended on its own
                    courseTask.Status = CourseTaskStatus.Done_Success;
                    Console.WriteLine("task has completed.");
                }
                else    
                {   // time out
                    courseTask.Status = CourseTaskStatus.Done_Failure;
                    Console.WriteLine("Timed out before.");
                }
            }
        }


    }
}
