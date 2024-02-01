using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Controllers;

public class MarcaProductoController : GenericApiController<MarcaProducto, MarcaProductoDto, MarcaProductoAddDto>
{
    public MarcaProductoController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _repository = unitOfWork.MarcaProductoRepository;
    }
}