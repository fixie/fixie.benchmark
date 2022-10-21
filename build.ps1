$ErrorActionPreference = "Stop"

function step($command) {
    write-host ([Environment]::NewLine + $command.ToString().Trim()) -fore CYAN
    & $command
    if ($lastexitcode -ne 0) { throw $lastexitcode }
}

step { dotnet --version }
step { dotnet tool restore }

step { dotnet clean src -c Release --nologo -v minimal }
step { dotnet build src -c Release --nologo }

step { dotnet fixie Fixie.Tests -c Release --no-build }
step { dotnet test src/xUnit.Tests -c Release --no-build --nologo }
