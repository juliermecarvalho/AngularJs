/// <reference path="../jquery-1.7.2.js" />
/// <reference path="../angular.js" />

var homeController = function ($scope, $window, $http) {
    
    $scope.salvar = function () {
        if ($('form').valid()) {
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

    $scope.editar = function (dto) {
        console.log(dto);
        $scope.DtoPessoa = dto;
    };

    var get = function() {
        $scope.DtoPessoas = [];
        $http.get('api/pessoa').success(function(pessoas, status) {
            $.each(pessoas, function (i, pessoa) {
                $scope.DtoPessoas.push(pessoa);
            });
            reset();
        });
    };
    
    var salvar = function () {
        $http.post('api/pessoa', $scope.DtoPessoa).success(function (data, status) {
            if (status === 201) {
                get();
            }
        }).error(function (data, status) {
            console.log('Error: ' + status);
        });
    };
    
    var reset = function() {
        $scope.DtoPessoa = {
            Id: '',
            Nome: '',
            Sexo: '',
            DescricaoSexo: ''
        };
    };

    (function() {
        reset();        
        get();
        
        
    })();
    

    
    
}

