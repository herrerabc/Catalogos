using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace Datos
{
    public class DaColonias : IDisposable
    {
        private string conn = "";
        public DaColonias()
        {
            conn = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        #region Insert
        public EColonias Colonias_Insert(EColonias item, ref ETransactionResult _transResult)
        {
            EColonias itemInserted = null;
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
                        sqlCmd.CommandText = "SP_Colonias_Insert";
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
                        sqlCmd.Parameters.AddWithValue("@IdEstado", item.IdEstado);
                        sqlCmd.Parameters.AddWithValue("@IdMunicipio", item.IdMunicipio);
                        sqlCmd.Parameters.AddWithValue("@cp", item.cp);
                        sqlCmd.Parameters.AddWithValue("@Descripcion", item.Descripcion);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemInserted = new EColonias();
                                itemInserted.Id = (int)reader["Id"];
                                itemInserted.IdEstado = (int)reader["IdEstado"];
                                itemInserted.IdMunicipio = (int)reader["IdMunicipio"];
                                itemInserted.cp = (long)reader["cp"];
                                itemInserted.Descripcion = reader["Descripcion"] == DBNull.Value ? null : (string)reader["Descripcion"];
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
        public List<EColonias> Colonias_GetAll(ref ETransactionResult _transResult)
        {
            var list = new List<EColonias>();
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
                        sqlCmd.CommandText = "SP_Colonias_SelectAll";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var item = new EColonias();
                                item.Id = (int)reader["Id"];
                                item.IdEstado = (int)reader["IdEstado"];
                                item.IdMunicipio = (int)reader["IdMunicipio"];
                                item.cp = (long)reader["cp"];
                                item.Descripcion = reader["Descripcion"] == DBNull.Value ? null : (string)reader["Descripcion"];
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
        public EColonias Colonias_Get(EColonias item, ref ETransactionResult _transResult)
        {
            EColonias itemFinded = null;
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
                        sqlCmd.Parameters.AddWithValue("@IdEstado", item.IdEstado);
                        sqlCmd.Parameters.AddWithValue("@IdMunicipio", item.IdMunicipio);
                        sqlCmd.CommandText = "SP_Colonias_Select";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                itemFinded = new EColonias();
                                itemFinded.Id = (int)reader["Id"];
                                itemFinded.IdEstado = (int)reader["IdEstado"];
                                itemFinded.IdMunicipio = (int)reader["IdMunicipio"];
                                itemFinded.cp = (long)reader["cp"];
                                itemFinded.Descripcion = reader["Descripcion"] == DBNull.Value ? null : (string)reader["Descripcion"];
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
        public void Colonias_Delete(EColonias item, ref ETransactionResult _transResult)
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
                        sqlCmd.CommandText = "SP_Colonias_Delete";
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
                        sqlCmd.Parameters.AddWithValue("@IdEstado", item.IdEstado);
                        sqlCmd.Parameters.AddWithValue("@IdMunicipio", item.IdMunicipio);
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
        public EColonias Colonias_Update(EColonias item, ref ETransactionResult _transResult)
        {
            EColonias itemUpdated = null;
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
                        sqlCmd.CommandText = "SP_Colonias_Update";
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
                        sqlCmd.Parameters.AddWithValue("@IdEstado", item.IdEstado);
                        sqlCmd.Parameters.AddWithValue("@IdMunicipio", item.IdMunicipio);
                        sqlCmd.Parameters.AddWithValue("@cp", item.cp);
                        sqlCmd.Parameters.AddWithValue("@Descripcion", item.Descripcion);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemUpdated = new EColonias();
                                itemUpdated.Id = (int)reader["Id"];
                                itemUpdated.IdEstado = (int)reader["IdEstado"];
                                itemUpdated.IdMunicipio = (int)reader["IdMunicipio"];
                                itemUpdated.cp = (long)reader["cp"];
                                itemUpdated.Descripcion = reader["Descripcion"] == DBNull.Value ? null : (string)reader["Descripcion"];
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