using System;
using Superpower.Display;

[Flags]
public enum ODataTokens
{
    [Token(Category = "Empty value", Example = "Empty string or null", Description = "Represents no value.")]
    None = 0,
    
    [Token(Category = "String value", Example = "'Hello World'", Description = "Parsed string value.")]
    StringValue = 1,
    
    [Token(Category = "Boolean Expression", Example = "True")]
    BooleanValue = 2,
    
    [Token(Category = "Object Field", Example = "payment.CreditCardNumber", Description = "An object property")]
    ObjectField = 4,
    
    [Token(Category = "Logical Operator", Example = "And, Or")]
    LogicalOperator = 8,
    
    [Token(Category = "Equality Operator", Example = "Eq, Nq, Gt Lt", Description = "All equality operators supported")]
    EqualityOperator = 16,
    
    [Token(Category = "Number value", Example = "1", Description = "Parsed number value.")]
    IntegerValue = 32
}