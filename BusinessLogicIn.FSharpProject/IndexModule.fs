module BusinessLogicInFSharpProject.IndexModule

open System.Net.Http
open System.Text.Json

type OCHLT =
    {
        o: float
        c: float
        h: float
        l: float
        t: float
    }

type IndexHistory =
    {
        ticker: string
        queryCount: int
        count: int
        status: string
        request_id: string
        results: List<OCHLT>
    }

// Syncronous fetching (just one stock here)
let getIndexHistory() =
    let apiKey = "tochCnfsU8BBdxYsZYAzKpR9cxs49e1N"
    let ticker = "I:NDX"
    let url = $"https://api.polygon.io/v2/aggs/ticker/{ticker}/range/1/day/2024-01-01/2024-03-10?sort=asc&limit=120&apiKey={apiKey}"
    let client = new HttpClient()
    let result = client.GetAsync(url)
    use response = result.Result.Content.ReadAsStringAsync()
    response.Result

// Parse CSV and re-arrange O,H,L,C - > H,L,O,C
let getOHLCPrices() =
    let data = JsonSerializer.Deserialize<IndexHistory>(getIndexHistory())
    data.results
    |> Seq.map (fun s -> float s.o, float s.h, float s.l, float s.c, float s.t)
    |> Seq.truncate 50

let getOHLC() =
    JsonSerializer.Deserialize<IndexHistory>(getIndexHistory())