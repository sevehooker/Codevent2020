namespace Day2

module Day2 =

    let Xor a b =
        match a, b with
        | true, false -> true
        | false, true -> true
        | _, _ -> false

    let parsePattern (pattern: string) =
        pattern.Split [|'-' ; ' ' ; ':'|]
        |> ( fun values -> (values.[0] |> int, values.[1] |> int, values.[2] |> char, values.[4]))

    let letterOccurances (letter: char, text: string) = 
        text
        |> Seq.filter (fun x' -> x' = letter)
        |> Seq.length
    
    let checkPattern1 (min: int, max: int, letter: char, password: string) =
        let count = letterOccurances(letter, password)
        count >= min && count <= max

    let checkPattern2 (pos1: int, pos2: int, letter: char, password: string) =
        Xor (password.ToCharArray().[pos1-1] = letter) (password.ToCharArray().[pos2-1] = letter)

    let countValidPasswords = Seq.fold ( fun count x -> if checkPattern2 x then count + 1 else count ) 0

    let validPasswords (arr: string array) =
        arr
        |> Array.map parsePattern
        |> countValidPasswords
