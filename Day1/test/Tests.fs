module Tests

open Xunit
open System.IO

open Day1

let sampleInput = File.ReadAllLines "Day1.sample.data"
                |> Array.map int
                |> Array.toList

[<Fact>]
let ``Should find product`` () =
    let result = Day1.findProduct sampleInput
    Assert.Equal(241861950, result)
