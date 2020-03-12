cd /d %~dp0

::here change menu name
set menuName=MD5

set regRoot=HKEY_CLASSES_ROOT\*\shell\
set "regPath=%regRoot%%menuName%"

reg add "%regPath%" /v AppliesTo /t REG_SZ /d . /f
reg add "%regPath%\command" /d "%cd%\GenerateMD5.exe \"%%1\"" /f
pause