namespace Lib

module Day5 =
    let rows = 127
    let columns = 7
    
    let toButtHole (row, column) =
        row * (columns+1) + column

    let buttSpread min max = (max-(max-min+1)/2)

    let rec findSeat (butt:string, minRow:int, maxRow:int, minCol:int, maxCol:int) = 
        if butt.Length > 0 then
            match butt.[0] with
            | 'F' -> findSeat(butt.[1..], minRow, buttSpread minRow maxRow, minCol, maxCol)
            | 'B' -> findSeat(butt.[1..], buttSpread minRow maxRow, maxRow, minCol, maxCol)
            | 'L' -> findSeat(butt.[1..], minRow, maxRow, minCol, buttSpread minCol maxCol)
            | 'R' -> findSeat(butt.[1..], minRow, maxRow, buttSpread minCol maxCol, maxCol)
            | _ -> (0, 0)
        else (maxRow, maxCol)

    let findButtHole butt =
        findSeat(butt, 0, rows, 0, columns)
        |> toButtHole

    let findBiggestButt butts =
        butts
        |> Array.maxBy findButtHole
        |> findButtHole

    let findMissingButt butts =
        butts
        |> Array.map findButtHole
        |> Array.sort
        |> Array.pairwise
        |> Array.find (fun (a, b) -> b <> a + 1)
        |> fun (a, _) -> a+1
