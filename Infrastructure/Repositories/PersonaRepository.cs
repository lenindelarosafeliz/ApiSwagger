using Applications.Interfaces;
using Dapper;
using Dominio.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly IConfiguration _configuration;

        public PersonaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Persona entity)
        {
            string sql = $"INSERT INTO Personas (Nombres, Apellidos) VALUES('{entity.Nombres}', '{entity.Apellidos}')";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }

        public async Task<int> DeleteAsync(Persona entity)
        {
            string sql = $"DELETE FROM Personas WHERE (Id = {entity.id})";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;

            }
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            string sql = $"SELECT Id, Nombres, Apellidos FROM Personas";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var personas = await connection.QueryAsync<Persona>(sql);
                return personas;
            }
        }

        public async Task<Persona> GetAsync(int id)
        {
            string sql = $"SELECT Id, Nombres, Apellidos FROM Personas WHERE (Id = {id})";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var persona = await connection.QueryAsync<Persona>(sql, new { Id = id });
                return persona.First();
            }
        }

        public async Task<int> UpdateAsync(Persona entity)
        {

            string sql = $"UPDATE Personas SET Nombres = '{entity.Nombres}', Apellidos='{entity.Apellidos}' WHERE (Id = {entity.id})";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;

            }
        }
    }
}