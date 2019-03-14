'use strict';
var customValidation = {
    addCustomValidation: function () {
        $("#userUpdateForm").validate({
            rules: validation.rules,
            messages: validation.messages,
            submitHandler: function (form) {
                actions.updateUser($("#userUpdateForm").attr("data-id"));
            }
        });
    },
    addCustomValidationMethods: function () {
        $.validator.addMethod("allLetters", function (value) {
            return validation.allLetters(value);
        });
        $.validator.addMethod("lengthWithoutSpace", function (value) {
            return validation.underflow(value);
        });
    }
}