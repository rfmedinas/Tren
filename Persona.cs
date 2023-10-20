using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class Persona
    {
		public int id { get; private set; }
		public string nombre { get; private set; }

		public Persona(int id, string nombre)
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

