﻿namespace Dominio.Dto
{
    public class TareaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string FkIdEstado { get; set; }
    }
}
