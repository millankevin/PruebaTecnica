namespace Dominio.Dto
{
    public class CrearTareaDto
    {
        public int Id { get; set; }
        public int FkIdEstado { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
    }
}
