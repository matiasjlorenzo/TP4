using System.Diagnostics.Eventing.Reader;
using TP4.Enums;
using TP4.Lógica;
using TP4.Models;

namespace TP4
{
    public partial class Form1 : Form
    {
        NumerosAleatorios obNA = new();

        public Form1()
        {
            InitializeComponent();
        }

        int simulaciones = 0;
        string evento = string.Empty;
        double reloj = 0;

        double rndLlegadaEmpleado = 0;
        double tiempoEntreLlegadas = 0;
        double proximaLlegada = 0;
        string aDondeVoy = string.Empty;

        double rndFinRegistro = 0;
        double tiempoFinRegistro = 0;
        double finRegistro = 0;

        double rndLlegadaTecnico = 0;
        double tiempoTecnico = 0;
        double tiempoLlegadaTecnico = 0;

        Cliente? tecnico = null;

        double rndFinMantenimiento = 0;
        double tiempoMantenimiento = 0;
        double finMantenimiento;

        int cola = 0;
        int acumuladorEmpleadosSeVan = 0;
        int acumuladorEmpleadosRegistrados = 0;
        double acumuladorTiempoEsperaEmpleados = 0;

        private void btnSimular_Click_1(object sender, EventArgs e)
        {
            evento = eEventos.Inicio;

            GenerarLlegadaEmpleado();

            GenerarLlegadaTecnico();

            dataGridSimulacion.Rows.Add(0, evento, reloj, rndLlegadaEmpleado, tiempoEntreLlegadas, proximaLlegada, aDondeVoy, "", "", "", rndLlegadaTecnico, tiempoTecnico, tiempoLlegadaTecnico, "", "", "", "", "Libre", "Libre", "Libre", "Libre", cola, acumuladorEmpleadosSeVan, acumuladorEmpleadosRegistrados, acumuladorTiempoEsperaEmpleados);

            simulaciones = int.Parse(txtCantSimulaciones.Text);

            evento = eEventos.LlegadaEmpleado;

            Servidor servidor = new Servidor();

            for (int i = 1; i < simulaciones; i++)
            {
                if (evento.Equals(eEventos.LlegadaEmpleado))
                {
                    GenerarLlegadaEmpleado();

                    if (servidor.Terminal1.Estado.Equals(eEstadosTerminales.Libre)) //!servidor.Terminal1.Ocupada
                    {
                        //servidor.Terminal1.Ocupada = true;
                        servidor.Terminal1.Estado = eEstadosTerminales.Ocupada;
                        servidor.Terminal1.HoraFinOperacion = finRegistro;
                        servidor.Terminal1.Cliente = new Cliente
                        {
                            TipoCliente = eTiposClientes.Empleado,
                            Estado = eEstadosEmpleados.SiendoAtendido,
                            HoraLlegada = reloj,
                            HoraEspera = 0,
                        };

                        GenerarFinRegistro();

                        servidor.Terminal1.HoraFinOperacion = finRegistro;

                        servidor.ColaClientes.Enqueue(servidor.Terminal1.Cliente);
                    }
                    else if (servidor.Terminal2.Estado.Equals(eEstadosTerminales.Libre)) //!servidor.Terminal2.Ocupada
                    {
                        //servidor.Terminal2.Ocupada = true;
                        servidor.Terminal2.Estado = eEstadosTerminales.Ocupada;
                        servidor.Terminal2.HoraFinOperacion = finRegistro;
                        servidor.Terminal2.Cliente = new Cliente
                        {
                            TipoCliente = eTiposClientes.Empleado,
                            Estado = eEstadosEmpleados.SiendoAtendido,
                            HoraLlegada = reloj,
                            HoraEspera = 0
                        };

                        GenerarFinRegistro();

                        servidor.Terminal2.HoraFinOperacion = finRegistro;

                        servidor.ColaClientes.Enqueue(servidor.Terminal2.Cliente);
                    }
                    else if (servidor.Terminal3.Estado.Equals(eEstadosTerminales.Libre)) //!servidor.Terminal3.Ocupada
                    {
                        //servidor.Terminal3.Ocupada = true;
                        servidor.Terminal3.Estado = eEstadosTerminales.Ocupada;
                        servidor.Terminal3.HoraFinOperacion = finRegistro;
                        servidor.Terminal3.Cliente = new Cliente
                        {
                            TipoCliente = eTiposClientes.Empleado,
                            Estado = eEstadosEmpleados.SiendoAtendido,
                            HoraLlegada = reloj,
                            HoraEspera = 0
                        };

                        GenerarFinRegistro();

                        servidor.Terminal3.HoraFinOperacion = finRegistro;

                        servidor.ColaClientes.Enqueue(servidor.Terminal3.Cliente);
                    }
                    else if (servidor.Terminal4.Estado.Equals(eEstadosTerminales.Libre)) //!servidor.Terminal4.Ocupada
                    {
                        //servidor.Terminal4.Ocupada = true;
                        servidor.Terminal4.Estado = eEstadosTerminales.Ocupada;
                        servidor.Terminal4.HoraFinOperacion = finRegistro;
                        servidor.Terminal4.Cliente = new Cliente
                        {
                            TipoCliente = eTiposClientes.Empleado,
                            Estado = eEstadosEmpleados.SiendoAtendido,
                            HoraLlegada = reloj,
                            HoraEspera = 0
                        };

                        GenerarFinRegistro();

                        servidor.Terminal4.HoraFinOperacion = finRegistro;

                        servidor.ColaClientes.Enqueue(servidor.Terminal4.Cliente);
                    }
                    else if (servidor.ColaClientes.Count < 9)
                    {
                        servidor.ColaClientes.Enqueue(new Cliente
                        {
                            TipoCliente = eTiposClientes.Empleado,
                            Estado = eEstadosEmpleados.EnCola,
                            HoraLlegada = reloj,
                            HoraEspera = 0
                        });
                    }
                    else
                        acumuladorEmpleadosSeVan++;

                }

                //Cambiar la validacion del tecnico esperando
                else if (evento.Equals(eEventos.FinRegistro))
                {
                    acumuladorEmpleadosRegistrados++;

                    if (servidor.Terminal1.HoraFinOperacion.Equals(reloj))
                    {
                        IEnumerable<Cliente> clientes = servidor.ColaClientes.Where(c => !c.Equals(servidor.Terminal1.Cliente));

                        Queue<Cliente> clientesEnOtrasTerminales = new();

                        foreach (var cliente in clientes)
                            clientesEnOtrasTerminales.Enqueue(cliente);

                        servidor.ColaClientes = clientesEnOtrasTerminales;

                        servidor.Terminal1.Cliente.Estado = eEstadosEmpleados.Destruido;

                        //AGREGAR A TABLA

                        if (tecnico != null && tecnico.Estado.Equals(eEstadosTecnicos.Esperando) && !servidor.Terminal1.MantenimientoRealizado)
                        {
                            tecnico.Estado = eEstadosTecnicos.Trabajando;
                            servidor.Terminal1.Cliente = tecnico;
                            servidor.Terminal1.Estado = eEstadosTerminales.Mantenimiento;

                            rndFinMantenimiento = obNA.GenerarNumeros(1).FirstOrDefault();
                            tiempoMantenimiento = 3 + (10 - 3) * rndFinMantenimiento;
                            servidor.Terminal1.HoraFinOperacion = reloj + tiempoMantenimiento;
                        }
                        else if (servidor.ColaClientes.Any(c => c.Estado.Equals(eEstadosEmpleados.EnCola)))
                        {
                            servidor.Terminal1.Cliente = servidor.ColaClientes.FirstOrDefault(c => c.Estado.Equals(eEstadosEmpleados.EnCola));
                            servidor.Terminal1.Estado = eEstadosTerminales.Ocupada;
                            servidor.Terminal1.Cliente.Estado = eEstadosEmpleados.SiendoAtendido;
                            servidor.Terminal1.Cliente.HoraEspera = reloj - servidor.Terminal1.Cliente.HoraLlegada;

                            acumuladorTiempoEsperaEmpleados += servidor.Terminal1.Cliente.HoraEspera;

                            GenerarFinRegistro();
                            servidor.Terminal1.HoraFinOperacion = finRegistro;
                        }
                        else
                        {
                            servidor.Terminal1.Estado = eEstadosTerminales.Libre;
                            //servidor.Terminal1.Ocupada = false;
                            servidor.Terminal1.HoraFinOperacion = 0;
                        }
                    }
                    else if (servidor.Terminal2.HoraFinOperacion.Equals(reloj))
                    {
                        IEnumerable<Cliente> clientes = servidor.ColaClientes.Where(c => !c.Equals(servidor.Terminal2.Cliente));

                        Queue<Cliente> clientesEnOtrasTerminales = new();

                        foreach (var cliente in clientes)
                            clientesEnOtrasTerminales.Enqueue(cliente);

                        servidor.ColaClientes = clientesEnOtrasTerminales;

                        servidor.Terminal2.Cliente.Estado = eEstadosEmpleados.Destruido;

                        //AGREGAR A TABLA

                        if (tecnico != null && tecnico.Estado.Equals(eEstadosTecnicos.Esperando) && !servidor.Terminal2.MantenimientoRealizado)
                        {

                            tecnico.Estado = eEstadosTecnicos.Trabajando;
                            servidor.Terminal2.Cliente = tecnico;
                            servidor.Terminal2.Estado = eEstadosTerminales.Mantenimiento;

                            rndFinMantenimiento = obNA.GenerarNumeros(1).FirstOrDefault();
                            tiempoMantenimiento = 3 + (10 - 3) * rndFinMantenimiento;
                            servidor.Terminal2.HoraFinOperacion = reloj + tiempoMantenimiento;
                        }
                        else if (servidor.ColaClientes.Any(c => c.Estado.Equals(eEstadosEmpleados.EnCola)))
                        {
                            servidor.Terminal2.Cliente = servidor.ColaClientes.FirstOrDefault(c => c.Estado.Equals(eEstadosEmpleados.EnCola));
                            servidor.Terminal2.Estado = eEstadosTerminales.Ocupada;
                            servidor.Terminal2.Cliente.Estado = eEstadosEmpleados.SiendoAtendido;
                            servidor.Terminal2.Cliente.HoraEspera = reloj - servidor.Terminal1.Cliente.HoraLlegada;

                            acumuladorTiempoEsperaEmpleados += servidor.Terminal2.Cliente.HoraEspera;

                            GenerarFinRegistro();
                            servidor.Terminal2.HoraFinOperacion = finRegistro;
                        }
                        else
                        {
                            servidor.Terminal2.Estado = eEstadosTerminales.Libre;
                            //servidor.Terminal2.Ocupada = false;
                            servidor.Terminal2.HoraFinOperacion = 0;
                        }
                    }
                    else if (servidor.Terminal3.HoraFinOperacion.Equals(reloj))
                    {
                        IEnumerable<Cliente> clientes = servidor.ColaClientes.Where(c => !c.Equals(servidor.Terminal3.Cliente));

                        Queue<Cliente> clientesEnOtrasTerminales = new();

                        foreach (var cliente in clientes)
                            clientesEnOtrasTerminales.Enqueue(cliente);

                        servidor.ColaClientes = clientesEnOtrasTerminales;

                        servidor.Terminal3.Cliente.Estado = eEstadosEmpleados.Destruido;

                        //AGREGAR A TABLA

                        if (tecnico != null && tecnico.Estado.Equals(eEstadosTecnicos.Esperando) && !servidor.Terminal3.MantenimientoRealizado)
                        {

                            tecnico.Estado = eEstadosTecnicos.Trabajando;
                            servidor.Terminal3.Cliente = tecnico;
                            servidor.Terminal3.Estado = eEstadosTerminales.Mantenimiento;

                            rndFinMantenimiento = obNA.GenerarNumeros(1).FirstOrDefault();
                            tiempoMantenimiento = 3 + (10 - 3) * rndFinMantenimiento;
                            servidor.Terminal3.HoraFinOperacion = reloj + tiempoMantenimiento;
                        }
                        else if (servidor.ColaClientes.Any(c => c.Estado.Equals(eEstadosEmpleados.EnCola)))
                        {
                            servidor.Terminal3.Cliente = servidor.ColaClientes.FirstOrDefault(c => c.Estado.Equals(eEstadosEmpleados.EnCola));
                            servidor.Terminal3.Estado = eEstadosTerminales.Ocupada;
                            servidor.Terminal3.Cliente.Estado = eEstadosEmpleados.SiendoAtendido;
                            servidor.Terminal3.Cliente.HoraEspera = reloj - servidor.Terminal1.Cliente.HoraLlegada;

                            acumuladorTiempoEsperaEmpleados += servidor.Terminal3.Cliente.HoraEspera;

                            GenerarFinRegistro();
                            servidor.Terminal3.HoraFinOperacion = finRegistro;
                        }
                        else
                        {
                            servidor.Terminal3.Estado = eEstadosTerminales.Libre;
                            //servidor.Terminal3.Ocupada = false;
                            servidor.Terminal3.HoraFinOperacion = 0;
                        }
                    }
                    else if (servidor.Terminal4.HoraFinOperacion.Equals(reloj))
                    {
                        IEnumerable<Cliente> clientes = servidor.ColaClientes.Where(c => !c.Equals(servidor.Terminal4.Cliente));

                        Queue<Cliente> clientesEnOtrasTerminales = new();

                        foreach (var cliente in clientes)
                            clientesEnOtrasTerminales.Enqueue(cliente);

                        servidor.ColaClientes = clientesEnOtrasTerminales;

                        servidor.Terminal4.Cliente.Estado = eEstadosEmpleados.Destruido;

                        //AGREGAR A TABLA

                        if (tecnico != null && tecnico.Estado.Equals(eEstadosTecnicos.Esperando) && !servidor.Terminal4.MantenimientoRealizado)
                        {
                            tecnico.Estado = eEstadosTecnicos.Trabajando;
                            servidor.Terminal4.Cliente = tecnico;
                            servidor.Terminal4.Estado = eEstadosTerminales.Mantenimiento;

                            rndFinMantenimiento = obNA.GenerarNumeros(1).FirstOrDefault();
                            tiempoMantenimiento = 3 + (10 - 3) * rndFinMantenimiento;
                            servidor.Terminal4.HoraFinOperacion = reloj + tiempoMantenimiento;
                        }
                        else if (servidor.ColaClientes.Any(c => c.Estado.Equals(eEstadosEmpleados.EnCola)))
                        {
                            servidor.Terminal4.Cliente = servidor.ColaClientes.FirstOrDefault(c => c.Estado.Equals(eEstadosEmpleados.EnCola));
                            servidor.Terminal4.Estado = eEstadosTerminales.Ocupada;
                            servidor.Terminal4.Cliente.Estado = eEstadosEmpleados.SiendoAtendido;
                            servidor.Terminal4.Cliente.HoraEspera = reloj - servidor.Terminal1.Cliente.HoraLlegada;

                            acumuladorTiempoEsperaEmpleados += servidor.Terminal4.Cliente.HoraEspera;

                            GenerarFinRegistro();
                            servidor.Terminal4.HoraFinOperacion = finRegistro;
                        }
                        else
                        {
                            servidor.Terminal4.Estado = eEstadosTerminales.Libre;
                            //servidor.Terminal4.Ocupada = false;
                            servidor.Terminal4.HoraFinOperacion = 0;
                        }
                    }
                }

                else if (evento.Equals(eEventos.LlegadaTecnico))
                {
                    tecnico = new()
                    {
                        TipoCliente = eTiposClientes.Tecnico,
                        Estado = eEstadosTecnicos.Esperando
                    };

                    tiempoLlegadaTecnico = 0;

                    if (servidor.Terminal1.Estado.Equals(eEstadosTerminales.Libre)) //!servidor.Terminal1.Ocupada
                    {
                        //servidor.Terminal1.Ocupada = true;
                        servidor.Terminal1.Estado = eEstadosTerminales.Mantenimiento;

                        GenerarFinMantenimiento();

                        servidor.Terminal1.HoraFinOperacion = finMantenimiento;

                        tecnico.Estado = eEstadosTecnicos.Trabajando;
                        tiempoLlegadaTecnico = 0;
                        servidor.Terminal1.Cliente = tecnico;
                    }
                    else if (servidor.Terminal2.Estado.Equals(eEstadosTerminales.Libre)) //!servidor.Terminal2.Ocupada
                    {
                        //servidor.Terminal2.Ocupada = true;
                        servidor.Terminal2.Estado = eEstadosTerminales.Mantenimiento;

                        GenerarFinMantenimiento();

                        servidor.Terminal2.HoraFinOperacion = finMantenimiento;

                        tecnico.Estado = eEstadosTecnicos.Trabajando;
                        tiempoLlegadaTecnico = 0;
                        servidor.Terminal2.Cliente = tecnico;
                    }
                    else if (servidor.Terminal3.Estado.Equals(eEstadosTerminales.Libre)) //!servidor.Terminal3.Ocupada
                    {
                        //servidor.Terminal3.Ocupada = true;
                        servidor.Terminal3.Estado = eEstadosTerminales.Mantenimiento;

                        GenerarFinMantenimiento();

                        servidor.Terminal3.HoraFinOperacion = finMantenimiento;

                        tecnico.Estado = eEstadosTecnicos.Trabajando;
                        tiempoLlegadaTecnico = 0;
                        servidor.Terminal3.Cliente = tecnico;
                    }
                    else if (servidor.Terminal4.Estado.Equals(eEstadosTerminales.Libre)) //!servidor.Terminal4.Ocupada
                    {
                        //servidor.Terminal4.Ocupada = true;
                        servidor.Terminal4.Estado = eEstadosTerminales.Mantenimiento;

                        GenerarFinMantenimiento();

                        servidor.Terminal4.HoraFinOperacion = finMantenimiento;

                        tecnico.Estado = eEstadosTecnicos.Trabajando;
                        tiempoLlegadaTecnico = 0;
                        servidor.Terminal4.Cliente = tecnico;
                    }
                    else //Entra en espera
                    {
                        tecnico = new()
                        {
                            TipoCliente = eTiposClientes.Tecnico,
                            Estado = eEstadosTecnicos.Esperando
                        };
                    }
                }

                else if (evento.Equals(eEventos.FinMantenimiento))
                {
                    if (servidor.Terminal1.HoraFinOperacion.Equals(reloj))
                    {
                        ReAsignarTerminal1(servidor);
                    }
                    else if (servidor.Terminal2.HoraFinOperacion.Equals(reloj))
                    {
                        ReAsignarTerminal2(servidor);
                    }
                    else if (servidor.Terminal3.HoraFinOperacion.Equals(reloj))
                    {
                        ReAsignarTerminal3(servidor);
                    }
                    else if (servidor.Terminal4.HoraFinOperacion.Equals(reloj))
                    {
                        ReAsignarTerminal4(servidor);
                    }

                    // validar que se realizaron todos los mantenimientos
                    if (servidor.Terminal1.MantenimientoRealizado.Equals(true) && servidor.Terminal2.MantenimientoRealizado.Equals(true)
                        && servidor.Terminal3.MantenimientoRealizado.Equals(true) && servidor.Terminal4.MantenimientoRealizado.Equals(true))
                    {
                        GenerarLlegadaTecnico();

                        servidor.Terminal1.MantenimientoRealizado = false;
                        servidor.Terminal2.MantenimientoRealizado = false;
                        servidor.Terminal3.MantenimientoRealizado = false;
                        servidor.Terminal4.MantenimientoRealizado = false;
                        tecnico = null;
                    }
                }

                //cargar tabla

                dataGridSimulacion.Rows.Add(i, evento, reloj,
                        rndLlegadaEmpleado, tiempoEntreLlegadas, proximaLlegada, aDondeVoy,
                        rndFinRegistro, tiempoFinRegistro, finRegistro,
                        rndLlegadaTecnico, tiempoTecnico, tiempoLlegadaTecnico, tecnico != null ? tecnico.Estado : "",
                        rndFinMantenimiento, tiempoMantenimiento, finMantenimiento,
                        servidor.Terminal1.Estado, servidor.Terminal2.Estado, servidor.Terminal3.Estado, servidor.Terminal4.Estado, servidor.ColaClientes.Count,
                        acumuladorEmpleadosSeVan, acumuladorEmpleadosRegistrados, acumuladorTiempoEsperaEmpleados);

                if (servidor.ColaClientes.Any())
                {
                    List<Cliente> clientes = servidor.ColaClientes.ToList();

                    for (int j = 0; j < servidor.ColaClientes.Count; j++)
                    {
                        if (dataGridSimulacion.Columns["Estado" + j.ToString()] != null)
                        {
                            dataGridSimulacion.Rows[i].Cells["Estado" + j.ToString()].Value = clientes[j].Estado;
                            dataGridSimulacion.Rows[i].Cells["Hora Llegada" + j.ToString()].Value = clientes[j].HoraLlegada.ToString();
                            dataGridSimulacion.Rows[i].Cells["Tiempo Espera" + j.ToString()].Value = clientes[j].HoraEspera.ToString();
                        }
                        else
                        {
                            int indiceColumna = dataGridSimulacion.Columns.Add("Estado" + j.ToString(), "Estado");
                            dataGridSimulacion.Rows[i].Cells[indiceColumna].Value = clientes[j].Estado;

                            int indiceColumna2 = dataGridSimulacion.Columns.Add("Hora Llegada" + j.ToString(), "Hora Llegada");
                            dataGridSimulacion.Rows[i].Cells[indiceColumna2].Value = clientes[j].HoraLlegada.ToString();

                            int indiceColumna3 = dataGridSimulacion.Columns.Add("Tiempo Espera" + j.ToString(), "Tiempo Espera");
                            dataGridSimulacion.Rows[i].Cells[indiceColumna3].Value = clientes[j].HoraEspera.ToString();
                        }
                    }
                }

                tiempoEntreLlegadas = 0;
                tiempoFinRegistro = 0;
                tiempoMantenimiento = 0;
                finRegistro = 0;

                var numeros = new List<double>(){ proximaLlegada, /*finRegistro,*/ tiempoLlegadaTecnico, /*finMantenimiento,*/
                    servidor.Terminal1.HoraFinOperacion, servidor.Terminal2.HoraFinOperacion, servidor.Terminal3.HoraFinOperacion, servidor.Terminal4.HoraFinOperacion,};

                reloj = numeros.Where(x => !x.Equals(0)).OrderByDescending(x => x).LastOrDefault();

                if (reloj == proximaLlegada)
                    evento = eEventos.LlegadaEmpleado;
                else if (reloj == tiempoLlegadaTecnico)
                    evento = eEventos.LlegadaTecnico;
                else if (reloj == servidor.Terminal1.HoraFinOperacion)
                    if (servidor.Terminal1.Estado == eEstadosTerminales.Ocupada)
                        evento = eEventos.FinRegistro;
                    else
                        evento = eEventos.FinMantenimiento;
                else if (reloj == servidor.Terminal2.HoraFinOperacion)
                    if (servidor.Terminal2.Estado == eEstadosTerminales.Ocupada)
                        evento = eEventos.FinRegistro;
                    else
                        evento = eEventos.FinMantenimiento;
                else if (reloj == servidor.Terminal3.HoraFinOperacion)
                    if (servidor.Terminal3.Estado == eEstadosTerminales.Ocupada)
                        evento = eEventos.FinRegistro;
                    else
                        evento = eEventos.FinMantenimiento;
                else if (reloj == servidor.Terminal4.HoraFinOperacion)
                    if (servidor.Terminal4.Estado == eEstadosTerminales.Ocupada)
                        evento = eEventos.FinRegistro;
                    else
                        evento = eEventos.FinMantenimiento;

            }
        }


