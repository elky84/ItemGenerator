rmdir output /S /Q

REM 데이터 변환 시작

excel2dotnet -d "%cd%" -n ItemGenerator.Types -u "using EnumExtend;" -e -l
if ERRORLEVEL 1 GOTO END

excel2dotnet -d "%cd%" -n ItemGenerator -u "using EnumExtend;" "using ItemGenerator.Types;" -l
if ERRORLEVEL 1 GOTO END

REM  데이터 변환 끝


REM 검증 시작

excel2dotnet -d "%cd%" -v
if ERRORLEVEL 1 GOTO END

REM 검증 끝


REM 데이터 복사 시작

del /Q /F "..\ItemGenerator\Types\*.cs"
robocopy "output\Enum" "..\ItemGenerator\Types" "*.cs" /E >> .\\output\\ExcelCopyLog.txt

del /Q /F "ItemGenerator\MasterData\*.cs"
robocopy "output\MasterData" "..\ItemGenerator\MasterData" "*.cs" /E >> .\\output\\ExcelCopyLog.txt

del /Q /F "ItemGenerator\json\*.json"
robocopy "output\MasterData" "..\ItemGenerator\json" "*.json" /E >> .\\output\\ExcelCopyLog.txt

cd ..

REM 데이터 복사 끝

:END
del *.temp

pause