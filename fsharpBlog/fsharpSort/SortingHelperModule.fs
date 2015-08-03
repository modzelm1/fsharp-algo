module SortingHelperModule
open System

let getTestList count maxVal =
    let rnd = System.Random(DateTime.Now.Millisecond)
    List.init count (fun _ -> rnd.Next (maxVal))

//compare my sorting results with .net implemented sorting function
//useful for short lists only
let testSortAlgo sortFun sortFunName =
    let listToSort = getTestList 10 10
    let sortResult1 = List.sort listToSort
    let sortResult2 = sortFun listToSort
    printfn "testing %s" sortFunName
    printfn "list to sort:          %A" listToSort
    printfn "reference sort result: %A" sortResult1
    printfn "sort result:           %A" sortResult2
    printfn "are sore and reference equal? %b" (sortResult1 = sortResult2)
    printfn "\n"

let testSortAlgoLongList sortFun sortFunName listSize =
    printfn "testing %s" sortFunName
    printfn "Generating test list ..."
    let listToSort = getTestList listSize Int32.MaxValue
    printfn "Test list generated!"
    printfn "Start sorting!"
    //let sortResult1 = List.sort listToSort
    let sortResult2 = sortFun listToSort
    //printfn "are sore and reference equal? %b" (sortResult1 = sortResult2)
    printfn "Done!"
    printfn "\n"
