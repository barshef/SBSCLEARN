$(function () {
    var dataGrid,
        selectBoxCategory, selectBoxCategoryText, selectBoxCategoryValue, selectBoxCourse, ServiceUrl, selectBoxCourseText, selectBoxCourseValue;

    var that = this;
    ServiceUrl = document.querySelector("#serviceUrl").value;  
    $('#courseDiv').hide();

    var categoryDataLoader = DevExpress.data.AspNet.createStore({
        key: "id",
        loadUrl: ServiceUrl + "/api/Course/getAllCategories"
    });


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
                that.showSelectedCourseDetails(selectBoxCategoryValue);
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

    this.showSelectedCourseDetails = function (categoryId) {
        $.ajaxSetup({
            cache: false
        });

        $('#courseDiv').show();
        
        $('#courseGrid').show();
        //console.log(ServiceUrl + "/api/Course/getCourseByCategoryId"); 
        var courseDataLoader = DevExpress.data.AspNet.createStore({
            key: "id",
            loadUrl: ServiceUrl + "/api/Course/getCourseByCategoryId",  
            loadParams: { categoryId: categoryId }
        });

        selectBoxCourse = $("#courseSelectBox").dxSelectBox({
            dataSource: courseDataLoader,
            valueExpr: "id",
            displayExpr: "courseName",
            searchEnabled: true,
            hoverStateEnabled: true,
            searchExpr: ["courseName", "id"],
            placeholder: "-- Click to Select Course Name --",
            showClearButton: true,
            onValueChanged: function (e) {
                var value = e.component.option("value");
                var text = e.component.option("text");
                //console.log(value);
                //console.log(text);
                var selectedCourseValue = value;
                var selectedCourseText = text;
                if (selectedCourseValue > 0) {
                    selectBoxCourseText = selectedCourseText;
                    selectBoxCourseValue = selectedCourseValue;
                    that.showSelectedUserCourseList(selectBoxCourseValue);
                }
                else if (selectedCourseValue <= 0) {
                    //ShowMessagePopup("Oops!", "Please select a valid category name!", "error");
                    selectBoxCourseText = selectedCourseText;
                    selectBoxCourseValue = selectedCourseValue;
                    $('#userScroresGrid').hide();
                    return false;
                }
            }
        }).dxSelectBox("instance");
    }

    this.showSelectedUserCourseList = function (courseId) {
        $.ajaxSetup({
            cache: false
        });

        $('#userScroresGrid').show();
        var remoteDataLoader = DevExpress.data.AspNet.createStore({
            key: "categoryId",
            loadUrl: ServiceUrl + "/api/Course/getUserScoreBycourseId",
            loadParams: { courseId: courseId }
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
                        dataField: "categoryName",
                        caption: "Category Name",
                        sortIndex: 0,
                        cssClass: 'font-bold',
                        sortOrder: 'asc'
                    },
                    {
                        caption: "UserName",
                        dataField: "categoryId"
                    }, 
                    {
                        caption: "Score",
                        dataField: "maxScore"
                    }
                ],

            };

        dataGrid = $("#userScroresGrid").dxDataGrid(gridOptions).dxDataGrid("instance");
    }
});




