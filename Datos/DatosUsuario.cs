using ApiRestIPSPROAA.Conexion;
using ApiRestIPSPROAA.Modelos;
using System.Data.SqlClient;

namespace ApiRestIPSPROAA.Datos
{
    public class DatosUsuario
    {
        Conexionbd cn = new Conexionbd();
        public async Task<List<Usuario>> MostrarUsuarios()
        {
            var lista = new List<Usuario>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("MostrarUsuarios", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var usu = new Usuario();
                            usu.Id = (int)item["IDUSUARIO"];
                            usu.Nombre = (string)item["NOMBREUSUARIO"];
                            usu.Clave = (string)item["CLAVE"];
                            usu.Estado = (Boolean)item["ESTADO"];
                            usu.Cargo = new Cargo();
                            usu.Cargo.Id = (int)item["IDCARGO"];
                            usu.Cargo.Nombre = (string)item["NOMBRECARGO"];
                            lista.Add(usu);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
