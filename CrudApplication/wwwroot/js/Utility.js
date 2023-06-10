
function requireTextField(controlId, errorMessage, validationtype = "all") {

    var Id = "#txt" + controlId
    var formGroup = "#formGroup" + controlId
    var errorField = "#err" + controlId

    var txtVal = $(Id).val()
    if (txtVal == "" || txtVal == undefined || txtVal == null) {
        $(formGroup).addClass("error-control")
        $(errorField).addClass("error-control")
        $(errorField).html("Please enter " + errorMessage)
        return false
    }
    else {
        $(formGroup).removeClass("error-control")
        $(errorField).removeClass("error-control")
        $(errorField).html("")
        return true
    }
}

function requireSelectField(controlId, errorMessage) {

    var Id = "#ddl" + controlId
    var formGroup = "#formGroup" + controlId
    var errorField = "#err" + controlId

    var ddlVal = $(Id).val()
    if (ddlVal == "-1" || ddlVal == undefined || ddlVal == null || ddlVal==0) {
        $(formGroup).addClass("error-control")
        $(errorField).addClass("error-control")
        $(errorField).html("Please Select " + errorMessage)
        return false
    }
    else {
        $(formGroup).removeClass("error-control")
        $(errorField).removeClass("error-control")
        $(errorField).html("")
        return true
    }
}

var Basepath = "https://localhost:44308/Api/"

function ApiCallAjax(url, data, type, async, fnresult, fnerror) {
    $.ajax({
        url: Basepath + url,
        data: data,
        type: type,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: async,
        headers: {
            "Authorization": "Bearer" + getToken()
        },
        Cache: false,
        success: function (response) {
            fnresult(response)            
        },
        error: function (err) {
            console.log(err)
            /*fnerror(err)*/
            switch (err.status) {
                case 401:
                    localStorage.removeItem("token");
                    localStorage.removeItem("user");
                    window.location.href = "/Home/Error"
                    break;
            }
        }
    })
}


function getToken() {
    if (localStorage.getItem("token") != null) {
        return localStorage.getItem("token")
    }
    else {
        return null
    }
}


