angular.module('codedayapp', ['auth0', 'ngRoute', 'codedayapp.home', 'codedayapp.login', 'ngMaterial'])
    .config(function ($routeProvider, authProvider) {
        $routeProvider.when('/', {
            controller: 'HomeCtrl',
            templateUrl: 'components/home/home.html',
            requiresLogin: true
        }).when('/login', {
            controller: 'LoginCtrl',
            templateUrl: 'components/login/login.html'
        });
        authProvider.init({
            domain: AUTH0_DOMAIN,
            clientID: AUTH0_CLIENT_ID,
            loginUrl: '/login'
        })
    })
    .run(function (auth) {
        auth.hookEvents();
    });