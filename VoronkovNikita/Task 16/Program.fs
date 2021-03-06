﻿let main lst1 lst2 = 
    let rvlst1 = List.rev (List.tail lst1)
    let rvlst2 = List.rev (List.tail lst2)
    let addition a b = 
        if List.head lst1 = List.head lst2
        then
            let sumList = List.toArray (List.map2 (fun x y -> x + y) a b)
            for i in 0..List.length a - 2 do
                if sumList.[i] >= 10
                then 
                    sumList.[i + 1] <- sumList.[i + 1] + 1
                    sumList.[i] <- sumList.[i] - 10     
            Array.toList (Array.rev sumList)
        else
            let sumList = List.toArray (List.map2 (fun x y -> x - y) a b)
            for i in 0..List.length a - 2 do
                if sumList.[i] < 0
                then 
                    sumList.[i + 1] <- sumList.[i + 1] - 1
                    sumList.[i] <- sumList.[i] + 10
            Array.toList (Array.rev sumList)
    let making_same_lengths m n = 
        if List.length m > List.length n
        then
            let lst3 = [for i in 0..List.length m - 1 -> if i < List.length n 
                                                         then rvlst2.[i]
                                                         else 0]//addition zeros to get 2 lists with the same length
            List.head lst1 :: addition m lst3
        elif List.length m < List.length n
        then
            let lst3 = [for i in 0..List.length n - 1 -> if i < List.length m
                                                            then rvlst1.[i]
                                                            else 0]
            List.head lst2 :: addition n lst3
        else 
            let pl = [|0|]//finding the biggest number to understand sign
            let finding h j = 
                for i in 0..List.length j - 1 do
                for p in 0..List.length h - 1 do
                if (h.[i] < j.[i]) && (i = p)
                then pl.[0] <- List.head j
                else pl.[0] <- List.head h
            finding lst1 lst2
            pl.[0] :: addition n m
    let l = making_same_lengths rvlst1 rvlst2
    let rec Deleting_Extra_Zeroes t =
        match t with
        | [] -> [0]
        | hd :: tl ->
             if hd = 0
             then Deleting_Extra_Zeroes tl
             else hd :: tl
    List.head l::Deleting_Extra_Zeroes (List.tail l)
main [-1; 1] [-1; 1; 0; 0] |> printfn "%A"
main [1; 6; 9; 3] [1; 2; 9; 0; 4; 5] |> printfn "%A"
main [-1; 1; 8; 9] [1; 1] |> printfn "%A"
main [1; 6; 2; 3; 4; 5; 6; 7; 8; 9; 0] [1; 1; 2; 3; 4; 5; 6; 7; 8; 9; 0] |> printfn "%A"
main [-1; 1; 0] [1; 1; 1] |> printfn "%A"