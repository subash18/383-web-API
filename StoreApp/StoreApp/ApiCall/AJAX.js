var username = $("input#email").val();
var password = $("input#password").val();

function make_base_auth(user, password) {
    var tok = username + ":" + password;
    var hash = btoa(tok);
    return "Basic " + hash;
}
$.ajax({
    type: "GET",
    url: "/api/ApiKey",
    dataTpe: "json",
    async: false,
    data: "{}",
    beforeSend: function(xhr) {
        xhr.setRequestHeader("Authorization", make_base_auth(username, password));
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