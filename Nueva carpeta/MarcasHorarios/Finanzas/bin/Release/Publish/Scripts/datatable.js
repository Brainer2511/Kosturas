var oTable;
var oTable1;
var oTable2;
var oTable3;

$(document).ready(function () { 
    $('.table4').DataTable({
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
        ]
    });

    if (oTable==null) {   
    oTable= $('.table0').DataTable({
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
        ]
        });
    }
    if (oTable1 == null) {
        oTable1 = $('.table1').DataTable({
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
            ]
        });
    }
    oTable2 = $('.table2').DataTable({
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
        ]
    });


    $('.buscar1').keyup(function () {
        debugger;
        oTable.columns(1).search($('.buscar1').val().trim());
        oTable1.columns(1).search($('.buscar1').val().trim());
        oTable2.columns(1).search($('.buscar1').val().trim());

        oTable.draw();
        oTable1.draw();
        oTable2.draw();
    });

    $('.buscar2').keyup(function () {
        debugger;
        oTable.columns(2).search($('.buscar2').val().trim());
        oTable1.columns(2).search($('.buscar2').val().trim());
        oTable2.columns(2).search($('.buscar2').val().trim());

        oTable.draw();
        oTable1.draw();
        oTable2.draw();
    });

    $('.buscar3').keyup(function () {
        debugger;
        oTable.columns(3).search($('.buscar3').val().trim());
        oTable1.columns(3).search($('.buscar3').val().trim());
        oTable2.columns(3).search($('.buscar3').val().trim());

        oTable.draw();
        oTable1.draw();
        oTable2.draw();
    });

    $('.buscar4').keyup(function () {
        debugger;
        oTable.columns(4).search($('.buscar4').val().trim());
        oTable1.columns(4).search($('.buscar4').val().trim());
        oTable2.columns(4).search($('.buscar4').val().trim());

        oTable.draw();
        oTable1.draw();
        oTable2.draw();
    });

    $('.buscar0').keyup(function () {
        debugger;

        oTable.columns(0).search($(this).val().trim());
       
        oTable.draw();
 
    });


    $('.buscar0-1').keyup(function () {
        debugger;
     
        oTable1.columns(0).search($(this).val().trim());
        
        oTable1.draw();
     
    });

});




jQuery.fn.dataTable.Api.register('sum()', function () {
    return this.flatten().reduce(function (a, b) {
        if (typeof a === 'string') {
            a = a.replace(/[^\d.-]/g, '') * 1;
        }
        if (typeof b === 'string') {
            b = b.replace(/[^\d.-]/g, '') * 1;
        }

        return a + b;
    }, 0);
});

//alertify.transition = "slide";
//alertify.theme.ok = "btn btn-primary";
//alertify.theme.cancel = "btn btn-danger";
//alertify.theme.input = "form-control";