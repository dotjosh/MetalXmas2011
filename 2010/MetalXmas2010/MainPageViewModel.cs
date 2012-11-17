using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Services.Client;
using System.Diagnostics;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Threading;
using MetalXmas2010.Core;
using MetalXmas2010.Web;
using MetalXmas2010.Web.Model;

namespace MetalXmas2010
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		private Comment _comment1;
		private Comment _comment2;
		private bool _comment1IsVisible;
		private bool _comment2IsVisible;
		private readonly Queue<Comment> _commentsQueue;
		private DispatcherTimer _changeCommentsTimer;
		private bool _isOnComment1 = true;
		private MetalXmasContext _allCommentContext;

		public MainPageViewModel()
		{
			_commentsQueue = new Queue<Comment>();
			_allCommentContext = ServiceFactory.Create();
			AllComments = _allCommentContext.Comments;
		}

		public Comment Comment1
		{
			get { return _comment1; }
			set
			{
				_comment1 = value;
				OnPropertyChanged("Comment1");
			}
		}

		public Comment Comment2
		{
			get { return _comment2; }
			set
			{
				_comment2 = value;
				OnPropertyChanged("Comment2");
			}
		}

		public EntitySet<Comment> AllComments { get; set; }

		public bool Comment1IsVisible
		{
			get { return _comment1IsVisible; }
			set
			{
				if (_comment1IsVisible == value)
					return;

				_comment1IsVisible = value;
				OnPropertyChanged("Comment1IsVisible");
			}
		}

		public bool Comment2IsVisible
		{
			get { return _comment2IsVisible; }
			set
			{
				if (_comment2IsVisible == value)
					return;
				_comment2IsVisible = value;
				OnPropertyChanged("Comment2IsVisible");
			}
		}

		public void StartShowingComments()
		{
			_changeCommentsTimer = new DispatcherTimer();
			_changeCommentsTimer.Interval = TimeSpan.FromSeconds(8);
			_changeCommentsTimer.Tick += (sender, args) => ShowMoreComments();
			ShowMoreComments();
		}

		private void ShowMoreComments()
		{
			_changeCommentsTimer.Stop();
			if(_commentsQueue.Count == 0)
			{
				GetMoreComments();
				return;
			}
			SetNewComment(_commentsQueue.Dequeue());
			_changeCommentsTimer.Start();
		}

		private void GetMoreComments()
		{
			var context = ServiceFactory.Create();
			context.Load(context.GetCommentsQuery(), operation =>
			{
				if(operation.HasError)
				{
					MessageBox.Show(operation.Error.ToString());
				}
				else
				{
					foreach (var comment in operation.Entities)
					{
						_commentsQueue.Enqueue(comment);
					}
					if (_commentsQueue.Count == 0)
					{
						_changeCommentsTimer.Start();
						return;
					}
					ShowMoreComments();
				}
			}, null);
		}

		private void SetNewComment(Comment comment)
		{
			Debug.WriteLine(comment.CommentID);

			if (_isOnComment1)
				Comment1 = comment;
			else
				Comment2 = comment;

			Comment1IsVisible = _isOnComment1;
			Comment2IsVisible = !_isOnComment1;
			_isOnComment1 = !_isOnComment1;
		}

		public void RefreshAllComments()
		{
			_allCommentContext.Load(_allCommentContext.GetCommentsQuery());
		}

		protected void OnPropertyChanged(string propertyName)
		{
			if(PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
}