using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AisLogistics.DataLayer.Common;
using AisLogistics.DataLayer.Utils;

namespace AisLogistics.DataLayer.ExceptionMiddleware;

internal class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            WebApiLogger.LogException(ex);
            await HandleExceptionMessageAsync(context);
        }
    }

    private static Task HandleExceptionMessageAsync(HttpContext context)
    {
        var request = FormatRequest(context.Request);
        const int statusCode = StatusCodes.Status500InternalServerError;
        var result = JsonSerializer.Serialize(new
        {
            StatusCode = statusCode,
            ErrorMessage = ErrorDescription.InternalServerError
        });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsync(result);
    }

    private static string FormatRequest(HttpRequest request)
    {
        List<RequestBody> requestData = new();

        if (request.HasFormContentType)
        {
            requestData.AddRange(request.Form.Select(s => new RequestBody(s.Key, s.Value)).ToList());
        }

        if (request.QueryString.HasValue)
        {
            requestData.AddRange(request.Query.Select(s => new RequestBody(s.Key, s.Value)).ToList());
        }
        return JsonSerializer.Serialize(requestData);
    }

}