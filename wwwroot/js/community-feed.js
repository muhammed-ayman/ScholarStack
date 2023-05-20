function previewImage(event) {
    var file = event.target.files[0];
    var reader = new FileReader();

    reader.onload = function(e) {
        var imagePreview = document.getElementById("imagePreview");
        imagePreview.innerHTML = '<img src="' + e.target.result + '" alt="Preview">';
    };

    reader.readAsDataURL(file);
}
  