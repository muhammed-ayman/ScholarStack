$(document).ready(function () {

    class UserManagement {
        constructor() { }

        // Code for deleting a user
        deleteUser(userId) {
            console.log("deleteUser called with userId:", userId);
            $.ajax({
                type: 'DELETE',
                url: '/Admin Dashboard/User Management/delete-user?id=' + userId,
                success: function () {
                    $('#deleteUserModal').modal('hide');

                    alert('User deleted successfully.');

                    location.reload();
                },
                error: function () {
                    alert('Failed to delete user.');
                }
            });
        }

        // Code for banning a user
        banUser(userId) {
            $.ajax({
                type: 'POST',
                url: '/admin/banuser/' + userId,
                success: function () {
                    $('#banUserModal').modal('hide');

                    alert('User banned successfully.');

                    location.reload();
                },
                error: function () {
                    alert('Failed to ban user.');
                }
            });
        }

        // Code for activating a user
        activateUser(userId) {
            $.ajax({
                type: 'POST',
                url: '/admin/activateuser/' + userId,
                success: function () {
                    $('#activateUserModal').modal('hide');

                    alert('User activated successfully.');
                    location.reload();
                },
                error: function () {
                    alert('Failed to activate user.');
                }
            });
        }
    }

    // Event handler for clicking the delete button
    $('table tbody').on('click', 'button.btn-danger', function () {
        const userId = $(this).closest('tr').data('userid');
        $('#deleteUserModal').data('userid', userId);
        $('#deleteUserModal').modal('show');

        $('#deleteUserButton').off('click').on('click', function () {
            deleteUser(userId);
        });
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