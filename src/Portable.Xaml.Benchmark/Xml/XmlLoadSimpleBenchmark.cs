﻿using System;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Portable.Xaml.Benchmark.Xml
{
	public class XmlLoadSimpleBenchmark : LoadBenchmark
	{
		public override string TestName => "XmlLoadSimpleBenchmark.xml";
	}
	
}
