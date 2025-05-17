using System;

namespace CentroEventos.Aplicacion {
    public interface IServicioAutorizacion {
        bool PoseeElPermiso(int idUsuario, Permiso permiso);
    }
}
