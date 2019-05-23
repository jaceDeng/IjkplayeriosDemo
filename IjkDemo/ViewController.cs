using Foundation;
using Ijkplayer.iOS.UI;
using System;
using UIKit;

namespace IjkDemo
{
    public partial class ViewController : UIViewController
    {
        private ZFPlayerController player;
        private UIView containerView;
        private ZFPlayerControlView controlView;
        private UIButton playBtn;
        private UIButton changeBtn;
        private UIButton nextBtn;
        private NSUrl[] assetURLs;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            assetURLs = new NSUrl[] { 
            new NSUrl ("http://tb-video.bdstatic.com/tieba-smallvideo/45_a68a54ff67c9db5bb05748e14c600a3b.mp4"),
            new NSUrl("http://tb-video.bdstatic.com/tieba-smallvideo/68_20df3a646ab5357464cd819ea987763a.mp4")
            };
            playBtn = new UIButton();
            changeBtn = new UIButton();
            containerView = new UIView
            {
                BackgroundColor = UIColor.Orange
            };
            nextBtn = new UIButton();
            playBtn.TouchDown += (sender, e) => {
                //var pp = this.player as ZFPlayerController;
                player.AssetURLs = this.assetURLs;
                player.PlayTheIndex(0);
            };
            ZFIJKPlayerManager playerManager = new ZFIJKPlayerManager();
            this.controlView = new ZFPlayerControlView();
            this.View.BackgroundColor = UIColor.White;
            this.View.AddSubview(this.containerView);
            this.containerView.AddSubview(this.playBtn);
            this.View.AddSubview(this.changeBtn);
            this.View.AddSubview(this.nextBtn);

            // ZFAVPlayerManager *playerManager = [[ZFAVPlayerManager alloc] init];
            //    KSMediaPlayerManager *playerManager = [[KSMediaPlayerManager alloc] init];
         
            /// 播放器相关
            this.player = ZFPlayerController.PlayerWithPlayerManager(playerManager, this.containerView);
            this.player.ControlView = this.controlView;


        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}