'use strict';
$(document).ready(function () {
    addElement.addContactDiv(4, addElement.contactDivTemplate);
    addElement.generateContactControl($("#ContactControl"));
    eventRegister.registerEvents();
    customValidation.addCustomValidationMethods();
    customValidation.addCustomValidation();
});