﻿// Learn more about F# at http://fsharp.org

open Day1
open System.IO

[<EntryPoint>]
let main argv =
    let data = File.ReadAllLines "Day1.data"
                    |> Array.map int
    
    printf "%d" (Day1.findProduct data)
    
    0 // return an integer exit code
