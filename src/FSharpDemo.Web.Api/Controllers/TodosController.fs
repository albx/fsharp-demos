namespace FSharpDemo.Web.Api.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open FSharpDemo.Web.Api

type TodoItem = { Id: int; Title: string; Completed: bool }

[<ApiController>]
[<Route("[controller]")>]
type TodosController (logger : ILogger<TodosController> ) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() = 
        let todos =[|
            for index in 0..5 ->
                { Id = index; Title = $"Todo #{index}"; Completed = false }
        |]
        todos

