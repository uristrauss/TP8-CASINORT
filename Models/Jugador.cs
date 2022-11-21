using System;
using System.Collections.Generic;
namespace TP8.Models;

public class Jugador
{

    private int _idJugador;
    private string _username;
    private DateTime _fechaNacimiento;
    private int _puntajeActual;
    private string _fotoJugador;
    private string _fkpais;
    


    public int IdJugador
          {
            get
            {
                return _idJugador;
            }
            set{
                _idJugador = value;
            }

          }

    public string Username 
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
        }
    }

    public DateTime FechaNacimiento 
    {
        get
        {
            return _fechaNacimiento;
        }
        set
        {
            _fechaNacimiento = value;
        }
    }

    public int PuntajeActual 
    {
        get
        {
            return _puntajeActual;
        }
        set{
            _puntajeActual = value;
        }
    }

    public string FotoJugador 
    {
        get
        {
            return _fotoJugador;
        }
        set{
            _fotoJugador = value;
        }
    }

    public string FkPais 
    {
        get
        {
            return _fkpais;
        }
        set{
            _fkpais = value;
        }
    }




}