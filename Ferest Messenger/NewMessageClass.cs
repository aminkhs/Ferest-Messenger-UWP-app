using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Input;
using Windows.UI.Xaml.Media.Animation;

namespace Ferest_Messenger
{
    class NewMessageClass
    {

        Rectangle msgrect = new Rectangle();
        TextBlock msgtxtblk = new TextBlock();
        TextBlock msgtime = new TextBlock();
        public bool recivemsg = false;

        public NewMessageClass()
        {
            
            msgtxtblk.FontFamily = new FontFamily("Assets/Fonts/SourceSansPro.ttf#Source Sans Pro");
            msgtime.FontFamily = new FontFamily("Assets/Fonts/SourceSansPro.ttf#Source Sans Pro");

            int sec = DateTimeOffset.Now.Second;
            int min = DateTimeOffset.Now.Minute;
            int hours = DateTimeOffset.Now.Hour;
            msgtime.Text = hours.ToString() + ":" + min.ToString();
        }

        public void AddMsgAnimate()
        {
            RepositionThemeAnimation AnimateUp = new RepositionThemeAnimation();
            AnimateUp.FromVerticalOffset = 0;
            AnimateUp.AutoReverse = false;
            AnimateUp.TargetName = "MSGHolder2Contents2";
        }

        public Rectangle rectangle
        {
            set { msgrect = value; }
            get { return msgrect; }
        }

        public TextBlock msgtext
        {
            set { msgtxtblk = value; }
            get { return msgtxtblk; }
        }

        public TextBlock time
        {
            set { msgtime = value; }
            get { return msgtime; }
        }

    }
}
