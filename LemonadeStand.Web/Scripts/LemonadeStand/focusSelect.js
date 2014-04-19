(function() {

    angular.module("lemonade")
        .directive("ngFocusSelect", function() {
            return {
                link: function(scope, element, attrs) {
                    $(element).on("focus", function() {
                        $(this).select();
                    });
                }
            }
        });

}());