var noteShareModule = angular.module('NoteShareModule', ['ngRoute']);

noteShareModule.config(function($routeProvider) {

    $routeProvider.when('/', {
        controller: 'notesListController',
        templateUrl: '/HtmlTemplates/notesList.html'
    })
    .when('/note/:id', {
        controller: 'noteDetailsController',
        templateUrl: '/HtmlTemplates/noteDetails.html'
    })
    .when('/addNote', {
        controller : 'noteAddNewController',
        templateUrl : '/HtmlTemplates/noteAddnew.html'
    })
    .when('/addCommet/:id', {
        controller : 'noteAddCommentController'
    });
}).
directive('newComment', function ()
{
    return {
        restrict: 'AE',
        templateUrl : '/HtmlTemplates/newComment.html'
    }
});