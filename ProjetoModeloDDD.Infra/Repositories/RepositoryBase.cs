using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Infra.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace ProjetoModeloDDD.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ProjetoModeloContext db = new ProjetoModeloContext();
        protected DbSet<TEntity> _dbSet;

        public RepositoryBase()
        {
            this._dbSet = db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            db.Set<TEntity>().Add(obj);
            db.SaveChanges();
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();

        }

        public TEntity GetByid(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {

            if (db.Entry(obj).State == EntityState.Detached)
                _dbSet.Attach(obj);

            //Remove objeto da base de dados
            _dbSet.Remove(obj);


            //Não Funciona
            //db.Set<TEntity>().Remove(obj);
            //db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            var entry = db.Entry<TEntity>(obj);

            //Obtem o id 
            var pkey = FindPrimaryKey<TEntity>(obj);

            //se está desanexando
            if (entry.State == EntityState.Detached)
            {
                //Cria novo objeto temporario
                var set = db.Set<TEntity>();

                //Obtem novo objeto pelo ID
                TEntity attachedEntity = set.Find(pkey);

                //Se localizou o objeto
                if (attachedEntity != null)
                {
                    //Adiciona o objeto no contexto
                    var attachedEntry = db.Entry(attachedEntity);

                    //Seta valores no objeto
                    attachedEntry.CurrentValues.SetValues(obj);
                }
                else
                {
                    //Define que objeto já está no contexto
                    entry.State = EntityState.Modified;
                }
            }
            
            db.SaveChanges();

            //Não Funciona
            //db.Entry(obj).State = EntityState.Modified;
            //db.SaveChanges();
        }

        public int FindPrimaryKey<T>(object item) 
        {
            //Pegar o tipo da Classe
            Type type = item.GetType();

            //Faz o Cast para o tipo da Classe
            var ClassType = Convert.ChangeType(item, type);

            //Localiza o atributo Key e retorna
            return (int)type.GetProperties()?.Where(e => e.GetCustomAttributes().Any(ee => ee.GetType() == typeof(KeyAttribute)))?.First().GetValue(ClassType);
        }
    }
}
