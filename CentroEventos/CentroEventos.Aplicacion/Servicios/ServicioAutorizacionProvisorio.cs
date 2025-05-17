using System;

namespace CentroEventos.Aplicacion.Servicios;

public class ServicioAutorizacionProvicional : IServicioAutorizacion {
    public bool PoseeElPermiso(int idUsuario,Permiso permiso) {
        return idUsuario == 1;
    }
}
