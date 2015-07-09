noteShareModule.controller('homeController', function($scope) {

})

.controller('notesListController', function($scope, $http) {
    
    $http.get('/api/NotesApi/List')
        .then(function (result) {

        $scope.note = result.data[0];
        $scope.notes = result.data;
    });
})

.controller('noteDetailsController', function($scope, $http, $routeParams) {

    $http.get('/api/NotesApi/Details/' + $routeParams.id)
        .then(function (result) {

            $scope.note = result.data;
        });
})

.controller('noteAddNewController', function ($scope, $http) {
    $scope.users;

    $http.get('api/UserApi/List').then(function (result) {
        $scope.users = result.data;
        //console.log($scope.users);
    });

    $scope.new_note = {
        Title: "",
        Text: "",
        UserId: ""
    };
    $scope.submit = function()
    {
        //posalji scope.new_note na api
        //console.log($scope.new_note.Text + " " + $scope.new_note.User);
        $http.post('api/NotesApi/Add', $scope.new_note)
        .success(function ()
        {
            window.location('/');
        })
        .error(function ()
        {
            window.location('/');
        });
    }
})

.controller('commentAddNewController', function ($scope, $http, $routeParams) {
    
    $scope.user_names = "";

    $scope.new_comment = {
        Text: "",
        UserId: "",
        Author:
            {
                CreatedOn: "",
                FullName: "",
                Id: "",
                IsPremiumUser: ""
            },
        NoteId: $routeParams.id
    };

    $http.get('api/UserApi/List').then(function (result) {
        $scope.users = result.data;
        $scope.user_names = angular.copy($scope.users);
    });

    $scope.submit = function ()
    {
        $scope.userId = angular.copy($scope.new_comment.user_Id);
        console.log($scope.user_Id + " ...1");
        console.log($scope.new_comment.userId + " ...6");
        if($scope.new_comment.Text != "" && $scope.new_comment.UserId != "")
            $http.post('api/CommentsApi/Add', $scope.new_comment)
            .success(function () {

                user_id = angular.copy($scope.new_comment.UserId);
                $scope.new_comment.Author = angular.copy($scope.user_names[user_id-1]); 
                $scope.note.Comments.push(angular.copy($scope.new_comment));

            })
            .error(function () {
                //jos nista...
            });
        else
        {
            //error treba bacit
        }
    }
});