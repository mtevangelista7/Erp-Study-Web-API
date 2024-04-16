set JAVA_HOME=C:\Users\p-mesantos\Downloads\java-jdk
set PATH=%JAVA_HOME%\bin;%PATH%

@REM dotnet sonarscanner begin /k:"TESTEAPI" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="sqp_09103ecd0b4dc7a369f93475a5194be0e3d33134"
@REM 
@REM dotnet build
@REM  
@REM dotnet sonarscanner end /d:sonar.token="sqp_09103ecd0b4dc7a369f93475a5194be0e3d33134"

dotnet sonarscanner begin /k:"ErpStudyTest" /d:sonar.host.url="http://localhost:9000" /d:sonar.token="sqp_398630627b67d39647765f186f35c3a967345571" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml
dotnet build --no-incremental
dotnet-coverage collect "dotnet test" -f xml -o "coverage.xml"
dotnet sonarscanner end /d:sonar.token="sqp_398630627b67d39647765f186f35c3a967345571"