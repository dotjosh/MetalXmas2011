﻿#pragma checksum "C:\Users\jschwartzberg\Documents\My Dropbox\Code\MetalXmas2010\MetalXmas2010\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "22A5CE0C9298C94B9432FE4457B5E32B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MetalXmas2010;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MetalXmas2010 {
    
    
    public partial class MainPage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard ScrollingBackgroundStoryboard;
        
        internal System.Windows.Media.Animation.Storyboard HideDriedelPlayerAnimation;
        
        internal System.Windows.Media.Animation.Storyboard HideComment1Animation;
        
        internal System.Windows.Media.Animation.Storyboard ShowComment1Animation;
        
        internal System.Windows.Media.Animation.Storyboard HideComment2Animation;
        
        internal System.Windows.Media.Animation.Storyboard ShowComment2Animation;
        
        internal System.Windows.Media.Animation.Storyboard ShowAllCommentsListAnimation;
        
        internal System.Windows.Media.Animation.Storyboard HideAllCommentsListAnimation;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image Background1;
        
        internal System.Windows.Controls.Image Background2;
        
        internal MetalXmas2010.CommentBlock Comment1;
        
        internal MetalXmas2010.CommentBlock Comment2;
        
        internal System.Windows.Controls.Button FullscreenMode;
        
        internal System.Windows.Controls.Border AllCommentsList;
        
        internal MetalXmas2010.SongPlayer DriedelOpeningPlayer;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/MetalXmas2010;component/MainPage.xaml", System.UriKind.Relative));
            this.ScrollingBackgroundStoryboard = ((System.Windows.Media.Animation.Storyboard)(this.FindName("ScrollingBackgroundStoryboard")));
            this.HideDriedelPlayerAnimation = ((System.Windows.Media.Animation.Storyboard)(this.FindName("HideDriedelPlayerAnimation")));
            this.HideComment1Animation = ((System.Windows.Media.Animation.Storyboard)(this.FindName("HideComment1Animation")));
            this.ShowComment1Animation = ((System.Windows.Media.Animation.Storyboard)(this.FindName("ShowComment1Animation")));
            this.HideComment2Animation = ((System.Windows.Media.Animation.Storyboard)(this.FindName("HideComment2Animation")));
            this.ShowComment2Animation = ((System.Windows.Media.Animation.Storyboard)(this.FindName("ShowComment2Animation")));
            this.ShowAllCommentsListAnimation = ((System.Windows.Media.Animation.Storyboard)(this.FindName("ShowAllCommentsListAnimation")));
            this.HideAllCommentsListAnimation = ((System.Windows.Media.Animation.Storyboard)(this.FindName("HideAllCommentsListAnimation")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Background1 = ((System.Windows.Controls.Image)(this.FindName("Background1")));
            this.Background2 = ((System.Windows.Controls.Image)(this.FindName("Background2")));
            this.Comment1 = ((MetalXmas2010.CommentBlock)(this.FindName("Comment1")));
            this.Comment2 = ((MetalXmas2010.CommentBlock)(this.FindName("Comment2")));
            this.FullscreenMode = ((System.Windows.Controls.Button)(this.FindName("FullscreenMode")));
            this.AllCommentsList = ((System.Windows.Controls.Border)(this.FindName("AllCommentsList")));
            this.DriedelOpeningPlayer = ((MetalXmas2010.SongPlayer)(this.FindName("DriedelOpeningPlayer")));
        }
    }
}
