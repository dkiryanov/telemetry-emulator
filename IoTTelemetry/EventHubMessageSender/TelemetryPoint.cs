using System;

namespace EventHubMessageSender
{
    public class TelemetryPoint
    {
        public double Temparature { get; set; }
        public double Humidity { get; set; }
        public DateTime Time { get; set; }

        public TelemetryPoint() { }

        public TelemetryPoint(Random rand)
        {
            Temparature = Math.Round(rand.NextDouble() * 60 - 2, 2);
            Humidity = Math.Round(rand.NextDouble() * 100 - 5, 2);
            Time = DateTime.UtcNow;
        }
    }
}
