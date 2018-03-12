// Write your JavaScript code.
// jQuery simples, apenas para manipular as informações entre dropdowns;


$(document).ready(function () {

    url = 'http://localhost:2564/Anuncio/';

    var selecionar = "<option value='0'>Selecione</option>";
    $('#Modelo').html(selecionar);
    $('#Versao').html(selecionar);

    var marcas = $.getJSON(url + 'Marcas', function (data) {
        var itens = "<option value='0'>Selecione</option>";
        $.each(data, function (i, marca) {
            itens += "<option value='" + marca.ID + "'> " + marca.Name + "</option>"
        })

        $('#Marca').html(itens);
    });



    $('#Marca').change(function () {
        $.getJSON(url + 'Modelos/', { ID: $('#Marca').val() }, function (data) {
            var itens = "<option value='0'>Selecione</option>";
            $('#Modelo').empty();
            $.each(data, function (i, modelo) {
                itens += "<option value='" + modelo.ID + "'> " + modelo.Name + "</option>";
            });
            $('#Modelo').html(itens);
            $('#MarcaID').val($('#Marca option:checked').text());
        })
    })

    $('#Modelo').change(function () {
        $.getJSON(url + 'Versoes/', { ModelID: $('#Modelo').val() }, function (data) {
            $('#Versao').empty();
            var itens = "<option value='0'>Selecione</option>";
            $.each(data, function (i, versao) {
                itens += "<option value='" + versao.ModelID + "'> " + versao.Name + "</option>";
            });

            $('#Versao').html(itens);
            $('#ModeloID').val($('#Modelo option:checked').text());
        })
    })

    $('#Versao').change(function () {
        $('#VersaoID').val($('#Versao option:checked').text());
    })
});