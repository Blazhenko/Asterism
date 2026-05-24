using System.Text.Json.Serialization;

namespace NotesApp;

    public class NoteRequest
    {
        [JsonPropertyName("command")]
        public string Command {get;set;} = "";
        [JsonPropertyName("path")]
        public string? Path {get;set;}
        [JsonPropertyName("content")]
        public string? Content {get;set;}
        [JsonPropertyName("query")]
        public string? Query {get;set;}
        [JsonPropertyName("folder")]
        public string? Folder {get;set;}
    }

    public class NoteResponse
    {
        [JsonPropertyName("ok")]
        public bool Ok {get;set;}
        [JsonPropertyName("data")]
        public string? Data {get;set;}
        [JsonPropertyName("items")]
        public string[]? Items {get;set;}
        [JsonPropertyName("error")]
        public string? Error {get;set;}
    }

