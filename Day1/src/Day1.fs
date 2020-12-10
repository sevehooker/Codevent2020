namespace Day1

module Day1 =

    let rec getPairs list =
        match list with
            | head :: tail -> List.allPairs [head] tail @ getPairs tail
            | [] -> []

    let rec getTriples elem list =
        match list with
            | head :: tail -> 
                let triples = getPairs list
                              |> List.map ( fun (a, b) -> (elem, a, b) );
                triples @ getTriples head tail
            | [] -> []

    let equals2020 (a, b, c) = a + b + c = 2020

    let product (a, b, c) = a * b * c

    let rec hasProduct (list) =
        match list with
            | head :: _ when equals2020 head -> product head
            | _ :: tail -> hasProduct tail
            | [] -> 0

    let findProduct (list: list<int>) =
        getTriples list.Head list.Tail
        |> hasProduct
        
