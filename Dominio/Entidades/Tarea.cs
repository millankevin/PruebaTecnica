namespace Dominio.Entidades
{
    public class Tarea
    {
        public int Id { get; set; }
        public int FkIdEstado { get; set; }
        public string Titulo { get; set; }               
        public string Descripcion { get; set; }
        public virtual Estado Estado { get; set; }

    }
}
