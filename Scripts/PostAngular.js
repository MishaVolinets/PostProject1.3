var app = angular.module("MyApp", ["ngRoute"]).config(function ($locationProvider,$routeProvider) {
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });


});
app.controller("PostCtrl", function ($scope, $http,$location) {
    $scope.isOpen = false;
    $scope.EPost = {};
    $scope.currentPost;
    var userId = $location.search();
    console.log(userId);
    $http.post('/Home/ShowUserPosts', {id: userId.UserId})
        .success(function (result) {
            $scope.Posts = result;
        });
    $scope.addPost = function (Post) {
        $http.post('/Home/SentPost', Post)
            .success(function (result) {
                $scope.Posts.unshift(result);
            });
    }
    $scope.deletePost = function (IdObj) {

        $http.post('/Home/DeletePost', { id: IdObj })
            .success(function (result) {
                var index;
                for (var i = 0; i < $scope.Posts.length; i++) {
                    if ($scope.Posts[i].Id == IdObj) {
                        index = i;
                        break;
                    }
                }
                $scope.Posts.splice(index, 1);
            });
    }
    $scope.editPost = function (Post) {
        $scope.currentPost = Post;
        $scope.EPost = angular.copy(Post);
    }
    $scope.saveEditedPost = function () {

        $http.post('/Home/SavePost', { model: $scope.EPost })
            .success(function (result) {
                $scope.currentPost = angular.extend($scope.currentPost, $scope.EPost);

            });
    }
    $scope.hidePopUp = function () {
        $("#PU-block").css("display", "none");
    }
});
app.controller("UserPageCtrl", function ($scope, $http, $location) {
    $scope.EditedUser = {}
    var params = $location.search();

    $http.post("/User/GetUserById", {UserId: params.UserId}).success(function (data) {
        $scope.User = data;
    });

    $scope.editUser = function (User) {
        $scope.currentUser = User;
        $scope.EditedUser = angular.copy(User);
    }
    $scope.SaveEditedUser = function () {
        $http.post("/User/SaveEditedPost", { user: $scope.EditedUser }).success(function (data) {
            $scope.currentUser = angular.extend($scope.currentUser, $scope.EditedUser);
        });

    }

});
app.controller("AllUsersCtrl", function ($scope, $http) {
    
    $http.get("/User/GetAllUsers").success(function (data) {
        $scope.Users = data;
    });

});