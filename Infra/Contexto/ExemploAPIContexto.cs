﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tnf.EntityFrameworkCore;
using Tnf.Runtime.Session;

namespace ExempleAPI.Infra.Contexto
{
    public class ExemploAPIContexto : TnfDbContext
    {
        #region DbSet
        //public DbSet<JpvEntidade> JpvEntidade { get; set; }
        #endregion

        public ExemploAPIContexto(DbContextOptions<ExemploAPIContexto> options, ITnfSession session) : base(options, session)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new JpvMap());
            base.OnModelCreating(modelBuilder);
        }

        public async Task<object> ExecutarFuncao(string nomeFuncao)
        {
            using var comando = Database.GetDbConnection().CreateCommand();
            comando.CommandText = "SELECT " + nomeFuncao + " FROM DUAL";
            Database.OpenConnection();
            return await comando.ExecuteScalarAsync();
        }

        public class SequenceValueGenerator : ValueGenerator<int>
        {
            private readonly string _sequenceName;

            public SequenceValueGenerator(string sequenceName)
            {
                _sequenceName = sequenceName;
            }

            public override bool GeneratesTemporaryValues => false;

            public override int Next(EntityEntry entry)
            {
                using (var command = entry.Context.Database.GetDbConnection().CreateCommand())
                {
                    //Postgres
                    //command.CommandText = $"SELECT NEXTVAL('{_sequenceName}')";

                    //SqlServer
                    command.CommandText = $"SELECT NEXT VALUE FOR dbo.{_sequenceName}";
                    entry.Context.Database.OpenConnection();
                    var reader = command.ExecuteScalar();
                    return Convert.ToInt32(reader);
                }
            }
        }
    }
}
