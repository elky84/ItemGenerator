rmdir output /S /Q

REM ������ ��ȯ ����

excel2dotnet -d "%cd%" -n ItemGenerator.Types -u "using EnumExtend;" -e -l
if ERRORLEVEL 1 GOTO END

excel2dotnet -d "%cd%" -n ItemGenerator -u "using EnumExtend;" "using ItemGenerator.Types;" -l
if ERRORLEVEL 1 GOTO END

REM  ������ ��ȯ ��


REM ���� ����

excel2dotnet -d "%cd%" -v
if ERRORLEVEL 1 GOTO END

REM ���� ��


REM ������ ���� ����

del /Q /F "..\ItemGenerator\Types\*.cs"
robocopy "output\Enum" "..\ItemGenerator\Types" "*.cs" /E >> .\\output\\ExcelCopyLog.txt

del /Q /F "ItemGenerator\MasterData\*.cs"
robocopy "output\MasterData" "..\ItemGenerator\MasterData" "*.cs" /E >> .\\output\\ExcelCopyLog.txt

del /Q /F "ItemGenerator\json\*.json"
robocopy "output\MasterData" "..\ItemGenerator\json" "*.json" /E >> .\\output\\ExcelCopyLog.txt

cd ..

REM ������ ���� ��

:END
del *.temp

pause