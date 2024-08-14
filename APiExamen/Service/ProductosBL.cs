using APiExamen.Entities;
using APiExamen.Repository.Interface;

namespace APiExamen.Service;

public class ProductosBL: IProductosBL
{
    private readonly IProductosRepositorio _repositorio;

    public ProductosBL(IProductosRepositorio repositorio) { _repositorio = repositorio; }
    public async Task<List<ProductosResponse>> GET() => await _repositorio.GET();
}
