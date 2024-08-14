using APiExamen.Entities;
using APiExamen.Repository.Interface;
using System.Data.SqlClient;


namespace APiExamen.Repository;

public class ProductosRepositorio: IProductosRepositorio
{

    private readonly string _conexion;

    public ProductosRepositorio(string conexion)
    {
        _conexion = conexion;
    }

    public async Task<List<ProductosResponse>> GET()
    {


        List<ProductosResponse> responses = new List<ProductosResponse>();

        string query = @"
            SELECT 
                a.descripcion AS tipo_producto,
                b.nombre AS nombre_producto,
                b.tasa,
                b.interes
            FROM 
                Producto a
            JOIN 
                Datos_Producto b 
            ON 
                b.id_producto = a.id_producto
        "; ;

        using (SqlConnection nuevaConexion = new SqlConnection(_conexion))
        using (SqlCommand cmd = new SqlCommand(query, nuevaConexion))
        {
            try
            {
                await nuevaConexion.OpenAsync();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        ProductosResponse productosResponse = new ProductosResponse();
                        productosResponse.tipo_producto = reader["tipo_producto"].ToString();
                        productosResponse.nombre_producto = reader["nombre_producto"].ToString();
                        productosResponse.tasa = reader.GetDecimal(reader.GetOrdinal("tasa"));
                        productosResponse.interes = reader.GetDecimal(reader.GetOrdinal("interes"));

                        responses.Add(productosResponse);

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await nuevaConexion.CloseAsync();
            }
        }

        return responses;

    }
}
