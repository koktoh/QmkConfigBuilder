export function getElementHeight(id) {
    return $(id).height();
}

export function getElementWidth(id) {
    return $(id).width();
}

export function exists(id) {
    return $(id).length > 0 ? true : false;
}

export function getElement(id) {
    return document.getElementById(id);
}

export function getCssPropertyValue(selector, propertyName) {
    return $(selector).css(propertyName);
}

export function show(selector) {
    $(selector).show();
}

export function hide(selector) {
    $(selector).hide();
}