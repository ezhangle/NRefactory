// 
// RedundantBaseConstructorCallAnalyzer.cs
// 
// Author:
//      Ciprian Khlud <ciprian.mustiata@yahoo.com>
// 
// Copyright (c) 2013 Ciprian Khlud <ciprian.mustiata@yahoo.com>
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CodeFixes;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.Text;
using System.Threading;
using ICSharpCode.NRefactory6.CSharp.Refactoring;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.FindSymbols;

namespace ICSharpCode.NRefactory6.CSharp.Diagnostics
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class RedundantBaseConstructorCallAnalyzer : GatherVisitorDiagnosticAnalyzer
	{
		static readonly DiagnosticDescriptor descriptor = new DiagnosticDescriptor (
			NRefactoryDiagnosticIDs.RedundantBaseConstructorCallAnalyzerID, 
			GettextCatalog.GetString("This is generated by the compiler and can be safely removed"),
			GettextCatalog.GetString("Redundant base constructor call"), 
			DiagnosticAnalyzerCategories.RedundanciesInDeclarations, 
			DiagnosticSeverity.Info, 
			isEnabledByDefault: true,
			helpLinkUri: HelpLink.CreateFor(NRefactoryDiagnosticIDs.RedundantBaseConstructorCallAnalyzerID),
			customTags: DiagnosticCustomTags.Unnecessary
		);

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create (descriptor);

		protected override CSharpSyntaxWalker CreateVisitor (SemanticModel semanticModel, Action<Diagnostic> addDiagnostic, CancellationToken cancellationToken)
		{
			return new GatherVisitor(semanticModel, addDiagnostic, cancellationToken);
		}

		class GatherVisitor : GatherVisitorBase<RedundantBaseConstructorCallAnalyzer>
		{
			public GatherVisitor(SemanticModel semanticModel, Action<Diagnostic> addDiagnostic, CancellationToken cancellationToken)
				: base (semanticModel, addDiagnostic, cancellationToken)
			{
			}

//			public override void VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
//			{
//				base.VisitConstructorDeclaration(constructorDeclaration);
//
//				if (constructorDeclaration.Initializer.ConstructorInitializerType != ConstructorInitializerType.Base)
//					return;
//				if (constructorDeclaration.Initializer.IsNull)
//					return;
//				if (constructorDeclaration.Initializer.Arguments.Count != 0)
//					return;
//				AddDiagnosticAnalyzer(new CodeIssue(constructorDeclaration.Initializer.StartLocation, constructorDeclaration.Initializer.EndLocation,
//				         ctx.TranslateString(""),
//				         ctx.TranslateString(""),
//				         script => {
//					var clone = (ConstructorDeclaration)constructorDeclaration.Clone();
//					script.Replace(clone.ColonToken, CSharpTokenNode.Null.Clone());
//					script.Replace(constructorDeclaration.Initializer, ConstructorInitializer.Null.Clone());
//					}) { IssueMarker = IssueMarker.GrayOut });
//			}
//
//			public override void VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
//			{
//				//ignore properties
//			}
//
//			public override void  VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
//			{
//				//ignore fields
//			}
//
//			public override void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
//			{
//				//ignore method declarations
//			}
		}
	}

	
}