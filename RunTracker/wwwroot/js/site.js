// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$(() => {
//    // Hide the delete confirmation initially
//    $("#confirm-delete-container").hide();

//    $(".run").each(function (i, obj) {
//        $(obj).on("click", () => {
//            var flip = obj.querySelector(".flip-container");
//            flip.classList.toggle("flipped");
//        });
//    });
//});

//function confirmDelete(runId) {
//    var popup = $("#confirm-delete-container");
//    popup.fadeToggle();

//    $("#confirm-delete").on("click", () => {
//        var hiddenField = document.querySelector("#delete-form > input");
//        hiddenField.value = runId;
//        var form = document.querySelector("#delete-form");
//        form.action = "/Home/Delete/DeleteRun?Id=" + runId;
//        form.submit();
//        popup.fadeToggle();
//    });

//    $("#cancel-delete").on("click", () => {
//        popup.fadeToggle();
//    });
//}