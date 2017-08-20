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

 		var vm = this;

 		vm.nomeCliente = "";
 		vm.cartaoCredito = "";
 		vm.cvv = "";
 		vm.dataExpiracao = "";
 		
 		$scope.result = 'cliente';

 		vm.enviaDadosCliente = function() {
 			return $http.post("http://550781e5.ngrok.io/api/register/buyer", 
 				/*data: {
 					Card: {
 						HolderName: vm.nomeCliente,
 						Number: vm.cartaoCredito,
 						Cvv: vm.cvv,
 						ExpirationDate: vm.dataExpiracao
 					},
 					FacebookKey: ,
 					FacebookId: ,
 				}*/
 				).then(function (resp) {
 					vm.data = resp;
 				});
 			}
 		}]);
