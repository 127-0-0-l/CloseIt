using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CloseIt
{
    public partial class MainWindow : Window
    {
        private const int _minBtnHeight = 30;
        private const int _maxBtnHeight = 100;
        private const int _minBtnWidth = 70;
        private const int _maxBtnWidth = 300;
        private readonly double _maxXPosition = SystemParameters.PrimaryScreenWidth - _maxBtnWidth;
        private readonly double _maxYPosition = SystemParameters.PrimaryScreenHeight - _maxBtnHeight;

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
            CreateButton();
        }

        private void CreateButton()
        {
            Button btn = new Button
            {
                Content = "Close",
                Background = Brushes.LightBlue
            };

            btn.MouseMove += (s, e) => RunAway(btn);
            RunAway(btn);
            cnvMain.Children.Add(btn);
        }

        private void RunAway(Button btn)
        {
            Random rnd = new Random();

            btn.Width = rnd.Next(_minBtnWidth, _maxBtnWidth);
            btn.Height = rnd.Next(_minBtnHeight, _maxBtnHeight);
            Canvas.SetLeft(btn, rnd.Next((int)_maxXPosition));
            Canvas.SetTop(btn, rnd.Next((int)_maxYPosition));
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Environment.Exit(0);
        }
    }
}