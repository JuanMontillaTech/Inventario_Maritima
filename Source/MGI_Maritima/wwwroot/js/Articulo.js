var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/Articulo/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "nombre", "width": "20%" },
            { "data": "descripcion", "width": "20%" }, 
            {
                "data": "id",
                "render": function (data) {                   
                    return `<div class="text-center">
                        <a href="/Articulo/UpInsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Editar
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:80px;'
                            onclick=Delete('/Articulo/Delete?id='+${data})>
                            Eliminar
                        </a>
                        </div>`;
                }, "width": "10%"
            }
        ],
        "language": {
            "emptyTable": "Data no encontrada",
            "lengthMenu": "Mostrando _MENU_ registros por pagina",
            "zeroRecords": "Nothing found - sorry",
            "info": "Mostrando page _PAGE_ of _PAGES_",
            "infoEmpty": "No hay registros disponibles.",
            "infoFiltered": "(filtered from _MAX_ total records)",
            "sSearch": "Buscar",
            "oPaginate": {
                "sNext": "Siguiente",
                "sPrevious": "Regresar"
            }

        },
        "width": "100%"
    });
}

function Delete(url) {
      Swal.fire({
        title: 'Esta Seguro de eliminar?',
        text: "No Podra Recuperar Este registro!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
