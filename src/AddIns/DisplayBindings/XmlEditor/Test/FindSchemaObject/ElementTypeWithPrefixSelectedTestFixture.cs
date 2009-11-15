﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision$</version>
// </file>

using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.XmlEditor;
using NUnit.Framework;
using System;
using System.IO;
using System.Xml.Schema;
using XmlEditor.Tests.Schema;
using XmlEditor.Tests.Utils;

namespace XmlEditor.Tests.FindSchemaObject
{
	/// <summary>
	/// Tests that an xs:element/@type="prefix:name" is located in the schema.
	/// </summary>
	[TestFixture]
	public class ElementTypeWithPrefixSelectedTestFixture : SchemaTestFixtureBase
	{
		XmlSchemaComplexType schemaComplexType;
		
		public override void FixtureInit()
		{
			XmlSchemaCompletionCollection schemas = new XmlSchemaCompletionCollection();
			schemas.Add(SchemaCompletion);
			XmlSchemaCompletion xsdSchemaCompletion = new XmlSchemaCompletion(ResourceManager.ReadXsdSchema());
			schemas.Add(xsdSchemaCompletion);
			
			string xml = GetSchema();
			int index = xml.IndexOf("type=\"xs:complexType\"");
			index = xml.IndexOf("xs:complexType", index);
			schemaComplexType = (XmlSchemaComplexType)XmlView.GetSchemaObjectSelected(xml, index, schemas, SchemaCompletion);
		}
		
		[Test]
		public void ComplexTypeName()
		{
			Assert.AreEqual("complexType", schemaComplexType.QualifiedName.Name);
		}
		
		[Test]
		public void ComplexTypeNamespace()
		{
			Assert.AreEqual("http://www.w3.org/2001/XMLSchema", schemaComplexType.QualifiedName.Namespace);
		}
		
		protected override string GetSchema()
		{
			return "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" targetNamespace=\"http://www.w3schools.com\" xmlns=\"http://www.w3schools.com\" elementFormDefault=\"qualified\">\r\n" +
				"\t<xs:element name=\"note\">\r\n" +
				"\t\t<xs:complexType> \r\n" +
				"\t\t\t<xs:sequence>\r\n" +
				"\t\t\t\t<xs:element name=\"text\" type=\"xs:complexType\"/>\r\n" +
				"\t\t\t</xs:sequence>\r\n" +
				"\t\t</xs:complexType>\r\n" +
				"\t</xs:element>\r\n" +
				"</xs:schema>";
		}
	}
}
