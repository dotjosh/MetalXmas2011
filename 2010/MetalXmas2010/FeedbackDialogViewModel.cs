using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Services.Client;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Media;
using MetalXmas2010.Core;
using MetalXmas2010.Web;
using MetalXmas2010.Web.Model;

namespace MetalXmas2010
{
	public class FeedbackDialogViewModel : INotifyPropertyChanged
	{
		private string _result;
		private Visibility _inputVisibility = Visibility.Visible;
		private Visibility _originalButtonsVisibility = Visibility.Visible;
		private Visibility _allDoneButtonVisibility = Visibility.Collapsed;
		private Brush _resultForeground;
		private MetalXmasContext _context;

		public FeedbackDialogViewModel()
		{
			Comment = new Comment();
			_context = ServiceFactory.Create();
			_context.Comments.Add(Comment);
		}

		public Comment Comment { get; set; }

		public string Result
		{
			get { return _result; }
			set
			{
				_result = value;
				OnPropertyChanged("Result");
			}
		}

		public Brush ResultForeground
		{
			get { return _resultForeground; }
			set
			{
				_resultForeground = value;
				OnPropertyChanged("ResultForeground");
			}
		}

		public Visibility InputVisibility
		{
			get { return _inputVisibility; }
			set
			{
				_inputVisibility = value;
				OnPropertyChanged("InputVisibility");
			}
		}

		public Visibility OriginalButtonsVisibility
		{
			get { return _originalButtonsVisibility; }
			set
			{
				_originalButtonsVisibility = value;
				OnPropertyChanged("OriginalButtonsVisibility");
			}
		}
		public Visibility AllDoneButtonVisibility
		{
			get { return _allDoneButtonVisibility; }
			set
			{
				_allDoneButtonVisibility = value;
				OnPropertyChanged("AllDoneButtonVisibility");
			}
		}


		public void Send()
		{
			_context.SubmitChanges(operation => 
			{
				if(operation.HasError)
				{
					Result = "There was a problem getting your letter to Santa!";
					InputVisibility = Visibility.Visible;
					ResultForeground = new SolidColorBrush(Colors.Red);
					AllDoneButtonVisibility = Visibility.Collapsed;
					OriginalButtonsVisibility = Visibility.Visible;
				}
				else
				{
					Result = "Got it, thanks!";
					ResultForeground = new SolidColorBrush(Colors.Green);
					InputVisibility = Visibility.Collapsed;
					AllDoneButtonVisibility = Visibility.Visible;
					OriginalButtonsVisibility = Visibility.Collapsed;
				}
			}, null);
		}

		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
}