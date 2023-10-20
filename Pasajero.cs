using System;

/** 
* Autor: Raúl Fernando Medina Sandoval
* Fecha de Creación: 12/10/2023 
* Descripción: Representa a un pasajero que viaja en un tren. Cada pasajero tiene un identificador único y un nombre.
**/
public class Pasajero : Persona
    {	
		public Pasajero(int id, string nombre)
		: base(id, nombre)
	{

		
	}
	public Pasajero(Persona persona)
	: base(persona.id, persona.nombre)
	{


	}
}
