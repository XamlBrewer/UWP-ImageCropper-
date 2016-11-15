# UWP-ImageCropper
An ImageCropper control for the Universal Windows Platform.

- Populated through a SourceImage dependency property, of type WriteableBitmap.

- Templatable UI allows to select a region by dragging a corner, dragging the entire selection, and pinch gesture.

- Exposes the result as CroppedImage, of type WriteableBitmap.

- This branch experiments with setting a fixed ratio for the cropped image through a AspectRatio property on the control.
