﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
///
/// </summary>
public class AtualizaDados
{
    SelecionaDados selecionaDados = new SelecionaDados();
    string sConexao = ConfigurationManager.AppSettings.Get("sConexaoSQL");


    public void AtualizaUsuario(int idUsuario, string login, string senha)
    {
        SqlConnection sqlConnection = new SqlConnection(sConexao);

        try
        {
            using (sqlConnection)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "usp_usuario_insert";
                sqlCommand.Parameters.AddWithValue("@IdUsuario", idUsuario);
                sqlCommand.Parameters.AddWithValue("@login", login);
                sqlCommand.Parameters.AddWithValue("@senha", senha);
                sqlConnection.Open();
                sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }
        finally
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection = null;
        }
    }

}
