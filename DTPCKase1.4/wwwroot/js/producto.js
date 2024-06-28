var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {url:'/admin/producto/getall'},
        "columns": [
            { data: 'nom_prod', "width": "25%" },
            { data: 'desc_prod', "width": "25%" },
            { data: 'stck_prod', "width": "15%" },
            { data: 'prec_prod', "width": "15%" },
            { data: 'categoria.nom_categoria', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                          <a href="/admin/producto/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Editar</a>  
                          <a onClick=Delete('/admin/producto/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Eliminar</a> 
                          </div>`
                },
                "width": "25%"
            }
         ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Estas Seguro?",
        text: "Esta acción no se puede revertir!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, elimínalo!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);

                }
            })
        }
    });
}