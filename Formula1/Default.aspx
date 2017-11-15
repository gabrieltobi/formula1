<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fórmula 1</title>

    <link href="favicon.ico" rel="icon" type="image/x-icon" />

    <link href="lib/datatables/css/datatables.min.css" rel="stylesheet" />
    <link href="assets/Default/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

        <div id="botoes">
            <button type="button" onclick="operacaoFato(1);">Criar Tabela Fato</button>
            <button type="button" onclick="operacaoFato(2);">Excluir Tabela Fato</button>
            <button type="button" onclick="operacaoFato(3);">Popular Tabela Fato</button>
            <button type="button" onclick="operacaoFato(4);">Consultar Tabela Fato</button>
            <button type="button" onclick="operacaoFato(5);">Metrica 1</button>
            <button type="button" onclick="operacaoFato(6);">Metrica 2</button>
            <button type="button" onclick="operacaoFato(7);">Metrica 3</button>
        </div>

        <div id="tabela"></div>
    </form>

    <script src="lib/jQuery/jquery-3.1.1.min.js"></script>
    <script src="lib/datatables/js/datatables.min.js"></script>
    <script src="lib/jsonToTable/jsonToTable.js"></script>
    <script src="assets/Default/Default.js?v=1"></script>
</body>
</html>
