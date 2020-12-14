module Tests

open Xunit
open Lib
open System.IO

let sampleData = File.ReadAllLines "Day4.sample.data"
                |> Array.toList
                |> Day4.parsePassports
    
[<Fact>]
let ``My test`` () =
    Assert.Equal(4, sampleData.Length)
    Assert.Equal(2, Day4.papersPlease(sampleData))
