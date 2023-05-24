$(document).ready(function () {
    var privilegeId = -1;

    // Show Delete Modal
    $('table tbody').on('click', 'button.delete-privilege', function () {
        privilegeId = $(this).closest('tr').data('privilege-id');
        $('#deletePrivilegeModal').modal('show');
        console.log(privilegeId);
    });

    // Modal Delete button
    $('.delete-privilege-modal').on('click', function () {
        // Perform the POST request to the server
        $.post('/api/dashboard/delete-privilege', { privilege_id: privilegeId })
            .done(function (data) {
                // Handle the response from the server
                console.log(data);
                successfulDeletion();
            })
            .fail(function (error) {
                console.log('Delete privilege request failed');
            });
    });

    // Successful Deletion alert
    function successfulDeletion() {
        PrivilegeEntry = $(`tr[data-privilege-id="${privilegeId}"]`);
        PrivilegeEntry.remove();
        $('#deletePrivilegeModal').modal('hide');
        alert('Privilege deleted successfully!');
    }

    // Modal Cancel button
    $(document).on('click', '.modal-cancel', function () {
        // Get the parent modal element
        var parentModal = $(this).closest('.modal');
        // Hide the modal
        parentModal.modal('hide');
    });
});