open System

let suffleList (inputList: int List) = 
        let rnd = System.Random DateTime.Now.Millisecond
        snd (List.fold (fun acc item -> 
                        let randomCardIndex = rnd.Next (fst acc, inputList.Length)
                        (fst acc) + 1 ,
                        List.mapi (fun tmpIndex tmpItem -> 
                            match tmpIndex with 
                                | t when t = randomCardIndex -> (snd acc).[fst acc]
                                | t when t = (fst acc) -> (snd acc).[randomCardIndex]
                                | _ -> tmpItem ) (snd acc) 
                     ) 
                     (0, inputList) 
                     inputList)

//let suffleArrayTest (inputArray: int[]) = 
//        let rnd = System.Random DateTime.Now.Millisecond
//        snd (Array.fold (fun acc item -> 
//                            let randomCardIndex = rnd.Next (fst acc, inputArray.Length)
//                            let tmp = inputArray.[randomCardIndex]
//                            inputArray.[randomCardIndex] <- inputArray.[fst acc]
//                            inputArray.[fst acc] <- tmp
//                            ((fst acc) + 1 , inputArray)
//                        ) 
//                     (0, inputArray) inputArray)

let suffleArray (inputArray: int[]) = 
        let rnd = System.Random DateTime.Now.Millisecond
        inputArray |> Array.fold (fun acc item -> 
                            let randomCardIndex = rnd.Next (acc, inputArray.Length)
                            let tmp = inputArray.[randomCardIndex]
                            inputArray.[randomCardIndex] <- inputArray.[acc]
                            inputArray.[acc] <- tmp
                            acc + 1
                        ) 0 
         |> ignore

let add resultSpace a b =
    let r = new Random(DateTime.Now.Millisecond)
    let loopList = [1..resultSpace]
    List.reduce (fun acc elem ->
                     let ra = r.Next(resultSpace)
                     let rb = r.Next(resultSpace)
                     match (ra, rb) with 
                        | x when fst x < a || snd x < b -> acc + 1
                        | _ -> acc                
                ) loopList

let multiply varMaxVal resultSpace a b =
    let r = new Random(DateTime.Now.Millisecond)
    let loopList = [1..resultSpace]
    List.reduce (fun acc elem ->
                     let ra = r.Next(varMaxVal)
                     let rb = r.Next(varMaxVal)
                     match (ra, rb) with 
                        | x when fst x < a && snd x < b -> acc + 1
                        | _ -> acc                
                ) loopList

[<EntryPoint>]
let main argv = 

    let toShuffleList = [1..10]
    let toShuffleArray = [|1..10|]
    let toShuffleArray2 = [|1..10|]

    printfn "input:  %A" (toShuffleList)
    printfn "result: %A" (suffleList toShuffleList)

    printfn ""

    printfn "input:  %A" (toShuffleArray)
    suffleArray toShuffleArray
    printfn "result: %A" (toShuffleArray)


//    let loopList = [1..1000]
//    let result = List.reduce (fun acc elem -> acc + (add 200 36 22)) loopList
//    printfn "add result: %A" (result/1000)
//
//    let loopList = [1..1000]
//    let result = List.reduce (fun acc elem -> acc + (multiply 100 10000 36 22)) loopList
//    printfn "multiply result: %A" (result/1000)

    0 // return an integer exit code
    