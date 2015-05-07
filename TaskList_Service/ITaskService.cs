using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TaskList_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITaskService" in both code and config file together.
    [ServiceContract]
    public interface ITaskService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetAllTask/")]
        List<TaskDataContract> GetAllTask();

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetTaskDetails/{TaskId}")]
        TaskDataContract GetTaskDetails(string TaskId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "/AddNewTask")]
        bool AddNewTask(TaskDataContract task);

        [OperationContract]
        [WebInvoke(Method = "PUT",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/UpdateTask")]
        void UpdateTask(TaskDataContract contact);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DeleteTask/{TaskId}")]
        void DeleteTask(string TaskId);
    }
}
