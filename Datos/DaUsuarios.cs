using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Entidades;

namespace Datos
{
    public class DaUsuarios : IDisposable
    {
        private string conn = "";
        public DaUsuarios()
        {
            conn = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        #region Insert
        public EUsuarios Usuarios_Insert(EUsuarios item, ref ETransactionResult _transResult)
        {
            EUsuarios itemInserted = null;
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
                        sqlCmd.CommandText = "SP_Usuarios_Insert";

                        sqlCmd.Parameters.AddWithValue("@Nombre", item.Nombre);
                        sqlCmd.Parameters.AddWithValue("@ApellidoP", item.ApellidoP);
                        sqlCmd.Parameters.AddWithValue("@ApellidoM", item.ApellidoM);
                        sqlCmd.Parameters.AddWithValue("@Telefono", item.Telefono);
                        sqlCmd.Parameters.AddWithValue("@Direccion", item.Direccion);
                        sqlCmd.Parameters.AddWithValue("@Email", item.Email);
                        sqlCmd.Parameters.AddWithValue("@Loggin", item.Loggin);
                        sqlCmd.Parameters.AddWithValue("@Password", item.Password);
                        sqlCmd.Parameters.AddWithValue("@Estado", item.Estado);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemInserted = new EUsuarios();
                                itemInserted.Id = (int)reader["Id"];
                                itemInserted.Nombre = (string)reader["Nombre"];
                                itemInserted.ApellidoP = (string)reader["ApellidoP"];
                                itemInserted.ApellidoM = (string)reader["ApellidoM"];
                                itemInserted.Telefono = reader["Telefono"] == DBNull.Value ? null : (decimal?)reader["Telefono"];
                                itemInserted.Direccion = reader["Direccion"] == DBNull.Value ? null : (string)reader["Direccion"];
                                itemInserted.Email = reader["Email"] == DBNull.Value ? null : (string)reader["Email"];
                                itemInserted.Loggin  = reader["Loggin"] == DBNull.Value ? null : (string)reader["Loggin"];
                                itemInserted.Password = reader["Password"] == DBNull.Value ? null : (string)reader["Password"];
                                itemInserted.Estado = (bool)reader["Estado"];
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
        public List<EUsuarios> Usuarios_GetAll(ref ETransactionResult _transResult)
        {
            var list = new List<EUsuarios>();
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
                        sqlCmd.CommandText = "SP_Usuarios_SelectAll";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var item = new EUsuarios();
                                item.Id = (int)reader["Id"];
                                item.Nombre = (string)reader["Nombre"];
                                item.ApellidoP = (string)reader["ApellidoP"];
                                item.ApellidoM = (string)reader["ApellidoM"];
                                item.Telefono = reader["Telefono"] == DBNull.Value ? null : (decimal?)reader["Telefono"];
                                item.Direccion = reader["Direccion"] == DBNull.Value ? null : (string)reader["Direccion"];
                                item.Email = reader["Email"] == DBNull.Value ? null : (string)reader["Email"];
                                item.Loggin = reader["Loggin"] == DBNull.Value ? null : (string)reader["Loggin"];
                                item.Password = reader["Password"] == DBNull.Value ? null : (string)reader["Password"];
                                item.Estado = (bool)reader["Estado"];
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
        public EUsuarios Usuarios_Get(EUsuarios item, ref ETransactionResult _transResult)
        {
            EUsuarios itemFinded = null;
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
                        sqlCmd.Parameters.AddWithValue("@Loggin", item.Loggin);
                        sqlCmd.CommandText = "SP_Usuarios_Select";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                itemFinded = new EUsuarios();
                                itemFinded.Id = (int)reader["Id"];
                                itemFinded.Nombre = (string)reader["Nombre"];
                                itemFinded.ApellidoP = (string)reader["ApellidoP"];
                                itemFinded.ApellidoM = (string)reader["ApellidoM"];
                                itemFinded.Telefono = reader["Telefono"] == DBNull.Value ? null : (decimal?)reader["Telefono"];
                                itemFinded.Direccion = reader["Direccion"] == DBNull.Value ? null : (string)reader["Direccion"];
                                itemFinded.Email = reader["Email"] == DBNull.Value ? null : (string)reader["Email"];
                                itemFinded.Loggin = reader["Loggin"] == DBNull.Value ? null : (string)reader["Loggin"];
                                itemFinded.Password = reader["Password"] == DBNull.Value ? null : (string)reader["Password"];
                                itemFinded.Estado = (bool)reader["Estado"];
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
        public void Usuarios_Delete(EUsuarios item, ref ETransactionResult _transResult)
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
                        sqlCmd.CommandText = "SP_Usuarios_Delete";
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
        public EUsuarios Usuarios_Update(EUsuarios item, ref ETransactionResult _transResult)
        {
            EUsuarios itemUpdated = null;
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
                        sqlCmd.CommandText = "SP_Usuarios_Update";
                        sqlCmd.Parameters.AddWithValue("@Id", item.Id);
                        sqlCmd.Parameters.AddWithValue("@Nombre", item.Nombre);
                        sqlCmd.Parameters.AddWithValue("@ApellidoP", item.ApellidoP);
                        sqlCmd.Parameters.AddWithValue("@ApellidoM", item.ApellidoM);
                        sqlCmd.Parameters.AddWithValue("@Telefono", item.Telefono);
                        sqlCmd.Parameters.AddWithValue("@Direccion", item.Direccion);
                        sqlCmd.Parameters.AddWithValue("@Email", item.Email);
                        sqlCmd.Parameters.AddWithValue("@Loggin", item.Loggin);
                        sqlCmd.Parameters.AddWithValue("@Password", item.Password);
                        sqlCmd.Parameters.AddWithValue("@Estado", item.Estado);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemUpdated = new EUsuarios();
                                itemUpdated.Id = (int)reader["Id"];
                                itemUpdated.Nombre = (string)reader["Nombre"];
                                itemUpdated.ApellidoP = (string)reader["ApellidoP"];
                                itemUpdated.ApellidoM = (string)reader["ApellidoM"];
                                itemUpdated.Telefono = reader["Telefono"] == DBNull.Value ? null : (decimal?)reader["Telefono"];
                                itemUpdated.Direccion = reader["Direccion"] == DBNull.Value ? null : (string)reader["Direccion"];
                                itemUpdated.Email = reader["Email"] == DBNull.Value ? null : (string)reader["Email"];
                                itemUpdated.Loggin  = reader["Loggin"] == DBNull.Value ? null : (string)reader["Loggin"];
                                itemUpdated.Password = reader["Password"] == DBNull.Value ? null : (string)reader["Password"];
                                itemUpdated.Estado = (bool)reader["Estado"];
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