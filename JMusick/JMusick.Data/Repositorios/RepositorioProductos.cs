﻿using JMusick.Data.Contratos;
using JMusick.Models;
using JMusick.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMusick.Data.Repositorios
{

    public class ProductosRepositorio : IProductosRepositorio
    {
        private TiendaDbContext _contexto;
        private readonly ILogger<ProductosRepositorio> _logger;

        public ProductosRepositorio(TiendaDbContext contexto, ILogger<ProductosRepositorio> logger)
        {
            _contexto = contexto;
            this._logger = logger;
        }
        public async Task<bool> Actualizar(Producto producto)
        {
            //_contexto.Productos.Attach(producto);
            //_contexto.Entry(producto).State = EntityState.Modified;

            var productoBD = await ObtenerProductoAsync(producto.Id);
            productoBD.Nombre = producto.Nombre;
            productoBD.Precio = producto.Precio;

            try
            {
                return await _contexto.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Actualizar)}: {ex.Message}");
            }
            return false;
        }

        public async Task<Producto> Agregar(Producto producto)
        {
            producto.Estatus = EstatusProducto.Activo;
            producto.FechaRegistro = DateTime.UtcNow;

            _contexto.Productos.Add(producto);
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Agregar)}: {ex.Message}");
                return null;
            }

            return producto;
        }

        public async Task<bool> Eliminar(int id)
        {
            //Se realiza una eliminación suave, solamente inactivamos el producto

            var producto = await _contexto.Productos
                                .SingleOrDefaultAsync(c => c.Id == id);

            producto.Estatus = EstatusProducto.Inactivo;
            _contexto.Productos.Attach(producto);
            _contexto.Entry(producto).State = EntityState.Modified;

            try
            {
                return (await _contexto.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Eliminar)}: {ex.Message}");

            }
            return false;

        }

        public async Task<Producto> ObtenerProductoAsync(int id)
        {
            return await _contexto.Productos
                               .SingleOrDefaultAsync(c => c.Id == id && c.Estatus == EstatusProducto.Activo);
        }

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            return await _contexto.Productos
                .Where(u => u.Estatus == EstatusProducto.Activo)
                .OrderBy(u => u.Nombre)
                                            .ToListAsync();
        }


    }

}
