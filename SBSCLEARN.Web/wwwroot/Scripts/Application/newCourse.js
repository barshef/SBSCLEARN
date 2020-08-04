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

    $('#btnSaveCourse').hide();

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

    $(".custom-file-input").on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
        $('#btnSaveCourse').show();
    });

    $('#btnSaveCourse').on('click', function () {
        var fileExtension = ['xls', 'xlsx', 'jpg', 'jpeg', 'png', 'pdf'];
        var filename = $('#fileupload').val();
        if (filename.length === 0) {
            $('#fileupload').val("");
            ShowMessagePopup("Oops!", "Please select a valid file!", "error");
            return false;
        }
        else {
            var extension = filename.replace(/^.*\./, '');
            if ($.inArray(extension, fileExtension) === -1) {
                var validExts = new Array(".xlsx", ".xls", "jpg", "jpeg", "png", "pdf");
                var fileUploader = $('#fileupload').val();
                $('#fileupload').val("");
                var msg = "Invalid file selected, valid files are of " + validExts.toString() + " types.";
                ShowMessagePopup("Wrong Extension!", msg, "error");
                return false;
            }
        }

        $('#btnSaveCourse').attr('disabled', 'disabled');
        var createCourseParameters = {};
        createCourseParameters.CourseName = $('#txtcourseName').val();
        createCourseParameters.CategoryId = selectBoxCategoryValue;
        //console.log(selectBoxYear);
        //console.log($('#payerUtin').val());
        var fdata = new FormData();
        var fileUpload = $("#fileupload").get(0);
        var files = fileUpload.files;
        //var baseUrl = "http://ogunstatebir.com/SelfServicePortal.WebCore";
        console.log("Got this far");
        //console.log(files);
        fdata.append(files[0].name, files[0]);
        $.ajax({
            type: "POST",
            url: ServiceUrl + "/api/Course/createCourse",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
                xhr.setRequestHeader('createCourseParameters', JSON.stringify(createCourseParameters));
            },
            data: fdata,
            contentType: false,
            processData: false,
            success: function (response) {
                $('#btnSaveCourse').removeAttr('disabled');
                console.log(response);
                var returnMsgId = response.statusId;
                console.log(returnMsgId);
                console.log(response.statusId);
                var returnMsg = response.statusMessage;
                //ShowMessagePopup("Successful!", "Course Created Successfully", "success");
                if (returnMsgId > 0 && returnMsgId !== null) {
                    swal({
                        title: "Successful!",
                        text: returnMsg,
                        icon: "success",
                        closeOnClickOutside: false,
                        closeOnEsc: false
                    })
                        .then((willDelete) => {
                            if (willDelete) {
                                location.reload();
                            } else {
                                swal("Transaction Successful, Please Reload The Page!", {
                                    icon: "success",
                                    closeOnClickOutside: false,
                                    closeOnEsc: false
                                });
                            }
                        });
                }
                else if (returnMsgId === -1) {
                    var returnErrorMsg = returnMsg;
                    ShowMessagePopup("Not Successful", returnErrorMsg, "error");
                }
                else {
                    var returnerrorMsg = returnMsg;
                    ShowMessagePopup("Not Successful", returnerrorMsg, "error");
                }
            },
            error: function (e) {
                ShowMessagePopup("Oops!", e.responseText, "error");
            }
        });
    })
});




