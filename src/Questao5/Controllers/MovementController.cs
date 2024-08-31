using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Movements;
using Questao5.Application.Commands.Movements.Models;
using Questao5.Infrastructure.Configurations.Controllers;
using Questao5.Infrastructure.CrossCutting.MessageCatalogs.Interfaces;
using System.Net;
using System.Threading.Tasks;
using Questao5.Application.Queries.Movements;
using Questao5.Application.Queries.Movements.Models;

namespace Questao5.Controllers;

[Route("api/movements")]
public class MovementController : BaseController<MovementController>
{
    public MovementController(IMediator mediatorService, IMessageCatalog messageCatalog) 
        : base(mediatorService, messageCatalog)
    {
    }

    /// <summary>
    /// api/movements.
    /// </summary>
    /// <remarks>
    /// <p>
    /// <b> Desciption: </b><br />
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
    /// <b> Desciption: </b><br />
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
    /// <li>NotFound.Account</li>
    /// </ul>
    /// </response>
    /// <response code="500"> InternalServerError
    /// <ul>
    /// <li> Error.Unexpected </li>
    /// </ul>
    /// </response>
    [HttpGet("balances")]
    [ProducesResponseType(typeof(GetBalanceQueryResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBalanceAsync([FromBody] GetBalanceQuery query)
        => await ExecuteAsync(async () => await _mediatorService.Send(query));
}