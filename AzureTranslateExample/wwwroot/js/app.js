(function () {
    'use strict';
angular.module('translatorApp', ['ui.materialize','ngAnimate'])
    .controller('mainCtrl', ["$scope","$http","$location", function ($scope,$http,$location) {
      var apiURI = $location.protocol() + "://" + $location.host() + ":" + $location.port() + "/api/translation";
      
      // variables
      $scope.translateBtnText = "Translate";
      $scope.langText = {
        "af": {
        "name": "Afrikaans",
        "dir": "ltr"
        },
        "ar": {
        "name": "Arabic",
        "dir": "rtl"
        },
        "bg": {
        "name": "Bulgarian",
        "dir": "ltr"
        },
        "bn": {
        "name": "Bangla",
        "dir": "ltr"
        },
        "bs": {
        "name": "Bosnian",
        "dir": "ltr"
        },
        "ca": {
        "name": "Catalan",
        "dir": "ltr"
        },
        "cs": {
        "name": "Czech",
        "dir": "ltr"
        },
        "cy": {
        "name": "Welsh",
        "dir": "ltr"
        },
        "da": {
        "name": "Danish",
        "dir": "ltr"
        },
        "de": {
        "name": "German",
        "dir": "ltr"
        },
        "el": {
        "name": "Greek",
        "dir": "ltr"
        },
        "en": {
        "name": "English",
        "dir": "ltr"
        },
        "es": {
        "name": "Spanish",
        "dir": "ltr"
        },
        "et": {
        "name": "Estonian",
        "dir": "ltr"
        },
        "fa": {
        "name": "Persian",
        "dir": "rtl"
        },
        "fi": {
        "name": "Finnish",
        "dir": "ltr"
        },
        "fil": {
        "name": "Filipino",
        "dir": "ltr"
        },
        "fj": {
        "name": "Fijian",
        "dir": "ltr"
        },
        "fr": {
        "name": "French",
        "dir": "ltr"
        },
        "he": {
        "name": "Hebrew",
        "dir": "rtl"
        },
        "hi": {
        "name": "Hindi",
        "dir": "ltr"
        },
        "hr": {
        "name": "Croatian",
        "dir": "ltr"
        },
        "ht": {
        "name": "Haitian Creole",
        "dir": "ltr"
        },
        "hu": {
        "name": "Hungarian",
        "dir": "ltr"
        },
        "id": {
        "name": "Indonesian",
        "dir": "ltr"
        },
        "it": {
        "name": "Italian",
        "dir": "ltr"
        },
        "ja": {
        "name": "Japanese",
        "dir": "ltr"
        },
        "ko": {
        "name": "Korean",
        "dir": "ltr"
        },
        "lt": {
        "name": "Lithuanian",
        "dir": "ltr"
        },
        "lv": {
        "name": "Latvian",
        "dir": "ltr"
        },
        "mg": {
        "name": "Malagasy",
        "dir": "ltr"
        },
        "ms": {
        "name": "Malay",
        "dir": "ltr"
        },
        "mt": {
        "name": "Maltese",
        "dir": "ltr"
        },
        "mww": {
        "name": "Hmong Daw",
        "dir": "ltr"
        },
        "nb": {
        "name": "Norwegian",
        "dir": "ltr"
        },
        "nl": {
        "name": "Dutch",
        "dir": "ltr"
        },
        "otq": {
        "name": "Querétaro Otomi",
        "dir": "ltr"
        },
        "pl": {
        "name": "Polish",
        "dir": "ltr"
        },
        "pt": {
        "name": "Portuguese",
        "dir": "ltr"
        },
        "ro": {
        "name": "Romanian",
        "dir": "ltr"
        },
        "ru": {
        "name": "Russian",
        "dir": "ltr"
        },
        "sk": {
        "name": "Slovak",
        "dir": "ltr"
        },
        "sl": {
        "name": "Slovenian",
        "dir": "ltr"
        },
        "sm": {
        "name": "Samoan",
        "dir": "ltr"
        },
        "sr-Cyrl": {
        "name": "Serbian (Cyrillic)",
        "dir": "ltr"
        },
        "sr-Latn": {
        "name": "Serbian (Latin)",
        "dir": "ltr"
        },
        "sv": {
        "name": "Swedish",
        "dir": "ltr"
        },
        "sw": {
        "name": "Kiswahili",
        "dir": "ltr"
        },
        "th": {
        "name": "Thai",
        "dir": "ltr"
        },
        "tlh": {
        "name": "Klingon",
        "dir": "ltr"
        },
        "to": {
        "name": "Tongan",
        "dir": "ltr"
        },
        "tr": {
        "name": "Turkish",
        "dir": "ltr"
        },
        "ty": {
        "name": "Tahitian",
        "dir": "ltr"
        },
        "uk": {
        "name": "Ukrainian",
        "dir": "ltr"
        },
        "ur": {
        "name": "Urdu",
        "dir": "rtl"
        },
        "vi": {
        "name": "Vietnamese",
        "dir": "ltr"
        },
        "yua": {
        "name": "Yucatec Maya",
        "dir": "ltr"
        },
        "yue": {
        "name": "Cantonese (Traditional)",
        "dir": "ltr"
        },
        "zh-Hans": {
        "name": "Chinese Simplified",
        "dir": "ltr"
        },
        "zh-Hant": {
        "name": "Chinese Traditional",
        "dir": "ltr"
        }
      };

      $scope.languages = [];
      $scope.language = 'es';
      $scope.sourceText = "";
      $scope.hideButton = true;
      $scope.queryRunning = false;
      $scope.hideTranslationResult = true;
      $scope.cardClass = "card";

      // methods
      var loadLanguages = function(){
          var arr1 = Object.keys($scope.langText);
          var arr2 = Object.values($scope.langText);

          for (var index = 0; index < arr1.length; index++) {
              var item = { "value": arr1[index], "name": arr2[index].name };
              $scope.languages.push(item);
          }
      }
      
      $scope.textChanged = function(){
        if($scope.sourceText.length === 0){
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
          $http.post(apiURI, { "FromLanguageISOCode":"en", "ToLanguageISOCode":$scope.language, "Text": $scope.sourceText })
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



