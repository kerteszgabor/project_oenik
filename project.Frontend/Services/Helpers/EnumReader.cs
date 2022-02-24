using System;
using System.ComponentModel;

namespace project.Client.Services.Helpers
{
	public static class EnumReader<T>
	{
        public static string GetDescription(T currentEnum)
        {
            System.Reflection.FieldInfo field = currentEnum.GetType().GetField(currentEnum.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return currentEnum.ToString();
            }
        }
    }
}

