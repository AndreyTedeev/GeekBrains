using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AndreyTedeev.AsteroidsUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Game _game;

        public MainPage()
        {
            this.InitializeComponent();
            var hostVisual = ElementCompositionPreview.GetElementVisual(GameCanvas);
            ContainerVisual _root = hostVisual.Compositor.CreateContainerVisual();
            this.SizeChanged += MainPage_SizeChanged;
            ElementCompositionPreview.SetElementChildVisual(GameCanvas, _root);
            _game = new Game();
            _game.Load(_root);
        }

        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _game.SizeChanged(this.ActualSize);
        }

        private void GameCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

        }
    }

}
