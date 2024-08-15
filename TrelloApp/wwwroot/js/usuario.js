
/*Modal*/
function detalleusuario(idusuario) {
    var urlusuario = "/Usuario/_DetalleUsuarioPartialView?id=" + idusuario;
    $.ajax({
        url: urlusuario,
        success: function (data) {
            console.log(data);
            $("#modalW").html(data);
            $("#datosusuario").modal("show");
        }
    });
}