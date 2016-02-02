/// <reference path="angular.js" />

var bookmarks = [];
//    {
//        "BookmarkId": "1", "Name": "Отделочные материалы", "Options": [
//        { "OptionId": "1", "Name": "Штукатурка KL", "Quantity": 1, "Price": 100, "Description": "Сухая смесь для выравнивания поверхности", "Packages": [], "Picture": "1", "isSelected": false },
//        { "OptionId": "2", "Name": "Клей обойный", "Quantity": 1, "Price": 101, "Description": "Клей разбавляемый водой для поклейки обоев", "Packages": [], "Picture": "2", "isSelected": false },
//        { "OptionId": "3", "Name": "Краска белая", "Quantity": 1, "Price": 103, "Description": "Краска вододисперсионная для внутренних работ", "Packages": [], "Picture": "3", "isSelected": false }
//        ], "Packages": [], "CompanyId": ""
//    },
//    {
//        "BookmarkId": "2", "Name": "Строительные материалы", "Options": [
//        { "OptionId": "4", "Name": "Цемент 100", "Quantity": 1, "Price": 100, "Description": "Цемент марки 100. Изготовитель ООО Рога и копыта. Краснодар", "Packages": [], "Picture": "", "isSelected": false },
//        { "OptionId": "5", "Name": "Кирпич облицовочный", "Quantity": 1, "Price": 101, "Description": "Кирпич облицовочный красный", "Packages": [], "Picture": "", "isSelected": false },
//        ], "Packages": [], "CompanyId": ""
//    }
//];

var bookmark = {
    "BookmarkId": null, "Name": null, "Options": [
    { "OptionId": null, "Name": null, "Quantity": 1, "Price": null, "Description": null, "Packages": [], "Picture": null, "isSelected": false }
    ], "Packages": [], "CompanyId": null
};

var options = [];// [{ "OptionId": null, "Name": null, "Quantity": null, "Price": null, "Description": null, "Packages": [], "Picture": null, "isSelected": false }];

var app = angular.module("ListApp", []);

app.controller("PanelController", ['$scope', '$http', '$location', function ($scope, $http, $location) {

    var p = $location.absUrl();
    accountId = p.replace("http://localhost:52205/List/Index/", "");
    url = "/api/BookmarkApi/" + accountId;
    //Получение данных об опциях
    $http.get(url).success(function (data) {
        $scope.bookmarks = data;
    });

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

    //Функция формирует корзину
    $scope.select = function (option, index) {
        if (option.isSelected) {
            options.push(option);
        };
        if (!option.isSelected) {
            options.splice(index, 1);
        };
    };

    $scope.total = function () {
        var summ = 0;
        for (var i = 0; i < $scope.options.length; i++) {
            summ = summ + $scope.options[i].Price * $scope.options[i].Quantity;
        }
        return summ;
    };

    $scope.bookmarks = bookmarks;
    $scope.options = options;
    $scope.bookmark = bookmark;

}]);


