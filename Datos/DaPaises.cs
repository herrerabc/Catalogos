using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Entidades;
namespace Datos
{
    public class DaPaises : IDisposable
    {
        private string conn = "";
        public DaPaises()
        {
            conn = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        #region Insert
        public EPaises Paises_Insert(EPaises item, ref ETransactionResult _transResult)
        {
            EPaises itemInserted = null;
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
                        sqlCmd.CommandText = "SP_Paises_Insert";
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
                        sqlCmd.Parameters.AddWithValue("@descripcion", item.descripcion);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemInserted = new EPaises();
                                itemInserted.Id = (int)reader["Id"];
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
        public List<EPaises> Paises_GetAll(ref ETransactionResult _transResult)
        {
            var list = new List<EPaises>();
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
                        sqlCmd.CommandText = "SP_Paises_SelectAll";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var item = new EPaises();
                                item.Id = (int)reader["Id"];
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
        public EPaises Paises_Get(EPaises item, ref ETransactionResult _transResult)
        {
            EPaises itemFinded = null;
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
                        sqlCmd.CommandText = "SP_Paises_Select";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                itemFinded = new EPaises();
                                itemFinded.Id = (int)reader["Id"];
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
        public void Paises_Delete(EPaises item, ref ETransactionResult _transResult)
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
                        sqlCmd.CommandText = "SP_Paises_Delete";
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
        public EPaises Paises_Update(EPaises item, ref ETransactionResult _transResult)
        {
            EPaises itemUpdated = null;
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
                        sqlCmd.CommandText = "SP_Paises_Update";
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
                        sqlCmd.Parameters.AddWithValue("@descripcion", item.descripcion);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemUpdated = new EPaises();
                                itemUpdated.Id = (int)reader["Id"];
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