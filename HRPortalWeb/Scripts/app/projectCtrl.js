(function () {
    'use strict';

var app = angular.module('app', []);//set and get the angular module
    app.controller('projectApiController', ['$scope', '$http', projectApiController]);

    //angularjs controller method
    function projectApiController($scope, $http) {

        //declare variable for mainain ajax load and entry or edit mode
        $scope.loading = true;
        $scope.addMode = false;
        $scope.updateMode = false;


        //get all customer information
        $http.get('/api/ProjectApi/GetProjects/').success(function (data) {
            $scope.projects = data;
            $scope.loading = false;
        })
       

        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });
        $scope.getById=function(){
            $http.get('api/ProjectApi/GetProject/' + this.project.Id).success(function (data) {
                $scope.updateMode = !$scope.updateMode;
                $scope.myProject = data;
            })
        };

        //by pressing toggleEdit button ng-click in html, this method will be hit
        $scope.toggleEdit = function () {
            this.projects.editMode = !this.projects.editMode;
        };

        //by pressing toggleAdd button ng-click in html, this method will be hit
        $scope.toggleAdd = function () {
            $scope.addMode = !$scope.addMode;
        };

        //update
        $scope.toggleUpdate=function() {
            $scope.updateMode = false;
        }

        //Insert Project
        $scope.add = function () {
            $scope.loading = true;
            $http.post('/api/ProjectApi/AddProject/', this.newproject).success(function (data) {
                alert("Added Successfully!!");
                $scope.addMode = false;
                $scope.projects.push(data);
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Adding Project! " + data.Message +data;
                $scope.loading = false;
            });
        };

        //Edit Project
        $scope.save = function () {
            alert("Edit");
            $scope.loading = true;
            var frien = this.project;  
            alert(frien);          
            $http.put('/api/ProjectApi/EditProject/' + frien.Id, frien).success(function (data) {
                alert("Saved Successfully!!");
                frien.editMode = false;
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving project! " + data;
                $scope.loading = false;
            });
        };

       //Delete Project
        $scope.deleteproject= function () {
            $scope.loading = true;
            var Id = this.project.Id;
            $http.delete('/api/ProjectApi/DeleteProject/' + Id).success(function (data) {
                alert("Deleted Successfully!!");
                $.each($scope.projects, function (i) {
                    if ($scope.projects[i].Id === Id) {
                        $scope.projects.splice(i, 1);
                        return false;
                    }
                });
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving Project! " + data;
                $scope.loading = false;
            });
        };

        $scope.updateproject = function () {
            $scope.loading = true;            
            $http.put('/api/ProjectApi/EditProject/', $scope.myProject).success(function (data) {
                alert("Saved Successfully!!");
               $scope.updateMode = false;
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while updating project! " + data;
                $scope.loading = false;
            });
        }

    }
})();