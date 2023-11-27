using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        private readonly Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            StartSnowfall();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Не додаю ялинку при завантаженні вікна
        }

        private void StartSnowfall()
        {
            for (int i = 0; i < 100; i++)
            {
                Ellipse snowflake = new Ellipse();
                snowflake.Width = 10;
                snowflake.Height = 10;
                snowflake.Fill = new SolidColorBrush(RandomColor());

                animationCanvas.Children.Add(snowflake);

                Canvas.SetLeft(snowflake, random.Next((int)animationCanvas.ActualWidth));
                Canvas.SetTop(snowflake, -random.Next(300));

                DoubleAnimation animation = new DoubleAnimation
                {
                    To = animationCanvas.ActualHeight,
                    Duration = TimeSpan.FromSeconds(random.Next(5, 10)),
                    RepeatBehavior = RepeatBehavior.Forever
                };

                snowflake.BeginAnimation(Canvas.TopProperty, animation);
            }
        }

        private void christmasTreeImage_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Ellipse ball = new Ellipse();
            ball.Width = 20;
            ball.Height = 20;
            ball.Fill = new SolidColorBrush(RandomColor());

            Point mousePosition = e.GetPosition(christmasTreeImage);

            Canvas.SetLeft(ball, mousePosition.X - ball.Width / 2);
            Canvas.SetTop(ball, mousePosition.Y - ball.Height / 2);

            animationCanvas.Children.Add(ball);
        }

        private Color RandomColor()
        {
            byte[] colorBytes = new byte[3];
            random.NextBytes(colorBytes);
            return Color.FromRgb(colorBytes[0], colorBytes[1], colorBytes[2]);
        }
    }
}
