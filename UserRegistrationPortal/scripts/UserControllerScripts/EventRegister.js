var eventRegister = {
    registerEvents: function () {
        $("#settings").on("click", function () {
            modelAction.open();
        });
        $("#closeModel").on("click", function () {
            modelAction.close();
        });
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