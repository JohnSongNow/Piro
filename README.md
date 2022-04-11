# Piro

## Introduction

I created this tool called `Piro` to help me display and visualize concepts better for my youtube videos. Originally I wrote a similar code back there in [Godot](https://godot.com) used an eariler pathfinding and parllel programming videos. I've since then ported the tool into Unity as a modernization process. 

#### Examples of videos
This tool is primarily used by me to create and visual new concepts, but is made available to anyone that wishes to tinker and run the visualizaitons themselves. My [video repository](https://github.com/JohnSongNow/youtube-videos) list can be found with a list of the scenes used for each video. Although the code is new there is no guarantee that each will is backwards compitable! To ensure that the cinematic can be ran please use the version that matches the videos release date.

## Setup
To use this tool first download [Unity](https://unity.com/), this project current uses `2020.3.24f1`.

This tool uses `C#`, you can the use the [c# docs](https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/) for more in depth documentation. It also tool makes extensive use of the [Coroutines](https://docs.unity3d.com/Manual/Coroutines.html) to control the flow of `Cutscene` and `Cinematic` nodes.

## Usage
Each video is broken up in terms of a `Cinematic` and `Cutscene` class

`Cinematic` is the root node of each scene and contains `Cutscene` nodes as their children. A `Cinematic` allow us to contain and cycle through each cutscene. By default all `Cutscene` nodes of a cinematic are set to non visible except the active cutscene.

`Cutscene` nodes are direct children of the `Cinematic` nodes and contain child nodes used to render and display. They have a function called `Play` which allows them change and manipulate the scene. 

The main signal of `StepBegan` allows us to control the flow of the cutscene by waiting for input until the user presses the next key `Q`. How you setup the scene is completely up your preference however. I recommend the scene with the following node structure.
```
SceneRoot
  - Camera
  - EventSystem
  - Canvas
    - Cinematic
      - Cutscene1
      - Cutscene2
      ...
    - CinematicControls
```
Please follow the [Bubble Sort Scene](https://github.com/JohnSongNow/Piro/tree/master/Assets/Cinematics/BubbleSort) as as an example!

Lastly you'll need to hook up your cutscenes to the cinematics by dragging them into the slots on the cinematic node.
![image](https://user-images.githubusercontent.com/11955347/162810315-d4da08df-374b-4216-b2e4-20625b4f95a5.png)

Below is an example of a standard `Play` method.

```
public override async void Play()
{        
  yield return base.Play();

  ListVisualSorts.waitTime = 0.1f;
  List<int> numbers = Enumerable.Range(1, 20).ToList();
  ListVisualSorts.ShuffleNumbers(numbers);
  bubbleListVisual.SetNumbers(numbers);
  mergeListVisual.SetNumbers(new List<int>(numbers));
  quickListVisual.SetNumbers(new List<int>(numbers));
  OnStepEnded();

  yield return new WaitForNextStep(this);
  Coroutine bubble = StartCoroutine(ListVisualSorts.BubbleSort(bubbleListVisual));
  Coroutine merge = StartCoroutine(ListVisualSorts.MergeSort(mergeListVisual, mergeHelperListVisual));
  Coroutine quick = StartCoroutine(ListVisualSorts.QuickSort(quickListVisual));
  yield return bubble;
  yield return merge;
  yield return quick;
  OnStepEnded();
}
```

#### Cutscene Control
![image_001_0000](https://user-images.githubusercontent.com/11955347/162806924-49559421-5468-4ef3-96a4-4318ba9bb9be.jpg)
The cutscene controls offers a way of manging which scene is currently active as well as provides a legend for the controls. It's visibility can ba toggled on/off by pressing `T`.

#### Recording
I use the plugin [Unity Recorder](https://learn.unity.com/tutorial/working-with-the-unity-recorder-2019-3) to record the cutscenes generated from Piro.

## Contributing/Error Correction
If you see any error or would like to contribute to this repository feel free to send me a message and/or submit a pull request.

As of right now there are no plans to convert the `PathFinding` video to use this newer library, please use [Godot Video Tools](https://github.com/JohnSongNow/godot-video-tools) to view older videos.

## License
This uses the MIT license.
