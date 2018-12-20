

(function (app) {

    debugger;
    app.controller("itiController", ['$scope', 'itiService', '$http', function ($scope, itiService, $http) {

        $scope.titulo = "ITI";


        $scope.listaIti = [];

        $scope.pesquisar = function () {

            itiService.query({ texto: $scope.texto }).$promise.then(
                function (response) {
                    $scope.listaIti = response
                });
        }


        $scope.download = function (arquivoNome) {


            $http.post('/api/v1/Iti', JSON.stringify(arquivoNome), { responseType: 'arraybuffer' })
                .then(function (data) {

                    var blob = new Blob([result]);
                    var link = document.createElement('a');
                    link.href = window.URL.createObjectURL(blob);
                    link.download = "myFileName.txt";
                    link.click();

                });


            }

            //itiService.save(JSON.stringify(arquivoNome), function (result) {
            //    debugger;
            //    var type = ".pdf";
            //    var link = document.createElement("a"); //set up anchor 

            //    link.setAttribute("target", "_blank");
            //    if (Blob !== undefined) {
            //        var blob = new Blob([result], { type: type });
            //        link.setAttribute("href", URL.createObjectURL(blob));
            //    } else {
            //        link.setAttribute("href", "data:.pdf," + encodeURIComponent(result));
            //    }
            //    var filename = "teste"
            //    link.setAttribute("download", filename);
            //    document.body.appendChild(link);
            //    link.click();
            //    document.body.removeChild(link);
            //},
            //    function (error) {

            //    });
        }

    }]);


})(app);