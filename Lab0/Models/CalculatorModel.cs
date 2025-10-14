namespace Lab0.Models;

public class CalculatorModel
{
    public double? X { get; set; }
    public double? Y { get; set; }
    public Operators Operator { get; set; }

    public bool IsValid()
    {
        return X is not null && Y is not null && Operator != Operators.Undefined;
    }
    
    
    public string Result  {
        get
        {
            switch (Operator)
            {
                case Operators.Add:
                    return $"{X} + {Y} = {X + Y}";
                case Operators.Sub:
                    return $"{X} - {Y} = {X - Y}";
                case Operators.Mul:
                    return $"{X} * {Y} = {X * Y}";
                case Operators.Div:
                    return $"{X} / {Y} = {X / Y}";
                default:
                    return "Nieznany operator";
            }
        }
    } 
}