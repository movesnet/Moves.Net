del *.nupkg

cd ..\Moves.Net
..\nuget\nuget.exe pack Moves.Net.csproj -Build -Properties Configuration=Release -OutputDirectory ..\nuget

cd ..\nuget
