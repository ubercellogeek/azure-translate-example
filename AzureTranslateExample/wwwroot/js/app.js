(function () {
    'use strict';
    angular.module('translatorApp', ['ui.materialize', 'ngAnimate', 'ngSanitize','dndLists'])
.filter('newlines', function(){
  return function(text){
     if(text == undefined) { return ''; }
     return text.replace(/\n/g, '<br/>');
  }
})
    .controller('mainCtrl', ["$scope","$http","$location", function ($scope,$http,$location) {
      var apiURI = $location.protocol() + "://" + $location.host() + ":" + $location.port() + "/api/translation";

        // variables
        $scope.models = {
            selected: null,
            lists: { "dstLanguages": [] }
        };
 
      $scope.translateBtnText = "Translate";
      $scope.languages = [];
      $scope.language = 'en';
      $scope.sourceText = "";
      $scope.hideButton = true;
      $scope.queryRunning = false;
      $scope.hideTranslationResult = true;
      $scope.cardClass = "card";
      $scope.dstLanguage = null;

      // methods
      var loadLanguages = function(){
         
          $http.get(apiURI + "/languages")
              .then(
              function (result) {
                  $scope.languages = result.data;
              },
              function (result) {

              }
              );
      }

      $scope.addDstLanguage = function () {
          if ($scope.dstLanguage != null) {
              $scope.models.lists.dstLanguages.push($scope.dstLanguage);
              $scope.dstLanguage = null;
              $scope.textChanged();
          }
      }

      $scope.textChanged = function(){
        if($scope.sourceText.length === 0 || $scope.models.lists.dstLanguages.length === 0){
            $scope.hideButton = true;
            $scope.queryRunning = false;
            $scope.hideTranslationResult = true;
            $scope.cardClass = "card";
            $scope.resultText = "";
        }
        else{
            $scope.hideButton = false;
        }
      }

      var resetUI = function(success,result){
          if(success === true){
            $scope.resultText = result.data.text;

            if(result.data.success == false){
                $scope.cardClass = "card red darken-4 white-text";
                $scope.resultText = "ERROR: " + result.data.message;
            }

            $scope.queryRunning = false;
            $scope.translateBtnText = "Translate";
            $scope.hideTranslationResult = false;
          }
          else{
            $scope.queryRunning = false;
            $scope.translateBtnText = "Translate";
            $scope.cardClass = "card red darken-4 white-text";
            $scope.resultText = "There was a fatal error error while calling the API.";
            $scope.resultStyle="color:red;font-weight:bold;";
            $scope.hideTranslationResult = false;
          }
      };

      $scope.translate = function(){
          $scope.queryRunning = true;

          $scope.translateBtnText = "Translating..."
          $http.post(apiURI, { "FromLanguageISOCode": $scope.language.isoCode, "ToLanguageISOCode": $scope.models.lists.dstLanguages.map(function (a) { return a.isoCode }), "Text": $scope.sourceText })
          .then(
              function(result){
                resetUI(true,result);
              },
              function(result){
                resetUI(false, result);
              }
          );
      }

      // Init
      loadLanguages();
    }]);
})();



