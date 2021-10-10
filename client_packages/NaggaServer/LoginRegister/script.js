app.controller('loginRegisterController',
    function ($scope, $window, toastr) {
        $scope.tabs = {
            Login: 'Login',
            Register: 'Register'
        }

        $scope.activeTab = null;

        $scope.loginForm = {
            Username: "",
            Password: ""
        };

        $scope.registerForm = {
            Username: "",
            Email: "",
            Password: ""
        };

        $scope.register = function () {
            var registerModeljson = JSON.stringify($scope.registerForm);
            $window.mp.trigger('registerInformationToServer', registerModeljson);
        };

        $scope.login = function () {
            var loginModelJson = JSON.stringify($scope.loginForm);
            $window.mp.trigger('loginInformationToServer', loginModelJson);
        };

        $scope.showToastrMessage = function (message, toastrType) {
            switch (toastrType) {
                case 0:
                    toastr.success(message);
                case 1:
                    toastr.info(message);
                case 2:
                    toastr.warning(message);
                case 3:
                    toastr.error(message);
            }
        };

        $scope.setActiveTab = function (activeTab) {
            $scope.activeTab = activeTab;
        };

        //Main function used for external calls from javascript
        $scope.executeAction = function(action, ...params){
            $scope[action](params);
        }

        $scope.init = function () {
            $scope.activeTab = $scope.tabs.Login;
        }

        $scope.init();
    });

function showToastrMessage(...args) {
    angular.element(document.getElementById('loginRegisterController')).scope().showToastrMessage(args[0], args[1]);
}