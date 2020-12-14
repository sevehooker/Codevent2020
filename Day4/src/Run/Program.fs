open Lib
open System.IO

[<EntryPoint>]
let main argv =
    let data = File.ReadAllLines "Day4.data"
                |> Array.toList
                |> Day4.parsePassports
    
    printfn "%d" (Day4.papersPlease(data))
    
    0
