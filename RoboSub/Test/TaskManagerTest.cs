using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboSub.Tasks;


namespace Test
{
    [TestClass]
    public class TaskManagerTest
    {
        [TestMethod]
        public void TestManager()
        {

            TaskManager taskManager = new TaskManager();

            ICourseTask task1 = new EnterGateTask(12);
            task1.Timeout = 1000;
            ICourseTask task2 = new EnterGateTask(12);

            taskManager.addTask(task1);
            taskManager.addTask(task2);

            taskManager.start();

            Assert.IsTrue(task1.Status == CourseTaskStatus.Done_Failure);
        }
    }
}
 