'use strict';
var eventRegister = {
    registerEvents: function () {
        $("#AddContactControl").on("click", function () {
            addElement.generateContactControl($("#ContactControl"));
        });
        $("#firstName").on("keyup", function () {
            validation.validator($("#registrationForm")).element("#firstName");
        });
        $("#lastName").on("keyup", function () {
            validation.validator($("#registrationForm")).element("#lastName");
        });
        $("#email").on("keyup", function () {
            validation.validator($("#registrationForm")).element("#email");
        });
        $("#password").on("keyup", function () {
            validation.validator($("#registrationForm")).element("#password");
            validation.validator($("#registrationForm")).element("#confirmPassword");
        });
        $("#confirmPassword").on("keyup", function () {
            validation.validator($("#registrationForm")).element("#confirmPassword");
        });
        $("#address").on("keyup", function () {
            validation.validator($("#registrationForm")).element("#address");
        });
        $("#register").on("click", function () {
            validation.validateContactNumbers();
        });
        $("#image").on("change", function () {
            validation.validator($("#registrationForm")).element("#image");
        })
    },
    registerContactControlEvents : function(index){
        $("#removeContact" + index).on("click", function () {
            addElement.removeContactControl($(this).attr("data-id"));
        });
        $("#contactNumber" + index).on("keyup", function (index) {
            validation.validateSingleContactNumber(this);
        });
    }
}