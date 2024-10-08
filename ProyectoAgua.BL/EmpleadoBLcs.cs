﻿using ProyectoAgua.EN;
using ProyectoAgua.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.BL
{
    public class EmpleadoBL
    {
        public async Task<int> CrearAsync(Empleado pEmpleado)
        {
            return await EmpleadoDAL.CrearAsync(pEmpleado);
        }

        public async Task<int> ModificarAsync(Empleado pEmpleado)
        {
            return await EmpleadoDAL.ModificarAsync(pEmpleado);
        }

        public async Task<int> EliminarAsync(Empleado pEmpleado)
        {
            return await EmpleadoDAL.DeleteAsync(pEmpleado);
        }

        public async Task<Empleado> ObtenerPorIdAsync(Empleado pEmpleado)
        {
            return await EmpleadoDAL.ObtenerPorIdAsync(pEmpleado);
        }

        public async Task<List<Empleado>> ObtenerTodosAsync()
        {
            return await EmpleadoDAL.ObtenerTodosAsync();
        }

        public async Task<List<Empleado>> BuscarAsync(Empleado pEmpleado)
        {
            return await EmpleadoDAL.BuscarAsync(pEmpleado);
        }
    }

}
