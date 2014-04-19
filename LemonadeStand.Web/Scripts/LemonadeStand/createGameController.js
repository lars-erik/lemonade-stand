(function() {

    function CreateGameController(scope) {
        scope.playerCount = 1;
        scope.players = [];
        scope.view = 1;

        scope.enterPlayers = function() {
            var i;
            for (i = scope.players.length; i < scope.playerCount; i++) {
                scope.players[i] = { name: "Player " + (i + 1) };
            }
            scope.players.splice(scope.playerCount, scope.players.length - scope.playerCount);
            scope.view = 2;
        }

        scope.changePlayerCount = function() {
            scope.view = 1;
        }

        scope.startGame = function () {
            scope.view = 3;
            scope.$emit("lemonade.start", scope.players);
        }
    }

    angular.module("lemonade").controller("createGameController", ["$scope", CreateGameController]);

}());