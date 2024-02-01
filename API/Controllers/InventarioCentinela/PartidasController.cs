using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Controllers;

public class PartidasController : GenericApiController<Partidas, PartidasDto, PartidasAddDto>
{
    public PartidasController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _repository = unitOfWork.PartidasRepository;
    }
}