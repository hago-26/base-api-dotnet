using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Controllers;

public class AsignacionesController : GenericApiController<Asignaciones, AsignacionesDto, AsignacionesAddDto>
{
    public AsignacionesController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _repository = unitOfWork.AsignacionesRepository;
    }
}