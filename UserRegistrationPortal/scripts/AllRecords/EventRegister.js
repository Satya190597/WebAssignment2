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
    }
}