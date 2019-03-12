'use strict';
String.prototype.format = function () {
    let stringValue = this;
    for(let index in arguments)
    {
        stringValue = stringValue.replace("{" + index + "}", arguments[index]);
    }
    return stringValue;
}