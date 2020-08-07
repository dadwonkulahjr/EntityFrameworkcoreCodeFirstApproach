function confirmDelete(uniqueId="", isDeleteClicked=false) {
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide('slow');
        $('#' + confirmDeleteSpan).show();

    }
    else {
        $('#' + confirmDeleteSpan).hide('slow');
        $('#' + deleteSpan).show();
    }


}