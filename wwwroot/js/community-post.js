$(document).ready(function () {
  // Function to update the vote count
  function updateVoteCount(postId) {
      $.ajax({
          type: 'GET',
          url: `/api/community-post/${postId}/votes`,
          success: function (response) {
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

  // Get all the post elements
  const postElements = document.querySelectorAll('.user-post');

  // Apply the vote handler to each post element
  postElements.forEach((postElement) => {
      const postId = postElement.getAttribute('data-post-id');
      const upvoteButton = postElement.querySelector('.like');
      const downvoteButton = postElement.querySelector('.dislike');

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
              })
              .fail(function () {
                  console.log('Downvote request failed');
              });
      });
  });
});