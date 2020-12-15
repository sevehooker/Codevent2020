module Tests

open Xunit
open Lib

let sampleData1 = "FBFBBFFRLR"
let sampleData2 = "BFFFBBFRRR"
let sampleData3 = "FFFBBBFRRR"
let sampleData4 = "BBFFBBFRLL"


[<Fact>]
let ``Find seat`` () =
    Assert.Equal((44, 5), Day5.findSeat(sampleData1, 0, 127, 0, 7))
    
[<Fact>]
let ``Find butt holes`` () =
    Assert.Equal(357, Day5.findButtHole sampleData1)
    Assert.Equal(567, Day5.findButtHole sampleData2)
    Assert.Equal(119, Day5.findButtHole sampleData3)
    Assert.Equal(820, Day5.findButtHole sampleData4)

[<Fact>]
let ``Find biggest butt`` () =
    Assert.Equal(820, Day5.findBiggestButt [| sampleData1; sampleData2; sampleData3; sampleData4 |])