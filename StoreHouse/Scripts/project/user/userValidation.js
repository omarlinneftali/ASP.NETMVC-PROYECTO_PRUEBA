
$(function () {

    var form = $("#userForm");

    form.validate({
        rules: {
            Name: {
                required: true,
                minlength: 5
            },

            UserName: {
                required: true,
                minlength: 6
            },
            Password: {
                required: true,
                minlength: 8

            },
            ConfirmPassword: {
                required: true,
                minlength: 8,
                equalTo: "#Password"


            },
            Email: {
                required: true,
                email: true

            }

        },
        messages: {

            Name: {
                required: "Este campo es requerido",
                minlength: jQuery.validator.format("Debe tener al menos {0} caracteres")
            },

            UserName: {
                required: "Este campo es requerido",
                minlength: jQuery.validator.format("Debe tener al menos {0} caracteres")
            },
            Password: {
                required: "Este campo es requerido",
                minlength: jQuery.validator.format("Debe tener al menos {0} caracteres")

            },
            ConfirmPassword: {
                required: "Este campo es requerido",
                minlength: jQuery.validator.format("Debe tener al menos {0} caracteres"),
                equalTo: "Este campo no coincide con la contraseña"


            },
            Email: {
                required: "Este campo es requerido",
                email: "Debe introducir un email valido"

            }

        },
        submitHandler: function (form, event) {

            event.preventDefault();

            submitUserForm(form);


        },
        errorClass: "invalid"


    });
})