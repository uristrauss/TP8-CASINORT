using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
namespace TP8.Models;

public class BD {

    private static string _connectionString =  @"Server=LAPTOP-RCUGHBAB\SQLEXPRESS;DataBase=CASINORT;Trusted_Connection=True;";


    public static void AgregarJugador(string Username, DateTime FechaNacimiento, string FotoJugador, int FkPais)
    {
        string SQL = "INSERT INTO Jugador (Username, FechaNacimiento, PuntajeActual, FotoJugador, FkPais) VALUES (@jUsername, @jFechaNacimiento, 100, @jFotoJugador, @jFkPais) ALTER TABLE Jugador ADD UNIQUE (Username)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(SQL, new {jUsername = Username, jFechaNacimiento = FechaNacimiento, jFotoJugador = FotoJugador, jFkPais = FkPais});
        }
    }

    public static void EliminarJugador(int IdJugador){
        string sql = "DELETE FROM Jugador WHERE IdJugador = @jId";
        using(SqlConnection db = new SqlConnection(_connectionString)){            
            db.Execute(sql, new { jId = IdJugador});
        }
    }

    public static Jugador VerInfoJugador(int IdJugador)
    {
        Jugador jugador = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sqlQuery = "SELECT * FROM Jugador WHERE IdJugador = @jId";
            jugador = db.QueryFirstOrDefault<Jugador>(sqlQuery, new{jId=IdJugador});
        }
        return jugador;
    }

    public static List<Jugador> ListarJugadores(){
        List<Jugador> ListaJugadores = new List<Jugador>();
        string sql = "SELECT TOP 5 * FROM Jugador inner join Pais on Pais.IdPais = Jugador.FkPais ORDER BY Jugador.PuntajeActual DESC";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            ListaJugadores = db.Query<Jugador>(sql).ToList();
        }
        return ListaJugadores;
    }

    public static List<Pais> ListarPaises(){
        List<Pais> ListaPaises = new List<Pais>();
        string sql = "SELECT * FROM Pais";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            ListaPaises = db.Query<Pais>(sql).ToList();
        }
        return ListaPaises;
    }


    public static Jugador Actualizar(string Username, int PuntajeActual)
    {
        Jugador jugador = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sqlQuery = "UPDATE Jugador SET PuntajeActual = @jPuntajeActual WHERE Username = @jUsername";
            jugador = db.QueryFirstOrDefault<Jugador>(sqlQuery, new{jPuntajeActual=PuntajeActual, jUsername=Username});
        }
        return jugador;
    }

    public static string TraerPais(string Username)
    {
        string Nombre = "";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sqlQuery = "SELECT Pais.Nombre FROM Pais inner join Jugador on Pais.IdPais = Jugador.FkPais WHERE Username = @jUsername ";
            Nombre = db.QueryFirstOrDefault<string>(sqlQuery, new{jUsername=Username});
        }
        return Nombre;
    }
    



    




}