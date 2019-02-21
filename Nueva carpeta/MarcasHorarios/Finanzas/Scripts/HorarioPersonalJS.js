
$(function () {
    $('#fecha').datetimepicker({
        format: "DD/MM/YYYY",
        sideBySide: true,
        widgetPositioning: {
            horizontal: 'right',
            vertical: 'top'
        }
    });
    $('#hora').datetimepicker({
        format: "HH:mm",
        sideBySide: true,
        widgetPositioning: {
            horizontal: 'right',
            vertical: 'top'
        }
    });
});
