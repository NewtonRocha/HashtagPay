'use strict';

/**
 * @ngdoc function
 * @name appApp.controller:LoginCtrl
 * @description
 * # LoginCtrl
 * Controller of the appApp
 */
 angular.module('appApp')
 .controller('LoginCtrl', ['$window',
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

			/*FB.Event.subscribe('auth.login', function(){
				rediretToHome();
			});*/
		};

		/*function rediretToHome() {
			$window.location.href = '/';
		}*/

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

	/*
	$.ajax({
	  type: 'POST',
	  //url: 'http://localhost:5000',
	  url: 'http://01fdb59a.ngrok.io/api/values',
	  data: JSON.stringify(data),
	  contentType: 'application/json; charset=utf-8',
	  success: function() {
		console.log('data is sent')
	  },
	  dataType: 'json'
	});
	*/
  /*$(document).ready(function() {
	$("#blaForm").submit(function(e) {
	  e.preventDefault();
	  console.log(data);
	  let tipo = $('input[name=type]:checked').val()
	  console.log(tipo)
	  if (tipo == 'comprador') {
		let card_number = $('input[name=card_number]').val()
		let cvv = $('input[name=cvv]').val()
		console.log(card_number)
		console.log(cvv)
		data["Card"] = {
		  "Number": card_number,
		  "Cvv": cvv,
		  "HolderName": "lalala",
		  "ExpirationDate": "nunca"
		};
		$.ajax({
		  type: 'POST',
		  //url: 'http://localhost:5000',
		  url: 'http://01fdb59a.ngrok.io/api/register/buyer',
		  data: JSON.stringify(data),
		  contentType: 'application/json; charset=utf-8',
		  success: function() {
			console.log("data is sent");
		  },
		  dataType: 'json'
		});
	  } else {
		let ag = $('input[name=ag]').val()
		let conta = $('input[name=conta]').val()
		console.log(ag)
		console.log(conta)
		data["BankAccount"] = {
		  "BankCode": "",
		  "Agencia": ag,
		  "AgenciaDv": "",
		  "Conta": conta,
		  "ContaDv": "",
		  "LegalName": "",
		  "DocumentNumber": ""
		};
		$.ajax({
		  type: 'POST',
		  //url: 'http://localhost:5000',
		  url: 'http://01fdb59a.ngrok.io/api/register/seller',
		  data: JSON.stringify(data),
		  contentType: 'application/json; charset=utf-8',
		  success: function() {
			console.log("data is sent");
		  },
		  dataType: 'json'
		});
	  }
	});
});*/

}]);
