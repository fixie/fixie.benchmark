. .\build-helpers

$authors = "Patrick Lioi"
$copyright = copyright 2019 $authors
$configuration = 'Release'

main {
    mit-license $copyright
    exec { dotnet --version }

    exec { dotnet clean src -c $configuration --nologo -v minimal }
    exec { dotnet build src -c $configuration --nologo }

    exec { dotnet fixie --configuration $configuration --no-build } src/Fixie.Tests
    exec { dotnet test --configuration $configuration --no-build } src/xUnit.Tests
}