using Mvvm.Services;
using System;
using System.Collections.Generic;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using XamlBrewer.Uwp.Controls;

namespace XamlBrewer.Uwp.ImageCropperSample
{
    public sealed partial class CameraPage : Page
    {
        private CameraService cameraService;

        public CameraPage()
        {
            this.InitializeComponent();

            cameraService = new CameraService(CameraPreview);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await cameraService.InitializeCameraAsync();
            base.OnNavigatedTo(e);
        }

        private async void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder temp = ApplicationData.Current.LocalCacheFolder;
            StorageFile file = await temp.CreateFileAsync("current_image.png", CreationCollisionOption.ReplaceExisting);

            await cameraService.MediaCapture.CapturePhotoToStorageFileAsync(ImageEncodingProperties.CreateJpeg(), file);

            file = null;
            file = await temp.GetFileAsync("current_image.png");

            var wb = new WriteableBitmap(1, 1);
            await wb.LoadAsync(file);
            this.ImageCropper.SourceImage = wb;

            await cameraService.StopPreviewAsync();
            this.CameraPreview.Visibility = Visibility.Collapsed;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            savePicker.FileTypeChoices.Add("Bitmap", new List<string>() { ".bmp" });
            savePicker.FileTypeChoices.Add("Graphical Interchange Format", new List<string>() { ".gif" });
            savePicker.FileTypeChoices.Add("Joint Photographic Experts Group", new List<string>() { ".jpg" });
            savePicker.FileTypeChoices.Add("Portable Network Graphics", new List<string>() { ".png" });
            var file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                await (this.CroppedImage.Source as WriteableBitmap).SaveAsync(file);
            }
        }
    }
}
