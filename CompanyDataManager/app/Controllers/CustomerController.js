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
        $scope.addForm.$setPristine();
        $scope.addForm.$setUntouched();
    }

    $scope.clearForm = function () {
        clearInput();
    }

}]);