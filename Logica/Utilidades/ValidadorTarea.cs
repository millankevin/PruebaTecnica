using Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Utilidades
{
    public static class ValidadorTarea
    {
        public static string ValidarCrearTarea(CrearTareaDto tarea) 
        {
            string validacion = string.Empty;
            if (string.IsNullOrEmpty(tarea.Titulo)) 
                validacion += "El titulo viene vacío ";
            if (string.IsNullOrEmpty(tarea.Descripcion))
                validacion += " La descripción está vacía";
            if (tarea.FkIdEstado == 0)
                validacion += " El estado es invalido";

            return validacion;
        }
    }
}
