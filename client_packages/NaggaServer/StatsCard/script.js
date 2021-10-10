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

function showStatsCard(...args) {
    angular.element(document.getElementById('statsCardController')).scope().showStatsCard(args[0]);
}