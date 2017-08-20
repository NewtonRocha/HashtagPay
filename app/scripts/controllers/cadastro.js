'use strict';

/**
 * @ngdoc function
 * @name appApp.controller:CadastroCtrl
 * @description
 * # CadastroCtrl
 * Controller of the appApp
 */
angular.module('appApp')
 .controller('CadastroCtrl', ['$window',
 	function($window) {

  		var self = this;

 		function statusChangeCallback(response) {
 			if (response.status === 'connected') {
 				hashtagpay(response);
 				rediretToHome();
 			}
 		}
 		
		// This function is called when someone finishes with the Login
		// Button.  See the onlogin handler attached to it in the sample
		// code below.
		self.checkLoginState = function () {
			FB.getLoginStatus(function(response) {
				statusChangeCallback(response);
				console.log(response);
			});
		}
		window.fbAsyncInit = function() {
			FB.init({
				appId      : '1946077955668680',
		cookie     : true,  // enable cookies to allow the server to access the session
		xfbml      : true,  // parse social plugins on this page
		version    : 'v2.8' // use graph api version 2.8
		});

			FB.getLoginStatus(function(response) {
				statusChangeCallback(response);
			});

			FB.Event.subscribe('auth.login', function(){
				rediretToCreateAccount();
			});
		};

		function rediretToHome() {
			$window.location.href = '/';
		}

		function rediretToCreateAccount() {
			$window.location.href = '#!/novaconta';
		}

		// Load the SDK asynchronously
		(function(d, s, id) {
			var js, fjs = d.getElementsByTagName(s)[0];
			if (d.getElementById(id)) return;
			js = d.createElement(s); js.id = id;
			js.src = "//connect.facebook.net/pt_BR/sdk.js";
			fjs.parentNode.insertBefore(js, fjs);
		}(document, 'script', 'facebook-jssdk'));
		var data = null;

		function hashtagpay(response) {
			var authResponse = response['authResponse']
			self.data = {
				"FacebookId": authResponse['userID'],
				"FacebookKey": authResponse['accessToken']
			}
		};
    
  }]);
