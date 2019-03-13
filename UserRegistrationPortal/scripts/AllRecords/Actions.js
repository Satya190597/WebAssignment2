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
                $("#contactList").append("<li> [" + data["Contacts"][value][0] + " ] " + data["Contacts"][value][1] + "</li>");
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
    getUpdateUserDetails : function(id)
    {
        $(".model-edit").show();
    }
}