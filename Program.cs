// See https://aka.ms/new-console-template for more information
using System;


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
				case 1:
					Console.WriteLine(tren);
					Console.WriteLine(tren.CalcularOcupacion());
					break;
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
				case 3:
					Console.WriteLine("Ingrese el ID del pasajero a eliminar:");
					if (int.TryParse(Console.ReadLine(), out int idPasajeroEliminar))
					{
						try
						{
							tren.EliminarReserva(idPasajeroEliminar);
							Console.WriteLine($"Reserva del pasajero con ID {idPasajeroEliminar} eliminada con éxito.");
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
						Console.WriteLine("ID inválido. Intente nuevamente.");
					}
					break;
				case 5:
					Console.WriteLine("Saliendo del programa...");
					break;
				default:
					Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
					break;
			}

		} while (opcion != 5);
	}

	public static int MostrarMenu()
	{
		Console.WriteLine("Seleccione una opción:");
		Console.WriteLine("1. Mostrar información del tren y ocupación.");
		Console.WriteLine("2. Crear reserva.");
		Console.WriteLine("3. Eliminar reserva.");
		Console.WriteLine("4. Buscar pasajero");
		Console.WriteLine("5. Salir.");

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