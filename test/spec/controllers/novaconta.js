'use strict';

describe('Controller: NovacontaCtrl', function () {

  // load the controller's module
  beforeEach(module('appApp'));

  var NovacontaCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    NovacontaCtrl = $controller('NovacontaCtrl', {
      $scope: scope
      // place here mocked dependencies
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(NovacontaCtrl.awesomeThings.length).toBe(3);
  });
});
