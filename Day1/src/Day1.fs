namespace Day1

module Day1 =

    let result values =
        for i = 0 to 1010 do
            match i with
            | value when List.exists (fun value -> value = i) values && List.exists (fun value -> 2020-i = value) values -> printfn "%d" (value*(2020-value))
            // | _ -> skip