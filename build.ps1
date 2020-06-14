. .\build-helpers

$authors = "Patrick Lioi"
$copyright = copyright 2019 $authors
$configuration = 'Release'

main {
    mit-license $copyright
    exec { dotnet --version }
    exec { dotnet tool restore }

    exec { dotnet clean src -c $configuration --nologo -v minimal }
    exec { dotnet build src -c $configuration --nologo }

    exec { dotnet fixie Fixie.Tests -c $configuration --no-build }
    exec { dotnet test src/xUnit.Tests -c $configuration --no-build }
}