// See https://aka.ms/new-console-template for more information
using System;

/** 
 * Autor: Raúl Fernando Medina Sandoval
 * Fecha de Creación: 22/10/2023 
 * Fecha de Modificacion: 23/10/2023
 ** Descripción:Programa que administra las reservas de un sistema de transporte ferreos. 
 **  permite a los usuarios realizar varias operaciones relacionadas con reservas sillas en un tren a los pasajeros
  **/
public class Program
{
	public static void Main(string[] args)
	{
		Tren tren = new Tren(1);
		tren.SetConductor(new Persona(99999, "Juan Perez"));
		int opcion;

		do
		{
			opcion = MostrarMenu();

			switch (opcion)
			{
                /** 
				 ** Case 1 Imprime la información del tren y calcula y muestra el porcentaje de ocupación del tren
				  **/
                case 1:
					Console.WriteLine(tren);
					Console.WriteLine($"El porcentaje de Ocupación es {tren.CalcularOcupacion() *100 } %");
                    //Console.WriteLine(tren.CalcularOcupacion());
					;
					break;
                /** 
				 ** Case 2 Solicita al usuario información para crear una nueva reserva y la crea en el tren.
				 ** Maneja excepciones si hay errores en la creación de la reserva.
				 **/
                case 2:
					Console.WriteLine("Ingrese el ID del pasajero:");
					if (int.TryParse(Console.ReadLine(), out int idPasajero) && idPasajero > 0)
					{
						Console.WriteLine("Ingrese el nombre del pasajero:");
						string nombrePasajero = Console.ReadLine();
						Pasajero nuevoPasajero = new Pasajero(idPasajero, nombrePasajero);
						try
						{
							Reserva reserva = tren.CrearReserva(nuevoPasajero, ClaseSilla.EJECUTIVA, PosicionSilla.PASILLO);
							Console.WriteLine($"La reserva Asignada es :{reserva}");
						}
						catch (Exception e)
						{
							Console.WriteLine($"Error: {e.Message}");
						}
					}
					else
					{
						Console.WriteLine("ID inválido. Intente nuevamente.");
					}
					break;
                /** 
				 ** Case 3 Solicita al usuario el ID del pasajero y elimina la reserva correspondiente en el tren.
				 **  Muestra el listado de reservas después de la eliminación.
				 **/
                case 3:
					Console.WriteLine("Ingrese el ID del pasajero a eliminar:");
					if (int.TryParse(Console.ReadLine(), out int idPasajeroEliminar))
					{
						try
						{
							tren.EliminarReserva(idPasajeroEliminar);
							Console.WriteLine($"Reserva del pasajero con ID {idPasajeroEliminar} eliminada con éxito.");
                            Console.WriteLine("El Listado de reservas es");
                            Console.WriteLine(String.Join(",", tren.GetReservas()));
						}
						catch (Exception e)
						{
							Console.WriteLine($"Error: {e.Message}");
						}
					}
					else
					{
						Console.WriteLine("ID inválido. Intente nuevamente.");
					}
					break;
                /** 
				 ** Case 4 Solicita al usuario el ID del pasajero y busca la reserva correspondiente en el tren.
				 **  Muestra la información de la reserva encontrada o maneja excepciones si no se encuentra.
				 **/
                case 4:
					Console.WriteLine("Ingrese el ID del pasajero a buscar:");
					if (int.TryParse(Console.ReadLine(), out int idPasajeroBuscar))
					{
						try
						{
							Reserva reservaEncontrada = tren.BuscarPasajero(idPasajeroBuscar);
							Console.WriteLine(reservaEncontrada);
						}
						catch (Exception e)
						{
							Console.WriteLine($"Error: {e.Message}");
						}
					}
					else
					{
						Console.WriteLine("ID inválido.Intente nuevamente.");
					}
					break;
                /** 
				 ** Case 5 Imprime el porcentaje de ocupación actual del tren.
				**/
                case 5:
                    
                    Console.WriteLine($"El porcentaje de Ocupación es {tren.CalcularOcupacion() * 100} %");
                    
                    ;
                    break;
                /** 
				 ** Case 6 Imprime el listado completo de todas las reservas existentes en el tren.
				**/
                case 6:
                    Console.WriteLine("El Listado de reservas es");
                    Console.WriteLine(String.Join(",", tren.GetReservas()));

                    ;
                    break;
                /** 
                   ** Case 7 Imprime un mensaje de despedida y termina el programa.
                  **/
                case 7:
					Console.WriteLine("Saliendo del programa...");
					break;
				default:
					Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
					break;
			}

		} while (opcion != 7);
	}
    /** 
     ** Imprime las opciones del menú al usuario y solicita la entrada  para seleccionar una opción
     **/
    public static int MostrarMenu()
	{

		Console.WriteLine("Seleccione una opción:");
		Console.WriteLine("1. Mostrar información del tren y ocupación.");
		Console.WriteLine("2. Crear reserva.");
		Console.WriteLine("3. Eliminar reserva.");
		Console.WriteLine("4. Buscar pasajero");
        Console.WriteLine("5. Consultar Ocupación del Tren");
        Console.WriteLine("6. Listado de Reservas");
        Console.WriteLine("7. Salir.");

		if (int.TryParse(Console.ReadLine(), out int opcion))
		{
			return opcion;
		}
		else
		{
			return -1; // Valor inválido
		}
	}
}