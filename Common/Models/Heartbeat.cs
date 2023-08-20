using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Models.Interface;
using Newtonsoft.Json;

namespace Common.Models;

public class Heartbeat : IEntity
{
    public int Id { get; set; }

    [JsonProperty("id")]
    public string? WakatimeId { get; set; }

    [JsonProperty("branch")]
    public string? Branch { get; set; }

    [JsonProperty("category")]
    public string? Category { get; set; }

    [JsonProperty("created_at")]
    public string? CreatedAt { get; set; }

    [JsonProperty("cursorpos")]
    public int Cursorpos { get; set; }

    // [JsonProperty("dependencies")]
    [NotMapped]
    public IEnumerable<string>? Dependencies { get; set; }

    [JsonProperty("entity")]
    public string? Entity { get; set; }

    [JsonProperty("is_write")]
    public bool IsWrite { get; set; }

    [JsonProperty("language")]
    public string? Language { get; set; }

    [JsonProperty("lineno")]
    public int Lineno { get; set; }

    [JsonProperty("lines")]
    public int Lines { get; set; }

    [JsonProperty("machine_name_id")]
    public string? MachineNameId { get; set; }

    [JsonProperty("project")]
    public string? Project { get; set; }

    [JsonProperty("project_root_count")]
    public int ProjectRootCount { get; set; }

    [JsonProperty("time")]
    public double Time { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("user_agent_id")]
    public string? UserAgentId { get; set; }

    [JsonProperty("user_id")]
    public string? UserId { get; set; }
}
