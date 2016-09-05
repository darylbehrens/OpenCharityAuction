function disableButton() {
    var isValid = $("#form").valid();
    if (isValid){
        var button = document.getElementById("button");
        button.disabled = true;
        button.value = "Saving...";
        $(button).css('color', 'lightgray');
    }
}

function checkboxToClear(checkBox, textToEnter, elementIdToChange) {
    var isChecked = $(checkBox).is(":checked");
    var inputToChange = $("#" + elementIdToChange);
    if (isChecked === true) {
        inputToChange.val(textToEnter);
        inputToChange.prop('disabled', true);
    }
    else{
        inputToChange.prop('disabled', false);
    }
}
