
namespace Core.Entities;

public class Asignaciones : BaseEntityExtended
{
    public int ActivoId { get; set; }
    public Activo Activo { get; set; }
    public int ResguradanteId { get; set; }
    public Empleado Resguardante { get; set; }
    public int MunicipioId { get; set; }
    public Municipio Municipio { get; set; }
    public string ResguardoUrl { get; set; }
    public string Comentarios { get; set; }
}