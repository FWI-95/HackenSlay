#!/usr/bin/env bash
set -e

# Install .NET 8 SDK
sudo apt-get update
sudo apt-get install -y wget apt-transport-https
wget https://packages.microsoft.com/config/ubuntu/24.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0

# Install SDL and OpenAL
sudo apt-get install -y libsdl2-dev libsdl2-image-dev libsdl2-mixer-dev libsdl2-ttf-dev libopenal-dev

# Restore dotnet tools and build content
dotnet tool restore
dotnet mgcb /@:Content/Content.mgcb

# Optionally build the project when --build is passed
if [ "$1" == "--build" ]; then
    dotnet build
fi
