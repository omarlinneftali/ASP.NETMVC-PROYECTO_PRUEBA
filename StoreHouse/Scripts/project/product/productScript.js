


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







function getProductData(searchQuery) {


    var url = "/Product/GetProducts";

    if (typeof searchQuery === "string") {

        url = "/Product/GetProducts/?searchQuery=" + searchQuery;

    }

    $.ajax({
        type: "Get",
        url: url,
        success: function (response) {
            $("#ProductTableData").html(response);


        }

    });

}

function filterByCategory(select) {


    var url = "/Product/GetProductsByCategoryID/?categoryID=" + select.value;


    $.ajax({
        type: "Get",
        url: url,
        success: function (response) {
            $("#ProductTableData").html(response);


        }

    });

    return false;
}


function submitProductForm(form) {




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

                getProductData();


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





function deleteProduct(url) {



    $.ajax({
        type: "GET",
        url: url,
        success: function (response) {

            if (response.isValid) {

                getProductData();

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

function searchProduct(searchInput) {

    getProductData(searchInput.value);

}


