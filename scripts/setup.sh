#!/usr/bin/env bash
# Erstellt mit Unterstützung von OpenAI Codex
set -e

# Install core dependencies
echo "Installing system dependencies..."
sudo apt-get update
sudo apt-get install -y wget unzip apt-transport-https \
    libgl1-mesa-dev libxrandr-dev libxinerama-dev libxcursor-dev libxi-dev \
    libsdl2-dev libsdl2-image-dev libsdl2-mixer-dev libsdl2-ttf-dev libopenal-dev

# Install Node.js
echo "Installing Node.js..."
curl -fsSL https://deb.nodesource.com/setup_20.x | sudo -E bash -
sudo apt-get install -y nodejs

# Install .NET SDK
echo "Installing .NET SDK..."
wget https://packages.microsoft.com/config/ubuntu/24.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0

# Install MonoGame templates
echo "Installing MonoGame templates..."
dotnet new --install MonoGame.Templates.CSharp

# Restore tools and build content
echo "Restoring tools and building content..."
dotnet tool restore
dotnet mgcb /@:Content/Content.mgcb

# === PowerShell installieren, falls nicht vorhanden ===
if ! command -v pwsh &> /dev/null; then
  echo "⚙️ PowerShell (pwsh) wird installiert..."

  # Voraussetzungen
  sudo apt-get update
  sudo apt-get install -y wget apt-transport-https software-properties-common

  # Microsoft Paketquelle einbinden
  wget -q https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb
  sudo dpkg -i packages-microsoft-prod.deb
  rm packages-microsoft-prod.deb

  # PowerShell installieren
  sudo apt-get update
  sudo apt-get install -y powershell
else
  echo "✅ PowerShell ist bereits installiert."
fi


# Optionally build the project
if [ "$1" == "--build" ]; then
    dotnet build
fi

# Fetch the backlog from Azure DevOps
pwsh -File ./scripts/fetch-devops-backlog.ps1

echo "Setup completed!"
