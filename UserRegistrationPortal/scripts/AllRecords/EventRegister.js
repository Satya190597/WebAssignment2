var eventRegister = {
    registerEvent : function()
    {
        $(".viewButton").on("click", function () {
            console.log("Attribute Value : " + $(this).attr("data-userId"));
            actions.getUserDetails($(this).attr("data-userId"));
        })
        $(".editButton").on("click", function () {
            actions.getUpdateUserDetails($(this).attr("data-userId"));
        })
        $("#closeEditModelButton").on("click", function () {
            $(".model-edit").hide();
        })
        $("#updateButton").on("click", function () {
            console.log("Update User No : "+$(this).attr("data-id"));
            //actions.updateUser($(this).attr("data-id"));
        })
        $(".deleteButton").on("click", function () {
            //console.log("Update User No : " + $(this).attr("data-id"));
            if (confirm("Are You Scure"))
            {
                actions.deleteUser($(this).attr("data-userId"));
            }
        })
        $("#closeViewModelButton").on("click", function () {
            $("#modelView").fadeOut(500);
        });

        /* Validation Events */
        $("#firstName").on("keyup", function () {
            validation.validator($("#userUpdateForm")).element("#firstName");
        });
        $("#lastName").on("keyup", function () {
            validation.validator($("#userUpdateForm")).element("#lastName");
        });
        $("#address").on("keyup", function () {
            validation.validator($("#userUpdateForm")).element("#address");
        });
        
    }
}