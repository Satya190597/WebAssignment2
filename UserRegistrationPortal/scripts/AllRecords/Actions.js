var actions = {
    getUserDetails : function(id)
    {
        userRegistrationPortalAjaxCall.ajaxGetCall("/Admin/GetUser/" + id).done(function (data) {
            $("#userImageView").attr("src",data["Details"]["Image"].replace("~/","/"));
            $("#firstNameView").html(data["Details"]["FirstName"]);
            $("#lastNameView").html(data["Details"]["LastName"]);
            $("#emailView").html(data["Details"]["Email"]);
            $("#addressView").html(data["Details"]["Address"]);
            console.log("Length : " + data["Contacts"].length);
            $("#contactList").html("");
            $.each(Object.keys(data["Contacts"]), function (key, value) {
                $("#contactList").append("<li><small>[" + data["Contacts"][value][0] + "]</small> " + data["Contacts"][value][1] + "</li>");
            })
            for(let i = 0; i < data["Contacts"].length;i++)
            {
                console.log("I value :" + i);
                console.log(data["Contacts"][i]);
                
            }
            $(".model-view").show();
        }).fail(function () {
            console.log("Something Went Wrong");
        });
    },
    updateUser : function(id)
    {
        let formData = { "FirstName": $("#firstName").val(), "LastName": $("#lastName").val(), "Address": $("#address").val() }
        console.log("Serialize Data " + JSON.stringify(formData));
        userRegistrationPortalAjaxCall.ajaxUpdateCall("/Admin/UpdateUser/"+id, JSON.stringify(formData)).done(function (data) {
            // Do something after ajax call is completed
            location.reload();
        })
    },
    deleteUser : function(id)
    {
        userRegistrationPortalAjaxCall.ajaxDeleteCall("/Admin/DeleteUser/" + id).done(function (data) {
            // Do something after ajax call is completed
            location.reload();
        })
    },
    getUpdateUserDetails : function(id)
    {
        userRegistrationPortalAjaxCall.ajaxGetCall("/Admin/GetUser/" + id).done(function (data) {
            $("#firstName").val(data["Details"]["FirstName"]);
            $("#lastName").val(data["Details"]["LastName"]);
            $("#address").val(data["Details"]["Address"]);
            $("#updateButton").attr("data-id", id);
            $("#userUpdateForm").attr("data-id", id);
            $(".model-edit").show();
        });
    }
}