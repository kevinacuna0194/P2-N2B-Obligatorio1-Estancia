﻿using ClassLibrary;
using ClassLibrary.Enum;

namespace ConsoleApp
{
    public class Program
    {
        private static Sistema? sistema;

        static void Main(string[] args)
        {
            sistema = Sistema.Instancia;

            string? input;
            bool codigo = true;

            while (codigo)
            {
                Bienvenida();
                Menu();
                input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    /** Listado de todos los animales **/
                    case "1":
                        ListarAnimales();
                        break;
                    /** mostrar todos los potreros con área mayor a dicha cantidad de hectáreas y una capacidad máxima superior al número dado **/
                    case "2":
                        Console.Clear();

                        int hectareas = InputNumber("Ingresar Cantidad de Hectareas");
                        int numero = InputNumber("Ingresar Capacidad Máxima");
                        sistema.ListarPotrerosHectareasCapacidadMaxima(hectareas, numero);
                        break;
                    /** Establecer el precio por kilogramo de lana de los ovinos **/
                    case "3":
                        Console.Clear();

                        int PrecioPorKiloLana = InputNumber("Ingrese Precio por kilogramo de Lana de los Ovinos:");
                        sistema.PrecioPorKiloLana(PrecioPorKiloLana);
                        break;
                    /** Alta de ganado bovino. **/
                    case "4":
                        Console.Clear();

                        Sistema.Resaltar("▀▄▀▄▀▄ ALTA DE GANADO BOVINO ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                        string codigoCaravana = InputText("Ingrese Código de Caravana: ").Trim();

                        Bovino bovino = sistema.ObtenerBovinoPorCodigoCaravana(codigoCaravana);

                        if (bovino is null)
                        {
                            Sexo sexo = InputSexo();

                            string raza = InputText("Ingrese Raza: ");

                            DateTime fechaNacimiento = InputDateTime("Ingrese Fecha de nacimiento: ");

                            int costoAdquisicion = InputNumber("Ingrese Costo Adquisición: ");

                            int costoAlimentacion = InputNumber("Ingrese Costo Alimentación: ");

                            int pesoActual = InputNumber("Ingrese Peso Actual: ");

                            bool esHibrido = InputBool("¿Es Híbrido? ");

                            TipoAlimentacion tipoAlimentacion = InputTipoAlimentacion();

                            int precioPorKiloBovinoEnPie = InputNumber("Ingrese Precio Por Kilo en Pie: ");

                            sistema.AltaBovino(codigoCaravana, sexo, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, esHibrido, tipoAlimentacion, precioPorKiloBovinoEnPie);
                        }
                        else
                        {
                            Sistema.Error("Existe un Bovino con Código de Caravana Ingresado. Presione una Tecla Para Continuar. \n");
                            Console.ReadKey();
                        }

                        break;
                    case "5":
                        /** Costo de Crianza Animal **/
                        Console.Clear();

                        Sistema.Resaltar("▀▄▀▄▀▄ COSTO DE CRIANZA POR ANIMAL ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                        string codigoCaravana1 = InputText("Ingrese Código de Caravana: ").Trim();

                        TipoAnimal tipoAnimal = InputTipoAnimal();

                        if (tipoAnimal == TipoAnimal.Ovino)
                        {
                            Ovino ovino = sistema.ObtenerOvinoPorCodigoCaravana(codigoCaravana1);

                            if (ovino is not null)
                            {
                                decimal costoCrianzaAnimal = sistema.CostoCrianzaAnimal(ovino);

                                Sistema.Exito($"Costo de Crianza del {TipoAnimal.Ovino} con (Código de Caravana: {codigoCaravana1}) = ${costoCrianzaAnimal}. Presione una Tecla Para Continuar. \n");
                                Console.ReadKey();
                            }
                            else
                            {
                                Sistema.Error("No Existe un Ovino con Código de Caravana Ingresado. Presione una Tecla Para Continuar. \n");
                                Console.ReadKey();
                            }
                        }
                        else if (tipoAnimal == TipoAnimal.Bovino)
                        {
                            Bovino bovino1 = sistema.ObtenerBovinoPorCodigoCaravana(codigoCaravana1);

                            if (bovino1 is not null)
                            {
                                decimal costoCrianzaAnimal = sistema.CostoCrianzaAnimal(bovino1);

                                Sistema.Exito($"Costo de Crianza {TipoAnimal.Bovino} (Código de Caravana: {codigoCaravana1}) = {costoCrianzaAnimal}. Presione una Tecla Para Continuar. \n");
                                Console.ReadKey();
                            }
                            else
                            {
                                Sistema.Error("No Existe un Bovino con Código de Caravana Ingresado. Presione una Tecla Para Continuar. \n");
                                Console.ReadKey();
                            }
                        }

                        break;
                    case "6":
                        /** Potencial precio de venta en Ovinos **/
                        Console.Clear();

                        Sistema.Resaltar("▀▄▀▄▀▄ POTENCIAL PRECIO DE VENTA OVINOS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                        string codigoCaravana2 = InputText("Ingrese Código de Caravana: ").Trim();

                        Ovino ovino1 = sistema.ObtenerOvinoPorCodigoCaravana(codigoCaravana2);

                        if (ovino1 is not null)
                        {
                            decimal precioVentaOvino = sistema.PrecioVentaOvino(ovino1);

                            Sistema.Exito($"Potencial Precio de venta Ovino (Código de Caravana: {codigoCaravana2}) = ${precioVentaOvino}. Presione una Tecla Para Continuar. \n");
                            Console.ReadKey();
                        }
                        else
                        {
                            Sistema.Error("No Existe un Ovino con Código de Caravana Ingresado. Presione una Tecla Para Continuar. \n");
                            Console.ReadKey();
                        }

                        break;
                    case "7":
                        /** Potencial precio de venta en Bovinos **/
                        Console.Clear();

                        Sistema.Resaltar("▀▄▀▄▀▄ POTENCIAL PRECIO DE VENTA BOVINOS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                        string codigoCaravana3 = InputText("Ingrese Código de Caravana: ").Trim();

                        Bovino bovino2 = sistema.ObtenerBovinoPorCodigoCaravana(codigoCaravana3);

                        if (bovino2 is not null)
                        {
                            decimal precioVentaOvino = sistema.PrecioVentaBovino(bovino2);

                            Sistema.Exito($"Potencial Precio de venta Bovino (Código de Caravana: {codigoCaravana3}) = ${precioVentaOvino}. Presione una Tecla Para Continuar. \n");
                            Console.ReadKey();
                        }
                        else
                        {
                            Sistema.Error("No Existe un Bovino con Código de Caravana Ingresado. Presione una Tecla Para Continuar. \n");
                            Console.ReadKey();
                        }

                        break;
                    case "8":
                        /** Ganancias estimadas de la venta de un potrero **/
                        Console.Clear();

                        Sistema.Resaltar("\n ▀▄▀▄▀▄ GANANCIAS ESTIMADAS DE VENTA POR POTRERO ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                        CantidadAnimalesPorPotrero();

                        int id = InputNumber("Ingrese ID del Potrero:");

                        Potrero potrero = sistema.ObtenerPotreroPorId(id);

                        if (potrero is not null)
                        {
                            decimal ganaciaVentaPotrero = sistema.GanaciaVentaPotrero(potrero);

                            Sistema.Exito($"Ganancias Estimadas del Potrero con ID {potrero.Id}: ${ganaciaVentaPotrero}. Presione una Tecla Para Continuar. \n");
                            Console.ReadKey();
                        }
                        else
                        {
                            Sistema.Error("No Existe un Potrero con ID Ingresado. Presione una Tecla Para Continuar. \n");
                            Console.ReadKey();
                        }

                        break;
                    case "9":
                        ListarBovinos();
                        break;
                    case "10":
                        ListarOvinos();
                        break;
                    case "11":
                        ListarPotreros();
                        break;
                    case "12":
                        ListarAnimalesPorPotrero();
                        break;
                    case "13":
                        ListarVacunas();
                        break;
                    case "14":
                        ListarVacunasPorAnimal();
                        break;
                    case "15":
                        ListarCapataces();
                        break;
                    case "16":
                        ListarPeones();
                        break;
                    case "17":
                        ListarTareas();
                        break;
                    case "18":
                        ListarTareasPorPeon();
                        break;
                    case "0":
                        Sistema.Exito("Cerrando Aplicación de Consola...".ToUpper());
                        codigo = false;
                        break;
                    default:
                        Sistema.Error("Opción Inválida. Presione una Tecla Para Continuar. \n".ToUpper());
                        Console.ReadKey();
                        break;
                }
            }
        }

        #region Get; Set;
        /** Get; Set; **/
        #endregion Get; Set;

        
        #region Métodos que Listan Información
        /** Métodos para Listar Información **/
        static void CantidadAnimalesPorPotrero()
        {
            try
            {
                foreach (Potrero potrero in sistema.Potreros)
                {
                    Sistema.Resaltar($"▀▄▀▄▀▄ POTRERO ID: {potrero.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                    Sistema.Resaltar($"Total de Animales: {potrero.Animales.Count}. Capacidad Máxima: {potrero.CapacidadMaxima} \n", ConsoleColor.DarkGray);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Sistema.Error($"{ex.Message} \n");
            }
        }

        static void ListarVacunasPorAnimal()
        {
            try
            {
                Console.Clear();

                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE TAREAS POR PEÓN ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                int contador = 1;

                foreach (Animal animal in sistema.Animales)
                {
                    if (animal.Vacunaciones.Count > 0)
                    {
                        if (animal is Ovino)
                        {
                            Ovino ovino = (Ovino)animal;

                            Sistema.Resaltar($"▀▄▀▄▀▄ OVINO {ovino.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                            foreach (Vacunacion vacunacion in ovino.Vacunaciones)
                            {
                                Console.WriteLine($"➜ {vacunacion} \n");
                            }
                        }
                        else if (animal is Bovino)
                        {
                            Bovino bovino = (Bovino)animal;

                            Sistema.Resaltar($"▀▄▀▄▀▄ BOVINO {bovino.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                            foreach (Vacunacion vacunacion in bovino.Vacunaciones)
                            {
                                Console.WriteLine($"➜ {vacunacion} \n");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Vacunas por Animal Listadas con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();

        }

        static void ListarTareasPorPeon()
        {
            try
            {
                Console.Clear();

                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE TAREAS POR PEÓN ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                int contador = 1;

                foreach (Empleado empleado in sistema.Empleados)
                {
                    if (empleado is Peon)
                    {
                        Peon peon = (Peon)empleado;

                        Sistema.Resaltar($"▀▄▀▄▀▄ PEÓN {peon.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                        foreach (Tarea tarea in peon.TareasAsignadas)
                        {
                            Console.WriteLine($"➜ {tarea} \n");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Tareas por Peón Listadas con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarAnimalesPorPotrero()
        {
            try
            {
                Console.Clear();

                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE ANIMALES POR POTRERO ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                int contador = 1;

                foreach (Potrero potrero in sistema.Potreros)
                {
                    Sistema.Resaltar($"▀▄▀▄▀▄ POTRERO {potrero.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                    foreach (Animal animal in potrero.Animales)
                    {
                        if (animal is Ovino)
                        {
                            Ovino ovino = (Ovino)animal;

                            Sistema.Resaltar($"▀▄▀▄▀▄ OVINO {ovino.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkGray);

                            Console.WriteLine($"➜ {animal} \n");
                        }
                        else if (animal is Bovino)
                        {
                            Bovino bovino = (Bovino)animal;

                            Sistema.Resaltar($"▀▄▀▄▀▄ BOVINO {bovino.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkGray);

                            Console.WriteLine($"➜ {animal} \n");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Animales por Potrero Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarPotreros()
        {
            Console.Clear();

            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE POTREROS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                int contador = 1;

                foreach (Potrero potrero in sistema.Potreros)
                {
                    Sistema.Resaltar($"▀▄▀▄▀▄ POTRERO {potrero.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {potrero} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Potreros Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarVacunas()
        {
            Console.Clear();

            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE VACUNAS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                int contador = 1;

                foreach (Vacuna vacuna in sistema.Vacunas)
                {
                    Sistema.Resaltar($"▀▄▀▄▀▄ VACUNA {vacuna.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {vacuna} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Vacunas Listadas con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarAnimales()
        {
            Console.Clear();

            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE ANIMALES ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (sistema.Animales.Count == 0) throw new ArgumentOutOfRangeException("Lista de Animales Vacía. Sistema\\ListarAnimales() \n");

                int contador = 1;

                foreach (Animal animal in sistema.Animales)
                {
                    if (animal is Ovino)
                    {
                        Ovino ovino = (Ovino)animal;

                        Sistema.Resaltar($"▀▄▀▄▀▄ OVINO {ovino.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {ovino} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                    else if (animal is Bovino)
                    {
                        Bovino bovino = (Bovino)animal;

                        Sistema.Resaltar($"▀▄▀▄▀▄ BOVINO {bovino.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {bovino} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Animales Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarOvinos()
        {
            Console.Clear();

            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE OVINOS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (sistema.Animales.Count == 0) throw new ArgumentOutOfRangeException("Lista de Animales Vacía. Sistema\\ListarOvinos() \n");

                int contador = 1;

                foreach (Animal animal in sistema.Animales)
                {
                    if (animal is Ovino)
                    {
                        Ovino ovino = (Ovino)animal;

                        Sistema.Resaltar($"▀▄▀▄▀▄ OVINO {ovino.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {ovino} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Ovinos Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarBovinos()
        {
            Console.Clear();

            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE BOVINOS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (sistema.Animales.Count == 0) throw new ArgumentOutOfRangeException("Lista de Animales Vacía. Sistema\\ListarBovinos() \n");

                int contador = 1;

                foreach (Animal animal in sistema.Animales)
                {
                    if (animal is Bovino)
                    {
                        Bovino bovino = (Bovino)animal;

                        Sistema.Resaltar($"▀▄▀▄▀▄ BOVINO {bovino.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {bovino} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Bovinos Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarTareas()
        {
            Console.Clear();

            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE TAREAS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (sistema.Tareas.Count == 0) throw new ArgumentOutOfRangeException("Lista de Tareas Vacía. Sistema\\ListarTareas() \n");

                int contador = 1;

                foreach (Tarea tarea in sistema.Tareas)
                {
                    Sistema.Resaltar($"▀▄▀▄▀▄ TAREA {tarea.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {tarea} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Tareas Listadas con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarCapataces()
        {
            Console.Clear();

            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE CAPATACES ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (sistema.Empleados.Count == 0) throw new ArgumentOutOfRangeException("Lista de Empleados Vacía. Sistema\\ListarCapataces() \n");

                int contador = 1;

                foreach (Empleado empleado in sistema.Empleados)
                {
                    if (empleado is Capataz)
                    {
                        Capataz capataz = (Capataz)empleado;

                        Sistema.Resaltar($"▀▄▀▄▀▄ CAPATAZ {capataz.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {capataz} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Capataces Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarPeones()
        {
            Console.Clear();

            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE PEONES ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (sistema.Empleados.Count == 0) throw new ArgumentOutOfRangeException("Lista de Empleados Vacía. Sistema\\ListarPeones() \n");

                int contador = 1;

                foreach (Empleado empleado in sistema.Empleados)
                {
                    if (empleado is Peon)
                    {
                        Peon peon = (Peon)empleado;

                        Sistema.Resaltar($"▀▄▀▄▀▄ PEÓN {peon.Id} ▄▀▄▀▄▀ \n", ConsoleColor.DarkBlue);

                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {peon} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("peones Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }
        #endregion Métodos que Listan Información

        #region Métodos Globales
        /** Métodos Globales **/
        static void SaltoDeLinea()
        {
            Console.WriteLine();
            return;
        }

        static bool InputBool(string mensaje)
        {
            bool exito = false;
            bool input = false;

            while (!exito)
            {
                try
                {
                    Sistema.Resaltar($"{mensaje} (S/N) \n", ConsoleColor.DarkBlue);
                    string inputString = Console.ReadLine().ToUpper();

                    if (inputString.Length != 1) throw new ArgumentOutOfRangeException("Cantidad de Dígitos Superior a la Esperada. Ingrese S o N. Program\\(string mensaje)");

                    switch (inputString)
                    {
                        case "S":
                            input = true;
                            exito = true;
                            break;
                        case "N":
                            input = false;
                            exito = true;
                            break;
                        default:
                            throw new ArgumentException("Opción Inválida. Program\\(string mensaje) \n");
                    }
                }
                catch (Exception ex)
                {
                    SaltoDeLinea();
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return input;
        }

        static DateTime InputDateTime(string mensaje)
        {
            bool exito = false;
            DateTime dateTime = DateTime.Now;

            while (!exito)
            {
                try
                {
                    Sistema.Resaltar($"{mensaje} (Day/Month/Year): \n", ConsoleColor.DarkBlue);

                    exito = DateTime.TryParse(Console.ReadLine(), out dateTime);

                    if (!exito) throw new ArgumentException("Formato de Fecha Incorrecto. Program\\InputDateTime(string mensaje)");
                }
                catch (Exception ex)
                {
                    SaltoDeLinea();
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return dateTime;
        }

        static TipoAnimal InputTipoAnimal()
        {
            bool exito = false;
            TipoAnimal tipoAnimal = new TipoAnimal();

            while (!exito)
            {
                try
                {
                    Sistema.Resaltar("Seleccione Tipo de Animal: \n", ConsoleColor.DarkBlue);

                    foreach (int numero in Enum.GetValues(typeof(TipoAnimal)))
                    {
                        Sistema.Resaltar($"{numero} ➟ {(TipoAnimal)numero} \n", ConsoleColor.DarkBlue);
                    }

                    string inputString = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputString)) throw new ArgumentException("String Vacío. Program\\TipoAnimal()");

                    bool isNumber = int.TryParse(inputString, out int number);

                    if (isNumber && Enum.IsDefined(typeof(TipoAnimal), number))
                    {
                        tipoAnimal = (TipoAnimal)number;
                        exito = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Opción Inválida. Program\\TipoAnimal()");
                    }
                }
                catch (Exception ex)
                {
                    SaltoDeLinea();
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return tipoAnimal;
        }

        static TipoAlimentacion InputTipoAlimentacion()
        {
            bool exito = false;
            TipoAlimentacion tipoAlimentacion = new TipoAlimentacion();

            while (!exito)
            {
                try
                {
                    Sistema.Resaltar("Seleccione Tipo de Alimentación: \n", ConsoleColor.DarkBlue);

                    foreach (int numero in Enum.GetValues(typeof(TipoAlimentacion)))
                    {
                        Sistema.Resaltar($"{numero} ➟ {(TipoAlimentacion)numero} \n", ConsoleColor.DarkBlue);
                    }

                    string inputString = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputString)) throw new ArgumentException("String Vacío. Program\\InputTipoAlimentacion()");

                    bool isNumber = int.TryParse(inputString, out int number);

                    if (isNumber && Enum.IsDefined(typeof(TipoAlimentacion), number))
                    {
                        tipoAlimentacion = (TipoAlimentacion)number;
                        exito = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Opción Inválida. Program\\InputTipoAlimentacion()");
                    }
                }
                catch (Exception ex)
                {
                    SaltoDeLinea();
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return tipoAlimentacion;
        }

        static Sexo InputSexo()
        {
            bool exito = false;
            Sexo sexo = new Sexo();

            while (!exito)
            {
                try
                {
                    Sistema.Resaltar("Seleccione Sexo del Animal: \n", ConsoleColor.DarkBlue);

                    foreach (int numero in Enum.GetValues(typeof(Sexo)))
                    {
                        Sistema.Resaltar($"{numero} ➟ {(Sexo)numero} \n", ConsoleColor.DarkBlue);
                    }

                    string inputString = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputString)) throw new ArgumentException("String Vacío. Program\\InputSexo()");

                    bool isNumber = int.TryParse(inputString, out int number);

                    if (isNumber && Enum.IsDefined(typeof(Sexo), number))
                    {
                        sexo = (Sexo)number;
                        exito = true;
                    }
                    else
                    {
                        SaltoDeLinea();
                        throw new ArgumentOutOfRangeException("Opción Inválida. Program\\InputSexo(string mensaje)");
                    }
                }
                catch (Exception ex)
                {
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return sexo;
        }

        static int InputNumber(string mensaje)
        {
            bool exito = false;
            int inputNumero = 0;
            bool isNumber = false;

            while (!exito)
            {
                try
                {
                    Sistema.Resaltar($"{mensaje} \n", ConsoleColor.DarkBlue);

                    isNumber = int.TryParse(Console.ReadLine(), out inputNumero);

                    if (!isNumber || inputNumero <= 0) throw new ArgumentOutOfRangeException("Número Incorrecto. Program\\InputText(string mensaje)");

                    exito = true;
                }
                catch (Exception ex)
                {
                    SaltoDeLinea();
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return inputNumero;
        }

        static string InputText(string mensaje)
        {
            bool exito = false;
            string? inputText = string.Empty;


            while (!exito)
            {
                try
                {
                    Sistema.Resaltar($"{mensaje} \n", ConsoleColor.DarkBlue);

                    inputText = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputText)) throw new ArgumentException("InputText Vacío. InputString(string mensaje)");

                    exito = true;
                }
                catch (Exception ex)
                {
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return inputText;
        }

        static void Menu()
        {
            Sistema.Resaltar("➡︎ 1 ➔ Listado de Todos los Animales \n".ToUpper(), ConsoleColor.DarkCyan);
            Sistema.Resaltar("➡︎ 2 ➔ Listado de Potreros con Área Mayor a Cantidad de Hectáreas Proporcionada y Capacidad Máxima Superior al Número Dado \n".ToUpper(), ConsoleColor.DarkCyan);
            Sistema.Resaltar("➡︎ 3 ➔ Establecer el Precio por Kilogramo de Lana de los Ovinos \n".ToUpper(), ConsoleColor.DarkCyan);
            Sistema.Resaltar("➡︎ 4 ➔ Alta de Ganado Bovino \n".ToUpper(), ConsoleColor.DarkCyan);
            Sistema.Resaltar("➡︎ 5 ➔ Costo de Crianza por Animal \n".ToUpper(), ConsoleColor.DarkCyan);
            Sistema.Resaltar("➡︎ 6 ➔ Potencial Precio de Venta Ovino \n".ToUpper(), ConsoleColor.DarkCyan);
            Sistema.Resaltar("➡︎ 7 ➔ Potencial Precio de Venta Bovino \n".ToUpper(), ConsoleColor.DarkCyan);
            Sistema.Resaltar("➡︎ 8 ➔ Ganancias Estimadas de Venta por Potrero \n".ToUpper(), ConsoleColor.DarkCyan);
            Console.WriteLine("➡︎ 9 ➔ Listar Ganado Bovino \n".ToUpper());
            Console.WriteLine("➡︎ 10 ➔ Listar Ganado Ovino \n".ToUpper());
            Console.WriteLine("➡︎ 11 ➔ Listar Potreros \n".ToUpper());
            Console.WriteLine("➡︎ 12 ➔ Listar Animales por Potrero \n".ToUpper());
            Console.WriteLine("➡︎ 13 ➔ Listar Vacunas \n".ToUpper());
            Console.WriteLine("➡︎ 14 ➔ Listar Vacunas por Animal \n".ToUpper());
            Console.WriteLine("➡︎ 15 ➔ Listar Capataces \n".ToUpper());
            Console.WriteLine("➡︎ 16 ➔ Listar Peones \n".ToUpper());
            Console.WriteLine("➡︎ 17 ➔ Listar Tareas \n".ToUpper());
            Console.WriteLine("➡︎ 18 ➔ Listar Tareas Por Peón \n".ToUpper());
            Console.WriteLine("➡︎ 0 ➔ Salir \n".ToUpper());
        }

        static void Bienvenida()
        {
            Console.Clear();
            SaltoDeLinea();

            Sistema.Resaltar("🐄 🐑 ▁ ▂ ▄ ▅ ▆ ▇ █ ESTANCIA █ ▇ ▆ ▅ ▄ ▂ ▁ 🐑 🐄", ConsoleColor.DarkGreen);
            Sistema.Resaltar("░▒▓█ Compra y Engorde de Bovinos y Ovinos █▓▒░".ToUpper(), ConsoleColor.DarkGreen);
            Console.WriteLine();
            Sistema.Resaltar("◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠ MENÚ ◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠", ConsoleColor.DarkYellow);
            Console.WriteLine();
        }
        #endregion Métodos Globales
    }
}
