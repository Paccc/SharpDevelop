﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;

namespace ICSharpCode.SharpDevelop.Parser
{
	/// <summary>
	/// Interface for global assembly cache service.
	/// </summary>
	public interface IGlobalAssemblyCacheService
	{
		/// <summary>
		/// Gets whether the file name is within the GAC.
		/// </summary>
		bool IsGACAssembly(string fileName);
		
		/// <summary>
		/// Gets the names of all assemblies in the GAC.
		/// </summary>
		IEnumerable<DomAssemblyName> GetGacAssemblyFullNames();
		
		/// <summary>
		/// Gets the file name for an assembly stored in the GAC.
		/// Returns null if the assembly cannot be found.
		/// </summary>
		string FindAssemblyInNetGac(DomAssemblyName reference);
	}
}