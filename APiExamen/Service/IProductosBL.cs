using APiExamen.Entities;

namespace APiExamen.Service;

public interface IProductosBL
{
    Task<List<ProductosResponse>> GET();
}
