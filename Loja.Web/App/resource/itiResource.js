


angular.module('myApp').factory('itiService', ['$resource',
    function ($resource) {



        return $resource('/api/v1/Iti/:texto',
            { texto: '@texto' },
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            },
            {
                "update": { method: "PUT", isArray: true },
                "save": { method: "POST", isArray: true },

            }
        );
    }]);









