var username = $("input#email").val();
var password = $("input#password").val();
$.ajax({
    type: "GET",
    url: "/api/ApiKey",
    dataTpe: "json",
    headers: {
        "Authorization": "Basic " + btoa(userame + ":" + password)
    },
    statusCode: {
        403: function() {
            alert("Incorrect credentials, please try again.");
        }
    },
    success: function(data) {
        console.log(data);
    }
})