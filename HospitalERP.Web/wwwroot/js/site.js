$(document).ready(function () {
    $('.row-menu').click(function () {      
        $('.button-section').toggleClass('hidden');
    });

    $('.delete-button').click(function () {
        var confirmationId = $(this).data('delete-confirmation');
        $(confirmationId).toggleClass('hidden');
    });

    $('.confirm-delete, .cancel-delete').click(function () {
        $('.hidden-buttons').addClass('hidden');
    });
    $('[data-toggle="tooltip"]').tooltip();
});