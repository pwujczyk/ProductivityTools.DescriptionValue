# ProductivityTools.DescriptionValue

Library allows to get description content from:
- Property
- Field
- Method
- Enum

```
typeof(TestClass).GetPropertyDescription("PropertyName");
typeof(TestClass).GetFieldDescription("FieldName");
typeof(TestClass).GetMethodDescription("Method1");
testClass.Enum.GetDescription();
```