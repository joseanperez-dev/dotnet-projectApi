using System;


namespace projectApi.Dto;


/*
*   Data Transfer Object that represents a generic response for requests.
*/
public class GenericResponseDTO
{
    /*
    *   Request status.
    */
    public string Status { get; set; }
    /*
    *   Request name.
    */
    public string Name { get; set; }
}
