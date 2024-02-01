using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Controllers;

public class ProductoController : GenericApiController<Producto, ProductoDto, ProductoAddDto>
{
    public ProductoController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _repository = unitOfWork.ProductoRepository;
    }
}