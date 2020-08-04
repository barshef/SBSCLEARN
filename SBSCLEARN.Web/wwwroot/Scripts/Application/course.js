$(function () {
    var dataGrid,
        selectBoxCategory, selectBoxCategoryText, selectBoxCategoryValue, yearListDataLoader, ServiceUrl;

    var that = this;
    ServiceUrl = document.querySelector("#serviceUrl").value;  
    console.log(ServiceUrl);

    //categoryDataLoaderTest = [{
    //    "Id": 0,
    //    "CategoryName": "-- Click to Select Assessment Year --"
    //},
    //{
    //    "Id": 1,
    //    "CategoryName": "Web Development",
    //},
    //{
    //    "Id": 2,
    //    "CategoryName": "Databases",
    //}
    //];

    var categoryDataLoader = DevExpress.data.AspNet.createStore({
        key: "id",
        loadUrl: ServiceUrl + "/api/Course/getAllCategories"
    });

    $('#btnSaveUpload').hide();

    selectBoxCategory = $("#categorySelectBox").dxSelectBox({
        dataSource: categoryDataLoader,
        valueExpr: "id",
        displayExpr: "categoryName",
        searchEnabled: true,
        hoverStateEnabled: true,
        searchExpr: ["categoryName", "id"],
        placeholder: "-- Click to Select Category Name --",
        showClearButton: true,
        onValueChanged: function (e) {
            var value = e.component.option("value");
            var text = e.component.option("text");
            //console.log(value);
            //console.log(text);
            var selectedCategoryValue = value;
            var selectedCategoryText = text;
            if (selectedCategoryValue > 0) {
                selectBoxCategoryText = selectedCategoryText;
                selectBoxCategoryValue = selectedCategoryValue;
                that.showSelectedCategoryDetails(selectBoxCategoryValue);
            }
            else if (selectedCategoryValue <= 0) {
                //ShowMessagePopup("Oops!", "Please select a valid category name!", "error");
                selectBoxCategoryText = selectedCategoryText;
                selectBoxCategoryValue = selectedCategoryValue;
                $('#courseGrid').hide();
                return false;
            }
        }
    }).dxSelectBox("instance");

    this.showSelectedCategoryDetails = function (categoryId) {
        $.ajaxSetup({
            cache: false
        });
        
        $('#courseGrid').show();
        //console.log(ServiceUrl + "/api/Course/getCourseByCategoryId"); 
        var remoteDataLoader = DevExpress.data.AspNet.createStore({
            key: "id",
            loadUrl: ServiceUrl + "/api/Course/getCourseByCategoryId",  
            loadParams: { categoryId: categoryId }
        });

        dataGrid,
            gridOptions = {
                dataSource: remoteDataLoader,
                remoteOperations: {
                    paging: true,
                    filtering: true,
                    sorting: true,
                    grouping: true,
                    summary: true,
                    groupPaging: true
                },
                searchPanel: {
                    visible: true,
                    placeholder: "Search...",
                    width: 250
                },
                paging: {
                    pageSize: 20
                },
                pager: {
                    showNavigationButtons: true,
                    showPageSizeSelector: true,
                    allowedPageSizes: [20, 50, 100, 250],
                    showInfo: true
                },
                hoverStateEnabled: true,
                showRowLines: true,
                rowAlternationEnabled: true,
                columnAutoWidth: true,
                columns: [
                    {
                        caption: 'S/N',
                        width: "auto",
                        allowSorting: false,
                        allowFiltering: false,
                        allowReordering: false,
                        allowHeaderFiltering: false,
                        allowGrouping: false,
                        cellTemplate: function (container, options) {
                            container.text(dataGrid.pageIndex() * dataGrid.pageSize() + (options.rowIndex + 1));
                        }
                    },
                    {
                        dataField: "courseName",
                        caption: "Course Name",
                        sortIndex: 0,
                        cssClass: 'font-bold',
                        sortOrder: 'asc'
                    }
                ],
                
            };

        dataGrid = $("#courseGrid").dxDataGrid(gridOptions).dxDataGrid("instance");
    }
});




