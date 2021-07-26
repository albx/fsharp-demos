// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open BasicFunctions

let printGreeting name = printfn "Hello %s from F#" name

type BST<'T> =
    | Empty
    | Node of value:'T * left: BST<'T> * right: BST<'T>

type ContactCard = 
    { Name     : string
      Phone    : string
      Verified : bool }

type Suit = 
    | Hearts 
    | Clubs 
    | Diamonds 
    | Spades

/// A Discriminated Union can also be used to represent the rank of a playing card.
type Rank = 
    /// Represents the rank of cards 2 .. 10
    | Value of int
    | Ace
    | King
    | Queen
    | Jack

    static member GetAllRanks() = 
        [ yield Ace
          for i in 2 .. 10 do yield Value i
          yield Jack
          yield Queen
          yield King ]

type Card = { Suit: Suit; Rank: Rank }


[<EntryPoint>]
let main argv =
    printGreeting "Alberto"

    let helloWorld = "Hello World"
    let substring = helloWorld.[0..6]
    printfn $"{substring}"

    let blackSquares = 
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do 
                  if (i+j) % 2 = 1 then 
                      yield (i, j) ]

    let numberList = [ 1 .. 1000 ]
    let squares = 
        numberList 
        |> List.map (fun x -> x*x) 

    let daysList = 
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do 
                  yield System.DateTime(2017, month, day) ]

    // Print the first 5 elements of 'daysList' using 'List.take'.
    printfn $"The first 5 days of 2017 are: {daysList |> List.take 5 |> List.map (fun x -> x.ToShortDateString())}"

    //let array = Array.init 10 (fun x -> x*2)
    //printfn $"{array}"

    let contact = { Name = "Alberto"; Phone = "1234"; Verified = true; }
    let contact2 = { Name = "Alberto"; Phone = "1234"; Verified = true; }

    let contact3 = 
        { contact with 
            Phone = "(206) 555-0112"
            Verified = true }

    printfn $"{contact = contact3}"

    let fullDeck = 
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do 
                  yield { Suit=suit; Rank=rank } ]

    /// This example converts a 'Card' object to a string.
    let showPlayingCard (c: Card) = 
        let rankString = 
            match c.Rank with 
            | Ace -> "Ace"
            | King -> "King"
            | Queen -> "Queen"
            | Jack -> "Jack"
            | Value n -> string n
        let suitString = 
            match c.Suit with 
            | Clubs -> "clubs"
            | Diamonds -> "diamonds"
            | Spades -> "spades"
            | Hearts -> "hearts"
        rankString  + " of " + suitString

    /// This example prints all the cards in a playing deck.
    let printAllCards() = 
        for card in fullDeck do 
            printfn $"{showPlayingCard card}"

    printAllCards()
    
    /// Check if an item exists in the binary search tree.
    /// Searches recursively using Pattern Matching.  Returns true if it exists; otherwise, false.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // Check the left subtree.
            else (exists item right) // Check the right subtree.
    
    /// Inserts an item in the Binary Search Tree.
    /// Finds the place to insert recursively using Pattern Matching, then inserts a new node.
    /// If the item is already present, it does not insert anything.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // No need to insert, it already exists; return the node.
            elif item < x then Node(x, insert item left, right) // Call into left subtree.
            else Node(x, left, insert item right) // Call into right subtree.

    0 // return an integer exit code