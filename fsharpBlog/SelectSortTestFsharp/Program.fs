open System

let reportTime (c:int) t =
    printfn "%i elements sorted in %f" c t

let restartStopWatch (s: System.Diagnostics.Stopwatch) =
    s.Stop()
    let elapsedTime = s.Elapsed.TotalMilliseconds
    s.Reset()
    elapsedTime

let getTestList count maxVal =
    let rnd = System.Random(DateTime.Now.Millisecond)
    List.init count (fun _ -> rnd.Next (10))

let testSorting (s: System.Diagnostics.Stopwatch) sortFunc listToSort =
    s.Start()
    let soredList1 = sortFunc listToSort
    reportTime (List.length listToSort)(restartStopWatch s)

let rec selectsort_fast = function
   | [] -> []
   | inputList ->
        let m = List.min inputList
        let minVal,gtMinVal = List.partition (fun e -> e = m) inputList 
        List.concat [minVal; selectsort_fast gtMinVal]

let rec selectsort_slow = function
   | [] -> []
   | inputList ->
        let minVal,gtMinVal = List.partition (fun e -> e = (List.min inputList)) inputList 
        List.concat [minVal; selectsort_slow gtMinVal]


[<EntryPoint>]
let main argv = 
    let listToSort1 = getTestList 100 10000
    let listToSort2 = getTestList 1000 10000
    let listToSort3 = getTestList 10000 10000

    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    restartStopWatch stopWatch |> ignore
    
    //To avoid overhead. It is probably  caused by JIT. 
    //When the function is first called it is compiled by JIT and then stored in cache.
    selectsort_fast listToSort1 |> ignore 
    selectsort_slow listToSort1 |> ignore

    printfn "Starting selectsort_fast"
    testSorting stopWatch selectsort_fast listToSort1
    testSorting stopWatch selectsort_fast listToSort2
    testSorting stopWatch selectsort_fast listToSort3
    printfn "selectsort_fast done"

    printfn ""

    printfn "Starting selectsort_slow"
    testSorting stopWatch selectsort_slow listToSort1
    testSorting stopWatch selectsort_slow listToSort2
    testSorting stopWatch selectsort_slow listToSort3
    printfn "selectsort_slow done"

    0 // return an integer exit code
