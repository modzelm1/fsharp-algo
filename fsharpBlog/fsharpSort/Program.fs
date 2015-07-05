open System

let rec selectsort = function
   | [] -> []
   | inputList ->
        let minVal,gtMinVal = List.partition (fun e -> e = (List.min inputList)) inputList 
        List.concat [minVal; selectsort gtMinVal]

let rec selectsortFold = function
   | [] -> []
   | [f] -> [f]
   | l ->
        fst (
            l |> 
                List.fold (
                    fun acc i ->
                        let minVal,gtMinVal = 
                            List.partition (fun e -> e = List.min (snd acc)) (snd acc) 
                        (List.concat[fst acc; minVal], gtMinVal)
                        ) ([], l))

let rec insertsortHelper = function
    | ([],[]) -> []
    | (l,[]) -> l
    | ([],r) -> []
    | (l,r) -> 
        let h = List.head r
        let t = List.tail r
        let s, g = List.partition ((>=) h) l
        insertsortHelper (List.concat [s;[h];g], t)

let rec insertsort = function
   | [] -> []
   | [f] -> [f]
   | f::t ->
        insertsortHelper ([f] , t)

let rec insertsortFold = function
   | [] -> []
   | [f] -> [f]
   | l ->
        l |> List.fold (fun acc i ->
                            let s, g = List.partition ((>=) i) acc 
                            List.concat [s;[i];g]
                            ) []

let rec quicksortFirst = function
   | [] -> []                         
   | first::rest -> 
        let smaller,larger = List.partition ((>=) first) rest 
        List.concat [quicksortFirst smaller; [first]; quicksortFirst larger]

let rec quicksortLast = function
   | [] -> []                         
   | inputList -> 
        let revList = List.rev inputList 
        quicksortFirst (List.concat [[revList.Head]; List.rev revList.Tail])

//stolen from: http://stackoverflow.com/questions/2889961/f-insert-remove-item-from-list
let removeAt index input =
  input 
  // Associate each element with a boolean flag specifying whether 
  // we want to keep the element in the resulting list
  |> List.mapi (fun i el -> (i <> index, el)) 
  // Remove elements for which the flag is 'false' and drop the flags
  |> List.filter fst |> List.map snd

let rec quicksortRandom = function
   | [] -> []                         
   | inputList ->
        let rnd = Random() 
        let randomIndex = rnd.Next(inputList.Length)
        let ravdomVal = List.nth inputList randomIndex
        let listWithoutRandomVal = removeAt randomIndex inputList
        quicksortFirst (List.concat [[ravdomVal]; listWithoutRandomVal])

[<EntryPoint>]
let main argv = 
    //printfn "%A" (quicksortFirst [1;5;23;18;9;1;3])
    //printfn "%A" (quicksortLast [1;5;23;18;9;1;3])
    //printfn "%A" (quicksortRandom [1;5;23;18;9;1;3])
    //printfn "%A" (selectsort [1;5;23;18;9;1;3])
    //printfn "%A" (insertsortFold [1;5;23;18;9;1;3])
    printfn "%A" (selectsortFold [1;5;23;18;9;1;3])
    //printfn "%A" (insertsort [1;5;23;18;9;1;3])
    0 // return an integer exit code
