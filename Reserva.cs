using System;
/** 
 * Autor: Raúl Fernando Medina Sandoval
 * Fecha de Creación: 12/10/2023 
 * Descripción: Representa la reserva de una silla realizada por un pasajero en un tren. Cada reserva  tiene un identificador único, una silla y  un pasajero asociado.
 **/
public class Reserva
{
	public Guid id { get; private set; }
	public Pasajero pasajero { get; set; }
	public Silla silla { get; set; }

	public Reserva(Pasajero pasajero, Silla silla)
	{
		this.id = Guid.NewGuid();
		this.pasajero = pasajero;
		this.silla = silla;
	}

	public override string ToString()
	{
		return "{" +
			   "\"id\":\""+id+"\"," +
			   "\"pasajero\":"+pasajero+"," +
			   "\"silla\":"+silla+"" +
			   "}";
	}
}
