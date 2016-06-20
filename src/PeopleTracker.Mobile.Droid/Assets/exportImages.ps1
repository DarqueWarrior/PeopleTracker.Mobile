###########################################################
# This is to unzip and copy files downloaded from 
# http://romannurik.github.io/AndroidAssetStudio/index.html
# into the correct location in my Android projects.

# So I can unzip files
[Reflection.Assembly]::LoadWithPartialName("System.IO.Compression.FileSystem")

$baseFolder = pwd

###########################################################
# Unzips file into the $baseFolder folder
Function UnZip ($zipFile)
{
    # Used to open files
    [IO.Compression.ZipFile]::ExtractToDirectory($zipFile, $baseFolder)
}

$zips = Get-ChildItem -Filter *.zip | Select-Object FullName

foreach($zip in $zips)
{
    UnZip -zipFile $zip.FullName

    Copy-Item .\res\drawable-hdpi\*.* ..\Resources\drawable\ -Verbose -Recurse -Force
    Copy-Item .\res\drawable-hdpi\*.* ..\Resources\drawable-hdpi\ -Verbose -Recurse -Force
    Copy-Item .\res\drawable-xhdpi\*.* ..\Resources\drawable-xhdpi\ -Verbose -Recurse -Force
    Copy-Item .\res\drawable-xxhdpi\*.* ..\Resources\drawable-xxhdpi\ -Verbose -Recurse -Force

    Remove-Item .\res -Recurse -Force
}