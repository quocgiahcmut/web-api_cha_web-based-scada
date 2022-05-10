namespace WebApi.Service;

public class KnownMetricStore
{
    public List<Metric> Metrics { get; set; }

    public KnownMetricStore()
    {
        Metrics = new List<Metric>()
        {
            //ep may
            new Metric { Name = "L6.CycleTime", ValueCase = DataType.Double, DoubleValue = 0 },
            new Metric { Name = "L6.OpenTime", ValueCase = DataType.Double, DoubleValue = 0 },
            new Metric { Name = "L6.CounterShot", ValueCase = DataType.Int32, IntValue = 0 },
            new Metric { Name = "L6.SetCycle", ValueCase = DataType.Double, DoubleValue = 0 },
            new Metric { Name = "L6.MachineStatus", ValueCase = DataType.Int32, IntValue = 0 },

            //qaqc plc
            new Metric { Name = "Sp Force Cylinder 12", ValueCase = DataType.Double, DoubleValue = 0 },
            new Metric { Name = "Sp Force Cylinder 3", ValueCase = DataType.Double, DoubleValue = 0 },
            new Metric { Name = "Sp No Press 12", ValueCase = DataType.Int32, IntValue = 0 },
            new Metric { Name = "Sp No Press 3", ValueCase = DataType.Int32, IntValue = 0 },
            new Metric { Name = "Sp Time Hold 12", ValueCase = DataType.Int32, IntValue = 0 },
            new Metric { Name = "Sp Time Hold 3", ValueCase = DataType.Int32, IntValue = 0 },
            new Metric { Name = "Pv Force Cylinder 1", ValueCase = DataType.Double, DoubleValue = 0 },
            new Metric { Name = "Pv Force Cylinder 2", ValueCase = DataType.Double, DoubleValue = 0 },
            new Metric { Name = "Pv Force Cylinder 3", ValueCase = DataType.Double, DoubleValue = 0 },
            new Metric { Name = "Pv No Press 1", ValueCase = DataType.Int32, IntValue = 0 },
            new Metric { Name = "Pv No Press 2", ValueCase = DataType.Int32, IntValue = 0 },
            new Metric { Name = "Pv No Press 3", ValueCase = DataType.Int32, IntValue = 0 },
            new Metric { Name = "Pv Time Hold 1", ValueCase = DataType.Int32, IntValue = 0 },
            new Metric { Name = "Pv Time Hold 2", ValueCase = DataType.Int32, IntValue = 0 },
            new Metric { Name = "Pv Time Hold 3", ValueCase = DataType.Int32, IntValue = 0 },
            new Metric { Name = "Selec 1 App", ValueCase = DataType.Boolean, BooleanValue = false },
            new Metric { Name = "Selec 2 App", ValueCase = DataType.Boolean, BooleanValue = false },
            new Metric { Name = "Mode App", ValueCase = DataType.Boolean, BooleanValue = false },
            new Metric { Name = "Green App", ValueCase = DataType.Boolean, BooleanValue = false },
            new Metric { Name = "Red App", ValueCase = DataType.Boolean, BooleanValue = false },
            new Metric { Name = "Error App", ValueCase = DataType.Boolean, BooleanValue = false },
            new Metric { Name = "Error Code", ValueCase = DataType.Int32, IntValue = 0 }
        };
    }
}
