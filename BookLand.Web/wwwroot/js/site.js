var table;
var datatable;
var updatedRow;
function showSuccessMessage() {
    toastr.options = {
        "progressBar": true,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": true,
        "showDuration": "200",
        "hideDuration": "200",
        "timeOut": "3000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    toastr.success('Done successfully');
};

function onModalSuccess(row) {
    showSuccessMessage();
    $('#Modal').modal('hide');

    if (updatedRow !== undefined) {
        datatable.row(updatedRow).remove().draw();
        updatedRow = undefined;
    }

    var newRow = $(row);
    datatable.row.add(newRow).draw();

    KTMenu.init();
    KTMenu.initHandlers();

};

$(function () {
    KTUtil.onDOMContentLoaded(function () {
        KTDatatablesExample.init();
    });

    $('.js-render-modal').on('click', function () {
        var modal = $('#Modal');
        var btn = $(this);

        if (btn.data('update') !== undefined) {
            updatedRow = btn.parents('tr');
        }
        $.get({
            url: btn.data('url'),
            success: function (modalView) {
                modal.find('.modal-body').html(modalView);
                $.validator.unobtrusive.parse(modal);
            }
        });
        modal.find('.modal-title').text(btn.data('title'));

        modal.modal('show');
    });
});

var KTDatatablesExample = function () {
    var initDatatable = function () {
        datatable = $(table).DataTable({
            "info": false,
            'order': [],
            'pageLength': 10,
        });
    }

    var exportButtons = () => {
        const documentTitle = 'Categories';
        var buttons = new $.fn.dataTable.Buttons(table, {
            buttons: [
                {
                    extend: 'copyHtml5',
                    title: documentTitle
                },
                {
                    extend: 'excelHtml5',
                    title: documentTitle
                },
                {
                    extend: 'csvHtml5',
                    title: documentTitle
                },
                {
                    extend: 'pdfHtml5',
                    title: documentTitle
                }
            ]
        }).container().appendTo($('#kt_datatable_example_buttons'));

        const exportButtons = document.querySelectorAll('#kt_datatable_example_export_menu [data-kt-export]');
        exportButtons.forEach(exportButton => {
            exportButton.addEventListener('click', e => {
                e.preventDefault();

                const exportValue = e.target.getAttribute('data-kt-export');
                const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                target.click();
            });
        });
    }

    var handleSearchDatatable = () => {
        const filterSearch = document.querySelector('[data-kt-filter="search"]');
        filterSearch.addEventListener('keyup', function (e) {
            datatable.search(e.target.value).draw();
        });
    }

    return {
        init: function () {
            table = document.querySelector('#data-table');

            if (!table) {
                return;
            }

            initDatatable();
            exportButtons();
            handleSearchDatatable();
        }
    };
}();