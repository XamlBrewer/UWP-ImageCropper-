using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using XamlBrewer.Uwp.Controls;

namespace XamlBrewer.Uwp.ImageCropperSample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".bmp");
            openPicker.FileTypeFilter.Add(".gif");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile imgFile = await openPicker.PickSingleFileAsync();
            if (imgFile != null)
            {
                var wb = new WriteableBitmap(1,1);
                await wb.LoadAsync(imgFile);
                this.ImageCropper.SourceImage = wb;
            }
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
