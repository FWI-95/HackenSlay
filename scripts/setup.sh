#!/bin/bash
set -e

echo "Installing system dependencies..."
sudo apt-get update
sudo apt-get install -y wget unzip libgl1-mesa-dev libxrandr-dev libxinerama-dev libxcursor-dev libxi-dev

echo "Installing .NET SDK..."
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --channel 8.0
export DOTNET_ROOT=$HOME/.dotnet
export PATH=$PATH:$HOME/.dotnet

echo "Installing Node.js and npm..."
curl -fsSL https://deb.nodesource.com/setup_20.x | sudo -E bash -
sudo apt-get install -y nodejs

echo "Installing MonoGame templates..."
dotnet new --install MonoGame.Templates.CSharp

echo "Setup completed!"


echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc
echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc


echo "Done"


# Todo: this is the newer script, has to be consolidated with the old one above

#!/usr/bin/env bash
set -e


# Install .NET 8 SDK
echo "Installing system dependencies..."
sudo apt-get update
sudo apt-get install -y wget unzip libgl1-mesa-dev libxrandr-dev libxinerama-dev libxcursor-dev libxi-dev apt-transport-https
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

pwsh -File ./scripts/fetch-devops-backlog.ps1 # Fetch the backlog from Azure DevOps