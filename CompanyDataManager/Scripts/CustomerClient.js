var app = angular.module('app', [])

app.factory('CustomerService', ['$http', '$q', function ($http, $q) {
    var service = {};

    service.getCustomers = function () {
        var deferred = $q.defer();
        $http.get('/Customer/GetCustomers').then(function (result) {
            deferred.resolve(result.data);
        }, function () {
            deferred.reject();
        });
        return deferred.promise;
    };

    service.getCustomerById = function (id) {
        var deferred = $q.defer();
        $http.get('/Customer/Details/' + id).then(function (result) {
            deferred.resolve(result.data);
        }, function () {
            deferred.reject();
        });
        return deferred.promise;
    };

    service.addCustomer = function (customer) {
        var deferred = $q.defer();
        $http.post('/Customer/Create', customer).then(function () {
            deferred.resolve();
        }, function () {
            deferred.reject();
        });
        return deferred.promise;
    };

    service.editCustomer = function (customer) {
        var deferred = $q.defer();
        $http.post('/Customer/Edit', customer).then(function () {
            deferred.resolve();
        }, function () {
            deferred.reject();
        });
        return deferred.promise;
    };

    service.deleteCustomer = function (id) {
        var deferred = $q.defer();
        $http.post('/Customer/Delete', { id: id }).then(function () {
            deferred.resolve();
        }, function () {
            deferred.reject();
        });
        return deferred.promise;
    };

    return service;
}]);

app.controller('CustomerController', ['$scope', 'CustomerService', function ($scope, CustomerService) {
    $scope.customers = [];

    getData();

    function getData() {
        CustomerService.getCustomers().then(function (result) {
            $scope.customers = result;
        });
    }

    $scope.deleteCustomerRequest = function (customer) {
        $scope.customer = customer;
    }

    $scope.deleteCustomer = function (id) {
        CustomerService.deleteCustomer(id).then(function () {
            getData();
            angular.element('#deleteModal').modal('hide');
        });

    }

    $scope.addCustomer = function (customer) {
        CustomerService.addCustomer(customer).then(function () {
            getData();
            angular.element('#addModal').modal('hide');
            clearInput();
        });
    }

    $scope.customer = {};
    $scope.editCustomer = function (id) {
        CustomerService.getCustomerById(id).then(function (result) {
            $scope.customer = result;
        });
    }

    $scope.updateCustomer = function (customer) {
        CustomerService.editCustomer(customer).then(function () {
            getData();
            angular.element('#updateModal').modal('hide');
        });
    }

    function clearInput() {
        $scope.customer = {};
        //$scope.addForm.PhoneNumber = '';
        $scope.addForm.$setPristine();
        $scope.addForm.$setUntouched();
    }

    $scope.clearForm = function () {
        clearInput();
    }

}]);