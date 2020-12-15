open Lib
open System.IO

[<EntryPoint>]
let main argv =
    let data = File.ReadAllLines "Day5.data"
    
    printfn "%d" (data |> Day5.findBiggestButt)
    
    printfn "%d" (data |> Day5.findMissingButt)

    0
