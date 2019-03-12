'use strict';
var customValidation = {
    addCustomValidation: function () {
        $("#registrationForm").validate({
            rules: validation.rules,
            messages: validation.messages,
            submitHandler: function (form) {
                if (validation.validateContactNumbers())
                {
                    if (confirm("Are You Scure You Want To Submit Your Details !"))
                    {
                        form.submit();
                    }
                    else
                    {  
                        return false;
                    }
                }
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
        $.validator.addMethod("passwordValidator", function (value) {
            return validation.passwordValidation(value);
        });
        $.validator.addMethod("size", function (value,element) {
            return validation.fileSize(element);
        });
    }
}