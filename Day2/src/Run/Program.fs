open Day2
open System.IO

[<EntryPoint>]
let main argv =
    let data = File.ReadAllLines "Day2.data"
    
    printfn "%d" (Day2.validPasswords data)
    
    0
