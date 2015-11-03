app.controller("RoshamboController", ["$scope", "$http", function($scope, $http) {
    $scope.humanPlayer = true;
    $scope.selectedMove = 1;

    $scope.getResult = function (move) {
        if (!$scope.humanPlayer) {
            $scope.selectedMove = Math.floor(Math.random() * 3);
        } else {
            $scope.selectedMove = move;
        }
        $http({ method: "POST", url: "/Home/PlayMove?playerMove=" + $scope.selectedMove + "&isPlayerHuman=" + $scope.humanPlayer })
        .success(function(data) {
            alert(data.ResultText);
            });
    };

    $scope.setGameUp = function(isHumanGame) {
        if (!isHumanGame) {
            $scope.humanPlayer = false;
            $("#mainGame").hide();
            $("#cpuGame").show();
        } else {
            $scope.humanPlayer = true;
            $("#mainGame").hide();
            $("#humanGame").show();
        }
    };
}]);