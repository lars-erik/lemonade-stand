(function() {

    function InputController(scope) {
        var playerIndex = 0,
            choices = [];

        function reset() {
            scope.glasses = null;
            scope.signs = null;
            scope.price = null;
            scope.minGlasses = 0;
            scope.maxGlasses = 1000;
            scope.minSigns = 0;
            scope.maxSigns = 1000;
        }

        scope.player = scope.players[0];
        reset();

        scope.nextCaption = scope.players.length > 1 ? "Next player" : "OK";

        scope.confirm = function() {
            choices[playerIndex] = {
                Glasses: scope.glasses,
                Signs: scope.signs,
                Price: scope.price
            };

            if (playerIndex < scope.players.length - 1) {
                playerIndex++;
                scope.player = scope.players[playerIndex];
                reset();
            } else {
                scope.$emit("lemonade.finishDay", choices);
            }
        }
    }

    angular.module("lemonade").controller("inputController", ["$scope", InputController]);

}());