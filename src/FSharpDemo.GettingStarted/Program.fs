// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

let addOne x:int = x + 1

let isOdd x = x % 2 <> 0

let addOneIfOdd input =
    let result =
        if isOdd input then
            input + 1
        else
            input

    result

[<EntryPoint>]
let main argv =
    //let one = addOneIfOdd 1
    //printfn $"Number: %d{one}"

    //let two = addOneIfOdd 2
    //printfn $"Two: %d{two}"

    let integerList = [ 1; 2; 3; 4; 5; 6; 7 ]
    let stringList = [ "one"; "two"; "three" ]

    for d in integerList do printfn $"%d{d}"

    let doubles = integerList |> List.filter(fun x -> x < 6) |> List.map(fun x -> x*2)

    for d in doubles do printfn $"%d{d}"

    0 // return an integer exit code