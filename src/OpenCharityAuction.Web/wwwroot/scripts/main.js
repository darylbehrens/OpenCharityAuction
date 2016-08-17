function disableButton() {
    var isValid = $("#form").valid();
    if (isValid){
        var button = document.getElementById("button");
        button.disabled = true;
        button.value = "Saving...";
        $(button).css('color', 'lightgray');
    }
    
}