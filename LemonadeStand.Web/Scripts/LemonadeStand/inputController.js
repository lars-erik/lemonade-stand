(function() {

    function InputController(scope) {
        var playerIndex = 0,
            choices = [];

        function reset() {
            scope.glasses = null;
            scope.signs = null;
            scope.price = null;
            scope.minGlasses = 0;
            scope.maxGlasses = Math.floor(scope.players[playerIndex].assets / scope.day.LemonadeCost);
            scope.minSigns = 0;
            scope.maxSigns = Math.floor(scope.players[playerIndex].assets / 15);
        }

        scope.player = scope.players[0];
        reset();

        scope.nextCaption = scope.players.length > 1 ? "Next player" : "OK";

        scope.$watch("glasses", function() {
            scope.maxSigns = Math.floor((scope.players[playerIndex].assets - (scope.glasses * scope.day.LemonadeCost)) / 15);
        });

        scope.$watch("signs", function() {
            scope.maxGlasses = Math.floor((scope.players[playerIndex].assets - (scope.signs * 15)) / scope.day.LemonadeCost);
        });

        scope.confirm = function () {
            if (scope.inputForm.$invalid) {
                return;
            }

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