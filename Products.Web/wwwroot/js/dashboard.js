//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadTotalProductsData();
    loadTotalCommentsPerProductData();
});

//Load Data function  
function loadTotalProductsData() {
    $.ajax({
        url: getBaseUrl() + "/v1/api/dashboard/totalproducts",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result);    
            $('#TotalProducts').text(result.totalProducts);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });


}


function loadTotalCommentsPerProductData() {
    $.ajax({
        url: getBaseUrl() + "/v1/api/dashboard/commentsperproduct",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';

                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.total + '</td>';
               

                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}









function getBaseUrl() {
    return "https://localhost:44323";
}





