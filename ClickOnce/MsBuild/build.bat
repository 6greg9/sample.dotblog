@echo off
::SET MSBUILD="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe"
SET MSBUILD="C:\Program Files (x86)\MSBuild\14.0\bin\msbuild.exe"

SET CARWIN="Simple.Winfrom.BuildClickOnce.sln"

%MSBUILD% %CARWIN% /target:publish /p:MapFileExtensions=true /p:TrustUrlParameters=true /p:UseApplicationTrust=true /p:CreateDesktopShortcut=true /p:BootstrapperEnabled=true /p:IsWebBootstrapper=true /p:InstallFrom=Web /p:UpdateEnabled=false /p:ApplicationVersion=2017.07.27.1 /p:TargetCulture=zh-TW /p:ProductName=ClickOnce�}�o�� /p:PublisherName=�F�M���K /p:InstallUrl= /p:PublishUrl= 

pause