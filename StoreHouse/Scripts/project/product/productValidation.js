$(function () {

    var form = $("#productForm");

    form.validate({
        rules: {
            "Product.Name": {
                required: true,
                minlength: 5
            },

            "Product.Description": {
                required: true,
                minlength: 9
            },
            "Product.Stock": {
                required: true,
                min: 0,
                digits: true
            },
            "Product.Price": {
                required: true,
                number: true,
                min: 1
            },
            "Product.CategoryID": {
                required: true

            },
            "Product.Category": {
                required: false
            }

        },
        messages: {
            "Product.Name": {
                required: "Debe suplir un valor",
                minlength: jQuery.validator.format("Debe tener al menos {0} caracteres")
            },

            "Product.Description": {
                required: "Debe suplir un valor",
                minlength: jQuery.validator.format("Debe tener al menos {0} caracteres")
            },
            "Product.Stock": {
                required: "Debe suplir un valor",
                digits: "Solo se acceptan numeros"
            },
            "Product.CategoryID": {
                required: "debe seleccionar una categoria",
            },
            "Product.Price": {
                required: "Debe suplir un valor",
                number: "solo se permiten valores numericos",
                min: jQuery.validator.format("el valor debe ser mayor o igual a  {0}")


            },





        },
        submitHandler: function (form, event) {

            event.preventDefault();

            submitProductForm(form);


        },
        errorClass: "invalid"


    });
})