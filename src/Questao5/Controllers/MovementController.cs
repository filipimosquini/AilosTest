using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Movements;
using Questao5.Application.Commands.Movements.Models;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Questao5.Application.Queries.Movements;
using Questao5.Application.Queries.Movements.Models;
using Questao5.BuildingBlocks.Controllers;
using Questao5.BuildingBlocks.CrossCutting.MessageCatalogs.Interfaces;

namespace Questao5.Controllers;

[Route("api/banks/movements")]
public class MovementController : BaseController<MovementController>
{
    public MovementController(ILoggerFactory loggerFactory, IMediator mediatorService, IMessageCatalog messageCatalog) 
        : base(loggerFactory, mediatorService, messageCatalog)
    {
    }

    /// <summary>
    /// api/movements.
    /// </summary>
    /// <remarks>
    /// <p>
    /// <b> Description: </b><br />
    /// This method create a movement. <br />
    /// </p>
    /// <p>
    /// <b> Requirements: </b><br />
    /// Not Exists. <br />
    /// </p>
    /// </remarks>
    /// <response code="200">OK</response>
    /// <response code="400">Bad Request
    /// <ul>
    ///     <li>Inactive.Account</li>
    ///     <li>Invalid.AccountNumber</li>
    ///     <li>Invalid.Amount</li>
    ///     <li>Invalid.MovementType</li>
    ///     <li>Invalid.RequestId</li>
    /// </ul>
    /// </response>
    /// <response code="404">Not Found
    /// <ul>
    ///     <li>NotFound.Account</li>
    /// </ul>
    /// </response>
    /// <response code="422">UnprocessableEntity
    /// <ul>
    ///     <li>NotRegistered.Movement</li>
    /// </ul>
    /// </response>
    /// <response code="500">InternalServerError
    /// <ul>
    ///     <li>Error.Unexpected</li>
    /// </ul>
    /// </response>
    [HttpPost]
    [ProducesResponseType(typeof(CreateMovementCommandResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateMovementAsync([FromBody] CreateMovementCommand command)
        => await ExecuteAsync(async () => await _mediatorService.Send(command));

    /// <summary>
    /// api/movements/balances.
    /// </summary>
    /// <remarks>
    /// <p>
    /// <b> Description: </b><br />
    /// This method get a balance result. <br />
    /// </p>
    /// <p>
    /// <b> Requirements: </b><br />
    /// Not Exists. <br />
    /// </p>
    /// </remarks>
    /// <response code="200"> OK </response>
    /// <response code="400"> Bad Request
    /// <ul>
    /// <li>Inactive.Account</li>
    /// <li>Invalid.AccountNumber</li>
    /// </ul>
    /// </response>
    /// <response code="404">Not Found
    /// <ul>
    ///     <li>NotFound.Account</li>
    /// </ul>
    /// </response>
    /// <response code="500"> InternalServerError
    /// <ul>
    /// <li> Error.Unexpected </li>
    /// </ul>
    /// </response>
    [HttpGet("balances")]
    [ProducesResponseType(typeof(GetBalanceQueryResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBalanceAsync([FromQuery] GetBalanceQuery query)
        => await ExecuteAsync(async () => await _mediatorService.Send(query));
}