[![Website](https://img.shields.io/website-up-down-green-red/http/shields.io.svg?label=elky-essay)](https://elky84.github.io)
![Made with](https://img.shields.io/badge/made%20with-.NET8-blue.svg)

![GitHub forks](https://img.shields.io/github/forks/elky84/ItemGenerator.svg?style=social&label=Fork)
![GitHub stars](https://img.shields.io/github/stars/elky84/ItemGenerator.svg?style=social&label=Stars)
![GitHub watchers](https://img.shields.io/github/watchers/elky84/ItemGenerator.svg?style=social&label=Watch)
![GitHub followers](https://img.shields.io/github/followers/elky84.svg?style=social&label=Follow)

![GitHub](https://img.shields.io/github/license/mashape/apistatus.svg)
![GitHub repo size in bytes](https://img.shields.io/github/repo-size/elky84/ItemGenerator.svg)
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/elky84/ItemGenerator.svg)

# ItemGenerator

랜덤 아이템 생성기입니다.

정의된 데이터 (엑셀 기반. excel 폴더내에 배치) 기반으로, 아이템을 생성해 콘솔 출력해줍니다.

현재 구현은 정의된 확률에 따라 아이템 타입을 결정짓고, 아이템 등급을 결정 지은 뒤, 해당 등급에 맞는 아이템, 등급에 맞는 옵션을 임의로 골라 부여합니다.

## required

* [dotnet 8 rumtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* [ExcelToDotNet](https://github.com/elky84/ExcelToDotNet)
  * `dotnet tool install -g ExcelCli`

## Excel data To Json & Code

execute `excel_data_convert.bat`

## Execute CLI options (execute build file)

### Count (-n)

`Cli -n 10000`
