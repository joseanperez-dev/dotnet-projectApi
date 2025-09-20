using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projectApi.Dto;

public class JugadorResponseDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Slug { get; set; }
    public int EquipoId {get; set;}
    //public EquipoDTO EquipoDto {get; set;}
    public string Posicion { get; set; }
    public DateTime Fecha { get; set; }
}
