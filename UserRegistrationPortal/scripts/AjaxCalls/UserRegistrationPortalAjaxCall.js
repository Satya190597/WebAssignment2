'use strict';
var userRegistrationPortalAjaxCall = {
    ajaxGetCall: function (url) {
        return $.ajax({
            url: url,
            method: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json"
        })
    },
    ajaxPostCall: function (url, data) {
        return $.ajax({
            url: url,
            method: "POST",
            contentType: "application/json;charset=utf-8",
            data: data
        })
    },
    ajaxUpdateCall: function (url, data) {
        return $.ajax({
            url: url,
            method: "PUT",
            contentType: "application/json;charset=utf-8",
            data: data
        })
    },
    ajaxDeleteCall: function (url) {
        return $.ajax({
            url: url,
            method: "DELETE",
            contentType: "application/json;charset=utf-8",
            dataType: "json"
        })
    }
}