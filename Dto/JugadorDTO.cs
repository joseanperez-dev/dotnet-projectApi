using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projectApi.Dto;

public class JugadorDTO
{
    public string Nombre { get; set; }
    public string? Posicion { get; set; }
    public int EquipoId { get; set; }
}
