$(function () {
    GetEmployee();
})

function GetEmployee() {
    ApiCallAjax("Employee/GetEmployees", null, "GET", true, function (result) {
        console.log(result)
    })
}