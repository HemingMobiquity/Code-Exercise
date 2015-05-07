/// <reference path="Modules.js" />
/// <reference path="Services.js" />

app.controller("Angular_RESTController", function ($scope, AngularJs_RESTService) {

    $scope.mode = 1;    //for state of edit, delete etc.

    GetAllRecords();
    //To Get All Tasks
    function GetAllRecords() {
        var promiseGet = AngularJs_RESTService.getAllTask();
        promiseGet.then(function (pl) { $scope.Tasks = pl.data },
              function (errorPl) {
                  console.error('Some Error in Getting Records.', errorPl);
              });
    }

    //To Clear all input controls.
    function ClearModels() {
        $scope.mode = 1;
        $scope.TaskID = "";
        $scope.Name = "";
        $scope.City = "";
        $scope.State = "";
    }

    //To Create new record and Edit an existing Record.
    $scope.save = function () {
        var Task = {
            Name: $scope.Name,
            City: $scope.City,
            State: $scope.State
        };
        if ($scope.mode === 1) {
            var promisePost = AngularJs_RESTService.post(Task);
            promisePost.then(function (pl) {
                $scope.TaskID = pl.data.TaskID;
                GetAllRecords();

                ClearModels();
            }, function (err) {
                console.log("Some error Occured" + err);
            });
        } else {
            //Edit the record    
            debugger;
            Task.TaskID = $scope.TaskID;
            var promisePut = AngularJs_RESTService.put($scope.TaskID, Task);
            promisePut.then(function (pl) {
                $scope.Message = "Task Updated Successfuly";
                GetAllRecords();
                ClearModels();
            }, function (err) {
                console.log("Some Error Occured." + err);
            });
        }
    };

    //To Get Task Detail on the Base of Task ID
    $scope.get = function (Task) {
        var promiseGetSingle = AngularJs_RESTService.get(Task.TaskID);
        promiseGetSingle.then(function (pl) {
            var res = pl.data;
            $scope.TaskID = res.TaskID;
            $scope.Name = res.Name;

            $scope.City = res.City;
            $scope.State = res.State;
            $scope.mode = 0;
        },
                  function (errorPl) {
                      console.log('Some Error in Getting Details', errorPl);
                  });
    }

    //To Delete Record
    $scope.delete = function (Task) {
        var promiseDelete = AngularJs_RESTService.delete(Task.TaskID);
        promiseDelete.then(function (pl) {
            $scope.Message = "Task Deleted Successfuly";
            GetAllRecords();
            ClearModels();
        }, function (err) {
            console.log("Some Error Occured." + err);
        });
    }
});