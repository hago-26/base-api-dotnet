using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Controllers;

public class EmpleadoController : GenericApiController<Empleado, EmpleadoDto, EmpleadoAddDto>
{
    public EmpleadoController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _repository = unitOfWork.EmpleadoRepository;
    }
}