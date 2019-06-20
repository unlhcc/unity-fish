# University of Nebraska at Lincoln Holland Computing Center's Unity-Fish Animation System

### Prerequisite
* You will need a server that is utilizing the Ganglia system monitoring tool
  * For additional information on Ganglia: http://ganglia.so
* Your server running ganglia will need to have the Unity-Fish Machine's IP as a trusted host to access the XML data.
  * You will need to uncomment the "trusted_hosts" line in /etc/ganglia/gmetad.conf
  * Add the Unity-Fish Machine's IP to this line (space seperated list).
  * Restart the gmetad.service.
* Your server running ganglia will also need to have XML request port (gmetad.conf lists this as 8651 by default) open through Firewalld.
* The machine hosting Unity Fish will need:
  * The Unity software: https://store.unity.com/download
  * At least Two-CPUs and 4-GB RAM to run the Fish program.

## Setting up Unity-Fish with your system

1. Download or clone the Unity Fish project repo: https://github.com/unlhcc/unity-fish.git
2. The following files are in C# (C-Sharp), so follow the C# syntax documents.
3. In your favorite text editor, modify /unity-fish/FishNodes/Assets/ScriptsDataRetriever.cs
  * Create variables for each cluster with the address as a string and the port as an int for Ganglia.
  ``` FishSpawner fishSpawner;
      string clusterURL = "127.0.0.1";
      int clusterPort = 8649;
  ```
  * Now in the GetXML() Function,  update it like this
  
  ```
  StartCoroutine (ParseXML ("<myCluster>.xml", <AddrString>, <PortInt>));
  ```
4. Next modify /unity-fish/FishNodes/Assets/FishSpawner.cs
  * Change the if statements to the colors of your fish.
  ```if (leader.Equals ("myCluster")) {
			if(isLeader){
				fd.fishColor = new Color(0f,0f,0f);
			}else{
				fd.fishColor = Color.FromRgb(255, 255, 255);
  ```
  
  * The `(leader.Equals)` name will be the cluster name within ganglia.
5. Now we will start using the Unity system.
  * Open Unity Hub
  * Select "Projects" side menu and select "Add"
  * In the dialog box navigate to the /FishNode directory and select it.
  * If your project has a warning about about "No matching editor" go to https://unity3d.com/get-unity/download/archive and find the appropriate version of Unity to download. Click on the green "Unity Hub" download link.
  * Once downloaded, launch the correct version of Unity from Unity Hub.
6. Fish Node configuration in Unity
  * Open the FishNode project, this will take a few minutes depending on your system.
  * Select "FishNodes" from the lower work area in the Unity interface.
  * Select the "open" button from the right work pane where "FishNodes" populated.
  * Change the text to the correct color and names to match the changes you made in C# files.
  	```
	Camera Pod > Camera Pod 1 > UIText > Running Text
	```
## Building the Project

1. Once the unnity-fish look and act they way you want save the project.
2. Use `Ctrl + Shift + B` to open the Project Build Dialog Box.
3. Select the sections of the project in the upper left that you want to build, we skipped the VR projects.
3. Choose your target system, in our case we did Windows 64 bit.
4. For ease of use later, select the "FishNodes" folder as the build destination.
5. Select "build", this should only take a few minutes.
6. Run the FishNodes.exe and enjoy!

## Controls for in "Game" (Source File)

* Controls for Fish Spawning (FishSpawner.cs)
  * `Shift + U` will spwan a new Leader Fish for Cluster 1.
  * `Shift + I` will spawn 50 new Cluster 1 Follower Fish.
  * `Shift + P` will spawn 50 new Cluster 2 Follower Fish.
  * `Shift + L` will kill all the Leader Fish in the tank.
  * `Shift + K` will kill ALL the fish in the tank.
* Controls for Fish Movement (FishApperanceChanger.cs)
  * `Numpad Plus Key` will make the fish larger.
  * `Numpad Minus Key` will make the fish smaller.
  * `-` will decrease the swimming speed of the fish.
  * `=` will increase the swimming speed of the fish.
* Controls for Cluster Information (DataRetriever.cs)
  * `Shift + R` will get new information from Ganglia and "respawn" the fish.
  * `Shift + E` will enable a "Fish Limiter" to limit the number of Fish on screen.
* Controls for the Camera (CameraController.cs)
  * `1` will show default camera view.
  * `2` will show secondary camera view.
* Controls for Selecting Fish (FishSelector.cs)
  * `Left-Mouse-Button` selects target Fish and shows a summary of its compute information.
* Controls for Game Menu (MenuUtilityKeys.cs)
  * `Esc` will exit the program.
  * `F11` will put the game into fullscreen mode.

