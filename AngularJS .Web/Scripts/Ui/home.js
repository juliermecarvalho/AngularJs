/// <reference path="../jquery-1.7.2.js" />
/// <reference path="../angular.js" />

function homeController($scope, $window, $http) {


    var salvar = function() {
        $http.post('api/pessoa', $scope.DtoPessoa).success(function(data, status) {
            if (status === 201) {

                console.log($scope.dtoPessoas);
                get();

            }
        }).error(function(data, status) {
            console.log('Error: ' + status);
        });
    };

    $scope.salvar = function() {
           salvar();
    };

    $scope.excluir = function(dto) {
        $http.delete('api/pessoa/'+ dto.Id).success(function(data, status) {
            get();

        }).error(function(data, status) {
            console.log('Error: ' + status);
        });
        //$http({ method: 'DELETE', url: 'api/pessoa/' + dto.Id }).
        //    success(function(data, status, headers, config) {
        //         this callback will be called asynchronously
        //         when the response is available
        //    }).
        //    error(function(data, status, headers, config) {
        //         called asynchronously if an error occurs
        //         or server returns response with status
        //         code outside of the <200, 400) range
        //    });
        //$.ajax({
        //    type: 'DELETE',
        //    url: 'api/pessoa/' + dto.Id,
        //    cache: false,
        //    statusCode: {
        //        200: function (data) {
                    
        //        }
        //    }
        //});
    };

    $scope.editar = function(dto) {
        $scope.DtoPessoa = dto;
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
        $scope.DtoPessoa = {
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