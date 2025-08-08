cd ..

rm -rf Builds
mkdir -p Builds/package/Runtime

cp ./BuildScripts/maggamelibraries.asmdef Builds/package/
cp ./BuildScripts/package.json Builds/package/
cp -r ./BuildScripts/MetaFiles/* Builds/Package/

dotnet publish MAG_GameLibraries.csproj -c Release -f netstandard2.1
cp ./bin/Release/netstandard2.1/MAG_GameLibraries.dll Builds/package/Runtime/
cp ./bin/Release/netstandard2.1/publish/Microsoft.Extensions.DependencyInjection.dll Builds/package/Runtime/
cp ./bin/Release/netstandard2.1/publish/Microsoft.Extensions.DependencyInjection.Abstractions.dll Builds/package/Runtime/

cd Builds/
tar -czf maggamelibraries-v0.0.1.tar.gz *