using Prueba.Model.Request;

namespace Prueba.Servicios;
public interface IProductosBL
{
    Task<List<ProductosResponse>> GET();
}
