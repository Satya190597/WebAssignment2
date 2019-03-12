var formAction = {
    updateUser : function()
    {
        let formData = { "FirstName": $("#firstName").val(), "LastName": $("#lastName").val(), "Address": $("#address").val() }
        console.log("Serialize Data " + JSON.stringify(formData));
        userRegistrationPortalAjaxCall.ajaxUpdateCall("/User/Update/", JSON.stringify(formData)).done(function (data) {
            // Do something after ajax call is completed
        })
    }
}