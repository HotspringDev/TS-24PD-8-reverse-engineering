using System;
using System.Globalization;
using System.Windows.Controls;

namespace T2208.Domain
{
	// Token: 0x020000AB RID: 171
	public class NotEmptyValidationRule : ValidationRule
	{
		// Token: 0x06000879 RID: 2169 RVA: 0x0002639C File Offset: 0x0002459C
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			return string.IsNullOrWhiteSpace((value ?? "").ToString()) ? new ValidationResult(false, "Field is required.") : ValidationResult.ValidResult;
		}
	}
}