        //cargar tabla al final del loop pero antes de definir el proximo evento
        //para el final del loop, definir el siguiente evento buscando la hora minima de: proximaLlegada, finRegistro,llegadaTecnico y finMantenimiento
        private void ReAsignarTerminal1(Servidor servidor)
        {
            servidor.Terminal1.MantenimientoRealizado = true;
            if (servidor.Terminal2.Estado.Equals(eEstadosTerminales.Libre) && !servidor.Terminal2.MantenimientoRealizado) //!servidor.Terminal2.Ocupada
            {
                servidor.Terminal2.Cliente = servidor.Terminal1.Cliente;
                servidor.Terminal1.Estado = eEstadosTerminales.Libre;
                servidor.Terminal2.Estado = eEstadosTerminales.Mantenimiento;

                GenerarFinMantenimiento();
                servidor.Terminal2.HoraFinOperacion = finMantenimiento;
                servidor.Terminal1.HoraFinOperacion = 0;
            }
            else if (servidor.Terminal3.Estado.Equals(eEstadosTerminales.Libre) && !servidor.Terminal3.MantenimientoRealizado) //!servidor.Terminal3.Ocupada
            {
                servidor.Terminal3.Cliente = servidor.Terminal1.Cliente;
                servidor.Terminal1.Estado = eEstadosTerminales.Libre;
                servidor.Terminal3.Estado = eEstadosTerminales.Mantenimiento;

                GenerarFinMantenimiento();
                servidor.Terminal3.HoraFinOperacion = finMantenimiento;
                servidor.Terminal1.HoraFinOperacion = 0;
            }

            else if (servidor.Terminal4.Estado.Equals(eEstadosTerminales.Libre) && !servidor.Terminal4.MantenimientoRealizado) //!servidor.Terminal4.Ocupada
            {
                servidor.Terminal4.Cliente = servidor.Terminal1.Cliente;
                servidor.Terminal1.Estado = eEstadosTerminales.Libre;
                servidor.Terminal4.Estado = eEstadosTerminales.Mantenimiento;

                GenerarFinMantenimiento();
                servidor.Terminal4.HoraFinOperacion = finMantenimiento;
                servidor.Terminal1.HoraFinOperacion = 0;
            }
            else if (servidor.ColaClientes.Any(c => c.Estado.Equals(eEstadosEmpleados.EnCola)))
            {
                servidor.Terminal1.Cliente = servidor.ColaClientes.FirstOrDefault(c => c.Estado.Equals(eEstadosEmpleados.EnCola));
                servidor.Terminal1.Cliente.Estado = eEstadosEmpleados.SiendoAtendido;
                servidor.Terminal1.Cliente.HoraEspera = reloj - servidor.Terminal1.Cliente.HoraLlegada;

                acumuladorTiempoEsperaEmpleados += servidor.Terminal1.Cliente.HoraEspera;

                servidor.Terminal1.Estado = eEstadosTerminales.Ocupada;

                GenerarFinRegistro();
                servidor.Terminal1.HoraFinOperacion = finRegistro;
                tecnico.Estado = eEstadosTecnicos.Esperando;


            }
            else
            {
                servidor.Terminal1.Estado = eEstadosTerminales.Libre;
                tecnico.Estado = eEstadosTecnicos.Esperando;
                servidor.Terminal1.HoraFinOperacion = 0;
            }
        }

