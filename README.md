# Unibersity of Nebraska at Lincoln Holland Computing Center's Unity-Fish Animation System

### Prerequisite
* You will need a server that is utilizing the Ganglia system monitoring tool
  ..* For additional information on Ganglia: http://ganglia.so
* The machine hosting Unity Fish will need:
  ..* The Unity software: https://store.unity.com/download
  ..* At least Two-CPUs and 4-GB RAM to run the Fish program.

## Setting up Unity-Fish with your system

1. Download or clone the Unity Fish project repo: https://github.com/unlhcc/unity-fish.git
2. In your favorite text editor, modify /unity-fish/FishNodes/Assets/ScriptsDataRetriever.cs
  ..* Create variables for each cluster with the address as a string and the port as an int for Ganglia.
  ``` FishSpawner fishSpawner;
      string clusterURL = "127.0.0.1";
      int clusterPort = 8649; ```
  ..* Now 
