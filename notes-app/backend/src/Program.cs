using System.Text;
using System.Text.Json;
using NotesApp;

var service = new NoteService();
var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};

while(true)
{
    var line = Console.ReadLine();

    if(line == null) break;
    if(line.Trim() == "") continue;

    NoteResponse response;

    try
    {
        var request = JsonSerializer.Deserialize<NoteRequest>(line, options)!;

        response = request.Command switch
        {
            "list" => new NoteResponse {Ok = true, Items = service.ListNotes(request.Folder!)},
            "read" => new NoteResponse {Ok = true, Data = service.ReadNote(request.Path!)},
            "save"   => SaveAndRespond(service, request),
            "delete" => DeleteAndRespond(service, request),
            "search" => new NoteResponse {Ok = true, Items = service.SearchNotes(request.Folder!, request.Query!)},
            _         => new NoteResponse {Ok = true, Error = "Unknown command"}
        };
    }
    catch (Exception ex)
    {
        response = new NoteResponse {Ok = false, Error = ex.Message};
    }

    Console.WriteLine(JsonSerializer.Serialize(response));
}

static NoteResponse SaveAndRespond(NoteService service, NoteRequest request)
{
    service.SaveNote(request.Path!, request.Content! ?? "");
    return new NoteResponse {Ok = true};
}

static NoteResponse DeleteAndRespond(NoteService service, NoteRequest request)
{
    service.DeleteNote(request.Path!);
    return new NoteResponse {Ok = true};
}