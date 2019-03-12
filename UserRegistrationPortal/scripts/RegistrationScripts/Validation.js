'use strict';
var validation = {
    rules: {
        firstName: {
            required: true,
            allLetters: true,
            minlength: 2,
            maxlength: 50
        },
        lastName: {
            required: true,
            allLetters: true,
            minlength: 2,
            maxlength: 50
        },
        email: {
            required: true,
            email: true,
            minlength: 4,
            maxlength: 255,
            remote: {
                url: "/CheckEmail/Verify/",
                type: "POST",
                data: {
                    email: function () {
                        return $("#email").val();
                    }
                }
            }
        },
        address: {
            required : true,
            lengthWithoutSpace: true,
            maxlength: 255,
        },
        password: {
            required: true,
            minlength: 8,
            maxlength: 50,
            passwordValidator: true,
        },
        confirmPassword: {
            required: true,
            equalTo: "#password"
        },
        image: {
            required: true,
            extension: "jpeg,jpg,png",
            size: true
        }
    },
    messages: {
        firstName: {
            required: "Please Enter Your First Name",
            allLetters: "Please Enter A Valid First Name",
            minlength: "Minimum 1 Characters Required",
            maxlength: "Maximum 50 Characters Are Accepted"
        },
        lastName: {
            required: "Please Enter Your Last Name",
            allLetters: "Please Enter A Valid Last Name",
            minlength: "Minimum 2 Characters Required",
            maxlength: "Maximum 50 Characters Are Accepted"
        },
        address: {
            required: "Please Enter Your Address",
            maxlength: "Maximum 50 Characters Are Accepted",
            lengthWithoutSpace: "Please Enter A Valid Address"
        },
        email: {
            required: "Please Enter Your Email",
            email: "Please Enter A Valid Email",
            minlength: "Minimum 5 Characters Required",
            maxlength: "Maximum 50 Characters Are Accepted",
            remote: "This Email Is Already Registered !"
        },
        password: {
            required: "Please Enter Your Password",
            minlength: "Password Size Must Be Of Eight Characters",
            maxlength: "Maximum 50 Characters Are Accepted",
            passwordValidator: "Password Must Contain 1 Digit 1 Lower Case 1 Upper Case And 1 Special Character"
        },
        confirmPassword: {
            required: "Please Enter Your Password",
            equalTo: "Password Mismatch"
        },
        contacts: {
            checkAllContacts: "Please Enter Valid Contacts",
            required: "Please Enter A Number",
        },
        image: {
            required: "Please Upload Your Image",
            extension: "Image Must Be In .jpeg, .jpg or .png Format",
            size: "File Size Must Be Less Than 1MB"
        }
    },
    underflow : function(value){
        return value.replace(/\s/g,"").length > 5;
    },
    allLetters : function(value){
        return /^[a-zA-Z]+$/.test(value);
    },
    passwordValidation : function(value){
        return /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/.test(value);
    },
    fileSize: function (element) {
        return element.files[0].size < 1000000 ? true : false;
    },
    validateContactNumbers: function () {
        let flag = true;
        for (let index = 1; index <= addElement.idIndex; index++)
        {
            let contactElement = $("#contactNumber" + index);
            let statusElement = $("#contactNumberStatus" + index);
            if (contactElement.val() != undefined)
            {
                if (!(/^\d{5,12}$/.test(contactElement.val())))
                {
                    statusElement.html("Please Enter A Valid Contact Number");
                    flag = false;
                }
                else
                {
                    statusElement.html("");
                }
            }
        }
        return flag;
    },
    validateSingleContactNumber: function (contact, index) {
        let text = (/^\d{5,12}$/.test($(contact).val())) ? "" : "Please Enter A Valid Contact Number";
        $("#contactNumberStatus" + $(contact).attr("data-id")).html(text);
    },
    validator: function (form) {
        return form.validate();
    }
}