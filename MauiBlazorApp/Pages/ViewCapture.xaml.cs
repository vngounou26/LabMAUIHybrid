using MauiBlazorApp.ViewModels;

namespace MauiBlazorApp.Pages;

public partial class ViewCapture : ContentPage
{
	private CaptureViewModel _viewModel;
	public ViewCapture(CaptureViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
	}

    private async void ImagePreview_Clicked(object sender,EventArgs e)
    {
		var media = await MediaPicker.CapturePhotoAsync();

		if(media is not null)
		{
			using MemoryStream memoryStream = new();
			await (await media.OpenReadAsync()).CopyToAsync(memoryStream);
			var base64String = Convert.ToBase64String(memoryStream.ToArray());
			ImagePreview.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(base64String)));

			await _viewModel.SaveImageCommand.ExecuteAsync(base64String);

			//var stream = await media.OpenReadAsync();
			//ImagePreview.Source = ImageSource.FromStream(() => stream);

		}
		
    }
}