# Videos
Video files used for the video info panel. 
These are handled by a Unity [Video Player](https://docs.unity3d.com/Manual/class-VideoPlayer.html) component,
which will render the video to a texture (`Video Texture.renderTexture`). In the UI, a Raw Image component
is used to render that texture to the screen. Since only 1 video is ever shown at once, the same texture
is reused across all videos.
