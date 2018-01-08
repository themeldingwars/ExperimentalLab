SET sourceDir="%cd%/packages"
SET destDir="%cd%/Flare/Packages"
SET remDirCmd=rmDir %destDir%

if not exist %destDir% mklink /j %destDir% %sourceDir%

pause