module BusinessLogicInFSharpProject.IndexModule

type OHLC =
    {
        o: float
        c: float
        h: float
        l: float
    }

// Parse CSV and return OHLC prices
let getOHLC() =
    System.IO.File.ReadAllText($"data.csv")
    |> fun data -> data.Replace(',', '.')
    |> fun data -> data.Replace('\r', ' ')
    |> fun data -> data.Split('\n')
    |> Seq.tail
    |> Seq.map (fun s -> s.Trim())
    |> Seq.map (fun s -> s.Split(';'))
    |> Seq.map (fun s -> 
        { 
            o = float s.[0]
            h = float s.[1]
            l = float s.[2]
            c = float s.[3]
        } : OHLC)
    |> Seq.truncate 20