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