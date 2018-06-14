## Objective
The [Soil TopARgraphy](eml.ubc.ca/projects/soil-topargraphy/) phone app allows UBC students, enrolled in the APBI 200 – Introduction to Soil Science course, to view topographical distribution of different soil types. The objective of the Soil TopARgraphy app is to allow students to learn about the effects of topography on formation of different soil types through an immersive and visual Augmented Reality (AR) terrain.
This app brings interactivity to the APBI 200 lectures and laboratory sessions focused on soil formation and classification, and in turn, promotes student engagement and deeper comprehension of the material.
## Background
As a part of the curriculum, students in the APBI 200 course learn about 10 soil orders, where the soil order is the broadest classification category in the Canadian system of soil classification. The topics of soil formation and classification are of direct importance for land use and management. Hence, it is essential that our future land managers have a solid understanding of soil formation and factors – like topography – that drive it. These topics are currently covered in the APBI 200 course through a series of lectures, laboratory activities, video footage, web-based resources, and a couple campus-based field trips. However, there is still a need to enhance students’ learning on this important topic, which led to the development of the Soil TopARgraphy app which brought in visual and tactile elements to the learning experience. 

Augmented Reality (AR) is a technology that overlays digital enhancements on top of existing reality, in this case through your phone like in Pokémon GO. With AR, different soil orders are shown within one real-life terrain across different parts of topography. We chose an area just north of Kamloops, BC as an example of the terrain model since the region is characterized by a great diversity of soil types.
## Description
With the Soil TopARgraphy app, which allows viewing and manipulating a terrain model, APBI 200 students will learn how topography impacts distribution of soil orders through its effects on microclimate (i.e. temperature and water). Students will be able to view the terrain model with a color-coded height map (Image 1) or a photorealistic satellite image (Image 2). Furthermore, students can tap on flags to read about different soil orders, see images, watch a video, and take a self-study quiz to review their understanding (Image 3 and 4).

## Platform: Android and iOS
## Tools: Unity, Vuforia, Blender, Mapbox, Github

## Progress
All the features of the app are complete; the app is currently in the testing phase, and will be modified according to the feedback received. The app could be launched into the Apple App Store and Google Play Store for convenient installation. In January 2019, the app will be tested in the APBI 200 – Introduction to Soil Science course and the project team will help with the set-up.
## The Team
Faculty 
- Dr. Maja Krzic, Faculty of Forestry | Faculty of Land and Food Systems

Students
- Daphne Liu, Team Lead & Developer (Jan 2018 to present)
- Tiger Oakes, Developer (Mar 2018 to present)
- Emma Ng, UX/UI Designer (Mar 2018 to present)
## Development

1. Install [Unity](https://unity3d.com/) with the Android Build Support and [Vuforia](https://library.vuforia.com/articles/Training/getting-started-with-vuforia-in-unity.html) Augmented Reality Support components.
2. Clone this project
3. Open the project in Unity

# Build iOS 

See also: https://unity3d.com/learn/tutorials/topics/mobile-touch/building-your-unity-game-ios-device-testing

1. Open Unity
2. File -> Build Setting 
3. Click "iOS" then the "Switch Platform" button if it isn't disabled
4. "Build" button then save somewhere on your computer
5. When building is complete, open the new folder and open the `.xcodeproj` file.
6. Plug in your iPhone and make sure to turn on development mode if prompted on the Mac.
7. With XCode open, click "Unity-iPhone" in the top of the left sidebar.
8. Resolve any errors on the "General" page that opens.
9. Press the play icon button to build.
10. Make sure your iPhone trusts the developer team set on the Mac. Settings -> General -> Device Management -> Developer App -> TopARGraphy
11. Done, you can run and debug.
