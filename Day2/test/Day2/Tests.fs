module Tests

open Day2
open Xunit

let text = "1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc"
let sampleData = text.Split '\n'

[<Fact>]
let ``My test`` () =
    let result = Day2.validPasswords sampleData

    Assert.Equal(1, result)
