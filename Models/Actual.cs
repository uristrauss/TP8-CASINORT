using System;
using System.Collections.Generic;
namespace TP8.Models;

public static class Actual
{

    private static int _idJugador;
    private static string _username;
    private static DateTime _fechaNacimiento;
    private static int _puntajeActual;
    private static string _fotoJugador;
    private static string _nombre;    
    private static int _num1, _num2, _num3, _num4, _num5;
    private static int _puntblack = 0;
    

    public static int IdJugador
          {
            get
            {
                return _idJugador;
            }
            set{
                _idJugador = value;
            }

          }

    public static string Username 
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

    public static DateTime FechaNacimiento 
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

    public static int PuntajeActual 
    {
        get
        {
            return _puntajeActual;
        }
        set{
            _puntajeActual = value;
        }
    }

    public static string FotoJugador 
    {
        get
        {
            return _fotoJugador;
        }
        set{
            _fotoJugador = value;
        }
    }

    public static string Nombre
    {
        get
        {
            return _nombre;
        }
        set
        {
            _nombre = value;
        }

    }

    public static int Num1{
        get{return _num1;}
        set{_num1 = value;}
    }
    public static int Num2{
        get{return _num2;}
        set{_num2 = value;}
    }

    public static int Num3{
        get{return _num3;}
        set{_num3 = value;}
    }

    public static int Num4{
        get{return _num4;}
        set{_num4 = value;}
    }

    public static int Num5{
        get{return _num5;}
        set{_num5 = value;}
    }

    public static int Puntblack
    {
        get
        {
            return _puntblack;
        }
        set
        {
            _puntblack = value;
        }

    }




}