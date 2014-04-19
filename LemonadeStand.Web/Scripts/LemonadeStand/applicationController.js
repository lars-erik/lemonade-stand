(function() {

    function ApplicationController(scope, urlService, http) {
        var urls,
            gameId;

        scope.currentView = "";
        scope.day = {};
        scope.players = [];
        scope.choices = [];
        scope.report = {};

        urlService.getUrls().then(function(result) {
            urls = result;
            scope.currentView = urls.views.createGame;
        });

        scope.$on("lemonade.start", function(evt, players) {
            http.post(
                urls.actions.createGame,
                { PlayerNames: $.map(players, function (p) { return p.name; }) }
            ).success(function(data) {
                gameId = data.Id;
                scope.players = players;
                scope.currentView = urls.views.welcome;
            });
        });

        scope.$on("lemonade.finishDay", function (evt, choices) {
            scope.choices = choices;
            http.post(
                urls.actions.finishDay,
                {
                    Id: gameId,
                    Choices: choices
                }
            ).success(function(data) {
                scope.report = data;
                scope.currentView = urls.views.financialReport;
            });
        });

        scope.nextDay = function() {
            var args = { Id: gameId };
            http.post(
                urls.actions.nextDay,
                args
            ).success(function (data) {
                scope.day = data;
                scope.currentView = urls.views.weatherForecast;
            });
        }

        scope.input = function() {
            scope.currentView = urls.views.input;
        }
    }

    angular.module("lemonade").controller("applicationController", [
        "$scope",
        "urlService",
        "$http",
        ApplicationController
    ]);

}());