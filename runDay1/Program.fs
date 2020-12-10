open Day1
open System.IO

[<EntryPoint>]
let main argv =
    let data = File.ReadAllLines "Day1.data"
                    |> Array.map int
                    |> Array.toList
    
    printf "%d" (Day1.findProduct data)
    
    0
