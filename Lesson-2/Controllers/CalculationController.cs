using Microsoft.AspNetCore.Mvc;

namespace Lesson_2.Controllers;

[ApiController]
[Route("")]
public class CalculationController : ControllerBase
{
    private static List<string> _history = new();
    private const double maxValue = 10e6;
    private const double minValue = -10e6;

    [HttpPost("/v1/Add")]
    public Response Add(Request request)
    {
        if (request.Operand1 >= maxValue && request.Operand2 >= maxValue)
        {
            throw new Exception("Результат слишком большое число");
        }
        if (request.Operand1 <= minValue && request.Operand2 <= minValue)
        {
            throw new Exception("Результат слишком маленькое число");
        }

        var result = request.Operand1 + request.Operand2;
        _history.Add($"{DateTime.UtcNow:hh:mm:ss}: {request.Operand1} + {request.Operand2} = {result}");
        return new Response()
        {
            Result = result
        };
    }
    
    [HttpPost("/v1/Substract")]
    public Response Substract(Request request)
    {
        if (request.Operand1 >= maxValue && request.Operand2 >= maxValue)
        {
            throw new Exception("Результат слишком большое число");
        }
        if (request.Operand1 <= minValue && request.Operand2 <= minValue)
        {
            throw new Exception("Результат слишком маленькое число");
        }

        var result = request.Operand1 - request.Operand2;
        _history.Add($"{DateTime.UtcNow:hh:mm:ss}: {request.Operand1} - {request.Operand2} = {result}");
        return new Response()
        {
            Result = result
        };
    }
    
    [HttpPost("/v1/Divide")]
    public Response Divide(Request request)
    {
        if (request.Operand1 >= maxValue && request.Operand2 >= maxValue)
        {
            throw new Exception("Результат слишком большое число");
        }
        if (request.Operand1 <= minValue && request.Operand2 <= minValue)
        {
            throw new Exception("Результат слишком маленькое число");
        }
        if (request.Operand2 == 0)
        {
            throw new Exception("Нельзя делить на 0");
        }
        var result = request.Operand1 / request.Operand2;
        _history.Add($"{DateTime.UtcNow:hh:mm:ss}: {request.Operand1} / {request.Operand2} = {result}");
        return new Response()
        {
            Result = result
        };
    }
    
    [HttpPost("/v1/Multiply")]
    public Response Multiply(Request request)
    {
        if (request.Operand1 >= maxValue && request.Operand2 >= maxValue)
        {
            throw new Exception("Результат слишком большое число");
        }
        if (request.Operand1 <= minValue && request.Operand2 <= minValue)
        {
            throw new Exception("Результат слишком маленькое число");
        }
        var result = request.Operand1 * request.Operand2;
        _history.Add($"{DateTime.UtcNow:hh:mm:ss}: {request.Operand1} * {request.Operand2} = {result}");
        return new Response()
        {
            Result = result
        };
    }

    [HttpGet("/v1/History")]
    public HistoryResponse History()
    {
        return new HistoryResponse()
        {
            Operations = _history.ToArray()
        };
    }
}