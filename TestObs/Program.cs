WeatherData weatherData = new WeatherData();
CurrentConditionDisplay currentDisplay = new CurrentConditionDisplay(weatherData);

weatherData.SetMeasurements(10, 20, 30);
weatherData.SetMeasurements(20, 30, 40);
weatherData.SetMeasurements(30, 40, 50);


#region Subject and observers

public interface IObserver
{
    void Update(float temp, float humidity, float pressure);
}

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public class WeatherData : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private float _tempreture;
    private float _humidity;
    private float _pressure;
    
    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var obs in _observers)
        {
            obs.Update(_tempreture, _humidity, _pressure);
        }
    }

    public void MeasurementsChanged()
    {
        NotifyObservers();
    }

    public void SetMeasurements(float tempreture, float humidity, float pressure)
    {
        _tempreture = tempreture;
        _humidity = humidity;
        _pressure = pressure;
        
        MeasurementsChanged();
    }
}



#endregion

#region Displays

public interface IDisplayElement
{
    void Display();
}

public class CurrentConditionDisplay : IDisplayElement, IObserver
{
    private float _tempreture;
    private float _humidity;
    private WeatherData _weatherData;
    
    public CurrentConditionDisplay(WeatherData weatherData)
    {
        _weatherData = weatherData;
        _weatherData.RegisterObserver(this);
    }
    public void Display()
    {
        Console.WriteLine($"Current conditions: {_tempreture} degree and humidity: {_humidity}%");
    }
    public void Update(float temp, float humidity, float pressure)
    {
        _tempreture = temp;
        _humidity = humidity;
        
        Display();
    }
}

#endregion