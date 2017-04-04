angular.module('codedayapp.home', ['auth0'])
    .controller('HomeCtrl', function ($scope, auth, $location) {
        $scope.userprofile = [];
        $scope.auth = auth;

        $scope.logout = function () {
            auth.signout();
            $location.path('/login');
        }
    });