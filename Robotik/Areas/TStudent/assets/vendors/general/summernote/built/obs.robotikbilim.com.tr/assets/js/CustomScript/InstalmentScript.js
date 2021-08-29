'use strict';
function getInstalments() {
    debugger;
    var table = $('#kt_table_instalment');
    table.DataTable({
        ajax: {
            url: '/Instalment/GetInstalments/',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: "json"
        },
        columns: [
            { data: 'Student' },
            { data: 'Classroom' },
            { data: 'Parent' },
            { data: 'Amount' },
            {
                data: 'Date',
                "type": "date",
                "render": function parseJsonDate(jsonDate) {
                    var fullDate = new Date(parseInt(jsonDate.substr(6)));
                    var twoDigitMonth = (fullDate.getMonth() + 1) + "";
                    if (twoDigitMonth.length == 1)
                        twoDigitMonth = "0" + twoDigitMonth;
                    var twoDigitDate = fullDate.getDate() + "";
                    if (twoDigitDate.length == 1)
                        twoDigitDate = "0" + twoDigitDate;
                    var currentDate = fullDate.getFullYear() + "/" + twoDigitMonth + "/" + twoDigitDate;
                    return currentDate;
                }
            },
            { data: 'User' },
            { data: 'Note' },
            {
                data: 'IsCompleted',
                render: function (data, type, full, meta) {
                    debugger;
                    var result = "";
                    if (full['IsCompleted'] == true) {
                        result = '<span style="width: 131px;"><span class="kt-badge kt-badge--success kt-badge--inline kt-badge--pill">Ödendi</span></span>';
                    }
                    else if (full['Status'] < 0) {
                        result = '<span style="width: 131px;"><span class="kt-badge kt-badge--warning kt-badge--inline kt-badge--pill">Ödenmedi</span></span>';
                    }
                    else {
                        result = '<span style="width: 131px;"><span class="kt-badge kt-badge--danger kt-badge--inline kt-badge--pill">Vadesi Geçmiş</span></span>';
                    }
                    return result;
                }
            }
        ],
        "order": [[4, "desc"]],
        lengthChange: false,
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        },
        responsive: true,
        orderCellsTop: true,
        fixedHeader: true,
        "destroy": true,
        "pageLength": 50
    });
}
;
//# sourceMappingURL=InstalmentScript.js.map