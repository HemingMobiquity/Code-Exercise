/// <reference path="../angular.min.js" />
/// <reference path="Modules.js" />

app.service("AngularJs_RESTService", function ($http) {
    //Create new record
    this.post = function (Task) {
        var request = $http({
            method: "post",
            url: "http://localhost:52073/TaskService.svc/AddNewTask",
            data: Task
        });
        return request;
    }

    //Update the task
    this.put = function (TaskID, Task) {
        var request = $http({
            method: "put",
            url: "http://localhost:52073/TaskService.svc/UpdateTask",
            data: Task
        });
        return request;
    }
    // task list
    this.getAllTask = function () {
        return $http.get("http://localhost:52073/TaskService.svc/GetAllTask");
    };

    //Get Single Task
    this.get = function (TaskID) {
        return $http.get("http://localhost:52073/TaskService.svc/GetTaskDetails/" + TaskID);
    }

    //Delete the Record
    this.delete = function (TaskID) {
        var request = $http({
            method: "delete",
            url: "http://localhost:52073/TaskService.svc/DeleteTask/" + TaskID
        });
        return request;
    }
});