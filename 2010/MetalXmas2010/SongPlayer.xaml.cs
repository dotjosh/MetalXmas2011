using System;
using System.Threading;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using MetalXmas2010.Core;

namespace MetalXmas2010
{
	public partial class SongPlayer : UserControl
	{
		public event Action Started;
		public event Action Stopped;
		private DispatcherTimer _updateProgressTimer;

		public SongPlayer()
		{
			InitializeComponent();
			UpdateButtonState();
			SongMediaElement.CurrentStateChanged += SongMediaElement_CurrentStateChanged;
			_updateProgressTimer = new DispatcherTimer();
			_updateProgressTimer.Interval = TimeSpan.FromSeconds(1);
			_updateProgressTimer.Tick += UpdateProgressTimer_Tick;
		}

		void SongMediaElement_CurrentStateChanged(object sender, RoutedEventArgs e)
		{
			UpdateButtonState();
		}

		public static DependencyProperty SongUrlProperty = DependencyProperty.Register("SongUrl", typeof (string), typeof (SongPlayer), null);
		public string SongUrl
		{
			get { return (string) GetValue(SongUrlProperty); }
			set { SetValue(SongUrlProperty, value); }
		}

		public static DependencyProperty SongTitleProperty = DependencyProperty.Register("SongTitle", typeof(string), typeof(SongPlayer), new PropertyMetadata(null, SongTitleChanged));
		private static void SongTitleChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
		{
			((SongPlayer) o).TitleTextBlock.Text = (string) args.NewValue;
		}
		public string SongTitle
		{
			get { return (string)GetValue(SongTitleProperty); }
			set { SetValue(SongTitleProperty, value); }
		}

		protected void OnStart()
		{
			if (Started != null)
				Started();
		}		
		
		protected void OnStop()
		{
			if (Stopped != null)
				Stopped();
		}

		public Duration Duration
		{
			get
			{
				return SongMediaElement.NaturalDuration;
			}
		}

		public TimeSpan Position
		{
			get
			{
				return SongMediaElement.Position;
			}
		}

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			Play();
		}

		public void Stop()
		{
			if (SongMediaElement.CurrentState == MediaElementState.Stopped)
				return;
			SongMediaElement.Stop();
			UpdateButtonState();
			_updateProgressTimer.Stop();
			OnStop();
		}

		private void StopButton_Click(object sender, RoutedEventArgs e)
		{
			Stop();
		}

		private void PauseButton_Click(object sender, RoutedEventArgs e)
		{
			SongMediaElement.Pause();
		}

		void UpdateProgressTimer_Tick(object sender, EventArgs e)
		{
			UpdateProgress();
		}

		private void UpdateProgress()
		{
			var positionTotalSeconds = SongMediaElement.Position.TotalSeconds;
			var durationSeconds = SongMediaElement.NaturalDuration.TimeSpan.TotalSeconds;
			if (durationSeconds == 0)
				return;
			SongProgress.Value = Math.Floor(positionTotalSeconds/durationSeconds * 100);
			if(positionTotalSeconds == durationSeconds)
				Stop();
		}

		public void Play()
		{
			if (SongMediaElement.CurrentState != MediaElementState.Paused)
			{
				SongMediaElement.Source = Helpers.GetSongUrl(SongUrl);
			}
			SongMediaElement.Play();
			OnStart();
			UpdateButtonState();
			_updateProgressTimer.Start();
		}

		private void UpdateButtonState()
		{
			switch(SongMediaElement.CurrentState)
			{
				case MediaElementState.Buffering:
				case MediaElementState.Opening:
				case MediaElementState.Playing:
					UpdateProgress();
					TitleTextBlock.Foreground = new SolidColorBrush(Colors.Black);
					StopButton.Visibility = Visibility.Visible;
					PauseButton.Visibility = Visibility.Visible;
					PlayButton.Visibility = Visibility.Collapsed;
					SongProgress.Visibility = Visibility.Visible;
					break;
				case MediaElementState.Stopped:
				case MediaElementState.Closed:
					TitleTextBlock.Foreground = new SolidColorBrush(Colors.White);
					SongProgress.Visibility = Visibility.Collapsed;
					StopButton.Visibility = Visibility.Collapsed;
					PauseButton.Visibility = Visibility.Collapsed;
					PlayButton.Visibility = Visibility.Visible;
					break;
				case MediaElementState.Paused:
					StopButton.Visibility = Visibility.Visible;
					PauseButton.Visibility = Visibility.Collapsed;
					PlayButton.Visibility = Visibility.Visible;
					break;
			}
		}
	}
}
