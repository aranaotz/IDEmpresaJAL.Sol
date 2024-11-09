var dataTable;

$(document).ready(function () {
    cargarDatatable();
});



function cargarDatatable() {
    dataTable = $("#tbl_TipoSolicitante").DataTable({
        "ajax": {
            "url": "/gestion/CTipoSolicitantes/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
           /* { "data": "id", "width": "5%" },*/
            { "data": "tipoSolicitante", "width": "15%" },
            { "data": "descripcion", "width": "70%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Gestion/CTipoSolicitantes/Edit/${data}" class="text-info" title="Editar" style="cursor:pointer;  font-size: x-large">
                                <i class="bi bi-pencil-square"></i>
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Gestion/CTipoSolicitantes/Delete/${data}") class="text-danger" title="Eliminar"  style="cursor:pointer;font-size: x-large">
                                <i class="bi bi-trash3-fill"></i>
                                </a>
                          </div>
                         `;
                }, "width": "10%"
            }
        ],
       
        pageLength: 25,
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando  _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 a 0 de 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                //"first": "Primero",
                //"last": "Ultimo",
                //"next": "Siguiente",
                //"previous": "Anterior"
            }
        },
        "width": "100%"
    });
}
function Delete(url) {
    swal({
        title: "¿Estas seguro de borrar?",
        text: "Este contenido no se podrá recuperar",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar",
        closeOnConfirm: false
    }, function (isConfirm) {
        if (!isConfirm) return;
        $.ajax({
            url: url,
            type: "DELETE",
            success: function () {
                swal("OK", "El registro se eliminó correctamente", "success");
                dataTable.ajax.reload();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                swal("Error deleting!", "Please try again", "error");
            }
        });
    });
}

