/**
 * @license
 * Unobtrusive validation support library for jQuery and jQuery Validate
 * Copyright (c) .NET Foundation. All rights reserved.
 * Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
 * @version v4.0.0
 */

/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, newcap: true, immed: true, strict: false */
/*global document: false, jQuery: false */

(function (factory) {
    if (typeof define === 'function' && define.amd) {
***REMOVED***// AMD. Register as an anonymous module.
***REMOVED***define("jquery.validate.unobtrusive", ['jquery-validation'], factory);
    } else if (typeof module === 'object' && module.exports) {
***REMOVED***// CommonJS-like environments that support module.exports     
***REMOVED***module.exports = factory(require('jquery-validation'));
    } else {
***REMOVED***// Browser global
***REMOVED***jQuery.validator.unobtrusive = factory(jQuery);
    }
}(function ($) {
    var $jQval = $.validator,
***REMOVED***adapters,
***REMOVED***data_validation = "unobtrusiveValidation";

    function setValidationValues(options, ruleName, value) {
***REMOVED***options.rules[ruleName] = value;
***REMOVED***if (options.message) {
***REMOVED***    options.messages[ruleName] = options.message;
***REMOVED***}
    }

    function splitAndTrim(value) {
***REMOVED***return value.replace(/^\s+|\s+$/g, "").split(/\s*,\s*/g);
    }

    function escapeAttributeValue(value) {
***REMOVED***// As mentioned on http://api.jquery.com/category/selectors/
***REMOVED***return value.replace(/([!"#$%&'()*+,./:;<=>?@\[\\\]^`{|}~])/g, "\\$1");
    }

    function getModelPrefix(fieldName) {
***REMOVED***return fieldName.substr(0, fieldName.lastIndexOf(".") + 1);
    }

    function appendModelPrefix(value, prefix) {
***REMOVED***if (value.indexOf("*.") === 0) {
***REMOVED***    value = value.replace("*.", prefix);
***REMOVED***}
***REMOVED***return value;
    }

    function onError(error, inputElement) {  // 'this' is the form element
***REMOVED***var container = $(this).find("[data-valmsg-for='" + escapeAttributeValue(inputElement[0].name) + "']"),
***REMOVED***    replaceAttrValue = container.attr("data-valmsg-replace"),
***REMOVED***    replace = replaceAttrValue ? $.parseJSON(replaceAttrValue) !== false : null;

***REMOVED***container.removeClass("field-validation-valid").addClass("field-validation-error");
***REMOVED***error.data("unobtrusiveContainer", container);

***REMOVED***if (replace) {
***REMOVED***    container.empty();
***REMOVED***    error.removeClass("input-validation-error").appendTo(container);
***REMOVED***}
***REMOVED***else {
***REMOVED***    error.hide();
***REMOVED***}
    }

    function onErrors(event, validator) {  // 'this' is the form element
***REMOVED***var container = $(this).find("[data-valmsg-summary=true]"),
***REMOVED***    list = container.find("ul");

***REMOVED***if (list && list.length && validator.errorList.length) {
***REMOVED***    list.empty();
***REMOVED***    container.addClass("validation-summary-errors").removeClass("validation-summary-valid");

***REMOVED***    $.each(validator.errorList, function () {
***REMOVED******REMOVED***$("<li />").html(this.message).appendTo(list);
***REMOVED***    });
***REMOVED***}
    }

    function onSuccess(error) {  // 'this' is the form element
***REMOVED***var container = error.data("unobtrusiveContainer");

***REMOVED***if (container) {
***REMOVED***    var replaceAttrValue = container.attr("data-valmsg-replace"),
***REMOVED******REMOVED***replace = replaceAttrValue ? $.parseJSON(replaceAttrValue) : null;

***REMOVED***    container.addClass("field-validation-valid").removeClass("field-validation-error");
***REMOVED***    error.removeData("unobtrusiveContainer");

***REMOVED***    if (replace) {
***REMOVED******REMOVED***container.empty();
***REMOVED***    }
***REMOVED***}
    }

    function onReset(event) {  // 'this' is the form element
***REMOVED***var $form = $(this),
***REMOVED***    key = '__jquery_unobtrusive_validation_form_reset';
***REMOVED***if ($form.data(key)) {
***REMOVED***    return;
***REMOVED***}
***REMOVED***// Set a flag that indicates we're currently resetting the form.
***REMOVED***$form.data(key, true);
***REMOVED***try {
***REMOVED***    $form.data("validator").resetForm();
***REMOVED***} finally {
***REMOVED***    $form.removeData(key);
***REMOVED***}

***REMOVED***$form.find(".validation-summary-errors")
***REMOVED***    .addClass("validation-summary-valid")
***REMOVED***    .removeClass("validation-summary-errors");
***REMOVED***$form.find(".field-validation-error")
***REMOVED***    .addClass("field-validation-valid")
***REMOVED***    .removeClass("field-validation-error")
***REMOVED***    .removeData("unobtrusiveContainer")
***REMOVED***    .find(">*")  // If we were using valmsg-replace, get the underlying error
***REMOVED***    .removeData("unobtrusiveContainer");
    }

    function validationInfo(form) {
***REMOVED***var $form = $(form),
***REMOVED***    result = $form.data(data_validation),
***REMOVED***    onResetProxy = $.proxy(onReset, form),
***REMOVED***    defaultOptions = $jQval.unobtrusive.options || {},
***REMOVED***    execInContext = function (name, args) {
***REMOVED******REMOVED***var func = defaultOptions[name];
***REMOVED******REMOVED***func && $.isFunction(func) && func.apply(form, args);
***REMOVED***    };

***REMOVED***if (!result) {
***REMOVED***    result = {
***REMOVED******REMOVED***options: {  // options structure passed to jQuery Validate's validate() method
***REMOVED******REMOVED***    errorClass: defaultOptions.errorClass || "input-validation-error",
***REMOVED******REMOVED***    errorElement: defaultOptions.errorElement || "span",
***REMOVED******REMOVED***    errorPlacement: function () {
***REMOVED******REMOVED******REMOVED***onError.apply(form, arguments);
***REMOVED******REMOVED******REMOVED***execInContext("errorPlacement", arguments);
***REMOVED******REMOVED***    },
***REMOVED******REMOVED***    invalidHandler: function () {
***REMOVED******REMOVED******REMOVED***onErrors.apply(form, arguments);
***REMOVED******REMOVED******REMOVED***execInContext("invalidHandler", arguments);
***REMOVED******REMOVED***    },
***REMOVED******REMOVED***    messages: {},
***REMOVED******REMOVED***    rules: {},
***REMOVED******REMOVED***    success: function () {
***REMOVED******REMOVED******REMOVED***onSuccess.apply(form, arguments);
***REMOVED******REMOVED******REMOVED***execInContext("success", arguments);
***REMOVED******REMOVED***    }
***REMOVED******REMOVED***},
***REMOVED******REMOVED***attachValidation: function () {
***REMOVED******REMOVED***    $form
***REMOVED******REMOVED******REMOVED***.off("reset." + data_validation, onResetProxy)
***REMOVED******REMOVED******REMOVED***.on("reset." + data_validation, onResetProxy)
***REMOVED******REMOVED******REMOVED***.validate(this.options);
***REMOVED******REMOVED***},
***REMOVED******REMOVED***validate: function () {  // a validation function that is called by unobtrusive Ajax
***REMOVED******REMOVED***    $form.validate();
***REMOVED******REMOVED***    return $form.valid();
***REMOVED******REMOVED***}
***REMOVED***    };
***REMOVED***    $form.data(data_validation, result);
***REMOVED***}

***REMOVED***return result;
    }

    $jQval.unobtrusive = {
***REMOVED***adapters: [],

***REMOVED***parseElement: function (element, skipAttach) {
***REMOVED***    /// <summary>
***REMOVED***    /// Parses a single HTML element for unobtrusive validation attributes.
***REMOVED***    /// </summary>
***REMOVED***    /// <param name="element" domElement="true">The HTML element to be parsed.</param>
***REMOVED***    /// <param name="skipAttach" type="Boolean">[Optional] true to skip attaching the
***REMOVED***    /// validation to the form. If parsing just this single element, you should specify true.
***REMOVED***    /// If parsing several elements, you should specify false, and manually attach the validation
***REMOVED***    /// to the form when you are finished. The default is false.</param>
***REMOVED***    var $element = $(element),
***REMOVED******REMOVED***form = $element.parents("form")[0],
***REMOVED******REMOVED***valInfo, rules, messages;

***REMOVED***    if (!form) {  // Cannot do client-side validation without a form
***REMOVED******REMOVED***return;
***REMOVED***    }

***REMOVED***    valInfo = validationInfo(form);
***REMOVED***    valInfo.options.rules[element.name] = rules = {};
***REMOVED***    valInfo.options.messages[element.name] = messages = {};

***REMOVED***    $.each(this.adapters, function () {
***REMOVED******REMOVED***var prefix = "data-val-" + this.name,
***REMOVED******REMOVED***    message = $element.attr(prefix),
***REMOVED******REMOVED***    paramValues = {};

***REMOVED******REMOVED***if (message !== undefined) {  // Compare against undefined, because an empty message is legal (and falsy)
***REMOVED******REMOVED***    prefix += "-";

***REMOVED******REMOVED***    $.each(this.params, function () {
***REMOVED******REMOVED******REMOVED***paramValues[this] = $element.attr(prefix + this);
***REMOVED******REMOVED***    });

***REMOVED******REMOVED***    this.adapt({
***REMOVED******REMOVED******REMOVED***element: element,
***REMOVED******REMOVED******REMOVED***form: form,
***REMOVED******REMOVED******REMOVED***message: message,
***REMOVED******REMOVED******REMOVED***params: paramValues,
***REMOVED******REMOVED******REMOVED***rules: rules,
***REMOVED******REMOVED******REMOVED***messages: messages
***REMOVED******REMOVED***    });
***REMOVED******REMOVED***}
***REMOVED***    });

***REMOVED***    $.extend(rules, { "__dummy__": true });

***REMOVED***    if (!skipAttach) {
***REMOVED******REMOVED***valInfo.attachValidation();
***REMOVED***    }
***REMOVED***},

***REMOVED***parse: function (selector) {
***REMOVED***    /// <summary>
***REMOVED***    /// Parses all the HTML elements in the specified selector. It looks for input elements decorated
***REMOVED***    /// with the [data-val=true] attribute value and enables validation according to the data-val-*
***REMOVED***    /// attribute values.
***REMOVED***    /// </summary>
***REMOVED***    /// <param name="selector" type="String">Any valid jQuery selector.</param>

***REMOVED***    // $forms includes all forms in selector's DOM hierarchy (parent, children and self) that have at least one
***REMOVED***    // element with data-val=true
***REMOVED***    var $selector = $(selector),
***REMOVED******REMOVED***$forms = $selector.parents()
***REMOVED******REMOVED***    .addBack()
***REMOVED******REMOVED***    .filter("form")
***REMOVED******REMOVED***    .add($selector.find("form"))
***REMOVED******REMOVED***    .has("[data-val=true]");

***REMOVED***    $selector.find("[data-val=true]").each(function () {
***REMOVED******REMOVED***$jQval.unobtrusive.parseElement(this, true);
***REMOVED***    });

***REMOVED***    $forms.each(function () {
***REMOVED******REMOVED***var info = validationInfo(this);
***REMOVED******REMOVED***if (info) {
***REMOVED******REMOVED***    info.attachValidation();
***REMOVED******REMOVED***}
***REMOVED***    });
***REMOVED***}
    };

    adapters = $jQval.unobtrusive.adapters;

    adapters.add = function (adapterName, params, fn) {
***REMOVED***/// <summary>Adds a new adapter to convert unobtrusive HTML into a jQuery Validate validation.</summary>
***REMOVED***/// <param name="adapterName" type="String">The name of the adapter to be added. This matches the name used
***REMOVED***/// in the data-val-nnnn HTML attribute (where nnnn is the adapter name).</param>
***REMOVED***/// <param name="params" type="Array" optional="true">[Optional] An array of parameter names (strings) that will
***REMOVED***/// be extracted from the data-val-nnnn-mmmm HTML attributes (where nnnn is the adapter name, and
***REMOVED***/// mmmm is the parameter name).</param>
***REMOVED***/// <param name="fn" type="Function">The function to call, which adapts the values from the HTML
***REMOVED***/// attributes into jQuery Validate rules and/or messages.</param>
***REMOVED***/// <returns type="jQuery.validator.unobtrusive.adapters" />
***REMOVED***if (!fn) {  // Called with no params, just a function
***REMOVED***    fn = params;
***REMOVED***    params = [];
***REMOVED***}
***REMOVED***this.push({ name: adapterName, params: params, adapt: fn });
***REMOVED***return this;
    };

    adapters.addBool = function (adapterName, ruleName) {
***REMOVED***/// <summary>Adds a new adapter to convert unobtrusive HTML into a jQuery Validate validation, where
***REMOVED***/// the jQuery Validate validation rule has no parameter values.</summary>
***REMOVED***/// <param name="adapterName" type="String">The name of the adapter to be added. This matches the name used
***REMOVED***/// in the data-val-nnnn HTML attribute (where nnnn is the adapter name).</param>
***REMOVED***/// <param name="ruleName" type="String" optional="true">[Optional] The name of the jQuery Validate rule. If not provided, the value
***REMOVED***/// of adapterName will be used instead.</param>
***REMOVED***/// <returns type="jQuery.validator.unobtrusive.adapters" />
***REMOVED***return this.add(adapterName, function (options) {
***REMOVED***    setValidationValues(options, ruleName || adapterName, true);
***REMOVED***});
    };

    adapters.addMinMax = function (adapterName, minRuleName, maxRuleName, minMaxRuleName, minAttribute, maxAttribute) {
***REMOVED***/// <summary>Adds a new adapter to convert unobtrusive HTML into a jQuery Validate validation, where
***REMOVED***/// the jQuery Validate validation has three potential rules (one for min-only, one for max-only, and
***REMOVED***/// one for min-and-max). The HTML parameters are expected to be named -min and -max.</summary>
***REMOVED***/// <param name="adapterName" type="String">The name of the adapter to be added. This matches the name used
***REMOVED***/// in the data-val-nnnn HTML attribute (where nnnn is the adapter name).</param>
***REMOVED***/// <param name="minRuleName" type="String">The name of the jQuery Validate rule to be used when you only
***REMOVED***/// have a minimum value.</param>
***REMOVED***/// <param name="maxRuleName" type="String">The name of the jQuery Validate rule to be used when you only
***REMOVED***/// have a maximum value.</param>
***REMOVED***/// <param name="minMaxRuleName" type="String">The name of the jQuery Validate rule to be used when you
***REMOVED***/// have both a minimum and maximum value.</param>
***REMOVED***/// <param name="minAttribute" type="String" optional="true">[Optional] The name of the HTML attribute that
***REMOVED***/// contains the minimum value. The default is "min".</param>
***REMOVED***/// <param name="maxAttribute" type="String" optional="true">[Optional] The name of the HTML attribute that
***REMOVED***/// contains the maximum value. The default is "max".</param>
***REMOVED***/// <returns type="jQuery.validator.unobtrusive.adapters" />
***REMOVED***return this.add(adapterName, [minAttribute || "min", maxAttribute || "max"], function (options) {
***REMOVED***    var min = options.params.min,
***REMOVED******REMOVED***max = options.params.max;

***REMOVED***    if (min && max) {
***REMOVED******REMOVED***setValidationValues(options, minMaxRuleName, [min, max]);
***REMOVED***    }
***REMOVED***    else if (min) {
***REMOVED******REMOVED***setValidationValues(options, minRuleName, min);
***REMOVED***    }
***REMOVED***    else if (max) {
***REMOVED******REMOVED***setValidationValues(options, maxRuleName, max);
***REMOVED***    }
***REMOVED***});
    };

    adapters.addSingleVal = function (adapterName, attribute, ruleName) {
***REMOVED***/// <summary>Adds a new adapter to convert unobtrusive HTML into a jQuery Validate validation, where
***REMOVED***/// the jQuery Validate validation rule has a single value.</summary>
***REMOVED***/// <param name="adapterName" type="String">The name of the adapter to be added. This matches the name used
***REMOVED***/// in the data-val-nnnn HTML attribute(where nnnn is the adapter name).</param>
***REMOVED***/// <param name="attribute" type="String">[Optional] The name of the HTML attribute that contains the value.
***REMOVED***/// The default is "val".</param>
***REMOVED***/// <param name="ruleName" type="String" optional="true">[Optional] The name of the jQuery Validate rule. If not provided, the value
***REMOVED***/// of adapterName will be used instead.</param>
***REMOVED***/// <returns type="jQuery.validator.unobtrusive.adapters" />
***REMOVED***return this.add(adapterName, [attribute || "val"], function (options) {
***REMOVED***    setValidationValues(options, ruleName || adapterName, options.params[attribute]);
***REMOVED***});
    };

    $jQval.addMethod("__dummy__", function (value, element, params) {
***REMOVED***return true;
    });

    $jQval.addMethod("regex", function (value, element, params) {
***REMOVED***var match;
***REMOVED***if (this.optional(element)) {
***REMOVED***    return true;
***REMOVED***}

***REMOVED***match = new RegExp(params).exec(value);
***REMOVED***return (match && (match.index === 0) && (match[0].length === value.length));
    });

    $jQval.addMethod("nonalphamin", function (value, element, nonalphamin) {
***REMOVED***var match;
***REMOVED***if (nonalphamin) {
***REMOVED***    match = value.match(/\W/g);
***REMOVED***    match = match && match.length >= nonalphamin;
***REMOVED***}
***REMOVED***return match;
    });

    if ($jQval.methods.extension) {
***REMOVED***adapters.addSingleVal("accept", "mimtype");
***REMOVED***adapters.addSingleVal("extension", "extension");
    } else {
***REMOVED***// for backward compatibility, when the 'extension' validation method does not exist, such as with versions
***REMOVED***// of JQuery Validation plugin prior to 1.10, we should use the 'accept' method for
***REMOVED***// validating the extension, and ignore mime-type validations as they are not supported.
***REMOVED***adapters.addSingleVal("extension", "extension", "accept");
    }

    adapters.addSingleVal("regex", "pattern");
    adapters.addBool("creditcard").addBool("date").addBool("digits").addBool("email").addBool("number").addBool("url");
    adapters.addMinMax("length", "minlength", "maxlength", "rangelength").addMinMax("range", "min", "max", "range");
    adapters.addMinMax("minlength", "minlength").addMinMax("maxlength", "minlength", "maxlength");
    adapters.add("equalto", ["other"], function (options) {
***REMOVED***var prefix = getModelPrefix(options.element.name),
***REMOVED***    other = options.params.other,
***REMOVED***    fullOtherName = appendModelPrefix(other, prefix),
***REMOVED***    element = $(options.form).find(":input").filter("[name='" + escapeAttributeValue(fullOtherName) + "']")[0];

***REMOVED***setValidationValues(options, "equalTo", element);
    });
    adapters.add("required", function (options) {
***REMOVED***// jQuery Validate equates "required" with "mandatory" for checkbox elements
***REMOVED***if (options.element.tagName.toUpperCase() !== "INPUT" || options.element.type.toUpperCase() !== "CHECKBOX") {
***REMOVED***    setValidationValues(options, "required", true);
***REMOVED***}
    });
    adapters.add("remote", ["url", "type", "additionalfields"], function (options) {
***REMOVED***var value = {
***REMOVED***    url: options.params.url,
***REMOVED***    type: options.params.type || "GET",
***REMOVED***    data: {}
***REMOVED***},
***REMOVED***    prefix = getModelPrefix(options.element.name);

***REMOVED***$.each(splitAndTrim(options.params.additionalfields || options.element.name), function (i, fieldName) {
***REMOVED***    var paramName = appendModelPrefix(fieldName, prefix);
***REMOVED***    value.data[paramName] = function () {
***REMOVED******REMOVED***var field = $(options.form).find(":input").filter("[name='" + escapeAttributeValue(paramName) + "']");
***REMOVED******REMOVED***// For checkboxes and radio buttons, only pick up values from checked fields.
***REMOVED******REMOVED***if (field.is(":checkbox")) {
***REMOVED******REMOVED***    return field.filter(":checked").val() || field.filter(":hidden").val() || '';
***REMOVED******REMOVED***}
***REMOVED******REMOVED***else if (field.is(":radio")) {
***REMOVED******REMOVED***    return field.filter(":checked").val() || '';
***REMOVED******REMOVED***}
***REMOVED******REMOVED***return field.val();
***REMOVED***    };
***REMOVED***});

***REMOVED***setValidationValues(options, "remote", value);
    });
    adapters.add("password", ["min", "nonalphamin", "regex"], function (options) {
***REMOVED***if (options.params.min) {
***REMOVED***    setValidationValues(options, "minlength", options.params.min);
***REMOVED***}
***REMOVED***if (options.params.nonalphamin) {
***REMOVED***    setValidationValues(options, "nonalphamin", options.params.nonalphamin);
***REMOVED***}
***REMOVED***if (options.params.regex) {
***REMOVED***    setValidationValues(options, "regex", options.params.regex);
***REMOVED***}
    });
    adapters.add("fileextensions", ["extensions"], function (options) {
***REMOVED***setValidationValues(options, "extension", options.params.extensions);
    });

    $(function () {
***REMOVED***$jQval.unobtrusive.parse(document);
    });

    return $jQval.unobtrusive;
}));
