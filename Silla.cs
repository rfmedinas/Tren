using System;
/** 
 * Autor: Raúl Fernando Medina Sandoval
 * Fecha de Creación: 12/10/2023 
 * Descripción: Representa una silla en un tren. Cada silla tiene un identificador único, una clase, una posición y un estado  para determinar si  está disponible o reservada 
 **/
public class Silla
{
	public string id { get; private set; }
	public ClaseSilla claseSilla { get; private set; }
	public PosicionSilla posicionSilla { get; private set; }
	public bool ocupada { get; set; }
	public int fila { get; private set; }

	public Silla(string id, ClaseSilla claseSilla, PosicionSilla posicionSilla, int fila)
	{
		this.id = id;
		this.claseSilla = claseSilla;
		this.posicionSilla = posicionSilla;
		this.fila = fila;
		this.ocupada = false;
	}

    public override string ToString() => "{" +
               "\"id\":\""+id+"\"," +
               "\"claseSilla\":\""+claseSilla+"\"," +
               "\"posicionSilla\":\""+posicionSilla+"\"," +
               "\"ocupada\":"+ocupada+"," +
               "\"fila\":\""+fila+"\"" +
               "}";
}
