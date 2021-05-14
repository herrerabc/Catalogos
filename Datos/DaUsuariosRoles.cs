using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Datos { 
    public class DaUsuariosRoles : IDisposable 
	{
		private string conn = "";
		public DaUsuariosRoles ()
		{
		    conn = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
		}

    #region Insert
	    public EUsuariosRoles UsuariosRoles_Insert(EUsuariosRoles item, ref ETransactionResult _transResult)
	    {
		    EUsuariosRoles itemInserted = null;
		    _transResult = new ETransactionResult();
		    SqlTransaction transaction= null;
		    try
			    {
			    using (SqlConnection sqlCon = new SqlConnection(conn))
			    {
				    sqlCon.Open();
				    using (SqlCommand sqlCmd = new SqlCommand())
				    {
					    transaction = sqlCon.BeginTransaction("InsertTransaction");
					    sqlCmd.Transaction = transaction;
					    sqlCmd.Connection = sqlCon;
					    sqlCmd.CommandType = CommandType.StoredProcedure;
					    sqlCmd.CommandText = "SP_UsuariosRoles_Insert";
					    sqlCmd.Parameters.AddWithValue("@IdUsuario",item.IdUsuario);
					    sqlCmd.Parameters.AddWithValue("@IdRol",item.IdRol);
					    using(var reader = sqlCmd.ExecuteReader())
						    {
						    while (reader.Read())
							    {
						    itemInserted = new EUsuariosRoles();
						    itemInserted.IdUsuario  =  (int) reader["IdUsuario"];
						    itemInserted.IdRol  =  (string) reader["IdRol"];
					    }
				    }
					    transaction.Commit();
					    _transResult.message = "OK";
					    _transResult.result = 0;
				    }
			    }
			    }
			    catch (Exception ex)
			    {
				    _transResult.message = ex.Message;
					    _transResult.result = 1;
				    try
				    {
				    transaction.Rollback();
				    }
				    catch (Exception rollBackEx)
					    {
						    _transResult.rollbackMessage = rollBackEx.Message;
					    _transResult.result = 1;
					    }
			    }
		    return itemInserted;
	     } 
    #endregion


    #region SelectAll
	    public List<EUsuariosRoles> UsuariosRoles_GetAll(ref ETransactionResult _transResult)
	    {
		    var list = new List<EUsuariosRoles>();
		    _transResult = new ETransactionResult();
		    SqlTransaction transaction= null;
		    try
		    {
			    using (SqlConnection sqlCon = new SqlConnection(conn))
			    {
				    sqlCon.Open();
				    using (SqlCommand sqlCmd = new SqlCommand())
				    {
					    transaction = sqlCon.BeginTransaction("SelectAllTranstaction");
					    sqlCmd.Transaction = transaction;
					    sqlCmd.Connection = sqlCon;
					    sqlCmd.CommandType = CommandType.StoredProcedure;
					    sqlCmd.CommandText = "SP_UsuariosRoles_SelectAll";
					    using (var reader = sqlCmd.ExecuteReader())
					    while (reader.Read())
					    {
						     var item = new EUsuariosRoles();
						    item.IdUsuario  =  (int) reader["IdUsuario"];
						    item.IdRol  =  (string) reader["IdRol"];
						    list.Add(item);
					    }
					    transaction.Commit();
					    _transResult.message = "OK";
					    _transResult.result = 0;
				    }
			    }
			    }
			    catch (Exception ex)
			    {
				    _transResult.message = ex.Message;
					    _transResult.result = 1;
				    try
				    {
				    transaction.Rollback();
				    }
				    catch (Exception rollBackEx)
					    {
						    _transResult.rollbackMessage = rollBackEx.Message;
					    _transResult.result = 1;
					    }
			    }
	    return list;
	     } 
    #endregion


    #region Select
	    public EUsuariosRoles UsuariosRoles_Get(EUsuariosRoles item, ref ETransactionResult _transResult)
	    {
		    EUsuariosRoles itemFinded = null;
		    _transResult = new ETransactionResult();
		    SqlTransaction transaction= null;
		    try
		    {
			    using (SqlConnection sqlCon = new SqlConnection(conn))
			    {
				    sqlCon.Open();
				    using (SqlCommand sqlCmd = new SqlCommand())
				    {
					    transaction = sqlCon.BeginTransaction("SelectTransaction");
					    sqlCmd.Transaction = transaction;
					    sqlCmd.Connection = sqlCon;
					    sqlCmd.CommandType = CommandType.StoredProcedure;
					    sqlCmd.Parameters.AddWithValue("@IdUsuario",item.IdUsuario);
					    sqlCmd.Parameters.AddWithValue("@IdRol",item.IdRol);
					    sqlCmd.CommandText = "SP_UsuariosRoles_Select";
					    using (var reader = sqlCmd.ExecuteReader())
					    while (reader.Read())
					    {
						     itemFinded = new EUsuariosRoles();
						    itemFinded.IdUsuario  =  (int) reader["IdUsuario"];
						    itemFinded.IdRol  =  (string) reader["IdRol"];
					    }
					    transaction.Commit();
					    _transResult.message = "OK";
					    _transResult.result = 0;
				    }
			    }
		
			    }
			    catch (Exception ex)
			    {
				    _transResult.message = ex.Message;
					    _transResult.result = 1;
				    try
				    {
				    transaction.Rollback();
				    }
				    catch (Exception rollBackEx)
					    {
						    _transResult.rollbackMessage = rollBackEx.Message;
					    _transResult.result = 1;
					    }
			    }
	    return itemFinded;
	     } 
    #endregion
    #region Delete
	    public void  UsuariosRoles_Delete(EUsuariosRoles item, ref ETransactionResult _transResult)
	    {
		
		    _transResult = new ETransactionResult();
		    SqlTransaction transaction= null;
		    try
		    {
		    using (SqlConnection sqlCon = new SqlConnection(conn))
		    {
			    sqlCon.Open();
			    using (SqlCommand sqlCmd = new SqlCommand())
			    {
				    transaction = sqlCon.BeginTransaction("DeleteTransaction");
				    sqlCmd.Transaction = transaction;
				    sqlCmd.Connection = sqlCon;
				    sqlCmd.CommandType = CommandType.StoredProcedure;
				    sqlCmd.CommandText = "SP_UsuariosRoles_Delete";
				    sqlCmd.Parameters.AddWithValue("@IdUsuario",item.IdUsuario);
				    sqlCmd.Parameters.AddWithValue("@IdRol",item.IdRol);
				    sqlCmd.ExecuteNonQuery();
				    transaction.Commit();
				    _transResult.message = "OK";
					    _transResult.result = 0;
			    }
		    }
			    }
			    catch (Exception ex)
			    {
				    _transResult.message = ex.Message;
					    _transResult.result = 1;
				    try
				    {
				    transaction.Rollback();
				    }
				    catch (Exception rollBackEx)
					    {
						    _transResult.rollbackMessage = rollBackEx.Message;
					    _transResult.result = 1;
					    }
			    }
	     } 
    #endregion

    #region Update
	    public EUsuariosRoles UsuariosRoles_Update(EUsuariosRoles item, ref ETransactionResult _transResult)
	    {
		    EUsuariosRoles itemUpdated = null;
		    _transResult = new ETransactionResult();
		    SqlTransaction transaction= null;
		    try
		    {
			    using (SqlConnection sqlCon = new SqlConnection(conn))
			    {
				    sqlCon.Open();
			    using (SqlCommand sqlCmd = new SqlCommand())
				    {
				    transaction = sqlCon.BeginTransaction("UpdateTransaction");
					    sqlCmd.Transaction = transaction;
					    sqlCmd.Connection = sqlCon;
					    sqlCmd.CommandType = CommandType.StoredProcedure;
					    sqlCmd.CommandText = "SP_UsuariosRoles_Update";
					    sqlCmd.Parameters.AddWithValue("@IdUsuario",item.IdUsuario);
					    sqlCmd.Parameters.AddWithValue("@IdRol",item.IdRol);
					    using(var reader = sqlCmd.ExecuteReader())
						    {
					    while (reader.Read())
					    {
							    itemUpdated = new EUsuariosRoles();
							    itemUpdated.IdUsuario  =  (int) reader["IdUsuario"];
							    itemUpdated.IdRol  =  (string) reader["IdRol"];
						    }
					    }
						    transaction.Commit();
						    _transResult.message = "OK";
						    _transResult.result = 1;
					    }
			    }
		    }
		    catch (Exception ex)
		    {
			    _transResult.message = ex.Message;
			    _transResult.result = 1;
			    try
			    {
			    transaction.Rollback();
			    }
			    catch (Exception rollBackEx)
					    {
						    _transResult.rollbackMessage = rollBackEx.Message;
						    _transResult.result = 1;
					    }
		    }
		    return itemUpdated;
	     } 
    #endregion

		    public void Dispose() 
		    {
			    GC.SuppressFinalize(this);
		    } 
    }
}