        private void ReAsignarTerminal2(Servidor servidor)
        {
            servidor.Terminal2.MantenimientoRealizado = true;
            if (servidor.Terminal1.Estado.Equals(eEstadosTerminales.Libre) && !servidor.Terminal1.MantenimientoRealizado) //!servidor.Terminal1.Ocupada
            {
                servidor.Terminal1.Cliente = servidor.Terminal2.Cliente;
                servidor.Terminal2.Estado = eEstadosTerminales.Libre;
                servidor.Terminal1.Estado = eEstadosTerminales.Mantenimiento;

                GenerarFinMantenimiento();
                servidor.Terminal1.HoraFinOperacion = finMantenimiento;
                servidor.Terminal2.HoraFinOperacion = 0;
            }
            else if (servidor.Terminal3.Estado.Equals(eEstadosTerminales.Libre) && !servidor.Terminal3.MantenimientoRealizado) //!servidor.Terminal3.Ocupada
            {
                servidor.Terminal3.Cliente = servidor.Terminal2.Cliente;
                servidor.Terminal2.Estado = eEstadosTerminales.Libre;
                servidor.Terminal3.Estado = eEstadosTerminales.Mantenimiento;

                GenerarFinMantenimiento();
                servidor.Terminal3.HoraFinOperacion = finMantenimiento;
                servidor.Terminal2.HoraFinOperacion = 0;
            }
            else if (servidor.Terminal4.Estado.Equals(eEstadosTerminales.Libre) && !servidor.Terminal4.MantenimientoRealizado) //!servidor.Terminal4.Ocupada
            {
                servidor.Terminal4.Cliente = servidor.Terminal2.Cliente;
                servidor.Terminal2.Estado = eEstadosTerminales.Libre;
                servidor.Terminal4.Estado = eEstadosTerminales.Mantenimiento;

                GenerarFinMantenimiento();
                servidor.Terminal4.HoraFinOperacion = finMantenimiento;
                servidor.Terminal2.HoraFinOperacion = 0;
            }
            else
            {
                tecnico.Estado = eEstadosTecnicos.Esperando;
                servidor.Terminal2.Estado = eEstadosTerminales.Libre;
                servidor.Terminal2.HoraFinOperacion = 0;
            }

            if (servidor.ColaClientes.Any(c => c.Estado.Equals(eEstadosEmpleados.EnCola)))
            {
                servidor.Terminal2.Cliente = servidor.ColaClientes.FirstOrDefault(c => c.Estado.Equals(eEstadosEmpleados.EnCola));
                servidor.Terminal2.Cliente.Estado = eEstadosEmpleados.SiendoAtendido;
                servidor.Terminal2.Cliente.HoraEspera = reloj - servidor.Terminal2.Cliente.HoraLlegada;

                acumuladorTiempoEsperaEmpleados += servidor.Terminal2.Cliente.HoraEspera;

                servidor.Terminal2.Estado = eEstadosTerminales.Ocupada;

                GenerarFinRegistro();
                servidor.Terminal2.HoraFinOperacion = finRegistro;
                //tecnico.Estado = eEstadosTecnicos.Esperando;            
            }
        }

