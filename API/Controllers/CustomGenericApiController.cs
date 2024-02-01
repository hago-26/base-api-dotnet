using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class GenericApiController<Entity, EntityDto, EntityAddDto> : BaseApiController 
                                            where Entity : BaseEntity 
                                            where EntityDto : class
                                            where EntityAddDto : class
{
    protected virtual IGenericRepository<Entity> _repository { get; set;}
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;    

    public GenericApiController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<Pager<EntityDto>>> Get([FromQuery] Params itemParams)
    {
        var resultado = await _repository
                                .GetAllAsync(itemParams.PageNumber, itemParams.PageSize, itemParams.Search);
        var listaResultados = _mapper.Map<List<EntityDto>>(resultado.registros);

        return new Pager<EntityDto>(listaResultados, resultado.totalRegistros, itemParams.PageNumber, itemParams.PageSize, itemParams.Search);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<EntityDto>> Get(int id)
    {
        var item = await _repository
                                .GetByIdAsync(id);
        if (item == null)
            return NotFound(new ApiResponse(404, "No se encontró el item"));

        return _mapper.Map<EntityDto>(item);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<Entity>> Post([FromBody] EntityAddDto itemAdd)
    {
        var propertyInfo = typeof(EntityAddDto).GetProperty("Id");
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(itemAdd, null);
        }
        
        var item = _mapper.Map<EntityAddDto, Entity>(itemAdd);

        var itemCreated = _repository.Add(item);
        await _unitOfWork.CompleteAsync();

        if (item == null)
        {
            return BadRequest(new ApiResponse(400, "No se pudo crear el item"));
        }
        
        return CreatedAtAction(nameof(Post), new { id = item.Id }, itemCreated );
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<EntityAddDto>> Put(int id, [FromBody]EntityAddDto itemPut)
    {
        var item = _mapper.Map<EntityAddDto, Entity>(itemPut);

        if (item == null)
            return NotFound(new ApiResponse(404, "No se encontró el item"));
        
        _repository.Update(item);

        await _unitOfWork.CompleteAsync();

        return itemPut;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<Entity>> Delete(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
        {
            return NotFound(new ApiResponse(404, "No se encontró el item"));
        }
        _repository.Remove(item);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}