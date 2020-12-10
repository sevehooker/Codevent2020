namespace Day1

module Day1 =

    let getPairs (elem, list) =
        List.allPairs [elem] list

    let equals2020 (a, b) = a + b = 2020

    let product (a, b) = a * b

    let rec hasProduct (list) =
        match list with
            | head :: tail when equals2020 head -> product head
            | head :: tail -> hasProduct tail
            | [] -> 0

    let findProduct arr =
        arr
        |> Array.fold ( fun pairs elem -> pairs @ getPairs(elem, Array.toList arr) ) List.empty<(int * int)>
        |> hasProduct
        
