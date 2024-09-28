namespace NewBridge;

class Program
{
    static void Main(string[] args)
    {
        LightTheme light = new LightTheme();
        HomePage page = new HomePage(light);

        Console.WriteLine(page.GetContent());
    }
    
    public class HomePage : WebPage
    {
        public HomePage(ITheme theme) : base(theme)
        {
        }

        public override string GetContent()
        {
            return $"Home Background color is: {_theme.GetBackgroundColor()} and Text color is: {_theme.GetTextColor()}";
        }
    }
    
    public class AboutPage : WebPage
    {
        public AboutPage(ITheme theme) : base(theme)
        {
        }

        public override string GetContent()
        {
            return $"About us Background color is: {_theme.GetBackgroundColor()} and Text color is: {_theme.GetTextColor()}";
        }
    }

    public interface IWebPage
    {
        string GetContent();
    }

    public abstract class WebPage : IWebPage
    {
        protected readonly ITheme _theme;
        protected WebPage(ITheme theme)
        {
            _theme = theme;
        }

        public abstract string GetContent();

        public string GetBackgroundColor()
        {
            return _theme.GetBackgroundColor();
        }
        
        public string GetTextColor()
        {
            return _theme.GetTextColor();
        }
    }
    
    public interface ITheme
    {
        string GetBackgroundColor();
        string GetTextColor();
    }
    
    public class LightTheme : ITheme
    {
        public string GetBackgroundColor()
        {
            return "White";
        }

        public string GetTextColor()
        {
            return "Black";
        }
    }
    
    public class DarkTheme : ITheme
    {
        public string GetBackgroundColor()
        {
            return "Black";
        }

        public string GetTextColor()
        {
            return "White";
        }
    }
}