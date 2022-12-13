using Dapper;
using Dapper.Contrib.Extensions;
using Marfrig.Model.data_model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Marfrig.Data
{
    public class CompraGado
    {
        private readonly IDbConnection _connection;
        private readonly CompraGadoItem _dataCompraGadoItem;

        public CompraGado(string sqlConnection) =>
            (_connection, _dataCompraGadoItem) = (new SqlConnection(sqlConnection), new Data.CompraGadoItem(sqlConnection));
        
        public IEnumerable<Model.data_model.CompraGado> Get()
        {
            const string sql = @"SELECT 
                            CG.*,PC.*
                            FROM  COMPRAGADO AS CG  (NOLOCK)
                            INNER JOIN PECUARISTA  AS PC (NOLOCK) ON  CG.IDPECUARISTA = PC.ID
                           ";
            var listCompraGado =
                _connection.Query<Model.data_model.CompraGado, Marfrig.Model.data_model.Pecuarista, Model.data_model.CompraGado>(sql,
                    (compraGado, pecuarista) =>
                    {
                        compraGado.Pecuarista = pecuarista;
                        return compraGado;
                    }, splitOn: "ID").ToList();
            listCompraGado.ForEach(compraGado=>compraGado.CompraGadoItems = _dataCompraGadoItem.ByCompraId(compraGado.Id).ToList());
            return listCompraGado;
        }


        public Model.data_model.CompraGado ById(int id)
        {
            const string sql = @"SELECT TOP(1)
                            CG.*,PC.*
                            FROM  COMPRAGADO AS CG  (NOLOCK)
                            INNER JOIN PECUARISTA  AS PC (NOLOCK) ON  CG.IDPECUARISTA = PC.ID WHERE CG.ID = @ID
                           ";
            var compraGadoResult =
                _connection.Query<Model.data_model.CompraGado, Marfrig.Model.data_model.Pecuarista, Model.data_model.CompraGado>(sql,
                    (compraGado, pecuarista) =>
                    {
                        compraGado.Pecuarista = pecuarista;
                        return compraGado;
                    }, splitOn: "ID",param:new{ID= id}).FirstOrDefault();
         
            if(compraGadoResult != null)
            compraGadoResult.CompraGadoItems = _dataCompraGadoItem.ByCompraId(compraGadoResult.Id).ToList();

            return compraGadoResult;
        }


        /*MESMO QUEBRANDO UM  DOS PARADIGMAS DO SOLID , RESOLVIR FAZER ASSIM PARA USAR DA ATOMICIDADE DO BANCO DE DADOS */
        public void Salvar(Model.data_model.CompraGado compraGado)
        {
            _connection.Open();
            var transaction = _connection.BeginTransaction();
            try
            {
                const string sqlOcorrencia = @" 
                                    BEGIN
                                         
                                        IF NOT EXISTS(SELECT ID FROM COMPRAGADO WHERE ID = @COMPRAGADOID)   
                                            BEGIN
                                                INSERT COMPRAGADO(CRIADOEM,IDPECUARISTA,INDICAIMPRESSO,DATAENTREGA) 
                                                VALUES (GETDATE(),@IDPECUARISTA,'0',@DATAENTREGA)  
                                                SELECT CAST(SCOPE_IDENTITY() AS INT);
                                            END
                                        ELSE 
                                            BEGIN
                                              UPDATE  COMPRAGADO SET IDPECUARISTA = @IDPECUARISTA,DATAENTREGA = @DATAENTREGA WHERE ID = @COMPRAGADOID
                                              SELECT ID FROM COMPRAGADO WHERE ID = @COMPRAGADOID
                                            END
                                        END
                                             
                    "
                ;

                var compragadoId = _connection.Query<int>(sqlOcorrencia, new { COMPRAGADOID = compraGado.Id,IDPECUARISTA = compraGado.Pecuarista.Id, DATAENTREGA  = compraGado.DataEntrega}, transaction).SingleOrDefault();

                foreach (var item in compraGado.CompraGadoItems)
                {
                    var sqlItem = item.Id == 0 ? @"
                                    IF NOT EXISTS(SELECT ID FROM COMPRAGADOITEM WHERE IDCOMPRAGADO = @IDCOMPRAGADO AND IDANIMAL = @IDANIMAL)   
                                        INSERT COMPRAGADOITEM (CRIADOEM,IDCOMPRAGADO,IDANIMAL,QUANTIDADE) VALUES(GETDATE(),@IDCOMPRAGADO,@IDANIMAL,@QUANTIDADE) --FIX EVITAR DUPLICIDADE
                                    ELSE
                                        UPDATE COMPRAGADOITEM  SET QUANTIDADE = @QUANTIDADE WHERE IDCOMPRAGADO = @IDCOMPRAGADO AND IDANIMAL = @IDANIMAL
                                " : @"UPDATE COMPRAGADOITEM  SET QUANTIDADE = @QUANTIDADE WHERE ID = @COMPRAGADOITEMID";
                    _connection.Execute(sqlItem, new { IDCOMPRAGADO = compragadoId , IDANIMAL = item.Animal.Id, COMPRAGADOITEMID  =item.Id,QUANTIDADE = item.Quantidade }, transaction); 
                } 

                transaction.Commit(); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                transaction.Rollback();
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }


        public void DeleteItem(int id)
        {
            _connection.Open();
            var transaction = _connection.BeginTransaction();
            try
            {
                var sql = @"DELETE COMPRAGADOITEM  WHERE ID = @ID ";
                _connection.Execute(sql, new { ID = id }, transaction);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                transaction.Rollback();
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
        public void Delete(int id)
        {
            _connection.Open();
            var transaction = _connection.BeginTransaction();
            try
            {
                var sql = @"
                    DELETE COMPRAGADOITEM  WHERE IDCOMPRAGADO = @ID
                    DELETE COMPRAGADO  WHERE ID = @ID ";
                _connection.Execute(sql, new { ID = id }, transaction);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                transaction.Rollback();
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
        public void AtualizaIndicaImpresso(int id)
        {
            _connection.Open();
            var transaction = _connection.BeginTransaction();
            try
            {
                var sql = @"UPDATE COMPRAGADO SET INDICAIMPRESSO = '1' WHERE ID = @ID ";
                _connection.Execute(sql, new {ID = id}, transaction);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                transaction.Rollback();
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}