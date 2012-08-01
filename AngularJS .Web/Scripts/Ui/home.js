﻿/// <reference path="../jquery-1.7.2.js" />
/// <reference path="../angular.js" />

function homeController($scope, $window, $http) {


    var salvar = function () {
        $http.post('api/pessoa', $scope.dtoPessoa).success(function(data, status) {
            if (status === 201) {
                get();
            }
        }).error(function(data, status) {
            console.log('Error: ' + status);
        });
    };

    $scope.salvar = function () {
        if ($scope.formHome.$valid) {
            salvar();
        }
    };

    $scope.excluir = function(dto) {
        $http.delete('/api/pessoa/' + dto.Id).success(function (data, status) {
            get();
        }).error(function(data, status) {
            console.log('Error: ' + status);
        });
      
    };

    $scope.editar = function(dto) {
        $scope.dtoPessoa = dto;
    };

    function get() {
        $scope.dtoPessoas = [];
        $http.get('api/pessoa').success(function (data, status) {
            $.each(data, function (i, d) {
                $scope.dtoPessoas.push(d);
            });
            reset();
        });
    }

    var reset = function() {
        $scope.dtoPessoa = {
            Id: '',
            Nome: '',
            Sexo: ''
        };
    };

    var init = function() {
        reset();        
        get();
       
    };
    

    init();
    
}