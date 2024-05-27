    using Microsoft.EntityFrameworkCore;
using App_DVP.Models;
using App_DVP.Servicios.Contrato;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.VisualBasic;
using App_Coink.Models;

namespace App_DVP.Servicios.Implementación
{
    public class UsuarioService : IUsuarioService
    {
        private readonly CoinkContext _dbContext;

        public UsuarioService(CoinkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EntidadPersona> GetPersona(
            string nombres,
            string telefono,
            string direccion,
            string pais,
            string departamento,
            string municipio)
        {
            EntidadPersona usuarioFound = await _dbContext.EntidadPersonas.Where(u => u.Telefono == telefono && u.Direccion == direccion)
                .FirstOrDefaultAsync();

            return usuarioFound;

            //throw new NotImplementedException();
        }

        public async Task<EntidadPersona> SavePersona(EntidadPersona modelo)
        {
            _dbContext.EntidadPersonas.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;

            //throw new NotImplementedException();
        }

        public async Task<PaisUsuario> GetPaisUsuario(string pais, string id_usuario)
        {
            PaisUsuario paisUsuarioFound = await _dbContext.PaisUsuarios.Where(u => u.Pais == pais && u.Id_Usuario == id_usuario)
                .FirstOrDefaultAsync();

            return paisUsuarioFound;
        
            //throw new NotImplementedException();
        }

        public async Task<PaisUsuario> SavePaisUsuario(PaisUsuario modelo)
        {
            var personaRegistrada = _dbContext.EntidadPersonas.ToList();
            var usuarioRegistrado = personaRegistrada.Select(item => new PaisUsuario
            {
                Pais = item.Pais,
                Id_Usuario = item.Telefono
            }).ToList();

            _dbContext.PaisUsuarios.AddRange(usuarioRegistrado);
            await _dbContext.SaveChangesAsync();
            return modelo;
        
            //throw new NotImplementedException();
        }

        public async Task<DepartamentoUsuario> GetDepartamentoUsuario(string departamento, string id_usuario)
        {
            DepartamentoUsuario departamentoUsuarioFound = await _dbContext.DepartamentoUsuarios.Where(u => u.Departamento == departamento && u.Id_Usuario == id_usuario)
                .FirstOrDefaultAsync();

            return departamentoUsuarioFound;

            //throw new NotImplementedException();
        }

        public async Task<DepartamentoUsuario> SaveDepartamentoUsuario(DepartamentoUsuario modelo)
        {
            var personaRegistrada = _dbContext.EntidadPersonas.ToList();
            var usuarioRegistrado = personaRegistrada.Select(item => new DepartamentoUsuario
            {
                Departamento = item.Departamento,
                Id_Usuario = item.Telefono
            }).ToList();

            _dbContext.DepartamentoUsuarios.AddRange(usuarioRegistrado);
            await _dbContext.SaveChangesAsync();
            return modelo;

            //throw new NotImplementedException();
        }

        public async Task<MunicipioUsuario> GetMunicipioUsuario(string municipio, string id_usuario)
        {
            MunicipioUsuario municipioUsuarioFound = await _dbContext.MunicipioUsuarios.Where(u => u.Municipio == municipio && u.Id_Usuario == id_usuario)
                .FirstOrDefaultAsync();

            return municipioUsuarioFound;

            //throw new NotImplementedException();
        }

        public async Task<MunicipioUsuario> SaveMunicipioUsuario(MunicipioUsuario modelo)
        {
            var personaRegistrada = _dbContext.EntidadPersonas.ToList();
            var usuarioRegistrado = personaRegistrada.Select(item => new MunicipioUsuario
            {
                Municipio = item.Municipio,
                Id_Usuario = item.Telefono
            }).ToList();

            _dbContext.MunicipioUsuarios.AddRange(usuarioRegistrado);
            await _dbContext.SaveChangesAsync();
            return modelo;

            //throw new NotImplementedException();
        }
    }
}
