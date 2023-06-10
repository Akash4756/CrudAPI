
$(document).ready(function () {

    $("#btnSubmit").click(function () {

        var isValid = true
        isValid = requireTextField("Name", "Your name")
        if (!isValid) { return isValid }

        isValid = requireTextField("Email", "Your email")
        if (!isValid) { return isValid }

        isValid = requireTextField("Password", "Your password")
        if (!isValid) { return isValid }

        isValid = requireSelectField("Gender", "Your gender")
        if (!isValid) { return isValid }

        isValid = requireTextField("Mobile", "Your Mobile")
        if (!isValid) { return isValid }

        isValid = requireTextField("Address", "Your Address")
        if (!isValid) { return isValid }

        isValid = requireSelectField("Is_Active", "Your IsActive")
        if (!isValid) { return isValid }
        
        console.log(isValid)
    })

    $("#txtName").keyup(function () {
        isValid = requireTextField("Name", "your name")
        if (!isValid) { return isValid }
    })

    $("#txtEmail").keyup(function () {
        isValid = requireTextField("Email", "your email")
        if (!isValid) { return isValid }
    })

    $("#txtPassword").keyup(function () {
        isValid = requireTextField("Password", "your password")
        if (!isValid) { return isValid }
    })

    $("#ddlGender").change(function () {
        isValid = requireSelectField("Gender", "your gender")
        if (!isValid) { return isValid }
    })

    $("#txtMobile").keyup(function () {
        isValid = requireTextField("Mobile", "your mobile")
        if (!isValid) { return isValid }
    })

    $("#txtAddress").keyup(function () {
        isValid = requireTextField("Address", "your address")
        if (!isValid) { return isValid }
    })

    $("#ddlIs_Active").change(function () {
        isValid = requireSelectField("Is_Active", "one")
        if (!isValid) { return isValid }
    })

})