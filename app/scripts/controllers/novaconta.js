'use strict';

/**
 * @ngdoc function
 * @name appApp.controller:NovacontaCtrl
 * @description
 * # NovacontaCtrl
 * Controller of the appApp
 */
 angular.module('appApp')
 .controller('NovacontaCtrl', ['$scope', '$http',
 	function ($scope, $http) {
 		$scope.result = 'pass';

 		/*var getURL = "http://01fdb59a.ngrok.io/api/values";
 		//getURL = "http://01fdb59a.ngrok.io/api/register/buyer";
 		//getULR = "http://01fdb59a.ngrok.io/api/register/seller";


 		$http
 		.get(getURL)
 		.then(function (response) {
 			$scope.data = response;
 			console.log(response);
 		});*/

 	}]);
