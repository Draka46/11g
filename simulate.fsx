
open System
#load "preditorPrey.fs"
open preditorPrey

[<EntryPoint>]
let main argv =
    if (argv.Length < 5) then
      printfn "This program takes 5 arguments to run."
      1
    else
      let input = Array.toList argv

      let field = Field(int input.[0], int input.[1], int input.[2],
                        int input.[3], int input.[4])
      field.createAnimals

      let output = None // Incomplete (end result to print, if any)
    
      if output <> None then
        printfn "%A" output
        0
      else
        printfn "An exception took place."
        1