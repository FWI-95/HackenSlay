# === Konfiguration ===
$organization = "FWI95"
$project = "games"
$areaPath = "games\\HackenSlay"  # Doppelte Backslashes wegen Encoding
$baseUrl = "https://dev.azure.com/$organization"
$pat = $env:DevOpsFWI95TaskPAT  # Speichere deinen PAT vorher sicher in einer Umgebungsvariable
$authHeader = @{
    Authorization = ("Basic {0}" -f [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(":$pat")))
    Accept        = "application/json"
}

# === Abfrage der aktiven PBIs & Tasks im aktuellen Sprint ===
$query = @"
SELECT
    [System.Id],
    [System.Title],
    [System.State],
    [System.WorkItemType]
FROM WorkItems
WHERE
    [System.TeamProject] = '$project'
    AND [System.AreaPath] = '$areaPath'
    AND [System.State] <> 'Closed'
    AND ([System.WorkItemType] = 'Product Backlog Item' OR [System.WorkItemType] = 'Task')
ORDER BY [System.WorkItemType], [System.Id]
"@

# === WIQL Query senden ===
$response = Invoke-RestMethod -Method Post -Uri "$baseUrl/$project/_apis/wit/wiql?api-version=7.0" -Headers $authHeader -Body (@{ query = $query } | ConvertTo-Json -Depth 10) -ContentType "application/json"

$ids = $response.workItems | Select-Object -ExpandProperty id

if (-not $ids) {
    Write-Host "⚠️ Keine aktiven PBIs oder Tasks gefunden." -ForegroundColor Yellow
    return
}

# === Details der Work Items holen ===
$workItemsUrl = "$baseUrl/_apis/wit/workitems?ids=$($ids -join ',')&api-version=7.0"
$items = Invoke-RestMethod -Method Get -Uri $workItemsUrl -Headers $authHeader

# === Ausgabe lokal speichern ===
$savePath = "$PSScriptRoot\active_workitems.json"
$items.value | ConvertTo-Json -Depth 10 | Set-Content -Path $savePath -Encoding UTF8

Write-Host "✅ Work Items gespeichert unter: $savePath" -ForegroundColor Green

