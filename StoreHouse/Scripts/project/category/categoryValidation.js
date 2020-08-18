$(function () {

    var form = $("#categoryForm");

    form.validate({
        rules: {
            Name: {
                required: true,
                minlength: 7
            },

            Description: {
                required: true,
                minlength: 9
            }
        },
        messages: {
            Name: {
                required: "debe suplir un valor",
                minlength: jQuery.validator.format("Debe tener al menos {0} caracteres")
            },

            Description: {
                required: "debe suplir un valor",
                minlength: jQuery.validator.format("Debe tener al menos {0} caracteres")
            }


        },
        submitHandler: function (form, event) {

            event.preventDefault();

            submitForm(form);


        },
        errorClass: "invalid"


    });








})

