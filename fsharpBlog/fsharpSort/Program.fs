module MainModule 
open System
open SortingModule
open SortingHelperModule

let reportTime t =
    printfn "list sorted in %f" t

let testSortTimes sortfun =
    let listToSort1 = SortingHelperModule.getTestList 100 Int32.MaxValue
    let listToSort2 = SortingHelperModule.getTestList 1000 Int32.MaxValue
    let listToSort3 = SortingHelperModule.getTestList 10000 Int32.MaxValue
    let listToSort4 = SortingHelperModule.getTestList 100000 Int32.MaxValue
    let listToSort5 = SortingHelperModule.getTestList 1000000 Int32.MaxValue
    
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let sortedList1 = sortfun listToSort1
    stopWatch.Stop()
    reportTime stopWatch.Elapsed.TotalMilliseconds
    stopWatch.Reset()

    stopWatch.Start()
    let sortedList2 = sortfun listToSort2
    stopWatch.Stop()
    reportTime stopWatch.Elapsed.TotalMilliseconds
    stopWatch.Reset()

    stopWatch.Start()
    let sortedList3 = sortfun listToSort3
    stopWatch.Stop()
    reportTime stopWatch.Elapsed.TotalMilliseconds
    stopWatch.Reset()

    stopWatch.Start()
    let sortedList4 = sortfun listToSort4
    stopWatch.Stop()
    reportTime stopWatch.Elapsed.TotalMilliseconds
    stopWatch.Reset()

//    stopWatch.Start()
//    let sortedList5 = sortfun listToSort5
//    stopWatch.Stop()
//    reportTime stopWatch.Elapsed.TotalMilliseconds
//    stopWatch.Reset()
//    printfn ""

[<EntryPoint>]
let main argv = 
    //testSortTimes selectsort works
    //testSortTimes quicksortFirst
    //testSortTimes quicksortLast
    //testSortTimes quicksortRandom
    testSortTimes insertsort
    testSortTimes mergeSort
    testSortTimes List.sort
    //testSortAlgoLongList selectsort "selectsort" 80000000
    //testSortAlgoLongList selectsortFold "selectsortFold" 80000000
    //testSortAlgoLongList insertsort "insertsort" 80000000
//    testSortAlgo quicksortFirst "quicksortFirst"
//    testSortAlgo quicksortLast "quicksortLast"
//    testSortAlgo quicksortRandom "quicksortRandom"
//    testSortAlgo selectsort "selectsort"
//    testSortAlgo insertsort "insertsort"
//    testSortAlgo mergeSort "mergeSort"
//    testSortAlgo selectsortFold "selectsortFold"
//    testSortAlgo insertsortFold "insertsortFold"
    0
