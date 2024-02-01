using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivoController : GenericApiController<Activo, ActivoDto, ActivoAddDto>
{
    public ActivoController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _repository = unitOfWork.ActivoRepository;
    }

    public override async Task<ActionResult<Activo>> Post([FromBody] ActivoAddDto itemAdd)
    {
        // Solo si tiene un id de partida, validar que la partida exista
        if (itemAdd.Partida != null)
        {
            // Traer la partida desde el id de la partida en itemAdd
            var partida = await _unitOfWork.PartidasRepository.GetByIdAsync(itemAdd.Partida.Value);

            // Validar que la partida exista
            if (partida == null)
                return NotFound(new ApiResponse(404, "No se encontró la partida"));

            if (partida.Activos != null)
                if (partida.GetCantidadRestante() < 1 )
                    return BadRequest(new ApiResponse(400, "La partida no tiene espacio para agregar un activo"));

            // Validar que la partida tenga espacio para agregar un activo
        }

        var item = _mapper.Map<Activo>(itemAdd);

        var itemCreated = _repository.Add(item);
        await _unitOfWork.CompleteAsync();

        if (item == null)
        {
            return BadRequest(new ApiResponse(400, "No se pudo crear el item"));
        }
        
        var itemResponse = _mapper.Map<ActivoDto>(itemCreated);

        return CreatedAtAction(nameof(Post), new { id = item.Id }, itemResponse );
    }


    [HttpGet("FromPartida")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ActivoDto>>> FromPartida([FromQuery] Params itemParams)
    {
        // Busacar con FindAsync lso activos que tenga partida != null

        var resultado = await _repository.FindAsyncPaginated(x => x.PartidaId != null, itemParams.PageNumber, itemParams.PageSize);

        // Mapear a ActivoDto
        var listaResultados = _mapper.Map<List<ActivoDto>>(resultado.registros);

        // Retornar
        return new Pager<ActivoDto>(listaResultados, resultado.totalRegistros, itemParams.PageNumber, itemParams.PageSize, itemParams.Search);

    }

    [HttpPost("FromPartida")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Activo>> PostFromPartida([FromBody] ActivoFromPartidaAddDto itemAdd)
    {
        var partida = await _unitOfWork.PartidasRepository.GetByIdAsync(itemAdd.Partida);

        if (partida == null)
            return NotFound(new ApiResponse(404, "No se encontró la partida"));
        
        if (partida.Activos != null)
            if (partida.GetCantidadRestante() < 1 )
                return BadRequest(new ApiResponse(400, "La partida no tiene espacio para agregar un activo"));

        var item = _mapper.Map<Activo>(partida);

        item.NoInventario = itemAdd.NoInventario;
        item.NoSerie = itemAdd.NoSerie;
        item.Comentarios = itemAdd.Comentarios;

        var itemCreated = _repository.Add(item);
        await _unitOfWork.CompleteAsync();

        if (itemCreated == null)
        {
            return BadRequest(new ApiResponse(400, "No se pudo crear el item"));
        }
        
        var itemResponse = _mapper.Map<ActivoDto>(itemCreated);

        return CreatedAtAction(nameof(Post), new { id = item.Id }, itemResponse );

    }


}