using Microsoft.EntityFrameworkCore;
using App_DVP.Models;
using App_Coink.Models;

namespace App_DVP.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<EntidadPersona> GetPersona
        (
            string nombres,
            string telefono,
            string direccion,
            string pais,
            string departamento,
            string municipio
        );
        Task<EntidadPersona> SavePersona(EntidadPersona modelo);

        Task<PaisUsuario> GetPaisUsuario
        (
            string pais,
            string id_usuario
        );
        Task<PaisUsuario> SavePaisUsuario(PaisUsuario modelo);

        Task<DepartamentoUsuario> GetDepartamentoUsuario
        (
            string departamento,
            string id_usuario
        );
        Task<DepartamentoUsuario> SaveDepartamentoUsuario(DepartamentoUsuario modelo);

        Task<MunicipioUsuario> GetMunicipioUsuario
        (
            string municipio,
            string id_usuario
        );
        Task<MunicipioUsuario> SaveMunicipioUsuario(MunicipioUsuario modelo);
    }
}
