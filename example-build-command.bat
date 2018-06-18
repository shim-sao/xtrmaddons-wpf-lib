if $(ConfigurationName) == Debug ( call "$(ProjectDir)autoexec.debug.bat" )
if $(ConfigurationName) == Release ( call "$(ProjectDir)autoexec.release.bat" )

:: Command to add to build
set ConfigurationName=$(ConfigurationName)
set ProjectDir=$(ProjectDir)
set ProjectName=$(ProjectName)
set SolutionDir=$(SolutionDir)
set SolutionName=$(SolutionName)
set TargetDir=$(TargetDir)
set TargetName=$(TargetName)
set TargetPath=$(TargetPath)
call "$(ProjectDir)autoexec.bat"