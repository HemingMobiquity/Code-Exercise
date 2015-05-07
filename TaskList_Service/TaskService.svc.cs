using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TaskList_Service.Model;

namespace TaskList_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TaskService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TaskService.svc or TaskService.svc.cs at the Solution Explorer and start debugging.
    public class TaskService : ITaskService
    {
        TaskManagementEntities ctx;

        public TaskService()
        {
            ctx = new TaskManagementEntities();
        }

        public List<TaskDataContract> GetAllTask()
        {
            var query = (from a in ctx.Tasks
                         select a).Distinct();

            List<TaskDataContract> taskList = new List<TaskDataContract>();

            query.ToList().ForEach(rec =>
            {
                taskList.Add(new TaskDataContract
                {
                    TaskID = Convert.ToString(rec.TaskID),
                    Name = rec.Name,                 
                    City = rec.City,
                    State = rec.State
                });
            });
            return taskList;
        }

        public TaskDataContract GetTaskDetails(string TaskId)
        {
            TaskDataContract task = new TaskDataContract();

            try
            {
                string tsk_ID = TaskId;
                var query = (from a in ctx.Tasks
                             where a.TaskID.Equals(tsk_ID)
                             select a).Distinct().FirstOrDefault();

                task.TaskID = Convert.ToString(query.TaskID);
                task.Name = query.Name;
               
                task.City = query.City;
                task.State = query.State;
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return task;
        }

        public bool AddNewTask(TaskDataContract task)
        {
            try
            {
                Task tsk = ctx.Tasks.Create();
                tsk.Name = task.Name;
                
                tsk.City = task.City;
                tsk.State = task.State;

                ctx.Tasks.Add(tsk);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return true;
        }

        public void UpdateTask(TaskDataContract task)
        {
            try
            {
                string Task_Id = task.TaskID;
                Task tsk = ctx.Tasks.Where(rec => rec.TaskID == Task_Id).FirstOrDefault();
                tsk.Name = task.Name;
               
                tsk.City = task.City;
                tsk.State = task.State;

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
        }

        public void DeleteTask(string TaskId)
        {
            try
            {
                string Tsk_Id = TaskId;
                Task std = ctx.Tasks.Where(rec => rec.TaskID == Tsk_Id).FirstOrDefault();
                ctx.Tasks.Remove(std);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
        }
    }
}
