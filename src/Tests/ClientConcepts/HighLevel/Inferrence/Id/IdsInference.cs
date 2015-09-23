﻿using System;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using Nest;
using Newtonsoft.Json.Linq;
using Tests.Framework;
using Tests.Framework.MockData;
using Xunit.Sdk;
using static Tests.Framework.RoundTripper;
using static Nest.Infer;
using Nest.Resolvers;

namespace Tests.ClientConcepts.HighLevel.Inferrence.FieldNames
{
	public class IdsInference
	{
		/** # Strongly typed field access 
		 * 
		 * Several places in the elasticsearch API expect the path to a field from your original source document as a string.
		 * NEST allows you to use C# expressions to strongly type these field path strings. 
		 *
		 * These expressions are assigned to a type called `FieldName` and there are several ways to create a instance of that type
		 */

		/** Using the constructor directly is possible but rather involved */
		[U] public void CanImplicitlyConvertToId()
		{
			Id idFromInt = 1;

			Expect("1").WhenSerializing(idFromInt);

			var resolver = new IdResolver(new ConnectionSettings()
				.InferMappingFor<Project>(m=>m.IdProperty(p=>p.Name)));
			var id = resolver.GetIdFor(new Project { Name = "x" });
			id.Should().Be("x");
			object o = new Project { Name = "x" };
			id = resolver.GetIdFor(typeof(Project), o);
			id.Should().Be("x");
			id = resolver.GetIdFor(typeof(Project), o);
			id.Should().Be("x");
		}
	}
}