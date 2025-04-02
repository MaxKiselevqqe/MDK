const SearchCatalogue = () => {
    $.ajax({
        url: 'api/catalogue',
        method: 'GET'
    })
        .done(function(data) {
            $.each(data, (item) => {
                $('#catalogue.grid')
                    .append(`<p>${item.name}</p>`);
            }

            );
        });
};
