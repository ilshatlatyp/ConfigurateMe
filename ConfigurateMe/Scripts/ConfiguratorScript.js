/// <reference path="angular.js" />

var options = [
        { "OptionId": "6", "Name": "Побелка KLM", "Quantity": 1, "Price": 100, "Description": "Сухая смесь для выравнивания поверхности", "Packages": [], "Picture": "1", "isSelected": false },
        { "OptionId": "7", "Name": "Клей обычный", "Quantity": 1, "Price": 101, "Description": "Клей разбавляемый водой для поклейки обоев", "Packages": [], "Picture": "2", "isSelected": false },
        { "OptionId": "8", "Name": "Краска синяя", "Quantity": 1, "Price": 103, "Description": "Краска вододисперсионная для внутренних работ", "Packages": [], "Picture": "3", "isSelected": false }
];
var bookmarks = [
    {
        "BookmarkId": "1", "Name": "Отделочные материалы", "Options": [
        { "OptionId": "1", "Name": "Штукатурка KL", "Quantity": 1, "Price": 100, "Description": "Сухая смесь для выравнивания поверхности", "Packages": [], "Picture": "1", "isSelected": false },
        { "OptionId": "2", "Name": "Клей обойный", "Quantity": 1, "Price": 101, "Description": "Клей разбавляемый водой для поклейки обоев", "Packages": [], "Picture": "2", "isSelected": false },
        { "OptionId": "3", "Name": "Краска белая", "Quantity": 1, "Price": 103, "Description": "Краска вододисперсионная для внутренних работ", "Packages": [], "Picture": "3", "isSelected": false }
        ], "Packages": [], "CompanyId": ""
    },
    {
        "BookmarkId": "2", "Name": "Строительные материалы", "Options": [
        { "OptionId": "4", "Name": "Цемент 100", "Quantity": 1, "Price": 100, "Description": "Цемент марки 100. Изготовитель ООО Рога и копыта. Краснодар", "Packages": [], "Picture": "", "isSelected": false },
        { "OptionId": "5", "Name": "Кирпич облицовочный", "Quantity": 1, "Price": 101, "Description": "Кирпич облицовочный красный", "Packages": [], "Picture": "", "isSelected": false },
        ], "Packages": [], "CompanyId": ""
    }
];
var pckge =[ { "PackageId": "1", "Name": "Строй Материалы", "Price": "180", "Description": "Комплект для строительства дома", "OptionVisible": false, "Optional": false, "UncompatibleOptions": false, "BookmarkId": 2, "Options": [] },
    { "PackageId": "2", "Name": "Строй Материалы ex", "Price": "190", "Description": "Комплект для строительства дома 2", "OptionVisible": false, "Optional": true, "UncompatibleOptions": false, "BookmarkId": 2, "Options": [] }];

pckge[0].Options = options;
pckge[1].Options = options;

bookmarks.Packages = pckge;

var app = angular.module("MainApp", []);

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
