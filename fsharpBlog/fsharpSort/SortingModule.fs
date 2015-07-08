module SortingModule
open System

let rec selectsort = function
   | [] -> []
   | inputList ->
        let m = List.min inputList //????(List.min inputList)
        let minVal,gtMinVal = List.partition (fun e -> e = m) inputList 
        List.concat [minVal; selectsort gtMinVal]

let rec selectsortFold = function
   | [] -> []
   | [f] -> [f]
   | l ->
        fst ( 
            l |> 
                List.fold (
                    fun acc i ->
                        let minVal,gtMinVal = List.partition (fun e -> e = List.min (snd acc)) (snd acc) 
                        (List.concat[fst acc; minVal], gtMinVal)
                )([], l))

let rec insertsortHelper = function
    | ([],[]) -> []
    | (l,[]) -> l
    | ([],r) -> []
    | (l,r) -> 
        let h = List.head r
        let t = List.tail r
        let s, g = List.partition (fun e -> e <= h) l//((>=) h) l
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

let rec mergeSortWorker = function
    | acc,[],[] -> acc
    | acc,l,[] -> List.concat [acc; l]
    | acc,[],r -> List.concat [acc; r]
    | acc,l, r ->
          let test = List.head l - List.head r
          match test with
            | t when t <= 0 ->
                mergeSortWorker (List.concat [acc; [List.head l]], List.tail l, r)
            | t when t > 0 ->
                mergeSortWorker (List.concat [acc; [List.head r]], l, List.tail r)
            | _ -> []

let rec mergeSort = function
    | [] -> []
    | [e] -> [e]
    | l ->
        let m = (List.length l)/2
        let leftPrt = l |> Seq.take m |> Seq.toList
        let rightPart = l |> Seq.skip m |> Seq.toList
        let fs = leftPrt |> mergeSort
        let ss = rightPart |> mergeSort
        mergeSortWorker([], fs, ss)