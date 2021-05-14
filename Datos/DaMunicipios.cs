using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Entidades;
namespace Datos
{
    public class DaMunicipios : IDisposable
    {
        private string conn = "";
        public DaMunicipios()
        {
            conn = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        #region Insert
        public EMunicipios Municipios_Insert(EMunicipios item, ref ETransactionResult _transResult)
        {
            EMunicipios itemInserted = null;
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
                        sqlCmd.CommandText = "SP_Municipios_Insert";
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
                        sqlCmd.Parameters.AddWithValue("@IdEstado", item.IdEstado);
                        sqlCmd.Parameters.AddWithValue("@descripcion", item.descripcion);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemInserted = new EMunicipios();
                                itemInserted.Id = (int)reader["Id"];
                                itemInserted.IdEstado = (int)reader["IdEstado"];
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
        public List<EMunicipios> Municipios_GetAll(ref ETransactionResult _transResult)
        {
            var list = new List<EMunicipios>();
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
                        sqlCmd.CommandText = "SP_Municipios_SelectAll";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var item = new EMunicipios();
                                item.Id = (int)reader["Id"];
                                item.IdEstado = (int)reader["IdEstado"];
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
        public EMunicipios Municipios_Get(EMunicipios item, ref ETransactionResult _transResult)
        {
            EMunicipios itemFinded = null;
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
                        sqlCmd.CommandText = "SP_Municipios_Select";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                itemFinded = new EMunicipios();
                                itemFinded.Id = (int)reader["Id"];
                                itemFinded.IdEstado = (int)reader["IdEstado"];
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
        public void Municipios_Delete(EMunicipios item, ref ETransactionResult _transResult)
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
                        sqlCmd.CommandText = "SP_Municipios_Delete";
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
                        sqlCmd.Parameters.AddWithValue("@IdEstado", item.IdEstado);
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
        public EMunicipios Municipios_Update(EMunicipios item, ref ETransactionResult _transResult)
        {
            EMunicipios itemUpdated = null;
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
                        sqlCmd.CommandText = "SP_Municipios_Update";
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
                        sqlCmd.Parameters.AddWithValue("@IdEstado", item.IdEstado);
                        sqlCmd.Parameters.AddWithValue("@descripcion", item.descripcion);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemUpdated = new EMunicipios();
                                itemUpdated.Id = (int)reader["Id"];
                                itemUpdated.IdEstado = (int)reader["IdEstado"];
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