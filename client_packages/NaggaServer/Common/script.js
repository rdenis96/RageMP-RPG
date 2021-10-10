//common variables

var clientPages = {
    None: "None",
    LoginRegister: "LoginRegister",
    StatsCard: "StatsCard"
};

//declaration for main Angularjs Module

var app = angular.module('naggaApp', ['toastr']);
app.config([
    'toastrConfig',
    function (toastrConfig) {
        angular.extend(toastrConfig, {
            autoDismiss: true,
            maxOpened: 1,
            newestOnTop: true,
            showMethod: 'slideDown',
            hideMethod: 'slideUp',
            positionClass: 'toast-top-center',
            preventDuplicates: true,
            preventOpenDuplicates: true,
            target: 'body',
            closeButton: true,
            extendedTimeOut: 0,
            timeOut: 5000
        });
    }]);

// Main Controller 
app.controller('mainController',
    function ($scope, $window, toastr) {
        $scope.clientPages = {
            None: "None",
            LoginRegister: "LoginRegister",
            StatsCard: "StatsCard"
        };

        // var templateUrl = $sce.getTrustedResourceUrl('external_static_template.html');
        // $templateRequest(templateUrl).then(function(template) {
        //     // template is the loaded HTML template as a string
        //     $scope.myHTML = template;
        // }, function() {
        //     // An error has occurred
        // });

        $scope.activePage = $scope.clientPages.None;

        $scope.showPage = function(clientPage = clientPages.None){
            switch(clientPage){
                case $scope.clientPages.LoginRegister:
                case $scope.clientPages.StatsCard:
                    $scope.activePage = clientPage;
                    break;
                default:
                    $scope.activePage = clientPages.None;
                    break;
            }
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

    });


// Login Register Controller
app.controller('loginRegisterController',
    function ($scope, $window) {
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

        $scope.setActiveTab = function (activeTab) {
            $scope.activeTab = activeTab;
        };

        $scope.init = function () {
            $scope.activeTab = $scope.tabs.Login;
        }

        $scope.init();
    });

// Stats Card Controller
app.controller('statsCardController',
    function ($scope, $window) {
        $scope.stats = {
            Name: "",
            Faction: "",
            FactionColor: "",
            NameTag: "",
            Age: 0,
            BankMoney: "",
            Money: "",
            Job: "",
            Level: 1,
            PhoneNumber: 0,
            RespectPoints: 0,
            Sex: ""
        };

        $scope.isEmptyOrSpaces = function(str){
            return str === null || str.match(/^ *$/) !== null;
        }

        $scope.showStatsCard = function (statsJson) {
            var stats = JSON.parse(statsJson);
            angular.copy(stats, $scope.stats);
            $scope.$apply();
        }
    });

function showStatsCard(clientPage, statsJson) {
    var clientPageController = getPageController(clientPage);
    angular.element(document.getElementById(clientPageController)).scope().showStatsCard(statsJson);
}

function showToastrMessage(clientPage, message, toastrType) {
    angular.element(document.getElementById('mainController')).scope().showToastrMessage(message, toastrType);
}

function showPage(clientPage) {
    angular.element(document.getElementById('mainController')).scope().showPage(clientPage);
}

function getPageController(clientPage){
    var clientPageController = 'mainController';
    switch(clientPage){
        case clientPages.LoginRegister:
            clientPageController = 'loginRegisterController';
            break;
        case clientPages.StatsCard:
            clientPageController = 'statsCardController';
            break;
        default:
            clientPageController = 'mainController';
            break;
    }
    return clientPageController;
}
