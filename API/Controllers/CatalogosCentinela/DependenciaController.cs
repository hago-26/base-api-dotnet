using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class DependenciaController : GenericApiController<Dependencia, DependenciaDto, DependenciaAddDto>
{
    public DependenciaController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _repository = unitOfWork.DependenciaRepository;
    }

}