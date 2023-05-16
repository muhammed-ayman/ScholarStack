$('#register-form').on("click", function(){
    var registerForm = $(this).closest('form')[0];
    registerForm.submit();
	return false;
});

if (window.location.href.includes("?handler=Register")) {
    $('.login-reg-bg').addClass('show');
}