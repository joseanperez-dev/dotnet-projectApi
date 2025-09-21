using System;

namespace projectApi.Dto;

/*
*   Objeto de transferencia de datos que representa una respuesta genérica para las peticiones.
*/
public class GenericResponseDTO
{
    /*
    *   Estado de la petición.
    */
    public string Status { get; set; }
    /*
    *   Nombre de la petición.
    */
    public string Name { get; set; }
}