﻿using System.Reflection;

namespace Lab.DynamicAccessor.Accessor2
{
    public class DynamicMemberManager
    {
        public static AccessorFactoryBase<PropertyInfo, IPropertyAccessor> Property { get; set; }

        public static AccessorFactoryBase<MethodInfo, Lab.DynamicAccessor.Accessor2. IMethodAccessor> Method { get; set; }

        static DynamicMemberManager()
        {
            Property = new PropertyAccessorFactory();
            Method   = new MethodAccessorFactory();
        }
    }
}