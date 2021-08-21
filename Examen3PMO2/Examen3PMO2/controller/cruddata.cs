using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Examen3PMO2.Models;


namespace Examen3PMO2.controller
{
    public class Crud
    {
        conexion conn = new conexion();
        public Task<List<Personas>> getReadPersonas()
        {
            return conn.GetConnectionAsync().Table<Personas>().ToListAsync();
        }

        public Task<Personas> getPersonasId(int id)
        {
            return conn
                .GetConnectionAsync()
                .Table<Personas>()
                .Where(item => item.id == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> getPersonasUpdateId(Personas personas)
        {
            return conn
                .GetConnectionAsync()
                .UpdateAsync(personas);

        }
        public Task<int> Delete(Personas personas)
        {
            return conn
                .GetConnectionAsync()
                .DeleteAsync(personas);
        }
    }
}
