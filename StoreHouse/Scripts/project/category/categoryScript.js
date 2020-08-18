




function openModal(url, title) {





    $.ajax({
        type: "GET",
        url: url,
        success: function (response) {




            $("#formModal .modal-body").html(response);
            $("#formModal .modal-title").html(title);
            $("#formModal").modal("show");


        }


    });

    return false;
}







function getCategoryData(searchQuery) {


    var url = "/Category/GetCategories";

    if (typeof searchQuery === "string") {

        url = "/Category/GetCategories/?searchQuery=" + searchQuery;

    }







    $.ajax({
        type: "Get",
        url: url,
        success: function (response) {
            $("#CategoryTableData").html(response);


        }

    });

}



function submitForm(form) {




    var data = new FormData(form);

    $.ajax({
        type: "Post",
        url: form.action,
        data: data,
        processData: false,
        contentType: false,




        success: function (response) {




            if (response.isValid) {
                $("#formModal").modal("hide");

                getCategoryData();


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





function deleteCategory(url) {



    $.ajax({
        type: "GET",
        url: url,
        success: function (response) {

            if (response.isValid) {

                getCategoryData();

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
                console.log("error");


            }

        }


    });

    return false;

}

function searchCategory(searchInput) {

    getCategoryData(searchInput.value);

}



