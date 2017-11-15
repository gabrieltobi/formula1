using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    [WebMethod]
    public static Retorno OperacaoFato(int operacao)
    {
        using (NpgsqlConnection conn = Conectar())
        {
            StringBuilder query = new StringBuilder("");
            if (operacao == 1)
            {
                query.Append("SELECT criarFato();");
            }
            else if (operacao == 2)
            {
                query.Append("DROP TABLE fato CASCADE;");
            }
            else if (operacao == 3)
            {
                query.Append("SELECT popularFato();");
            }
            else if (operacao == 4)
            {
                query.Append("SELECT * FROM fato;");
            }
            else if (operacao == 5)
            {
                query.Append("SELECT * FROM metrica1();");
            }
            else if (operacao == 6)
            {
                query.Append("SELECT * FROM metrica2();");
            }
            else if (operacao == 7)
            {
                query.Append("SELECT * FROM metrica3();");
            }
            else
            {
                return new Retorno("Operação Inválida", true);
            }

            using (NpgsqlCommand cmd = new NpgsqlCommand(query.ToString(), conn))
            using (NpgsqlDataAdapter ad = new NpgsqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                try
                {
                    ad.Fill(dt);

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return new Retorno(serializer.Serialize(rows), false);
                }
                catch (Exception ex)
                {
                    if (ex.Data["Code"] != null)
                    {
                        return new Retorno(ex.Data["Code"].ToString(), true);
                    }
                    else
                    {
                        return new Retorno("", false);
                    }
                }
            }
        }
    }

    public static NpgsqlConnection Conectar()
    {
        string host = "localhost";
        string usuario = "postgres";
        string senha = "admin";
        string database = "postgres";

        NpgsqlConnection conn = new NpgsqlConnection("Host=" + host + ";Username=" + usuario + ";Password=" + senha + ";Database=" + database + "");

        if (conn != null && conn.State == ConnectionState.Open) conn.Close();
        else conn.Open();

        return conn;
    }

    public class Retorno
    {
        public Retorno(string conteudo, bool erro)
        {
            this.conteudo = conteudo;
            this.erro = erro;
        }

        public string conteudo;
        public bool erro;
    }
}