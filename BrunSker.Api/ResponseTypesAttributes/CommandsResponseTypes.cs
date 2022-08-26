using BrunSker.Business.Settings.NotificationSettings;
using Microsoft.AspNetCore.Mvc;

namespace BrunSker.Api.ResponseTypesAttributes
{
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public class CommandsResponseTypes : Attribute
    {
    }
}
