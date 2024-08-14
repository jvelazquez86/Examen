using APiExamen.Entities;

namespace APiExamen.Repository.Interface;

public interface IProductosRepositorio
{
    Task<List<ProductosResponse>> GET();
}
