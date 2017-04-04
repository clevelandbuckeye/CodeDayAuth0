angular.module('codedayapp.login', ['auth0'])
    .controller('LoginCtrl', function ($scope, auth, $location) {
        $scope.login = function () {
            auth.signin({}, function (profile, token) {
                $location.path('/');
            }, function (error) {
                console.log("there was an error", error);
                //alert('error either profile or password is incorrect')
            });
        }
    });