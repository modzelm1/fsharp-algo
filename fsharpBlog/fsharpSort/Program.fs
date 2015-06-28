let rec selectsort = function
   | [] -> []
   | inputList ->
        let minVal,greaterThanMinVal = List.partition ((>=) (List.min inputList)) inputList 
        List.concat [minVal; selectsort greaterThanMinVal]

//we don't know if the first element is on the right place
//so we have to check it every time
//we increase left list, decreased right list and put element from the right ot left
let rec insertsortHelper = function
    | ([],[]) -> []
    | (l,[]) -> l
    | ([],r) -> []
    | (l,r) -> 
        let h = List.head r
        let t = List.tail r
        let s, g = List.partition ((>=) h) l
        insertsortHelper (List.concat [s;[h];g], t)

let rec insertsort2 = function
   | [] -> []
   | [f] -> [f]
   | f::t ->
        insertsortHelper ([f] , t)

let rec insertsort = function
   | [] -> []
   | [first] -> [first]
   | first::second::tail ->
        let test = first - second
        match test with
        | t when t <= 0 ->
            insertsortHelper (List.concat[ [first]; [second] ] , tail)
        | t when t > 0 ->
            insertsortHelper (List.concat[ [second]; [first] ] , tail)
        | _ -> []


[<EntryPoint>]
let main argv = 
    //printfn "%A" (quicksort [1;5;23;18;9;1;3])
    printfn "%A" (selectsort [1;5;23;18;9;1;3])
    printfn "%A" (insertsort [1;5;23;18;9;1;3])
    printfn "%A" (insertsort2 [1;5;23;18;9;1;3])
    //testmin [1;5;23;18;9;1;3]
    0 // return an integer exit code
