﻿using System;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes.Columns;
using System.Diagnostics;
using Portable.Xaml.Json;

namespace Portable.Xaml.Benchmark.Json
{
	public abstract class LoadBenchmark : IXamlBenchmark
	{
		public abstract string TestName { get; }

		protected Stream GetStream() => typeof(IXamlBenchmark).Assembly.GetManifestResourceStream("Portable.Xaml.Benchmark.Json." + TestName);

		Portable.Xaml.XamlSchemaContext pxc;
		[Benchmark(Baseline = true)]
		public void PortableXaml()
		{
			pxc = pxc ?? (pxc = new XamlSchemaContext());
			using (var stream = GetStream())
				Portable.Xaml.XamlServices.Load(new Portable.Xaml.Json.XamlJsonReader(stream, pxc));
		}

		[Benchmark]
		public void NewtonsoftJson()
		{
			using (var stream = GetStream())
			using (var reader = new StreamReader(stream))
				Newtonsoft.Json.JsonConvert.DeserializeObject(reader.ReadToEnd());
		}

		/*
		[Benchmark]
		public void PortableXamlNoCache()
		{
			using (var stream = GetStream())
				Portable.Xaml.Json.XamlJsonServices.Load(stream);
		}*/
	}
}
