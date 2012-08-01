/// <reference path="../jquery-1.7.2.js" />
/// <reference path="../angular.js" />

function homeController($scope, $window, $http) {
    
    $scope.salvar = function () {
        if ($scope.formHome.$valid) {
            salvar();
        }
    };

    $scope.excluir = function(dto) {
        $http.delete('/api/pessoa/' + dto.Id).success(function (data, status) {
            if (status === 200) {
                get();
            }
        }).error(function(data, status) {
            console.log('Error: ' + status);
        });
      
    };

    $scope.editar = function(dto) {
        $scope.dtoPessoa = dto;
    };

    var get = function() {
        $scope.dtoPessoas = [];
        $http.get('api/pessoa').success(function(pessoas, status) {
            $.each(pessoas, function (i, pessoa) {
                $scope.dtoPessoas.push(pessoa);
            });
            reset();
        });
    };
    
    var salvar = function () {
        $http.post('api/pessoa', $scope.dtoPessoa).success(function (data, status) {
            if (status === 201) {
                get();
            }
        }).error(function (data, status) {
            console.log('Error: ' + status);
        });
    };
    
    var reset = function() {
        $scope.dtoPessoa = {
            Id: '',
            Nome: '',
            Sexo: ''
        };
    };

    (function() {
        reset();        
        get();
       
    })();
    

    
    
}