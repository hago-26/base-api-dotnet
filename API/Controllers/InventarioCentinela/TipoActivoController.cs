using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Controllers;

public class TipoActivoController : GenericApiController<TipoActivo, TipoActivoDto, TipoActivo>
{
    public TipoActivoController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _repository = unitOfWork.TipoActivoRepository;
    }
}