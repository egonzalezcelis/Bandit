
function find(url, tblId, fresponse, ocolumns) {
    $.ajaxSetup({
        'beforeSend': function (xhr) {
            xhr.overrideMimeType('text/html; charset=iso-8859-1');
        },
        cache: false
    });
    var otable = $("#" + tblId);
    var tbl;
    tbl = otable.DataTable({
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sInfo": "Mostrando desde _START_ hasta _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando desde 0 hasta 0 de 0 registros",
            "sInfoFiltered": "(filtrado de _MAX_ registros en total)",
            "sInfoPostFix": "",
            "sSearch": "Filtrar Resultados:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Primero",
                "sPrevious": "Anterior",
                "sNext": "Siguiente",
                "sLast": "Ultimo"
            }
        },
        "ajax": {
            "url": url,
            "cache": false
        },
        "columns": ocolumns
    });
    $.fn.dataTable.ext.errMode = 'throw';
    $("#" + tblId + " tbody").on('click', 'a', function () {
        var data = this.id.replace("dbtn.", "");
        fresponse(data);
    });
}

