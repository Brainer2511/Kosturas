var listMarcas = [];
function AddMarca(id)
{
    if (FindMarca(id)) {
        listMarcas.splice($.inArray(id, listMarcas), 1);
    }
    else {
        listMarcas.push(id);
    }
    alert(listMarcas);
}
function FindMarca(id) {
    for (var i = 0; i < listMarcas.length; i++) {
        if (listMarcas[i]==id) {
            return true;
        }
    }
    return false;
}
oTable = $('.table').DataTable({
    "language": {
        "info": "Mostrando _START_ a _END_ de _TOTAL_ registros",
        "search": "Buscar",
        "infoEmpty": "Mostrando 0 to 0 of 0 datos    ",
        "infoFiltered": "(filtrar de _MAX_ datos totales)",
        "lengthMenu": "Mostrar _MENU_ datos",
        "loadingRecords": "Cargando...",
        "processing": "Procesando...",
        "zeroRecords": "Ningun registro coincide",
        "paginate": {
            "first": "Primero",
            "last": "Último",
            "next": "Siguiente",
            "previous": "Anterior"
        }
    },
    "dom": 'lfBrtip',
    buttons: [{ extend: 'print', text: '<span class="icon-printer"></span> Imprimir', className: 'btnO btnO-sm btnO-default' },
        { extend: 'pdfHtml5', text: '<span class="icon-file-pdf"></span> PDF', className: 'btnO btnO-sm btnO-default' },
        { extend: 'csvHtml5', text: '<span class="icon-libreoffice"></span> CSV', className: 'btnO btnO-sm btnO-default' },
        { extend: 'copy', text: '<span class="icon-copy"></span> Copiar', className: 'btnO btnO-sm btnO-default' },
        { extend: 'excelHtml5', text: '<span class="icon-file-excel"></span> Excel', className: 'btnO btnO-sm btnO-default' },
        {
            text: 'Omitir',
            className: 'btnO btnO-sm btnO-default',
            action: function (e, dt, node, config) {
                alert('Activated!');
                this.disable(); // disable button
            }
        }
    ],
    "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        if (aData[10] > aData[11]) {
            $('td', nRow).css('background-color', '#00C851');
        }
        else if (aData[10] < aData[11]) {
            $('td', nRow).css('background-color', '#F80');
        }
    }
});