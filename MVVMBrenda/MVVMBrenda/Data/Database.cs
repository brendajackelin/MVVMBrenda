using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using MVVMBrenda.Models;

namespace MVVMBrenda.Data
{ 
    public class Database
    {
        SQLiteAsyncConnection db;

        public Database(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Empleado>().Wait();
        }

        public Task<int> SavedEmpleadoAsync(Empleado emp)
        {
            if (emp.IdEmpleado != 0)
            {
                return db.UpdateAsync(emp);
            }
            else
            {
                return db.InsertAsync(emp);
            }
        }
        public Task<int> DeleteEmpleadoAsync(Empleado emp)
        {
            return db.DeleteAsync(emp);
        }
        public Task<List<Empleado>> GetEmpleadosAsync()
        {
            return db.Table<Empleado>().ToListAsync();
        }
        public Task<Empleado> GetEmpleadoByIdAsync(int IdEmpleado)
        {
            return db.Table<Empleado>().Where(a => a.IdEmpleado == IdEmpleado).FirstOrDefaultAsync();
        }
    }
}
