using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Entidades;
namespace Datos
{
    public class DaEstados : IDisposable
    {
        private string conn = "";
        public DaEstados()
        {
            conn = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        #region Insert
        public EEstados Estados_Insert(EEstados item, ref ETransactionResult _transResult)
        {
            EEstados itemInserted = null;
            _transResult = new ETransactionResult();
            SqlTransaction transaction = null;
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
                        sqlCmd.CommandText = "SP_Estados_Insert";
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
                        sqlCmd.Parameters.AddWithValue("@IdPais", item.IdPais);
                        sqlCmd.Parameters.AddWithValue("@descripcion", item.descripcion);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemInserted = new EEstados();
                                itemInserted.Id = (int)reader["Id"];
                                itemInserted.IdPais = (int)reader["IdPais"];
                                itemInserted.descripcion = reader["descripcion"] == DBNull.Value ? null : (string)reader["descripcion"];
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
        public List<EEstados> Estados_GetAll(ref ETransactionResult _transResult)
        {
            var list = new List<EEstados>();
            _transResult = new ETransactionResult();
            SqlTransaction transaction = null;
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
                        sqlCmd.CommandText = "SP_Estados_SelectAll";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var item = new EEstados();
                                item.Id = (int)reader["Id"];
                                item.IdPais = (int)reader["IdPais"];
                                item.descripcion = reader["descripcion"] == DBNull.Value ? null : (string)reader["descripcion"];
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
        public EEstados Estados_Get(EEstados item, ref ETransactionResult _transResult)
        {
            EEstados itemFinded = null;
            _transResult = new ETransactionResult();
            SqlTransaction transaction = null;
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
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
                        sqlCmd.CommandText = "SP_Estados_Select";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                itemFinded = new EEstados();
                                itemFinded.Id = (int)reader["Id"];
                                itemFinded.IdPais = (int)reader["IdPais"];
                                itemFinded.descripcion = reader["descripcion"] == DBNull.Value ? null : (string)reader["descripcion"];
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
        public void Estados_Delete(EEstados item, ref ETransactionResult _transResult)
        {

            _transResult = new ETransactionResult();
            SqlTransaction transaction = null;
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
                        sqlCmd.CommandText = "SP_Estados_Delete";
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
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
        public EEstados Estados_Update(EEstados item, ref ETransactionResult _transResult)
        {
            EEstados itemUpdated = null;
            _transResult = new ETransactionResult();
            SqlTransaction transaction = null;
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
                        sqlCmd.CommandText = "SP_Estados_Update";
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
                        sqlCmd.Parameters.AddWithValue("@IdPais", item.IdPais);
                        sqlCmd.Parameters.AddWithValue("@descripcion", item.descripcion);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemUpdated = new EEstados();
                                itemUpdated.Id = (int)reader["Id"];
                                itemUpdated.IdPais = (int)reader["IdPais"];
                                itemUpdated.descripcion = reader["descripcion"] == DBNull.Value ? null : (string)reader["descripcion"];
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