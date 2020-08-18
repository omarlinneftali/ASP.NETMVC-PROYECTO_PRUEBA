function submitUserForm(form) {

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