using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class GenericApiController<T> : BaseApiController where T : BaseEntity
{
    protected virtual IGenericRepository<T> _repository { get; set;}
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;

    protected virtual Type ListDataDtoType { get; set; }
    

    public GenericApiController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;

        ListDataDtoType = typeof(T);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<Pager<T>>> Get([FromQuery] Params itemParams)
    {
        var resultado = await _repository
                                .GetAllAsync(itemParams.PageNumber, itemParams.PageSize, itemParams.Search);
        var listaResultados = _mapper.Map<List<T>>(resultado.registros);

        return new Pager<T>(listaResultados, resultado.totalRegistros, itemParams.PageNumber, itemParams.PageSize, itemParams.Search);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<T>> Get(int id)
    {
        var item = await _repository
                                .GetByIdAsync(id);
        if (item == null)
            return NotFound(new ApiResponse(404, "No se encontró el item"));

        return _mapper.Map<T>(item);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<T>> Post([FromBody] T itemAdd)
    {
        var item = _mapper.Map<T>(itemAdd);

        _repository.Add(item);
        await _unitOfWork.CompleteAsync();

        if (item == null)
        {
            return BadRequest(new ApiResponse(400, "No se pudo crear el item"));
        }
        
        itemAdd.Id = item.Id;
        return CreatedAtAction(nameof(Post), new { id = itemAdd.Id }, itemAdd);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<T>> Put(int id, [FromBody]T item)
    {
        if (item == null)
            return NotFound(new ApiResponse(404, "No se encontró el item"));
        
        _repository.Update(item);

        await _unitOfWork.CompleteAsync();

        return item;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<T>> Delete(int id)
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