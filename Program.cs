// See https://aka.ms/new-console-template for more information
using System;


public class Program
{
	public static void Main(string[] args)
	{
		Tren tren = new Tren(1);
		Console.WriteLine(tren);
		Console.WriteLine(tren.CalcularOcupacion());
		Pasajero raul = new Pasajero(1, "Raúl Medina");
		try
		{
			Reserva reserva = tren.CrearReserva(pasajero: raul, ClaseSilla.EJECUTIVA, PosicionSilla.PASILLO);
			Console.WriteLine($"La reserva Asignada es :{reserva}");
		}
		catch (Exception e)
		{
			Console.WriteLine("error");
			throw new Exception(e.Message);
		}

		Pasajero jose = new Pasajero(2, "Jose Gomez");
		try
		{
			Reserva reserva = tren.CrearReserva(jose, ClaseSilla.EJECUTIVA, PosicionSilla.VENTANA);
			Console.WriteLine($"La reserva Asignada es :{reserva}");
		}
		catch (Exception e)
		{
			Console.WriteLine("error");
			throw new Exception(e.Message);
		}

		Console.WriteLine(tren.CalcularOcupacion());

		try
		{
			//tren.EliminarReserva(raul);
			Console.WriteLine("El Listado de reservas es");
			//tren.GetReservas().ToList().ForEach(Console.WriteLine);					
			Console.WriteLine(String.Join(",", tren.GetReservas()));
		}
		catch (Exception e)
		{
			throw new Exception(e.Message);
		}

		Console.WriteLine(tren.CalcularOcupacion());

		Pasajero angela = new Pasajero(3, "Angela Pedraza");
		try
		{
			Reserva reserva = tren.CrearReserva(angela, ClaseSilla.EJECUTIVA, PosicionSilla.VENTANA);
			Console.WriteLine($"La Reserva Asignada es :{reserva}");
		}
		catch (Exception e)
		{
			Console.WriteLine("error");
			throw new Exception(e.Message);
		}

		Console.WriteLine(tren);
		try
		{
			Reserva reservaEncontrada = tren.BuscarPasajero(2);
			Console.WriteLine(reservaEncontrada);
			reservaEncontrada = tren.ConsultarReserva(reservaEncontrada.id.ToString());
			Console.WriteLine(reservaEncontrada);
		}
		catch (Exception e)
		{
			throw new Exception(e.Message);
		}
	}
}