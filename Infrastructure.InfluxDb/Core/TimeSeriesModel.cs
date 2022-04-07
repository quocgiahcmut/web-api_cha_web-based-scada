namespace Infrastructure.InfluxDb.Core;

public class TimeSeriesModel
{
    public string FieldName { get; set; }
    public object FieldValue { get; set; }

    public TimeSeriesModel(string fieldName, object fieldValue)
    {
        FieldName = fieldName;
        FieldValue = fieldValue;
    }
}
