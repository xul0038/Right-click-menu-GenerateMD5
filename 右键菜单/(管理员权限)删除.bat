set menuName=MD5

set regRoot=HKEY_CLASSES_ROOT\*\shell\
set "regPath=%regRoot%%menuName%"

reg delete "%regPath%" /f
pause