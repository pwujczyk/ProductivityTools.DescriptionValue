<!--Category:C#,SQL--> 
 <p align="right">
    <a href="https://www.nuget.org/packages/ProductivityTools.DescriptionValue/"><img src="Images/Header/Nuget_border_40px.png" /></a>
    <a href="http://productivitytools.tech/productivitytools-createsqlserverdatabase/"><img src="Images/Header/ProductivityTools_green_40px_2.png" /><a> 
    <a href="https://www.github.com/pwujczyk/ProductivityTools.DescriptionValue"><img src="Images/Header/Github_border_40px.png" /></a>
</p>
<p align="center">
    <a href="https://www.powershellgallery.com/packages/ProductivityTools.PSSetLockScreen/">
        <img src="Images/Header/LogoTitle_green_500px.png" />
    </a>
</p>


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