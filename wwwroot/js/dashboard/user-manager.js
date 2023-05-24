$(document).ready(function () {
    var userId = -1;

    // --- User Deletion --- //
    // Show Delete Modal
    $('table tbody').on('click', 'button.delete-user', function () {
        userId = $(this).closest('tr').data('user-id');
        $('#deleteUserModal').modal('show');
    });

    // Modal Delete button
    $('.delete-user-modal').on('click', function () {
        // Perform the POST request to the server
        $.post('/api/dashboard/delete-user', { user_id: userId })
            .done(function (data) {
                // Handle the response from the server
                console.log(data);
                successfulDeletion();
            })
            .fail(function (error) {
                console.log('Delete user request failed');
            });
    });

    // Successful Deletion alert
    function successfulDeletion() {
        UserEntry = $(`tr[data-user-id="${userId}"]`);
        UserEntry.remove();
        $('#deleteUserModal').modal('hide');
        alert('User deleted successfully!');
    }



    // --- User Ban --- //
    // Show Ban Modal
    $('table tbody').on('click', 'button.ban-user', function () {
        userId = $(this).closest('tr').data('user-id');
        $('#banUserModal').modal('show');
    });

    // Modal Ban button
    $('.ban-user-modal').on('click', function () {
        // Perform the POST request to the server
        $.post('/api/dashboard/ban-user', { user_id: userId })
            .done(function (data) {
                // Handle the response from the server
                console.log(data);
                successfulBan();
            })
            .fail(function (error) {
                console.log('Ban user request failed');
            });
    });

    // Successful Ban alert
    function successfulBan() {
        UserEntry = $(`tr[data-user-id="${userId}"]`);
        UserEntry.css('color', 'red');
        $('#banUserModal').modal('hide');
        alert('User banned successfully!');
    }



    // --- User Activation --- //
    // Show Activate Modal
    $('table tbody').on('click', 'button.activate-user', function () {
        userId = $(this).closest('tr').data('user-id');
        $('#activateUserModal').modal('show');
    });

    // Modal Activate button
    $('.activate-user-modal').on('click', function () {
        // Perform the POST request to the server
        $.post('/api/dashboard/activate-user', { user_id: userId })
            .done(function (data) {
                // Handle the response from the server
                console.log(data);
                successfulActivate();
            })
            .fail(function (error) {
                console.log('Activate user request failed');
            });
    });

    // Successful Activate alert
    function successfulActivate() {
        UserEntry = $(`tr[data-user-id="${userId}"]`);
        UserEntry.css('color', 'black');
        $('#activateUserModal').modal('hide');
        alert('User activated successfully!');
    }



    // Modal Cancel button
    $(document).on('click', '.modal-cancel', function () {
        // Get the parent modal element
        var parentModal = $(this).closest('.modal');
        // Hide the modal
        parentModal.modal('hide');
    });
});

