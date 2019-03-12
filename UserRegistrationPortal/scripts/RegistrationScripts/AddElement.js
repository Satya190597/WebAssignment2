'use strict';
var addElement = {
    idIndex: 1,
    controllerTemplateDefault: "<div id=\"contact{0}\" class=\"contact-holder\"><div class=\"contact-type-holder\"><select id=\"contactType{1}\" name=\"contactTypes[]\" class=\"input-control input-control-select\"></select><input type=\"button\" id=\"AddContactControl\" value=\"Add\" class=\"add-contact-button\"></div><div class=\"contact-contact-holder\"><input type=\"text\" id=\"contactNumber{2}\" name=\"contacts[]\" class=\"input-control\" data-id=\"{3}\" placeholder=\"Number\"/></div><div class=\"contact-error-status\"><strong id=\"contactNumberStatus{4}\" class=\"error\"></strong></div></div>",
    controllerTemplate: "<div id=\"contact{0}\" class=\"contact-holder\"><div class=\"contact-type-holder\"><select id=\"contactType{1}\" name=\"contactTypes[]\" class=\"input-control input-control-select\"></select></div><div class=\"contact-contact-holder\"><input type=\"text\" id=\"contactNumber{2}\" name=\"contacts[]\" class=\"input-control\" data-id=\"{3}\" placeholder=\"Number\"/></div><div class=\"contact-remove-button\"><input type=\"button\" id=\"removeContact{4}\" data-id=\"{5}\" value=\"Remove\" class=\"remove-contact-button\"/></div><div class=\"contact-error-status\"><strong id=\"contactNumberStatus{6}\" class=\"error\"></strong></div></div>",
    contactDivTemplate: "<div class=\"flex-form-group\"><div class=\"flex-form-label\"><label>Contact<sup>*</sup></label></div><div class=\"flex-form-control\"><div class=\"contact-control-wrapper\"><div class=\"contact-control\" id=\"ContactControl\"></div></div></div></div>",
    generateContactControl: function (containerId) {

        template = addElement.idIndex == 1 ? addElement.controllerTemplateDefault.toString().format(this.idIndex, this.idIndex, this.idIndex, this.idIndex, this.idIndex) : addElement.controllerTemplate.toString().format(this.idIndex, this.idIndex, this.idIndex, this.idIndex, this.idIndex, this.idIndex, this.idIndex);
        containerId.append(template);
        userRegistrationPortalAjaxCall.ajaxGetCall("/ContactType/Details").done(function (data) {
            let Id = "#contactType" + addElement.idIndex;
            for(let index = 0; index < data.length; index++)
            {
                $(Id).append("<option value=\""+data[index].Id+"\">"+data[index].ContactTypeText+"</option>");
            }
            eventRegister.registerContactControlEvents(addElement.idIndex);
            addElement.idIndex++;
        });
    },
    removeContactControl: function (containerId) {
        if (containerId != 1)
        {
            $("#contact" + containerId).remove();
        }
    },
    addContactDiv: function (position,template) {
        $(".flex-form-group:eq("+position+")").append(template);
    }
}