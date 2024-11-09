var dataTable;

$(document).ready(function () {
    cargarDatatable();
});



function cargarDatatable() {
    dataTable = $("#tbl_programas").DataTable({

        "ajax": {
            "url": "/ConfiguradorSIGA/Programas/GetAllVobo",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            /* { "data": "id", "width": "5%" },*/
            { "data": "nombre", "width": "30%" },
            {
                "data": "tipoProgramaId",
                "render": function (data) {
                    return (data === 1) ? `<span class="text-center">Reglas de operación
                          </span > ` : `<span class="text-center">Lineamiento
                          </span >`;
                },
                "width": "15%",
                "className": "text-center"
            },
            { "data": "fechaInicio", "width": "10%", "className": "text-center" },
            { "data": "fechaFin", "width": "10%", "className": "text-center" },
            {
                "data": "presupuesto",
                "render": $.fn.dataTable.render.number(',', '.', 2, '$ '),
                with: "10%", "className": "text-center"
            },
            {
                "data": "estatusProgramaId",
                "render": function (data) {
                    if (data == 1)
                    {   
                        return `<span class="badge text-bg-primary" title="Programa creado">Creado</span > `
                    }
                    if (data == 2) {

                        return `<span class="badge text-bg-info title="El programa se ha enviado a Planeación para su validación">Enviado a VoBo</span > `
                    }
                    if (data == 3) {
                        return `<span class="badge text-bg-warning" title="El programa tiene observaciones realizadas por Planeación">Observado</span > `
                    }
                    if (data == 4) {
                        return `<span class="badge text-bg-success" title="El programa ha sido revisado y aprobado por Planeación">Autorizado</span > `
                    }
                },
                "className": "text-center",
                "with:": "10%"
            },
            
            {
                "data": "id",
               
                "render": function (data, type, row) {

                    switch (row.estatusProgramaId)
                    {
                        case 1:
                            return `<div class="text-center">
                                    <a href="/ConfiguradorSIGA/Programas/Edit/${data}" class="text-info" title="Editar" style="cursor:pointer;  font-size: x-large">
                                    <i class="bi bi-pencil-square"></i>
                                    </a>
                                    &nbsp;
                                    <a href="/ConfiguradorSIGA/Programas/Componentes/${data}" class="text-primary" title="Agregar componente presupuestal"  style="cursor:pointer;font-size: x-large">
                                    <i class="bi bi-wrench-adjustable-circle-fill"></i>
                                    </a>
                                    &nbsp;

                                    <a onclick=VoBo("/ConfiguradorSIGA/Programas/VoBoArea/${data}") class="text-primary" title="Enviar programa para su aprobación"  style="cursor:pointer;font-size: medium">
                                    VoBo
                                    </a>
                              </div>
                             `;
                            break;
                        case 2:
                            return `<div class="text-center small">
                                   Programa enviado a validación
                              </div>
                             `;
                            break;
                        case 3:
                            return `<div class="text-center">
                                    <a href="/ConfiguradorSIGA/Programas/Edit/${data}" class="text-info" title="Editar" style="cursor:pointer;  font-size: x-large">
                                    <i class="bi bi-pencil-square"></i>
                                    </a>
                                    &nbsp;
                                    <a href="/ConfiguradorSIGA/Programas/Componentes/${data}" class="text-primary" title="Agregar componente presupuestal"  style="cursor:pointer;font-size: x-large">
                                    <i class="bi bi-wrench-adjustable-circle-fill"></i>
                                    </a>
                                    &nbsp;

                                    <a onclick=VoBo("/ConfiguradorSIGA/Programas/VoBoArea/${data}") class="text-primary" title="Enviar programa para su aprobación"  style="cursor:pointer;font-size: medium">
                                    VoBo
                                    </a>
                              </div>
                             `;
                            break;
                        case 4:
                            return `<div class="text-center small">
                                   Programa autorizado
                              </div>
                             `;
                            break;
                        default:
                            return `<div class="text-center">
                                   
                              </div>
                             `;
                    }

                   /* return "Data 1: " + row.estatusProgramaId;*/
                    
                }, "width": "20%"
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

    function VoBo(url) {
        swal({
            title: "¿Estas seguro que deseas enviar el programa a validación de planeación?",
            text: "Este contenido no se podrá editar",
            type: "warning",
            showCancelButton: true,
            cancelButtonText: "Cancelar",
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Si, enviar",
            closeOnConfirm: false
        }, function (isConfirm) {
            if (!isConfirm) return;
            $.ajax({
                url: url,
                type: "GET",
                success: function () {
                    swal("OK", "El registro se envió correctamente", "success");
                    dataTable.ajax.reload();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    swal("Error deleting!", "Please try again", "error");
                }
            });
        });
    }

