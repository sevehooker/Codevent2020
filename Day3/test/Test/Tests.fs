module Tests

open Lib
open Xunit

let sampleData = "..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#"

[<Fact>]
let ``Day 3`` () =
    let sampleGrid = sampleData.Split '\n' |> Array.map (fun x -> x.Trim())
    let result = 
        Day3.toboggan(sampleGrid, 0, 0, 1, 1) *
        Day3.toboggan(sampleGrid, 0, 0, 1, 3) *
        Day3.toboggan(sampleGrid, 0, 0, 1, 5) *
        Day3.toboggan(sampleGrid, 0, 0, 1, 7) *
        Day3.toboggan(sampleGrid, 0, 0, 2, 1)

    Assert.Equal(336, result)
