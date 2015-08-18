open System

let suffle (inputList: int List) = 
        let rnd = System.Random DateTime.Now.Millisecond
        List.fold (fun acc item -> 
                        let randomCardIndex = rnd.Next (fst acc, inputList.Length)
                        (fst acc) + 1 ,
                        List.mapi (fun tmpIndex tmpItem -> 
                            match tmpIndex with 
                                | t when t = randomCardIndex -> (snd acc).[fst acc]
                                | t when t = (fst acc) -> (snd acc).[randomCardIndex]
                                | _ -> tmpItem ) (snd acc) 
                     ) 
                     (0, inputList) 
                     inputList



[<EntryPoint>]
let main argv = 

    let toShuffle1 = [1; 2; 3; 4; 5; 6; 7; 8; 9 ]
    let toShuffle2 = [1; 2; 3; 4; 5; 6; 7; 8; 9 ]
    let toShuffle3 = [1; 2; 3; 4; 5; 6; 7; 8; 9 ]

    printfn "%A" (suffle toShuffle1)
    printfn "%A" (suffle toShuffle2)
    printfn "%A" (suffle toShuffle3)

    0 // return an integer exit code
    