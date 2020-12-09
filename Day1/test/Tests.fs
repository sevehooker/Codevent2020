module Tests

open Xunit
open System.IO

open Day1

let sampleInput = File.ReadAllLines "Day1.sample.data"
                |> Array.map int

[<Fact>]
let ``Should find product`` () =
    let result = Day1.findProduct sampleInput
    Assert.Equal(514579, result)
