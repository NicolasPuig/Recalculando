using System;
using System.Collections;
using System.Collections.Generic;

namespace Version1
{
    public class Tag
    {
        private string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombre = value;
                }
            }
        }
        public List<Atributos> Atributos { get; set; }
        public Tag(string nombre, List<Atributos> atributos)
        {
            this.Nombre = nombre;
            this.Atributos = atributos;
        }

        // Metodo que imprime todos los atributos de un tag.
        public string RetornarAtributos()
        {
            string atributos = "";
            foreach (Atributos Atr in this.Atributos)
            {
                atributos += Atr.Clave + "=" + Atr.Valor + "\n";
            }
            return atributos;
        }
    }
}