using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Enums
{
    public class eEventos
    {
        public const string
             Inicio = "Inicialización",
             LlegadaEmpleado = "Llegada Empleado",
             FinRegistro = "Fin Registro",
             LlegadaTecnico = "Llegada Técnico",
             FinMantenimiento = "Fin Mantenimiento";
    }

    public class eEstadosTecnicos
    {
        public const string
            Esperando = "Esperando",
            Trabajando = "Trabajando";
    }

    public class eEstadosTerminales
    {
        public const string
            Libre = "Libre",
            Ocupada = "Ocupada",
            Mantenimiento = "Mantenimiento";
    }

    public class eEstadosEmpleados
    {
        public const string
            SiendoAtendido = "Siendo Atendido",
            Destruido = "Destruido",
            EnCola = "En Cola";
    }

    public enum eTiposClientes
    {
        Empleado = 1,
        Tecnico = 2
    }
}
