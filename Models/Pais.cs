using System;
using System.Collections.Generic;
namespace TP8.Models;

public class Pais
{

    private int _idpais;
    private string _nombre;



            public int IdPais
          {
            get
            {
                return _idpais;
            }
            set{
                _idpais = value;
            }

          }

            public string Nombre
          {
            get
            {
                return _nombre;
            }
            set{
                _nombre = value;
            }

          }

}