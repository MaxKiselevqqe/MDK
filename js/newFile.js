$(document).on('click', 'button[data-action="add_new_game"]', function() {

    let name = $('input[data-id="add"_new_game"]').val();
    let desription = $('text area[data-id="add"_new_game_description"]').val();

    $.ajax({
        method: 'POST',
        url: 'api/admin/addnewgame',
        contentType: 'application/json',
        data: JSON.stringify({
            name, description
        })
    });
}
);
