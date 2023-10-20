using System;
/** 
 * Autor: Raúl Fernando Medina Sandoval
 * Fecha de Creación: 12/10/2023 
 * Descripción: Representa a un pasajero que viaja en un tren. Cada pasajero tiene un identificador único y un nombre.
 **/
public class Pasajero
{
	public int id { get; private set; }
	public string nombre { get; private set; }

	public Pasajero(int id, string nombre)
	{
		this.id = id;
		this.nombre = nombre;
	}

	
	 public override string ToString()
	{
		return "{\"id\":\"" + id + "\"" +
			   ",\"nombre\":\"" + nombre + "\"}";
	}
}
