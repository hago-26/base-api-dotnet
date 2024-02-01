using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Controllers;

public class SubcentroController : GenericApiController<Subcentro, SubcentroDto, SubcentroAddDto>
{
    public SubcentroController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _repository = unitOfWork.SubcentroRepository;
    }
}