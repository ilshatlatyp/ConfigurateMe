/// <reference path="angular.js" />

var options = [{ "OptionId": "", "Name": "", "Quantity": "", "Price": "", "Description": "", "Packages": [], "Picture": "", "isSelected": false }];
var bookmarks = [];
//    {
//        "BookmarkId": "1", "Name": "Отделочные материалы", "Options": [
//        { "OptionId": "1", "Name": "Штукатурка KL", "Quantity": "", "Price": "100", "Description": "Сухая смесь для выравнивания поверхности", "Packages": [], "Picture": "1", "isSelected": false },
//        { "OptionId": "2", "Name": "Клей обойный", "Quantity": "", "Price": "101", "Description": "Клей разбавляемый водой для поклейки обоев", "Packages": [], "Picture": "2", "isSelected": false },
//        { "OptionId": "3", "Name": "Краска белая", "Quantity": "", "Price": "103", "Description": "Краска вододисперсионная для внутренних работ", "Packages": [], "Picture": "3", "isSelected": false }
//        ], "Packages": [], "CompanyId": ""
//    },
//    {
//        "BookmarkId": "2", "Name": "Строительные материалы", "Options": [
//        { "OptionId": "4", "Name": "Цемент 100", "Quantity": "", "Price": "100", "Description": "Цемент марки 100. Изготовитель ООО Рога и копыта. Краснодар", "Packages": [], "Picture": "", "isSelected": false },
//        { "OptionId": "5", "Name": "Кирпич облицовочный", "Quantity": "", "Price": "101", "Description": "Кирпич облицовочный красный", "Packages": [], "Picture": "", "isSelected": false },
//        ], "Packages": [], "CompanyId": ""
//    }
//];

var bookmark = {
    "BookmarkId": null, "Name": null, "Options": [
    { "OptionId": null, "Name": null, "Quantity": null, "Price": null, "Description": null, "Picture": null, "isSelected": false }
    ],  "CompanyId": null
};

var emptyBookmark = bookmark;

//var bookmarkOption = bookmark;
   
var app = angular.module("ConfAng", ['ngHandsontable', 'ngFileUpload', 'ngRoute']);
//app.config(['$routeProvider', '$locationProvider',
//  function ($routeProvider, $locationProvider) {
//      $routeProvider
//        .when('/Book/:bookId', {
//            templateUrl: 'book.html',
//            controller: 'BookCtrl',
//            controllerAs: 'book'
//        })
//        .when('/Book/:bookId/ch/:chapterId', {
//            templateUrl: 'chapter.html',
//            controller: 'ChapterCtrl',
//            controllerAs: 'chapter'
//        });

//      $locationProvider.html5Mode(true);
//  }]);


var handsontableData = [];

//Контроллер для закладок
app.controller("PanelController", function ($scope) {
    this.tab = 1;

    this.selectTab = function (setTab) {
        this.tab = setTab;
    }
    this.isSelected = function (checkTab) {
        return this.tab === checkTab;
    }
    this.tabInc = function (maxTab) {
        if (this.tab < maxTab) {
            this.tab = this.tab + 1;
        }
    };
});

app.controller("HotController", ['$scope', '$http', '$location', function ($scope, $http, $location) {

    var p = $location.absUrl();
    accountId = p.replace("http://localhost:52205/Option/Index/", "");
    url = "/api/BookmarkApi/" + accountId;
    //Получение данных об опциях
    $http.get(url).success(function (data) {
        $scope.bookmarks = data.Bookmarks;
        $scope.company = data;
    });

    

    //Функция обработки изменений в таблице
    var myAfterChangeHandler = function () {
        $scope.handsontableData = this.getData();
        $scope.options = $scope.handsontableData;
    };
    //Настройки таблицы
    $scope.settings = {
        colHeaders: true,
        rowHeaders: true,
        colWidths: 250,
        minSpareRows: 3,
        minRows: 3,
        manualColumnResize: true,
        afterChange: myAfterChangeHandler
    };

    $scope.options = options;
    $scope.bookmarks = bookmarks;
    $scope.bookmarkOption = bookmark;

    // Функция вычисления индекса
    var getIndex = function (bm) {
        if (bm.BookmarkId) {
            for (var i = 0; i < bookmarks.length; i++) {
                if (bookmarks[i].BookmarkId === bm.BookmarkId) {
                    return i
                };
            };
        }
        else {
            for (var i = 0; i < bookmarks.length; i++) {
                if (bookmarks[i].Name === bm.Name) {
                    return i;
                };
            };
        };
    };

    // Функция загрузки Закладки в массив
    $scope.updateBookmarks = function (bookmarkSelected) {
        var index = getIndex(bookmarkSelected);
        checkOptions($scope.options);
        $scope.bookmarks[index].Options = $scope.options;
    };
 

    // Функция добавления элемента массива
    var addBookmark = function (bookmark) {
        $scope.bookmarks.push(bookmark);
    };

    //Функция проверки заполнености таблицы
    var checkOptions = function (bookmarkOpt) {
        for (var i = 0; i < bookmarkOpt.length; i++) {
            if (!bookmarkOpt[i].Name) {
                bookmarkOpt.splice(i, 1);
            };
        };
    };

    //Функция добавления пустого раздела
    $scope.addEmpty = function () {
        emptyBookmark.CompanyId = $scope.company.CompanyId;
        $scope.bookmarks.push(emptyBookmark);
    };

    //Функция удаления раздела
    $scope.remove = function (bookmark) {
        var index = getIndex(bookmark);
        $scope.bookmarks.splice(index, 1);
    };

    //Функция сохранения
    $scope.saveChanges = function (bookmark) {
        
    };
}]);
//Контроллер для загрузки изображений
app.controller("ImageController", ['$scope', 'Upload', function ($scope, Upload) {

    $scope.bookmarks = bookmarks;
    $scope.bookmarkOption = bookmark;

    $scope.onFileSelect = function ($files) {
        //$files: an array of files selected, each file has name, size, and type.
        for (var i = 0; i < $files.length; i++) {
            var file = $files[i];
            $scope.upload = $upload.upload({
                url: 'server/upload/url', //upload.php script, node.js route, or servlet url
                data: { myObj: $scope.myModelObj },
                file: file,
            }).progress(function (evt) {
                console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
            }).success(function (data, status, headers, config) {
                // file is uploaded successfully
                console.log(data);
            });
        }
    };

}]);