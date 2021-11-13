using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{
    public static class SQLiteHelper
    {
        internal const string ConnectionString = @"Data Source=C:\Users\twook\PubSQLite\DDD.db; Version=3;";

        /// <summary>
        /// パラメータなし(SQL)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        internal static IReadOnlyList<T> Query<T>(
            string sql,
            Func<SQLiteDataReader, T> createEntity)
        {
            return Query<T>(sql, null, createEntity);
        }

        /// <summary>
        /// パラメータあり
        /// </summary>
        /// <typeparam name="T">Entityの型</typeparam>
        /// <param name="sql">SQL文</param>
        /// <param name="parameters">バインドパラメーター</param>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        internal static IReadOnlyList<T> Query<T>(
            string sql,
            SQLiteParameter[] parameters,
            Func<SQLiteDataReader, T> createEntity)
        {
            var result = new List<T>();

            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {

                connection.Open();

                //パラメーターがnullでない場合実行
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        result.Add(createEntity(reader));
                    }
                }
            }

            return result;
        }

        internal static T QuerySingle<T>(
            string sql,
            Func<SQLiteDataReader, T> createEntity,
            T nullEntity)
        {
            return QuerySingle<T>(sql, null, createEntity, nullEntity);
        }


        internal static T QuerySingle<T>(
        string sql,
        SQLiteParameter[] parameters,
        Func<SQLiteDataReader, T> createEntity,
        T nullEntity)
        {
        
            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {

                connection.Open();
                //パラメーターがnullでない場合実行
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        return createEntity(reader);
                    }
                }
            }

            return nullEntity;
        }

        internal static void Execute(
            string insert,
            string update, 
            SQLiteParameter[] parameters)
        {
            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(update, connection))
            {

                connection.Open();
                //パラメーターがnullでない場合実行
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                //更新件数が1件もなければINSERT処理を実行
                if (command.ExecuteNonQuery() < 1)
                {
                    command.CommandText = insert;
                    command.ExecuteNonQuery();
                }
            }
 
        }

        internal static void Execute(
            string sql,
            SQLiteParameter[] parameters)
        {
            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {

                connection.Open();
                //パラメーターがnullでない場合実行
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                    command.ExecuteNonQuery();
            }

        }
    }
}
