// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var favoriteButton = $('#favoriteButton');

    favoriteButton.click(function (e) {
        e.preventDefault();
        var repositoryId = favoriteButton.attr('data-repository-id');
        var isFavorite = favoriteButton.attr('data-is-favorite') === 'True';

        $.ajax({
            url: '/Repository/Favorite',
            type: 'POST',
            data: {
                repositoryId: repositoryId,
                isFavorite: !isFavorite
            },
            success: function (result) {
                favoriteButton.attr('data-is-favorite', !isFavorite);
                if (!isFavorite) {
                    favoriteButton.addClass('btn-warning').removeClass('btn-outline-warning');
                    favoriteButton.find('i').addClass('fas').removeClass('far');
                } else {
                    favoriteButton.removeClass('btn-warning').addClass('btn-outline-warning');
                    favoriteButton.find('i').removeClass('fas').addClass('far');
                }
            },
            error: function () {
                alert('Ocorreu um erro ao favoritar o repositório');
            }
        });
    });
});


$(document).ready(function () {
    getDataTable('#table-repositorio');
});

function getDataTable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

//Modal para confirmar o delete de todos os repositorios
function confirmDelete() {
    if (confirm("Tem certeza que deseja excluir todos os repositórios?")) {
        window.location.href = "/Repositorios/ApagarTodos";
    }
}


