using System.Data.SqlClient;
using Dapper;
public static class BD
{
    private static string connectionString = @"Server=localhost;DataBase=Elecciones 2023;Trusted_Connection=True;";
    public static void agregarCandidato(Candidato can)
    {
        string SQL = "INSERT INTO Candidato(IdPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES(@pIdPartido, @pApellido, @pNombre, @pFechaNacimiento , @pFoto , @pPostulacion)";
        using (SqlConnection db = new SqlConnection(connectionString))
        {
           db.Execute(SQL, new{pIdPartido=can.IdPartido, pApellido = can.Apellido, pNombre = can.Nombre, pFechaNacimiento = can.FechaNacimiento, pFoto = can.Foto, pPostulacion = can.Postulacion});
        }
       
    }
    public static void eliminarCandidato(int idCandidato)
    {
        string SQL = "DELETE FROM Candidato WHERE IdCandidato = @ID";
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            db.Execute(SQL, new{ID = idCandidato});
        }
    }
    
    public static Partido VerInfoPartido(int idPartido)
    {
        Partido Info = new Partido();
        string SQL = "SELECT * FROM Partido WHERE IdPartido = @idPart";
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            Info = db.QueryFirstOrDefault<Partido>(SQL, new{idPart = idPartido});
        }
        return Info;
    }
    public static Candidato VerInfoCandidato(int idCandidato)
    {
        Candidato InfoCandidato = new Candidato();
        string SQL = "SELECT * FROM Candidato WHERE IdCandidato = @idCan";
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            InfoCandidato = db.QueryFirstOrDefault(SQL, new{idCan = idCandidato});
        }
        return InfoCandidato;
    }
    public static List<Partido> ListarPartidos()
    {
        List<Partido> ListaPartidos = new List<Partido>();
        string SQL = "SELECT * FROM Partido";
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            ListaPartidos = db.Query<Partido>(SQL).ToList();
        }
        return ListaPartidos;
    }
      public static List<Candidato> ListarCandidatos(int idPartido)
    {
        List<Candidato> ListaCandidatos = new List<Candidato>();
        string SQL = "SELECT * FROM Candidato WHERE IdPartido = @idPart";
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            ListaCandidatos = db.Query<Candidato>(SQL, new{idPart = idPartido}).ToList();
        }
        return ListaCandidatos;
    }
    
}