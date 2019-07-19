namespace GiraffeApp

module HttpHandlers =

    open Microsoft.AspNetCore.Http
    open FSharp.Control.Tasks.V2.ContextInsensitive
    open Giraffe
    open GiraffeApp.Models

    let handleGetHello =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let response = {
                    Text = "Hello world, from Giraffe!"
                }
                return! json response next ctx
            }
            
    let handleGetHelloWithName (name: string) (next: HttpFunc) (ctx: HttpContext) =
        task {
            let response = {
                Text = sprintf "Hello, %s" name
            }

            return! json response next ctx
        }