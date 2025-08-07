cd ..

rm -rf Builds
mkdir Builds
mkdir Builds/temp

cp ./BuildScripts/maggamelibraries.asmdef Builds/temp/
cp ./BuildScripts/package.json Builds/temp/

dotnet build MAG_GameLibraries.csproj -c Release
cp ./bin/Release/netstandard2.1/MAG_GameLibraries.dll Builds/temp/

# Create tar package
tar -czf ./Builds/maggamelibraries-v0.0.1.tgz ./Builds/temp/
