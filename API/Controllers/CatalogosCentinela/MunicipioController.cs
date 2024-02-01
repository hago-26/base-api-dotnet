using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Controllers;

public class MunicipioController : GenericApiController<Municipio, MunicipioDto, MunicipioAddDto>
{
    public MunicipioController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _repository = unitOfWork.MunicipioRepository;
    }
}