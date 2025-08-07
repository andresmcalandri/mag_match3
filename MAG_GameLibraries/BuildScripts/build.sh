cd ..

rm -rf Builds
mkdir -p Builds/package/Runtime

cp ./BuildScripts/maggamelibraries.asmdef Builds/package/
cp ./BuildScripts/package.json Builds/package/

dotnet build MAG_GameLibraries.csproj -c Release
cp ./bin/Release/netstandard2.1/MAG_GameLibraries.dll Builds/package/Runtime/

cd Builds/
tar -czf maggamelibraries-v0.0.1.tgz -C package .