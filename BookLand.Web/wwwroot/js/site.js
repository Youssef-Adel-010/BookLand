var updatedRow;

$(function () {
    // Handle modal render
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

function onModalSuccess(item) {
    showSuccessMessage();
    $('#Modal').modal('hide');

    if (updatedRow === undefined) {
        $('.fill-the-table').append(item);
    } else {
        $(updatedRow).replaceWith(item);
        updatedRow = undefined;
    }

};