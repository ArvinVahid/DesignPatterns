namespace AbstractFactory;

class Program
{
    static void Main(string[] args)
    {
        FactoryCreator factory = new FactoryCreator(new MacUiFactory());
        var button= factory.CreateButton();
        var checkbox= factory.CreateCheckBox();
        Console.WriteLine(button.Render());
        Console.WriteLine(checkbox.Render());


    }

    #region Factory

    public class FactoryCreator
    {
        private readonly IUIFactory _ui;
        public FactoryCreator(IUIFactory ui)
        {
            _ui = ui;
        }

        public IButton CreateButton()
        {
            return _ui.CreateButton();
        }
        
        public ICheckBox CreateCheckBox()
        {
            return _ui.CreateCheckBox();
        }
    }
    
    public interface IUIFactory
    {
        public IButton CreateButton();
        public ICheckBox CreateCheckBox();
    }

    public class WindowsUiFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ICheckBox CreateCheckBox()
        {
            return new WindowsCheckBox();
        }
    }
    
    public class MacUiFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new MacOsButton();
        }

        public ICheckBox CreateCheckBox()
        {
            return new MacOsCheckBox();
        }
    }

    #endregion
    
    #region Interfaces and concretes

    public interface IButton
    {
        string Render();
    }
    
    public interface ICheckBox
    {
        string Render();
    }
    
    public class WindowsButton : IButton
    {
        public string Render()
        {
            return "Windows Button Style";
        }
    }
    
    public class MacOsButton : IButton
    {
        public string Render()
        {
            return "Mac OS Button Style";
        }
    }
    
    public class WindowsCheckBox : ICheckBox
    {
        public string Render()
        {
            return "Windows Checkbox Style";
        }
    }
    
    public class MacOsCheckBox : ICheckBox
    {
        public string Render()
        {
            return "Mac OS Checkbox Style";
        }
    }

    #endregion
}