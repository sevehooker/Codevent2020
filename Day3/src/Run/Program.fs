open Lib
open System.IO

[<EntryPoint>]
let main argv =
    let data = File.ReadAllLines "Day3.data"
    
    let result =
        Day3.toboggan(data, 0, 0, 1, 1) *
        Day3.toboggan(data, 0, 0, 1, 3) *
        Day3.toboggan(data, 0, 0, 1, 5) *
        Day3.toboggan(data, 0, 0, 1, 7) *
        Day3.toboggan(data, 0, 0, 2, 1)

    printf "%d " (Day3.toboggan(data, 0, 0, 1, 1))
    printf "%d " (Day3.toboggan(data, 0, 0, 1, 3))
    printf "%d " (Day3.toboggan(data, 0, 0, 1, 5))
    printf "%d " (Day3.toboggan(data, 0, 0, 1, 7))
    printf "%d " (Day3.toboggan(data, 0, 0, 2, 1))

    printfn "%d" result
    
    0
