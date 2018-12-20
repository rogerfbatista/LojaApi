
var app = angular.module("myApp", ["ngRoute", 'ngResource']);
app.config(function ($routeProvider, $locationProvider) {

    debugger;

    $locationProvider.hashPrefix('!');

    $routeProvider
        .when("/", {
            controller: "itiController",
            templateUrl: "/App/views/Iti.html"

        })

});
