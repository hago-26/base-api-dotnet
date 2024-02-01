using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Controllers;

public class ProveedorController : GenericApiController<Proveedor, ProveedorDto, ProveedorAddDto>
{
    public ProveedorController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _repository = unitOfWork.ProveedorRepository;
    }
}