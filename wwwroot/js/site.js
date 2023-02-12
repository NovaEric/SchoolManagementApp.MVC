// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//SweetAlert

$(function () {
  $('.table').DataTable();
  $(".deleteBtn").click(function (e) {
    swal({
      title: "Are you sure?",
      text: "Once deleted, you will not be able to recover it!",
      icon: "warning",
      buttons: true,
      dangerMode: true,
    }).then((willDelete) => {
      if (willDelete) {
        swal("Seccessfully deleted!", {
          icon: "success",
        });
        var btn = $(this);
        var id = btn.data("id");
        $("#deleteid").val(id);
        $("#deleteForm").submit();
      }
    });
  });
});
