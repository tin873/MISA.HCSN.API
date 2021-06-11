using Dapper;
using MISA.HCSH.Core.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MISA.HCSN.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        //tên đối tượng
        protected string _tableName = string.Empty;

        protected string _connectionString = ""+
               "Host=47.241.69.179; " +
               "Port=3306;" +
               "User Id= nvmanh; " +
               "Password=12345678;" +
               "Database= TEST.MISA.QLTS_copy; " +
               "convert zero datetime=True;";
        protected IDbConnection _dbConnection;

        public BaseRepository()
        {
            _tableName = typeof(T).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }
        public int Delete(Guid entityId)
        {
            var dynamicParameter = new DynamicParameters();
            dynamicParameter.Add($"{_tableName}Id", entityId);
            var result = _dbConnection.Execute($"Proc_Delete{_tableName}", param: dynamicParameter, commandType: CommandType.StoredProcedure);
            return result;
        }

        public T GetById(Guid entityId)
        {
            var dynamicParameter = new DynamicParameters();
            dynamicParameter.Add($"{_tableName}Id", entityId);
            var entity = _dbConnection.Query<T>($"Proc_Get{_tableName}ById", param: dynamicParameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        public IEnumerable<T> GetEntities()
        {
            var entities = _dbConnection.Query<T>($"Proc_Get{_tableName}", commandType: CommandType.StoredProcedure);
            return entities;
        }

        public int Insert(T entity)
        {
            try
            {
                if(_dbConnection.State != ConnectionState.Open)
                {
                    _dbConnection.Open();
                }   
                var result = _dbConnection.Execute($"Proc_Insert{_tableName}", param: entity, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Update(T entity)
        {
            try
            {
                if (_dbConnection.State != ConnectionState.Open)
                {
                    _dbConnection.Open();
                }
                using(var transaction = _dbConnection.BeginTransaction())
                {
                    var result = _dbConnection.Execute($"Proc_Update{_tableName}", param: entity, commandType: CommandType.StoredProcedure, transaction: transaction);
                    transaction.Commit();
                    return result;
                }    
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
