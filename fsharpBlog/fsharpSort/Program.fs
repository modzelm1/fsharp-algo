module MainModule 
open System
open SortingHelperModule
open SortingModule

let reportTime t =
    printfn "list sorted in %f" t

let restartStopWatch (s: System.Diagnostics.Stopwatch) =
    s.Stop()
    let elapsedTime = s.Elapsed.TotalMilliseconds
    s.Reset()
    elapsedTime

let testSortTimes sortfun =
    let listToSort1 = SortingHelperModule.getTestList 100 Int32.MaxValue
    let listToSort2 = SortingHelperModule.getTestList 1000 Int32.MaxValue
    let listToSort3 = SortingHelperModule.getTestList 10000 Int32.MaxValue
    let listToSort4 = SortingHelperModule.getTestList 100000 Int32.MaxValue

    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    stopWatch.Stop();
    stopWatch.Reset();
    
    stopWatch.Start()
    let sortedList1 = sortfun listToSort1
    reportTime (restartStopWatch stopWatch)

    stopWatch.Start()
    let sortedList2 = sortfun listToSort2
    reportTime (restartStopWatch stopWatch)

    stopWatch.Start()
    let sortedList3 = sortfun listToSort3
    reportTime (restartStopWatch stopWatch)

    stopWatch.Start()
    let sortedList4 = sortfun listToSort4
    reportTime (restartStopWatch stopWatch)

[<EntryPoint>]
let main argv = 
    //testSortTimes selectsort //works
    //testSortTimes quicksortFirst
    //testSortTimes quicksortLast
    //testSortTimes quicksortRandom
    //testSortTimes insertsort
    //testSortTimes mergeSort
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
