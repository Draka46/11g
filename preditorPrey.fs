
module preditorPrey

open System

[<AbstractClass>]
type Animal (loc : int*int, spe : string) = class
  let mutable loc = loc
  member this.location with get() = loc and set(x) = loc <- x
  member this.species = spe
  
  abstract member multiplyCheck : bool

  abstract member checkTile : Animal -> bool
end

type Mice (loc : int*int, mulC : int) = class
  inherit Animal (loc, "mice")
  let multiplyCount = mulC
  let mutable _count = 0
  member this.count with get() = _count and set(x) = _count <- x

  override this.multiplyCheck : bool =
    if (_count = multiplyCount) then
      _count <- 0
      true
    else
      false
  
  override this.checkTile (animal : Animal) =
    false
end

type Owl (loc : int*int) = class
  inherit Animal (loc, "owl")
  
  override this.multiplyCheck : bool =
    false

  override this.checkTile (animal : Animal) : bool =
    if (animal.species = "mice") then true
    else false
end

type Field (n : int, T : int, p : int, M : int, O: int) = class
  let rnd = System.Random()
  let mutable _animals = []
  member this.animals with get() = _animals and set(x) = _animals <- x

  member this.spawnLocation (lst : Animal List) : (int*int) =
    let mutable loc = (rnd.Next n, rnd.Next n)
    while (List.forall (fun (x : Animal) -> 
        if x.location = loc then true else false) lst) do 
          loc <- (rnd.Next n, rnd.Next n)
    loc

  member this.createAnimals =
    for i = 0 to O do
      _animals <- _animals @ [(Owl(this.spawnLocation _animals) :> Animal)]
    for i = 0 to M do
      _animals <- _animals @ [(Mice(this.spawnLocation _animals, p) :> Animal)]
  
  member this.multiplyMouse =
    _animals <- _animals @ [(Mice(this.spawnLocation _animals, p) :> Animal)]

  member this.simulate = 
    for i = 0 to T do
      // Incomplete.
      // Check if animals multiply
      // If not, get move-to coordinates for animals (random adjacent coordinate)
      // If tile is non-empty, call checkTile for whether tile is appropriate
      // Delete animals (mice) that are in a tile that another animal (owl) moved onto
      // Update location
      do printf "" // ignore (keeps visual studio from complaining)
end
