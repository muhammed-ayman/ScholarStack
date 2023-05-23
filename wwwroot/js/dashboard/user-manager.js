$(document).ready(function () {
    var userId = -1;
    // Event handler for clicking the delete button
    $('table tbody').on('click', 'button.delete-user', function () {
        userId = $(this).closest('tr').data('user-id');
        console.log(userId);
        $('#deleteUserModal').modal('show');

    });

    $('.delete-user-modal').on('click', function () {
        var tempUserId = userId;
        console.log(tempUserId);
        // Perform the POST request to the server
        $.post('/api/dashboard/delete-user', { user_id: tempUserId })
            .done(function (data) {
                // Handle the response from the server
                console.log(data);
                successfulDeletion();
            })
            .fail(function (error) {
                console.log('Delete user request failed', error.responseText);
                
            });
    });

    function successfulDeletion() {
        deletedUserEntry = $(`tr[data-user-id="${userId}"]`);
        deletedUserEntry.remove();
        $('#deleteUserModal').modal('hide');
        alert('User deleted successfully!');
    }

    $(document).on('click', '.modal-cancel', function () {
        // Get the parent modal element
        var parentModal = $(this).closest('.modal');
        // Hide the modal
        parentModal.modal('hide');
    });

    // Event handler for clicking the ban button
    $('table tbody').on('click', 'button.btn-warning', function () {
        const userId = $(this).closest('tr').data('userid');
        $('#banUserModal').data('userid', userId);
        $('#banUserModal').modal('show');
    });

    // Event handler for clicking the activate button
    $('table tbody').on('click', 'button.btn-success', function () {
        const userId = $(this).closest('tr').data('userid');
        $('#activateUserModal').data('userid', userId);
        $('#activateUserModal').modal('show');
    });

    // Event handler for clicking the ban button in the ban user modal
    $('#banUserButton').click(function () {
        const userId = $('#banUserModal').data('userid');
        banUser(userId);
    });

    // Event handler for clicking the activate button in the activate user modal
    $('#activateUserButton').click(function () {
        const userId = $('#activateUserModal').data('userid');
        activateUser(userId);
    });
});