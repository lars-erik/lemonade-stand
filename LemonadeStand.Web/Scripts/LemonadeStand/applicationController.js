(function() {

    function ApplicationController(scope, urlService, http) {
        var urls,
            gameId;

        scope.currentView = "";
        scope.day = {};
        scope.players = [];
        scope.choices = [];
        scope.report = {};
        scope.ogDescription = escape("Try Lemonade Stand");

        urlService.getUrls().then(function(result) {
            urls = result;
            scope.currentView = urls.views.createGame;
        });

        scope.$on("lemonade.start", function(evt, players) {
            http.post(
                urls.actions.createGame,
                { PlayerNames: $.map(players, function (p) { return p.name; }) }
            ).success(function(data) {
                var i;

                gameId = data.Id;
                scope.players = players;
                scope.currentView = urls.views.welcome;

                for (i = 0; i < scope.players.length; i++) {
                    scope.players[i].assets = 200;
                }
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
                var i;

                scope.report = data;
                scope.currentView = urls.views.financialReport;
                $("body").addClass(scope.report.EventName.replace(/ /gi, "").toLowerCase());

                for (i = 0; i < scope.players.length; i++) {
                    scope.players[i].assets += scope.report.Results[i].Profits;
                }

                scope.ogDescription = scope.players[0].name + ' made $' + (scope.players[0].assets / 100) + ' selling lemonade. Have a go, maybe you\'ll get rich!';
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
                $("body").attr("class", scope.day.Weather.Name.replace(/ /gi, "").toLowerCase());
            });
        }

        scope.newGame = function() {
            scope.currentView = urls.views.createGame;
        }

        scope.input = function() {
            scope.currentView = urls.views.input;
        }

        scope.share = function() {
            FB.ui(
              {
                  method: 'feed',
                  name: 'Lemonade Stand',
                  link: 'http://lemonade.aabech.no',
                  picture: 'http://lemonade.aabech.no/content/images/share.jpg',
                  description: scope.ogDescription,
                  display: "popup"
              },
              function (response) {
              }
            );
        }
    }

    angular.module("lemonade").controller("applicationController", [
        "$scope",
        "urlService",
        "$http",
        ApplicationController
    ]);

}());