        private void ReAsignarTerminal3(Servidor servidor)
        {
            servidor.Terminal3.MantenimientoRealizado = true;
            if (servidor.Terminal1.Estado.Equals(eEstadosTerminales.Libre) && !servidor.Terminal1.MantenimientoRealizado) //!servidor.Terminal1.Ocupada
            {
                servidor.Terminal1.Cliente = servidor.Terminal3.Cliente;
                servidor.Terminal3.Estado = eEstadosTerminales.Libre;
                servidor.Terminal1.Estado = eEstadosTerminales.Mantenimiento;

                GenerarFinMantenimiento();
                servidor.Terminal1.HoraFinOperacion = finMantenimiento;
                servidor.Terminal3.HoraFinOperacion = 0;
            }
            else if (servidor.Terminal2.Estado.Equals(eEstadosTerminales.Libre) && !servidor.Terminal2.MantenimientoRealizado) //!servidor.Terminal2.Ocupada
            {
                servidor.Terminal2.Cliente = servidor.Terminal3.Cliente;
                servidor.Terminal3.Estado = eEstadosTerminales.Libre;
                servidor.Terminal2.Estado = eEstadosTerminales.Mantenimiento;

                GenerarFinMantenimiento();
                servidor.Terminal2.HoraFinOperacion = finMantenimiento;
                servidor.Terminal3.HoraFinOperacion = 0;
            }
            else if (servidor.Terminal4.Estado.Equals(eEstadosTerminales.Libre) && !servidor.Terminal4.MantenimientoRealizado) //!servidor.Terminal4.Ocupada
            {
                servidor.Terminal4.Cliente = servidor.Terminal3.Cliente;
                servidor.Terminal3.Estado = eEstadosTerminales.Libre;
                servidor.Terminal4.Estado = eEstadosTerminales.Mantenimiento;

                GenerarFinMantenimiento();
                servidor.Terminal4.HoraFinOperacion = finMantenimiento;
                servidor.Terminal3.HoraFinOperacion = 0;
            }
            else
            {
                tecnico.Estado = eEstadosTecnicos.Esperando;
                servidor.Terminal3.HoraFinOperacion = 0;
                servidor.Terminal3.Estado = eEstadosTerminales.Libre;
            }

            if (servidor.ColaClientes.Any(c => c.Estado.Equals(eEstadosEmpleados.EnCola)))
            {
                servidor.Terminal3.Cliente = servidor.ColaClientes.FirstOrDefault(c => c.Estado.Equals(eEstadosEmpleados.EnCola));
                servidor.Terminal3.Cliente.Estado = eEstadosEmpleados.SiendoAtendido;
                servidor.Terminal3.Cliente.HoraEspera = reloj - servidor.Terminal3.Cliente.HoraLlegada;

                acumuladorTiempoEsperaEmpleados += servidor.Terminal3.Cliente.HoraEspera;

                servidor.Terminal3.Estado = eEstadosTerminales.Ocupada;

                GenerarFinRegistro();
                servidor.Terminal3.HoraFinOperacion = finRegistro;
                //tecnico.Estado = eEstadosTecnicos.Esperando;             
            }
        }

