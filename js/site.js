// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification



$(document).on('click', '.nav-link[data-page="catalogue"]', function (e) {
    e.preventDefault();
    ShowCataloguePage();
});

$(document).on('click', '.nav-link[data-page="add_game"]', function (e) {
    e.preventDefault();
    ShowAddNewGamePage();
});

$(document).on('click', '.nav-link[data-page="cart"]', function (e) {
    e.preventDefault();
    ShowCartPage();
});

// Поисковик
$(document).on('click', 'button[data-id="search_catalogue-btn"]', function () {
    let query = $('input[data-id="search_catalogue-input"]').val();
    SearchCatalogue(query);
});

const ShowCataloguePage = () => {
    $('main').html(`
  
    <p>Дисциплины</p>
      <div class="search">
    <input class="input" data-id="search_catalogue-input" placeholder="Поиск">
    
    <button class="search-btn" data-id="search_catalogue-btn">Поиск</button>
    </div>
        <div id="catalogue-grid"></div>`);
    SearchCatalogue();
};

const ShowAddNewGamePage = () => {
    $('main').html(
        `<p>Добавление новой дисциплины</p>
      <input data-id="add_new_game" placeholder="название"> 
      <textarea data-id="add_new_game_description" placeholder="Описание"></textarea>
      <button data-action="add_new_game">Добавить</button>`);
};
// Избранное
const ShowCartPage = () => {
    $('main').html(
        `<p>Избранное</p> 
        <div data-id="cart_table"></div>`);
    ShowCartList();
};

const ShowCartList = () => {
    $.ajax({
        method: 'GET',
        url: '/api/cart'
    })
        .done((data) => {
            let list = '';
            $.each(data, function () {
                list += `<div data-id="${this.games.id}">
                    <p>${this.games.name} - ${this.quantity}</p>
                    <div class="cart-btn">
                    <button data-action="cart_add_game">В избранное</button>
                    <button data-action="cart_remove_game">Убрать</button>
                    </div>
                    </div>`;
            });
            $('div[data-id="cart_table"]').html(list);
        })
        .fail((error) => {
            console.error('Error loading cart:', error);
        });
};

// Добавление в избранное
$(document).on('click', 'button[data-action="catalogue_add_game"]', function () {
    let gameId = $(this).parent().attr('data-id');
    $.ajax({
        url: '/api/cart',
        method: 'POST',
        data: JSON.stringify(gameId),
        contentType: 'application/json',
    })
        .done(function () {
            ShowCartList();
        })
        .fail(function (error) {
            console.error('Error adding to cart:', error);
        });
});

// Инкрементирование в избранном
$(document).on('click', 'button[data-action="cart_add_game"]', function () {
    let gameId = $(this).parent().attr('data-id');
    $.ajax({
        url: '/api/cart',
        method: 'POST',
        data: JSON.stringify(gameId),
        contentType: 'application/json'
    })
        .done(function () {
            ShowCartList();
        })
        .fail(function (error) {
            console.error('Error incrementing cart item:', error);
        });
});

// убрать из избранного
$(document).on('click', 'button[data-action="cart_remove_game"]', function () {
    let gameId = $(this).parent().attr('data-id');
    $.ajax({
        url: '/api/cart/remove',
        method: 'POST',
        data: JSON.stringify(gameId),
        contentType: 'application/json',
    })
        .done(function () {
            ShowCartList();
        })
        .fail(function (error) {
            console.error('Error removing from cart:', error);
        });
});

const SearchCatalogue = (query = '') => {
    $('#catalogue-grid').html('');
    $.ajax({
        url: '/api/catalogue',
        method: 'GET',
        data: { query: query }
    })
        .done(function (data) {
            $.each(data, function () {
                $('#catalogue-grid').append(`<div class="cis-container" data-id="${this.id}">
                <p>${this.name} - ${this.description}</p>
                
                <button class= "catalogue-btn" data-action="catalogue_add_game">В избранное</button>
                
            </div>`);
            });
        })
        .fail(function (error) {
            console.error('Error searching catalogue:', error);
        });
};
document.querySelectorAll('[class^="b-"]').forEach(el => {
    el.classList.remove(el.classList[0]);
})
