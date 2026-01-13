using System.Reflection;
class Assemblies_Reflection
{
    public static void main()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Console.WriteLine(assembly);
        Assembly assem=Assembly.LoadFrom("D:\\Capgemini\\HelloWorld\\EnterpriseData\\bin\\Debug\\net10.0\\EnterpriseData.dll");
        Employee employeeObject = new Employee();
        Type type = employeeObject.GetType();
        Console.WriteLine(type);
        
        MethodInfo method = type.GetMethod("DisplayDetails");
        method.Invoke(employeeObject, null);
        
        PropertyInfo prop = type.GetProperty("Name");
        prop.SetValue(employeeObject, "John");
        Console.WriteLine(prop);
        method.Invoke(employeeObject, null);
        
        FieldInfo field = type.GetField(
            "salary",BindingFlags.NonPublic | BindingFlags.Instance);
        field.SetValue(employeeObject, 50000);
        field.GetValue(employeeObject);
        method.Invoke(employeeObject, null);
        Console.WriteLine(field);

        ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
        object obj = ctor.Invoke(null);
        ConstructorInfo ctor1 = type.GetConstructor(new Type[] {typeof(string),typeof(double) });
        object obj2=ctor1.Invoke(new object[]{"Sandeep",100000000});
        method.Invoke(obj, null);
        method.Invoke(obj2, null);
    }
}