using Microsoft.AspNetCore.Mvc;

namespace BrunSker.Api.ResponseTypesAttributes
{
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public class QueryCommandsResponseTypes : Attribute
    {
    }
}