        private void ReAsignarTerminal4(Servidor servidor)
        {
            servidor.Terminal4.MantenimientoRealizado = true;
            if (servidor.Terminal1.Estado.Equals(eEstadosTerminales.Libre) && !servidor.Terminal1.MantenimientoRealizado) //!servidor.Terminal1.Ocupada
            {
                servidor.Terminal1.Cliente = servidor.Terminal4.Cliente;
                servidor.Terminal4.Estado = eEstadosTerminales.Libre;
                servidor.Terminal1.Estado = eEstadosTerminales.Mantenimiento;

                GenerarFinMantenimiento();
                servidor.Terminal1.HoraFinOperacion = finMantenimiento;
                servidor.Terminal4.HoraFinOperacion = 0;
            }
            else if (servidor.Terminal2.Estado.Equals(eEstadosTerminales.Libre) && !servidor.Terminal2.MantenimientoRealizado) //!servidor.Terminal2.Ocupada
            {
                servidor.Terminal2.Cliente = servidor.Terminal4.Cliente;
                servidor.Terminal4.Estado = eEstadosTerminales.Libre;
                servidor.Terminal2.Estado = eEstadosTerminales.Mantenimiento;

                GenerarFinMantenimiento();
                servidor.Terminal2.HoraFinOperacion = finMantenimiento;
                servidor.Terminal4.HoraFinOperacion = 0;
            }
            else if (servidor.Terminal3.Estado.Equals(eEstadosTerminales.Libre) && !servidor.Terminal3.MantenimientoRealizado) //!servidor.Terminal3.Ocupada
            {
                servidor.Terminal3.Cliente = servidor.Terminal4.Cliente;
                servidor.Terminal4.Estado = eEstadosTerminales.Libre;
                servidor.Terminal3.Estado = eEstadosTerminales.Mantenimiento;

                GenerarFinMantenimiento();
                servidor.Terminal3.HoraFinOperacion = finMantenimiento;
                servidor.Terminal4.HoraFinOperacion = 0;
            }
            else
            {
                tecnico.Estado = eEstadosTecnicos.Esperando;
                servidor.Terminal4.Estado = eEstadosTerminales.Libre;
                servidor.Terminal4.HoraFinOperacion = 0;
            }

            if (servidor.ColaClientes.Any(c => c.Estado.Equals(eEstadosEmpleados.EnCola)))
            {
                servidor.Terminal4.Cliente = servidor.ColaClientes.FirstOrDefault(c => c.Estado.Equals(eEstadosEmpleados.EnCola));
                servidor.Terminal4.Cliente.Estado = eEstadosEmpleados.SiendoAtendido;
                servidor.Terminal4.Cliente.HoraEspera = reloj - servidor.Terminal4.Cliente.HoraLlegada;

                acumuladorTiempoEsperaEmpleados += servidor.Terminal4.Cliente.HoraEspera;

                servidor.Terminal4.Estado = eEstadosTerminales.Ocupada;

                GenerarFinRegistro();
                servidor.Terminal4.HoraFinOperacion = finRegistro;
                //tecnico.Estado = eEstadosTecnicos.Esperando;              
            }
        }

