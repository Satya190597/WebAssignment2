var validations = {
    rules: {
        FirstName : {
            required : true,
            allLetters : true,
            maxlength : 50
        },
        LastName : {
            required : true,
            allLetters : true,
            maxlength : 50
        },
        Email : {
            required : true,
            email : true,
            uniqueEmail : true,
            maxlength : 50
        },
        Address: {
            required : true,
            maxlength : 255,
            customMinlength : true
        },
        Password : {
            required : true,
            maxlength : 50,
            customMinlength : true
        },
        ConfirmPassword: {
            required : true,
            equalTo : "#password" 
        },
        Contacts: {
            required: true,
            customContactValidation : true
        }
    },
    messages: {

    }
}