module GiraffeApp.Routes


open Microsoft.AspNetCore.Http

open Giraffe
open GiraffeApp.HttpHandlers

let routes: HttpFunc -> HttpContext -> HttpFuncResult =
    choose [
        subRoute "/api"
            (choose [
                GET >=> choose [
                    route "/hello" >=> handleGetHello

                    // New route function added here
                    routef "/hello/%s" handleGetHelloWithName
                ]
            ])
        setStatusCode 404 >=> text "Not Found" ]