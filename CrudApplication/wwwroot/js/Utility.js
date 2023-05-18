
function requireTextField(controlId, errorMessage, validationtype = "all", Length = 500) {

    var Id = "#txt" + controlId
    var formGroup = "#formGroup" + controlId
    var errorField = "#err" + controlId
    $(Id).attr("maxLength", length)

    var txtVal = $(Id).val()
    if (txtVal == "" || txtVal == undefined || txtVal == null) {
        $(formGroup).addClass("error-control")
        $(errorField).addClass("error-control")
        $(errorField).html("Please enter" + errorMessage)
        return false
    }
    else {
        $(formGroup).removeClass("error-control")
        $(errorField).removeClass("error-control")
        $(errorField).html("")
    }
}