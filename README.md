<!--Category:C#--> 
 <p align="right">
    <a href="https://www.nuget.org/packages/ProductivityTools.DescriptionValue/"><img src="Images/Header/Nuget_border_40px.png" /></a>
    <a href="http://productivitytools.tech/description-attribute-value/"><img src="Images/Header/ProductivityTools_green_40px_2.png" /><a> 
    <a href="https://www.github.com/pwujczyk/ProductivityTools.DescriptionValue"><img src="Images/Header/Github_border_40px.png" /></a>
</p>
<p align="center">
    <a href="http://productivitytools.tech/">
        <img src="Images/Header/LogoTitle_green_500px.png" />
    </a>
</p>


# Description attribute value

Library allows to get description content from DescriptionAttribute.
<!--more-->

Currently it retrieve value from following elements:

- Property

- Field 

- Method

- Enum



Usage example:
```c#
typeof(TestClass).GetPropertyDescription("PropertyName"); 
typeof(TestClass).GetFieldDescription("FieldName"); 
typeof(TestClass).GetMethodDescription("Method1"); 
testClass.Enum.GetDescription();
```

<img src="Images/GetDescription.png" />