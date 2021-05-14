
$(document).ready(function () {
    cargarGrid();
});
function cargarGrid() {
    $.ajax({
        url: '/Usuarios/GetLista',
        method: 'get',
        success: function (data) {
            BuilDataTable(data);
        }
    });
}
function BuilDataTable(data) {

    table = $('#tbUsuarios').dataTable({
        destroy: true,

        data: data,
        'columns': [
            { "key": true, "title": "Id", "data": "Id", "searchable": false, "visible": false },
            { "key": false, "title": "Nombre", "data": "Nombre", "searchable": true },
            { "key": false, "title": "Apellido Paterno", "data": "ApellidoP", "searchable": true },
            { "key": false, "title": "Correo", "data": "Email", "searchable": true },
            {
                "title": "Acciones",
                "sWidth": "28%",
                "data": "Id",
                "searchable": false,
                "sortable": false,
                "render": function (data, type, full, meta) {
                    return "<a title='Actualizar' href='Usuarios/Editar/' class='editUsuario btn btn-success glyphicon glyphicon-pencil'> </a> | " +
                            "<a title='Detalles' href='Usuarios/Consulta/" + data + "' class='detailsUsuario btn btn-primary glyphicon glyphicon-eye-open'> </a> | " +
                            "<a title='Eliminar' href='Usuarios/Eliminar/" + data + "' class='deleteUsuario btn btn-danger glyphicon glyphicon-trash'> </a>";
                }
            }
        ],
        'lengthMenu': [[5, 10, 15], [5, 10, 15]],
        language: {
            url: "/Content/Plugins/DataTable/Spanish.json"
        }
    });
    
    $("#btnAgregar").click(function(){
        event.preventDefault();
        var url = $(this).data("url");
        $.get(url, function (data) {
            var modal = $('#ContainerModal').html(data);
            $('#TitleModal').html('Nueva Taxonomía N1');
            $('#PrincipalModal').modal('show');
        });

    });

    $('.editUsuario').on("click", function (event) {

        event.preventDefault();

        var url = $(this).attr("href");

        $.get(url, function (data) {
            var modal = $('#ContainerModal').html(data);
            $('#TitleModal').html('Editar Usuario');
            $('#PrincipalModal').modal('show');
        });

    });


    $('#tbUsuarios').on("click", ".detailsUsuario", function (event) {

        event.preventDefault();

        var url = $(this).attr("href");

        $.get(url, function (data) {
            var modal = $('#ContainerModal').html(data);
            $('#TitleModal').html('Detalle Usuario');
            $('#PrincipalModal').modal('show');
        });

    });

    $('#tbUsuarios').on("click", ".deleteUsuario", function (event) {
        event.preventDefault();
        var url = $(this).attr("href");
        $.get(url, function (data) {
            var modal = $('#ContainerModal').html(data);
            $('#TitleModal').html('Eliminar Usuario');
            $('#PrincipalModal').modal('show');
        });

    });
    function CreateSuccess(data) {
        if (data != "success") {
            $('#ContainerModal').html(data);
            return;
        }
        $('#PrincipalModal').modal('hide');
        $('#ContainerModal').html("");
        swal("Exito", "Se ha guardado el registro exitosamente.", "success")
        cargarGrid()
    }
    function UpdateSuccess(data) {
        if (data != "success") {
            $('#ContainerModal').html(data);
            return;
        }
        $('#PrincipalModal').modal('hide');
        $('#ContainerModal').html("");
        swal("Exito", "Se ha actualizado el registro exitosamente.", "success")
        cargarGrid()
    }
    function DeleteSuccess(data) {
        if (data != "success") {
            $('#ContainerModal').html(data);
            return;
        }
        $('#PrincipalModal').modal('hide');
        $('#ContainerModal').html("");
        swal("Exito", "Se ha eliminado el registro exitosamente.", "success")
        cargarGrid()
    }
}


