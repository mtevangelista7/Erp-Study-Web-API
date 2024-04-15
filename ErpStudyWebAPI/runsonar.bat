set JAVA_HOME=C:\Users\p-mesantos\Downloads\java-jdk
set PATH=%JAVA_HOME%\bin;%PATH%

dotnet sonarscanner begin /k:"TESTEAPI" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="sqp_09103ecd0b4dc7a369f93475a5194be0e3d33134"

dotnet build
 
dotnet sonarscanner end /d:sonar.token="sqp_09103ecd0b4dc7a369f93475a5194be0e3d33134"