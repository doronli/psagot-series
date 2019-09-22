// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const app = angular.module('moviesFilterApp', []);

app.controller('myCtrl', function ($scope, $http) {
    $scope.seriesAndMovies = [];
    $scope.orderBy = 'title';

    // get the movies and series data
    $http.get("./Home/GetMovies")
        .then(res => {
            $scope.seriesAndMovies = res.data;

            //console.log($scope.seriesAndMovies);
        });

    // order the data by user choice
    $scope.OrderBy = orderBy => {
        $scope.orderBy = orderBy;
        //console.log($scope.orderBy);
    }

    // moving to Series Details
    $scope.SeriesDetails = movie => {
        $scope.movieDetails = movie;
        document.getElementById("modal-img").src = "/Images/" + movie.imagePath;
        document.getElementById("modal-numOfSeason").innerHTML = movie.numOfSeason;
        document.getElementById("modal-views").innerHTML = movie.views;
        document.getElementById("modal-details").innerHTML = movie.details;
        document.getElementById("modal-title").innerHTML = movie.title;

        $("#modal-movie-detail").modal('show');
    }

});

//app.controller('modalController', ['$scope', function ($scope) {

//}]);