        private void GenerarFinRegistro()
        {
            double finRegistroA = Convert.ToDouble(txtFinRegistroA.Text);
            double finRegistroB = Convert.ToDouble(txtFinRegistroB.Text);

            rndFinRegistro = obNA.GenerarNumeros(1).FirstOrDefault();
            tiempoFinRegistro = finRegistroA + (finRegistroB - finRegistroA) * rndFinRegistro;
            finRegistro = reloj + tiempoFinRegistro;
        }

        private void GenerarFinMantenimiento()
        {
            double finMantemientoA = Convert.ToDouble(txtFinMantenimientoA.Text);
            double finMantemientoB = Convert.ToDouble(txtFinMantenimientoB.Text);

            rndFinMantenimiento = obNA.GenerarNumeros(1).FirstOrDefault();
            tiempoMantenimiento = finMantemientoA + (finMantemientoB - finMantemientoA) * rndFinMantenimiento;
            finMantenimiento = reloj + tiempoMantenimiento;
        }

        private void GenerarLlegadaTecnico()
        {
            double llegadaTecnicoA = Convert.ToDouble(txtLlegadaTecnicoA.Text);
            double llegadaTecnicoB = Convert.ToDouble(txtLlegadaTecnicoB.Text);

            rndLlegadaTecnico = obNA.GenerarNumeros(1).FirstOrDefault();
            tiempoTecnico = llegadaTecnicoA + (llegadaTecnicoB - llegadaTecnicoA) * rndLlegadaTecnico;
            tiempoLlegadaTecnico = reloj + tiempoTecnico;
        }

        private void GenerarLlegadaEmpleado()
        {
            double media = Convert.ToDouble(txtMedia.Text);

            rndLlegadaEmpleado = obNA.GenerarNumeros(1).FirstOrDefault();
            tiempoEntreLlegadas = Math.Round(tiempoEntreLlegadas + (-media * Math.Log(1 - rndLlegadaEmpleado)), 2);
            proximaLlegada = reloj + tiempoEntreLlegadas;
        }
    }
}