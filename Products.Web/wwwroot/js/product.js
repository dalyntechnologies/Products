//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: getBaseUrl() + "/v1/api/products/product",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
             
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.price + '</td>';
                html += '<td>' + item.releaseDate + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.id + ')">Edit</a>  | <a href="#" onclick="Delete(' + item.id + ')">Delete</a> | <a href="#" onclick="Details(' + item.id + ')">Details</a></td >  ';
                
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var productObj = {
      
        Name: $('#Name').val(),
        Price: +($('#Price').val()),
        ReleaseDate: new Date($('#ReleaseDate').val()),
    };
    $.ajax({
        url: getBaseUrl() + "/v1/api/products/product",
        data: JSON.stringify(productObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            // alert(errormessage.responseText);
            console.log(errormessage)
        }
    });
}  

function getbyID(productId) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
    $('#ReleaseDate').css('border-color', 'lightgrey');
    $.ajax({
        url: getBaseUrl() + "/v1/api/products/product/" + productId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {          
            $('#ProductId').val(result.id);
            $('#Name').val(result.name);
            $('#Price').val(result.price);
            $('#ReleaseDate').val(result.releaseDate)           
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
 
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var productObj = {
        Id: +($('#ProductId').val()),
        Name: $('#Name').val(),
        Price: +($('#Price').val()),
        ReleaseDate: $('#ReleaseDate').val(),
       
    };
    $.ajax({
        url: getBaseUrl() + "/v1/api/products/product/" + productObj.Id,
        data: JSON.stringify(productObj),
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ProductId').val("");
            $('#Name').val("");
            $('#Price').val("");
            $('#ReleaseDate').val("");
           
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

 
function Delete(productId) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: getBaseUrl() +"/v1/api/products/product/" + productId,
            type: "DELETE",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}





function getBaseUrl() {
    return "https://localhost:44323";
}
function clearTextBox() {
 
    $('#Name').val("");
    $('#Price').val("");
    $('#ReleaseDate').val("");   
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
    $('#ReleaseDate').css('border-color', 'lightgrey');
}
  
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Price').val().trim() == "") {
        $('#Price').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Price').css('border-color', 'lightgrey');
    }
    if ($('#ReleaseDate').val().trim() == "") {
        $('#ReleaseDate').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ReleaseDate').css('border-color', 'lightgrey');
    }

    return isValid;
}  


//comments
function addComment() {
    isValid = true;
    if ($('#CommentsBox').val().trim() == "") {
        $('#CommentsBox').css('border-color', 'Red');
        isValid = false;
        return;
    } else {
       
        $('#CommentsBox').css('border-color', 'lightgrey');
        
    }   
    
    var commentObj = {
        Comment: $('#CommentsBox').val().trim(), 
        ProductId: +($('#SelectedProductId').val())
    };

    

    $.ajax({
        url: getBaseUrl() + "/v1/api/comments/comment",
        data: JSON.stringify(commentObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadComments(+($('#SelectedProductId').val()));
            
        },
        error: function (errormessage) {
            // alert(errormessage.responseText);
            console.log(errormessage)
        }
    });



    $('#CommentsBox').val("");
    $('#CommentsBox').css('border-color', 'lightgrey');
}

function loadComments(id) {
    $.ajax({
        url: getBaseUrl() + "/v1/api/comments/comment/" +id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

         
            $('#CommentsList').empty();
            
      
            $.each(result, function (key, item) {
               
                var fixingContent =
                    '<li >' + item.commentDescription + '</li>';
                $('.List').append(fixingContent);
            });
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Details(productId) {
    getProductsDetails(productId);
}

function getProductsDetails(productId) {
   
    $.ajax({
        url: getBaseUrl() + "/v1/api/products/product/" + productId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#SelectedProductId').val(result.id);
            $('#SelectedProduct').text(result.name);
            
            $('#CommentsSection').show();
            loadComments(result.id);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}