
$(document).ready(function () {
    $("#files").on("change", handleFileSelect);
});

function handleFileSelect(e) {
    var files = e.target.files;
    var filesArr = Array.prototype.slice.call(files);
    filesArr.forEach(function (f, item) {
        if (f.type.match("image.*")) {
            var reader = new FileReader();
            reader.readAsDataURL(f);
            $("#NombreArchivo").empty();
            $("#NombreArchivo").attr("title", f.name);
            $("#NombreArchivo").append("<span class='glyphicon glyphicon-file kv-caption-icon' style='display:inline-block'></span>" + f.name);
        }
        else {
            alert(f.name + ' no esta permitido cargarlo');
            return;
        }
    });
}

alertify.defaults.transition = "slide";
alertify.defaults.theme.ok = "btn btn-primary";
alertify.defaults.theme.cancel = "btn btn-danger";
alertify.defaults.theme.input = "form-control";