﻿namespace Common.Models;

// {
// "branch": "main",
// "category": "coding",
// "created_at": "2023-08-13T10:44:46Z",
// "cursorpos": 1,
// "dependencies": [],
// "entity": "D:/My Projects/2023-08/PresentationPages/Vanarkel.UI.Jobs/Vanarkel.UI.Jobs.Server/Pages/Counter.razor",
// "id": "3ba962c3-a54d-43b4-8b16-3784f25ec883",
// "is_write": false,
// "language": "Blazor",
// "lineno": 1,
// "lines": 20,
// "machine_name_id": "3263e671-d8cf-4e2d-ae9c-2bafc0c091c1",
// "project": "Vanarkel.UI.Jobs",
// "project_root_count": 5,
// "time": 1691923485.533802,
// "type": "file",
// "user_agent_id": "52bc8d62-943c-49c3-bf82-c6fba4703c00",
// "user_id": "261ee501-1b33-464c-8873-6be422308f2f"
// }

public class Heartbeat
{
    public string Branch { get; set; }
    public string Category { get; set; }
    public string CreatedAt { get; set; }
    public int Cursorpos { get; set; }
    public string[] Dependencies { get; set; }
    public string Entity { get; set; }
    public string Id { get; set; }
    public bool IsWrite { get; set; }
    public string Language { get; set; }
    public int Lineno { get; set; }
    public int Lines { get; set; }
    public string MachineNameId { get; set; }
    public string Project { get; set; }
    public int ProjectRootCount { get; set; }
    public double Time { get; set; }
    public string Type { get; set; }
    public string UserAgentId { get; set; }
    public string UserId { get; set; }
}