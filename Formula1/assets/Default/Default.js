function operacaoFato(operacao) {
    PageMethods.OperacaoFato(operacao, operacaoFunc);

    function operacaoFunc(retorno) {
        var tabela = document.getElementById("tabela");
        tabela.className = "";

        if (retorno.erro) {
            tabela.className = "erro";

            if (retorno.conteudo == "42P07") {
                tabela.innerHTML = "Tabela fato já existe.";
            } else if (retorno.conteudo == "42P01") {
                tabela.innerHTML = "Tabela fato não existe.";
            } else if (retorno.conteudo == "23505") {
                tabela.innerHTML = "Tabela fato já foi populada.";
            } else {
                tabela.innerHTML = retorno.conteudo;
            }
        } else {
            if (operacao == 1) {
                tabela.innerHTML = "Tabela fato criada.";
            } else if (operacao == 2) {
                tabela.innerHTML = "Tabela fato excluída.";
            } else if (operacao == 3) {
                tabela.innerHTML = "Tabela populada.";
            } else if (operacao >= 4) {
                var conteudo = JSON.parse(retorno.conteudo);

                if (conteudo.length) {
                    var jsonHtmlTable = ConvertJsonToTable(JSON.parse(retorno.conteudo));
                    tabela.innerHTML = jsonHtmlTable;
                    $("#tabela table").DataTable();
                }
                else {
                    tabela.innerHTML = "Tabela sem dados.";
                    tabela.className = "erro";
                }
            }
        }
    }
}