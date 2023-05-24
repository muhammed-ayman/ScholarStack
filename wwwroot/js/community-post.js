$(document).ready(function () {
    // Function to update the vote count
    function updateVoteCount(postId) {
        $.ajax({
            type: 'GET',
            url: `/api/community-post/${postId}/votes`,
            success: function (response) {
                // Update the vote count elements
                var upvotesElement = $(`.user-post[data-post-id="${postId}"] .upvote-btn ins`);
                var downvotesElement = $(`.user-post[data-post-id="${postId}"] .downvote-btn ins`);
                upvotesElement.text(response.upvotes);
                downvotesElement.text(response.downvotes);

                // Update the vote count in the post meta-data
                var postMetaElement = $(`.user-post[data-post-id="${postId}"] .post-meta`);
                var commentCountElement = postMetaElement.find('.comment ins');
                var upvoteCountElement = postMetaElement.find('.like ins');
                var downvoteCountElement = postMetaElement.find('.dislike ins');

                commentCountElement.text(response.commentCount);
                upvoteCountElement.text(response.upvotes);
                downvoteCountElement.text(response.downvotes);
            },
            error: function () {
                // Display an error message if the AJAX request fails
                alert('An error occurred while retrieving the vote count. Please try again.');
            }
        });
    }

    // Function to handle adding a comment
    function addComment(postId, commentText) {
        $.ajax({
            type: 'POST',
            url: `/api/community-post/${postId}/add-comment`,
            data: { comment_text: commentText },
            success: function (response) {
                // Handle the response from the server
                console.log('Comment added successfully');
                console.log(response);

                // Optionally, you can perform additional actions after adding the comment
                // For example, you can update the comment count or display the new comment on the page

                // Update the vote count
                updateVoteCount(postId);

                // Add the new comment to the page
                var user = response.user;
                var comment = response.comment;
                var commentHtml = `
                    <li>
                        <div class="comet-avatar">
                            <img src="images/profile/admin.png" alt="">
                        </div>
                        <div class="we-comment">
                            <div class="coment-head">
                                <h5><a href="#" title="">${user.username}</a></h5>
                                <span>${comment.timeStamp}</span>
                                <a class="we-reply" href="#" title="Reply"><i class="fa fa-reply"></i></a>
                                <a class="we-reply" style="color: red;" href="#" title="Delete Comment" id="delete-comment"><i class="fa fa-trash"></i></a>
                                <a class="we-reply" style="color: rgb(128, 0, 0);" href="#" title="Ban User" id="ban-user"><i class="fa fa-ban"></i></a>
                            </div>
                            <p>${comment.content}</p>
                        </div>
                    </li>`;

                // Prepend the new comment to the comment list
                var commentList = $(`.user-post[data-post-id=${postId}] ul.comments-data`);
                var secondToLastLi = commentList.find('li').eq(-2);
                secondToLastLi.before(commentHtml);
            },
            error: function () {
                // Display an error message if the AJAX request fails
                alert('An error occurred while adding the comment. Please try again.');
            }
        });
    }

    // Function to handle deleting a comment
    function deleteComment(postId, commentId) {
        console.log(commentId);
        $.ajax({
            type: 'POST',
            url: '/api/community-post/delete-comment',
            data: { post_id: postId, comment_id: commentId },
            success: function (response) {
                // Handle the response from the server
                alert('Comment deleted successfully!');
                console.log('Comment deleted successfully');
                console.log(response);

                // Remove the deleted comment from the page
                var commentElement = $(`.user-post[data-post-id=${postId}] li[data-comment-id=${commentId}]`);
                commentElement.remove();
            },
            error: function (error) {
                console.log(error);
                // Display an error message if the AJAX request fails
                alert('An error occurred while deleting the comment. Please try again.');
            }
        });
    }

    // Function to handle banning a user
    function banUser(userId) {
        $.ajax({
            type: 'POST',
            url: '/api/dashboard/ban-user',
            data: { user_id: userId },
            success: function (response) {
                // Handle the response from the server
                alert('User banned successfully!');
                console.log('User banned successfully');
                console.log(response);

                // Optionally, you can perform additional actions after banning the user
                // For example, you can display a message or update the user's status on the page
            },
            error: function () {
                // Display an error message if the AJAX request fails
                alert('An error occurred while banning the user. Please try again.');
            }
        });
    }

    // Get all the post elements
    const postElements = document.querySelectorAll('.user-post');

    // Apply the vote handler to each post element
    postElements.forEach((postElement) => {
        const postId = postElement.getAttribute('data-post-id');
        const upvoteButton = postElement.querySelector('.like');
        const downvoteButton = postElement.querySelector('.dislike');
        const addCommentButton = postElement.querySelector('.add-comment-btn');
        const commentTextInput = postElement.querySelector('.comment-text-input');

        // Add event listeners to the upvote and downvote buttons
        upvoteButton.addEventListener('click', () => {
            // Perform the POST request to the server
            $.post('/api/community-post/upvote', { community_post_id: postId })
                .done(function (data) {
                    // Handle the response from the server
                    console.log('Upvote request successful');
                    console.log(data);
                    // Update the vote count
                    updateVoteCount(postId);
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    console.log('Upvote request failed');
                    console.log('Error:', jqXHR.responseText);
                });
        });

        downvoteButton.addEventListener('click', () => {
            // Perform the POST request to the server
            $.post('/api/community-post/downvote', { community_post_id: postId })
                .done(function (data) {
                    // Handle the response from the server
                    console.log('Downvote request successful');
                    console.log(data);
                    // Update the vote count
                    updateVoteCount(postId);
                }).js
                .fail(function () {
                    console.log('Downvote request failed');
                });
        });

        addCommentButton.addEventListener('click', () => {
            const commentText = commentTextInput.value;
            if (commentText.trim() !== '') {
                // Perform the POST request to add the comment
                addComment(postId, commentText);

                // Clear the comment text input
                commentTextInput.value = '';
            }
        });

        // Event delegation for deleting a comment
        $(postElement).on('click', '.delete-comment-btn', function () {
            const commentId = $(this).data('comment-id');
            deleteComment(postId, commentId);
        });

        // Event delegation for banning a user
        $(postElement).on('click', '.ban-user-btn', function () {
            const userId = $(this).data('user-id');
            banUser(userId);
        });
    });
});
