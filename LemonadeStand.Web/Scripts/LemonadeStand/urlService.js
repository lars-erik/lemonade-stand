(function() {

    function UrlService(urlServiceUrl, http, q) {
        //return function () {
            var cachedUrls = null;

            this.getUrls = function() {
                var deferred = q.defer();
                if (cachedUrls === null) {
                    http.get(urlServiceUrl)
                        .success(function(data) {
                            cachedUrls = data;
                            deferred.resolve(cachedUrls);
                        });
                } else {
                    deferred.resolve(cachedUrls);
                }
                return deferred.promise;
            }
        //}
    }

    angular.module("lemonade").service("urlService", ["urlServiceUrl", "$http", "$q", UrlService]);

}());