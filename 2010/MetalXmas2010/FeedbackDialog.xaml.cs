using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MetalXmas2010
{
	public partial class FeedbackDialog : ChildWindow
	{
		private FeedbackDialogViewModel _viewModel;

		public FeedbackDialog()
		{
			InitializeComponent();
			_viewModel = new FeedbackDialogViewModel();
			DataContext = _viewModel;
		}

		private void OKButton_Click(object sender, RoutedEventArgs e)
		{
			_viewModel.Send();
		}		
		
		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
		}
	}
}

