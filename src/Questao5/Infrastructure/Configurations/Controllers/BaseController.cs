﻿using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Questao5.Infrastructure.CrossCutting.MessageCatalogs.Interfaces;
using Questao5.Infrastructure.CrossCutting.MessageCatalogs.Models;
using Questao5.Infrastructure.Configurations.Exceptions;

namespace Questao5.Infrastructure.Configurations.Controllers;

/// <summary>
/// Base controller class.
/// </summary>
public abstract class BaseController<T> : Controller
{
    /// <summary>
    /// Gets or Sets the mediator service.
    /// </summary>
    protected IMediator _mediatorService { get; }

    /// <summary>
    /// Gets the message catalog.
    /// </summary>
    protected IMessageCatalog _messageCatalog { get; } 

    protected BaseController(IMediator mediatorService, IMessageCatalog messageCatalog)
    {
        _mediatorService = mediatorService;
        _messageCatalog = messageCatalog;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDataObject">The type of the data object.</typeparam>
    /// <param name="function">The function</param>
    /// <returns></returns>
    protected virtual async Task<IActionResult> ExecuteAsync<TDataObject>(Func<Task<TDataObject>> function)
        => await ExecuteAsync(function, HttpStatusCode.OK);


    /// <summary>
    /// Generate the response asynchronous.
    /// </summary>
    /// <typeparam name="TDataObject">The type of the data object.</typeparam>
    /// <param name="function">The function</param>
    /// <param name="httpStatusCode">The response code.</param>
    /// <returns></returns>
    protected virtual async Task<IActionResult> ExecuteAsync<TDataObject>(Func<Task<TDataObject>> function,
        HttpStatusCode httpStatusCode)
    {
        BaseController<T> baseController = this;

        try
        {
            TDataObject dataObject = await function();

            return baseController.StatusCode((int)httpStatusCode, new
            {
                data = dataObject
            });
        }
        catch (AppCustomException ex)
        {
            return baseController.HandleAppCustomException(ex);
        }
        catch (ValidationException ex)
        {
            return baseController.HandleValidationException(ex);
        }
        catch (Exception exception)
        {
            return baseController.HandleFatalError();
        }
    }


    /// <summary>
    /// Handle the exception result when fatal error occurs.
    /// </summary>
    /// <returns></returns>
    private IActionResult HandleFatalError()
    {
        return StatusCode((int) HttpStatusCode.InternalServerError, new
        {
            notifications = this._messageCatalog.Get("UNEXPECTED_ERROR")
        });
    }

    /// <summary>
    /// Handle the exception result when AppCustomException occurs.
    /// </summary>
    /// <param name="exception"> The exception. </param>
    /// <returns></returns>
    private IActionResult HandleAppCustomException(AppCustomException exception)
    {
        if (string.IsNullOrWhiteSpace(exception.Message))
        {
            return StatusCode((int)exception.HttpStatusCode);
        }

        var _notifications = new List<Notification>();
        var notificationsFromFile = this._messageCatalog.Get(exception.Message) ?? this._messageCatalog.Get("UNEXPECTED_ERROR");

        if (notificationsFromFile.Any())
        {
            foreach (var notification in notificationsFromFile)
            {
                _notifications.Add(new Notification
                {
                    Code = notification.Code,
                    Message = notification.Message
                });
            }
        }

        return StatusCode((int)exception.HttpStatusCode, new
        {
            notifications = _notifications
        });
    }

    /// <summary>
    /// Handle the exception result when ValidationException occurs.
    /// </summary>
    /// <param name="exception"> The exception. </param>
    /// <returns></returns>
    private IActionResult HandleValidationException(ValidationException exception)
    {
        var _notifications = new List<Notification>();
        
        foreach (ValidationFailure error in exception.Errors)
        {
            var notificationsFromFile = this._messageCatalog.Get(error.ErrorCode);

            if (notificationsFromFile.Any())
            {
                foreach (var notification in notificationsFromFile)
                {
                    _notifications.Add(new Notification
                    {
                        Code = notification.Code,
                        Message = notification.Message
                    });
                }
            }
            else
            {
                _notifications.Add(new Notification
                {
                    Code = error.ErrorCode,
                    Message = error.ErrorMessage
                });
            }
        }

        return StatusCode((int)HttpStatusCode.BadRequest, new
        {
            notifications = _notifications
        });
    }
}