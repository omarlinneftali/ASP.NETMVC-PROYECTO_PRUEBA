function submitLoginForm(form) {


    var data = new FormData(form);

    $.ajax({
            type: "Post",
            url: form.action,
            data: data,
            processData: false,
            contentType: false,

            success: function (response) {

                if (response.isValid) {

                    window.location.href = "/Product/index";

                    $.notify(response.message,
                        {
                            globalPosition: "top center",
                            className: "success"
                        });

                } else {

                    $.notify(response.message,
                        {
                            globalPosition: "top center",
                            className: "error"
                        });
                }

            },
            error: function (error) {
                console.log("error");
            }

        }
    );

    return false;

}




$(function () {

    var form = $("#loginForm");

    form.validate({
        rules: {
            
            Password: {
                required: true,
                minlength: 4

            },
           
            Email: {
                required: true,
                email: true

            }
        },
        messages: {

            
            Password: {
                required: "Este campo es requerido",
                minlength: jQuery.validator.format("Debe tener al menos {0} caracteres")

            },
            
            Email: {
                required: "Este campo es requerido",
                email: "Debe introducir un email valido"

            }

        },
        submitHandler: function (form, event) {

            event.preventDefault();

            submitLoginForm(form);


        },
        errorClass: "invalid"


    });
})