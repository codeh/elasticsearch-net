﻿using System;

namespace Nest
{
	public class DateAttribute : ElasticsearchPropertyAttribute 
	{
		public NonStringIndexOption? Index { get; set; }
		public double Boost { get; set; }
		public DateTime NullValue { get; set; }
		public bool IncludeInAll { get; set; }
		public int PrecisionStep { get; set; }
		public bool IgnoreMalformed { get; set; }
		public string Format { get; set; }
		public NumericResolutionUnit NumericResolution { get; set; }
		public override IProperty ToProperty() => new DateProperty(this);
	}	
}