var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "api/book",
            "type": "GET",
            "dataType": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbm", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-danger">
                             <a href="/BookList/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                             Edit
                             </a>
                             &nbsp;
                             <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                                onClick=Delete('api/Delete/id='+${data})>
                             Delete
                             </a>
                            </div>
                           `;
                },
                "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}