﻿//
// NRefactoryDiagnosticIDs.cs
//
// Author:
//       Mike Krüger <mkrueger@xamarin.com>
//
// Copyright (c) 2015 Xamarin Inc. (http://xamarin.com)
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

namespace ICSharpCode.NRefactory6.CSharp.Diagnostics
{
	public static class NRefactoryDiagnosticIDs
	{
		public const string PartialTypeWithSinglePartDiagnosticID = "NR0001";
		public const string ConvertClosureToMethodDiagnosticID = "NR0002";
		public const string BaseMethodCallWithDefaultParameterDiagnosticID = "NR0003";
		public const string EmptyConstructorAnalyzerID = "NR0004";
		public const string EmptyDestructorAnalyzerID = "NR0005";
		public const string EmptyNamespaceAnalyzerID = "NR0006";
		public const string EnumUnderlyingTypeIsIntAnalyzerID = "NR0007";
		public const string SealedMemberInSealedClassAnalyzerID = "NR0008";
		public const string NonPublicMethodWithTestAttributeAnalyzerID = "NR0009";
		public const string ConvertConditionalTernaryToNullCoalescingAnalyzerID = "NR0010";
		public const string ConvertIfStatementToConditionalTernaryExpressionAnalyzerID = "NR0011";
		public const string ConvertIfStatementToSwitchStatementAnalyzerID = "NR0012";
		public const string ConvertNullableToShortFormAnalyzerID = "NR0013";
		public const string ConvertToStaticTypeAnalyzerID = "NR0014";
		public const string InvokeAsExtensionMethodAnalyzerID = "NR0015";
		public const string BitwiseOperatorOnEnumWithoutFlagsAnalyzerID = "NR0016";
		public const string CompareNonConstrainedGenericWithNullAnalyzerID = "NR0017";
		public const string CompareOfFloatsByEqualityOperatorAnalyzerID = "NR0018";
		public const string ConditionalTernaryEqualBranchAnalyzerID = "NR0019";
		public const string DelegateSubtractionAnalyzerID = "NR0020";
		public const string DoNotCallOverridableMethodsInConstructorAnalyzerID = "NR0021";
		public const string EmptyGeneralCatchClauseAnalyzerID = "NR0022";
		public const string EventUnsubscriptionViaAnonymousDelegateAnalyzerID = "NR0023";
		public const string LongLiteralEndingLowerLAnalyzerID = "NR0024";
		public const string NonReadonlyReferencedInGetHashCodeAnalyzerID = "NR0025";
		public const string ObjectCreationAsStatementAnalyzerID = "NR0026";
		public const string OperatorIsCanBeUsedAnalyzerID = "NR0027";
		public const string OptionalParameterRefOutAnalyzerID = "NR0028";
		public const string ValueParameterNotUsedAnalyzerID = "NR0029";
	}
}