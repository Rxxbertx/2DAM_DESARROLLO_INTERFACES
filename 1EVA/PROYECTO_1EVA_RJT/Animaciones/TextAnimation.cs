using System;
using System.Windows.Controls;
using System.Windows.Threading;

public class TextAnimation
{
    private string fullText;
    private int currentIndex;
    private TextBlock textBlock;
    private DispatcherTimer timer;

    public TextAnimation(TextBlock textBlock, string fullText)
    {
        this.textBlock = textBlock;
        this.fullText = fullText;

        timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(30) // Ajusta el intervalo según  preferencias
        };
        timer.Tick += Timer_Tick;
    }

    public void Start()
    {
        currentIndex = 0;
        textBlock.Text = "";
        timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        if (currentIndex < fullText.Length)
        {
            textBlock.Text += fullText[currentIndex];
            currentIndex++;
        }
        else
        {
            timer.Stop();
        }
    }
}
