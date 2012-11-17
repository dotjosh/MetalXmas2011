using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MetalXmas2010.Core;

namespace MetalXmas2010
{
	public partial class MainPage : UserControl
	{
		private List<SongPlayer> _songPlayers;
		private MainPageViewModel _viewModel;

		public MainPage()
		{
			InitializeComponent();
			Loaded += OnLoaded;

			_viewModel = new MainPageViewModel();
			_viewModel.PropertyChanged += (o, eventArgs) =>
			                                     {
													 if (eventArgs.PropertyName == "Comment1IsVisible")
													 {
														 if (_viewModel.Comment1IsVisible)
															ShowComment1Animation.Begin();
														 else
															 HideComment1Animation.Begin();
													 }
													 else if (eventArgs.PropertyName == "Comment2IsVisible")
													 {
														 if (_viewModel.Comment2IsVisible)
															ShowComment2Animation.Begin();
														 else
															 HideComment2Animation.Begin();
													 }
			                                     };
			DataContext = _viewModel;

			Application.Current.Host.Content.FullScreenChanged += (sender, args) => UpdateScrollingBackground();
		}

		private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
		{
			if(new Random().Next(50) % 2 == 0)
			{
				DriedelOpeningPlayer.SongTitle = "Hallelujah Opening";
				DriedelOpeningPlayer.SongUrl = "Metal Xmas 2008/Guitalujah (Final).mp3";
			}
			else
			{
				DriedelOpeningPlayer.SongTitle = "Dreidel Opening";
				DriedelOpeningPlayer.SongUrl = "Metal Xmas 2009/Dreidel Opening.mp3";
			}
			DriedelOpeningPlayer.Stopped += () =>
			                                {
			                                	HideDriedelPlayerAnimation.Begin();
			                                };
			DriedelOpeningPlayer.Play();

			_viewModel.StartShowingComments();

			_songPlayers = this
				.Descendents()
				.OfType<SongPlayer>()
				.ToList();
			foreach(var player in _songPlayers)
			{
				SongPlayer player1 = player;
				player.Started += () => PlayerStarted(player1);
			}

			bool isMac = Environment.OSVersion.Platform == PlatformID.MacOSX;
			if(!isMac)
				ScrollingBackgroundStoryboard.Begin();
		}

		private void UpdateScrollingBackground()
		{
			bool isMac = Environment.OSVersion.Platform == PlatformID.MacOSX;
			if(isMac)
			{
				if(Application.Current.Host.Content.IsFullScreen)
				{
					ScrollingBackgroundStoryboard.Begin();
				}
				else
				{
					ScrollingBackgroundStoryboard.Stop();
				} 
			}

			if(Application.Current.Host.Content.IsFullScreen)
			{
				FullscreenMode.Content = "Back to Windowed Mode";
			}
			else
			{
				FullscreenMode.Content = "Go Fullscreen!";
			}
		}

		private void PlayerStarted(SongPlayer startedPlayer)
		{
			foreach (var otherPlayer in _songPlayers.Except(new[] { startedPlayer }))
			{
				otherPlayer.Stop();
			}
		}

		private void FullscreenMode_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Host.Content.IsFullScreen = !Application.Current.Host.Content.IsFullScreen;
		}

		private void GiveUsFeedback_Click(object sender, RoutedEventArgs e)
		{
			AllCommentsList.Visibility = Visibility.Collapsed;
			var feedbackDialog = new FeedbackDialog();
			feedbackDialog.Show();
		}

		private bool isFeedbackVisible = false;
		private void SeeTheFeedback_Click(object sender, RoutedEventArgs e)
		{
			if (isFeedbackVisible)
			{
				HideAllCommentsListAnimation.Begin();
			}
			else
			{
				_viewModel.RefreshAllComments();
				ShowAllCommentsListAnimation.Begin();
			}
			isFeedbackVisible = !isFeedbackVisible;
		}
	}

	public static class VisualTreeEnumeration
	{
		public static IEnumerable<DependencyObject> Descendents(this DependencyObject root)
		{
			int count = VisualTreeHelper.GetChildrenCount(root);
			for (int i = 0; i < count; i++)
			{
				var child = VisualTreeHelper.GetChild(root, i);
				yield return child;
				foreach (var descendent in Descendents(child))
					yield return descendent;
			}
		}
	}
}
