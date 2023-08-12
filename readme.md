# Wakatime Stats

## Contents
| Section | Description |
| --- | --- |
| [Structure](#structure) | The structure of the project |

## Structure
```mermaid
flowchart TD
    classDef presentation stroke:#f0f
    classDef api stroke:#f00
    classDef service stroke:#0f0
    classDef data stroke:#00f


    Dashboard["Dashboard
        [Langauge]: TypeScript

        The dashboard to display
        the Wakatime data
        "]:::presentation
    API["API
        [Langauge]: C# / F#

        API to access the 
        Wakatime data
        "]:::api
    synchronizer["Synchronizer
        [Langauge]: C#

        Service to fetch the 
        Wakatime data
        "]:::api
    business["Business
        [Langauge]: F# / C#

        Service to process/fetch
        the Wakatime data
        "]:::service
    stats["Data Science
        [Langauge]: F#

        Service to create
        statistics from the
        Wakatime data
        "]:::service
    datalayer["Data
        [Langauge]: C#

        Service to access
        the Wakatime data
        from the database
        "]:::data

    Dashboard --> API
    synchronizer --> business
    API --> business

    subgraph Data Access
        business --> stats
        stats --> datalayer
        business --> datalayer
        datalayer -->  database[(Database)]:::data
    end
```