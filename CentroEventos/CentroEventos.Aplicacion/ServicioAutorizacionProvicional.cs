using System;

namespace CentroEventos.Aplicacion;

public class ServicioAutorizacionProvicional : IServicioAutorizacion
{
    public bool PoseeElPermiso(int idUsuario,Permiso permiso){
        if(idUsuario==1)return true;
        else return false;
    }
}
