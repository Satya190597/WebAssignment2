var eventRegister = {
    registerEvents: function () {
        $("#settings").on("click", function () {
            modelAction.open();
        });
        $("#closeModel").on("click", function () {
            modelAction.close();
        });
        $("#update").on("click", function () {
            //console.log("Working");
            //console.log("Serialize Data " + JSON.stringify($('#userUpdateForm').serialize()));
            // -- Test my ajax call --
            formAction.updateUser();
        });
    }
}