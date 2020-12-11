namespace Lib

module Day3 =

    let getGridPos (grid: string array, row: int, col: int) = 
        if row < grid.Length then Some(grid.[row].ToCharArray().[col % grid.[0].Length]) else None

    let rec toboggan (grid: string array, curRow: int, curCol: int, down: int, right: int) =
        match getGridPos(grid, curRow, curCol) with
        // | Some('.') -> printf "clear at (%d, %d)\n" curRow curCol; toboggan(grid, curRow + down, curCol + right, down, right)
        // | Some('#') -> printf "hit at (%d, %d)\n" curRow curCol; toboggan(grid, curRow + down, curCol + right, down, right) + 1
        | Some('.') -> toboggan(grid, curRow + down, curCol + right, down, right)
        | Some('#') -> toboggan(grid, curRow + down, curCol + right, down, right) + 1
        | None -> 0
