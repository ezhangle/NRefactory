// EmptyConstructorAnalyzer.cs
// 
// Author:
//      Ji Kun <jikun.nus@gmail.com>
// 
// Copyright (c) 2013 Ji Kun
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
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SaHALL THE
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
	public class PublicConstructorInAbstractClassAnalyzer : DiagnosticAnalyzer
	{
		static readonly DiagnosticDescriptor descriptor = new DiagnosticDescriptor (
			NRefactoryDiagnosticIDs.PublicConstructorInAbstractClassAnalyzerID, 
			GettextCatalog.GetString("Constructor in abstract class should not be public"),
			GettextCatalog.GetString("Constructor in abstract class should not be public"), 
			DiagnosticAnalyzerCategories.PracticesAndImprovements, 
			DiagnosticSeverity.Info, 
			isEnabledByDefault: true,
			helpLinkUri: HelpLink.CreateFor(NRefactoryDiagnosticIDs.PublicConstructorInAbstractClassAnalyzerID)
		);

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create (descriptor);

		public override void Initialize(AnalysisContext context)
		{
			//context.RegisterSyntaxNodeAction(
			//	(nodeContext) => {
			//		Diagnostic diagnostic;
			//		if (TryGetDiagnostic (nodeContext, out diagnostic)) {
			//			nodeContext.ReportDiagnostic(diagnostic);
			//		}
			//	}, 
			//	new SyntaxKind[] { SyntaxKind.None }
			//);
		}

		static bool TryGetDiagnostic (SyntaxNodeAnalysisContext nodeContext, out Diagnostic diagnostic)
		{
			diagnostic = default(Diagnostic);
			//var node = nodeContext.Node as ;
			//diagnostic = Diagnostic.Create (descriptor, node.GetLocation ());
			//return true;
			return false;
		}

//		class GatherVisitor : GatherVisitorBase<PublicConstructorInAbstractClassAnalyzer>
//		{
//			public GatherVisitor(SemanticModel semanticModel, Action<Diagnostic> addDiagnostic, CancellationToken cancellationToken)
//				: base(semanticModel, addDiagnostic, cancellationToken)
//			{
//			}

////			public override void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
////			{
////				if (!typeDeclaration.HasModifier(Modifiers.Abstract)) {
////					return;
////				}
////				foreach (var constructor in typeDeclaration.Children.OfType<ConstructorDeclaration>()) {
////					VisitConstructorDeclaration(constructor);
////				}
////			}
////
////			public override void VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
////			{
////				if (constructorDeclaration.HasModifier(Modifiers.Public)) {
////
////					var makeProtected = new CodeAction(ctx.TranslateString("Make constructor protected"), script => script.Replace(constructorDeclaration.ModifierTokens.First(t => t.Modifier == Modifiers.Public), new CSharpModifierToken(TextLocation.Empty, Modifiers.Protected)), constructorDeclaration.NameToken);
////					var makePrivate = new CodeAction(ctx.TranslateString("Make constructor private"), script => script.Remove(constructorDeclaration.ModifierTokens.First(t => t.Modifier == Modifiers.Public)), constructorDeclaration.NameToken);
////
////					AddDiagnosticAnalyzer(new CodeIssue(constructorDeclaration.NameToken, ctx.TranslateString("Constructor in Abstract Class should not be public"), new[] {
////						makeProtected,
////						makePrivate
////					}));
////				}
////			}
//		}
	}
}