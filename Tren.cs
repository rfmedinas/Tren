using System;
using System.Collections.Generic;


/** 
 * Autor: Raúl Fernando Medina Sandoval
 * Fecha de Creación: 13/10/2023 
 * Descripción: Representa un tren, con un número determinado de sillas, divididas en clases económica y ejecutiva. 
 **/
public class Tren
{
	private int id;
	private List<Silla> sillas = new List<Silla>();
	private List<Reserva> reservas = new List<Reserva>();
	private int numEconomicas = 80;
	private int numEjecutivas = 20;
	private int numSillasFila = 4;
	private Persona conductor;

	public Tren(int id)
	{
		this.id = id;
		CrearSilla(ClaseSilla.EJECUTIVA);
		CrearSilla(ClaseSilla.ECONOMICA);
	}

	public List<Silla> GetSillas()
	{
		return sillas;
	}

	public void SetSillas(List<Silla> sillas)
	{
		this.sillas = sillas;
	}

	public List<Reserva> GetReservas()
	{
		return reservas;
	}

	public void SetReservas(List<Reserva> reservas)
	{
		this.reservas = reservas;
	}
	public Persona GetConductor()
	{
		return conductor;
	}

	public void SetConductor( Persona conductor)
	{
		this.conductor = conductor;
	}
	/**
	 *Descripcion: Método que crea  el listado de silla  para un tren teniendo en cuenta la Clase  
	 **/
	private void CrearSilla(ClaseSilla claseSilla)
	{
		int numSillas = claseSilla == ClaseSilla.ECONOMICA ? numEconomicas : numEjecutivas;
		for (int i = 0; i < numSillas; i++)
		{
			int fila = (i / numSillasFila) + 1;
			int posicion = i % numSillasFila;
			string posicionFila = $"{fila}-{(char)(posicion + 65)}";
			PosicionSilla posicionSilla = i % 2 == 0 ? PosicionSilla.VENTANA : PosicionSilla.PASILLO;
			Silla silla = new Silla(posicionFila, claseSilla, posicionSilla, fila);
			sillas.Add(silla);
		}
	}
	/**
	 *Descripcion: Se utiliza para calcular la ocupación del tren. El método devuelve un valor entre 0 y 1, donde 0 representa una ocupación del 0% y 1 representa una ocupación del 100%. 
	 **/
	public double CalcularOcupacion()
	{
		double numOcupadas = 0.0;
		if (sillas.Count == 0)
		{
			return 0.0;
		}
		foreach (Silla silla in sillas)
		{
			if (silla.ocupada)
			{
				numOcupadas += 1;
			}
		}
		return numOcupadas / sillas.Count;
	}
	/**
	 *Descripcion: Se utiliza para crear una reserva para un pasajero en una silla determinada. El método acepta los siguientes parámetros: idSilla: Identificador de la silla.
                  * idPasajero: Identificador del pasajero
 	 **/
	public Reserva? CrearReserva(Pasajero pasajero, ClaseSilla claseSilla, PosicionSilla posicionSilla)
	{
		foreach (Reserva reserva in reservas)
		{
			if (reserva.pasajero != null && reserva.pasajero.id == pasajero.id)
			{
				throw new Exception("El pasajero ya tiene una reserva");
			}
		}

		foreach (Silla silla in sillas)
		{
			if (silla.posicionSilla == posicionSilla && silla.claseSilla == claseSilla && !silla.ocupada)
			{
				Reserva nuevaReserva = new Reserva(pasajero, silla);
				silla.ocupada = true;
				reservas.Add(nuevaReserva);
				return nuevaReserva;
			}
		}
		return null;
	}
	/**
	 *Descripcion: Se utiliza para eliminar una reserva de una silla determinada. El método acepta el siguiente parámetro:
	 			* idSilla: Identificador de la silla.
 	 **/
	public void EliminarReserva(Pasajero pasajero)
	{
		Reserva? reservaEliminar = null;
		foreach (Reserva reserva in reservas)
		{
			if (reserva.pasajero != null && reserva.pasajero.id == pasajero.id)
			{
				reservaEliminar = reserva;
				break;
			}
		}

		if (reservaEliminar != null)
		{
			reservaEliminar.silla.ocupada = false;
			reservas.Remove(reservaEliminar);
		}
		else
		{
			throw new Exception("El pasajero no tiene Reserva");
		}
	}
	/**
	* Descripcion: Se utiliza para buscar un pasajero en una silla determinada. El método acepta el siguiente parámetro:
				* idPasajero: Identificador del pasajero.
 	 **/
	public Reserva BuscarPasajero(int id)
	{
		foreach (Reserva reserva in reservas)
		{
			if (reserva.pasajero != null && reserva.pasajero.id == id)
			{
				return reserva;
			}
		}
		throw new Exception("El pasajero no tiene Reserva");
	}
	/**
	* Descripcion: Se utiliza para consultar una reserva  devuelve cedula, nombre del pasajero y  silla Asignada. El método acepta el siguiente parámetro: id del pasajero idPasajero: Identificador del pasajero.
 	 **/
	public Reserva ConsultarReserva(string id)
	{
		foreach (Reserva reserva in reservas)
		{
			if (reserva.id.ToString() == id)
			{
				return reserva;
			}
		}
		throw new Exception("No Existe la reserva Consultada");
	}


	public override string ToString()
  {
		
		return 
			   "{\"id\":\"" + id + "\"," +
			   "\"conductor\":\"" + conductor + "\"," +
			   "\"numEconomicas\":\"" + numEconomicas + "\"," +
			   "\"numEjecutivas\":\"" + numEjecutivas + "\"," +
			   "\"numSillasFila\":\"" + numSillasFila + "\"," +
			   "\"ocupacion\":\"" + CalcularOcupacion() * 100 + "%\"," +
			   "\"Sillas\":\"" + string.Join(",", sillas) + "\"," +
			   "\"Reservas\":\"" + string.Join(",", reservas) + "\"" +
			   
			   "}";

	}
}
