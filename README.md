# Valheim Mod Patches

### Features
- Roof and fire checks disabled for crafting station
- Fire, exposure, and wet checks disabled for bed
- Carry all items through portal

### Tools
- [BepInEx Pack Valheim](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/)- Inject and Run DLLs
- [Harmony](https://harmony.pardeike.net/) (incl. with BepInEx) - Patching methods at runtime
- [ILSpy](https://github.com/icsharpcode/ILSpy) - Decompiling Unity Files
- [MS Visual Studio](https://visualstudio.microsoft.com/) - Code & Build C# (with .NET desktop environment)

### Setup
- Create `Class Library (.NET Framework)` in Visual Studio  
- Copy all files from `BepInExPack_Valheim` to game folder's root
- Copy below DLL files to `libs` folder in the project
```
Valheim\BepInEx\core\0Harmony.dll
Valheim\BepInEx\core\BepInEx.dll
Valheim\valheim_Data\Managed\assembly_valheim.dll
Valheim\valheim_Data\Managed\UnityEngine.dll
Valheim\valheim_Data\Managed\UnityEngine.CoreModule.dll
```
- Add references to above files in Visual Studio
- Rename `.cs` file to mod class name and patches go in here

### Installing the Mod
- Copy DLL from `\bin\Debug` with the same name as the mod class
- Paste in `Valheim\BepInEx\plugins`
- Check if it's loaded during game startup in BepInEx console

### References
- https://youtu.be/kd4a5ED6HWU
- https://harmony.pardeike.net/articles/patching-injections.html
