﻿//
// CSharpCodeGenerationService.cs
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
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory6.CSharp.CodeGeneration
{


	public class CSharpCodeGenerationService
	{
		readonly static Type typeInfo;
		readonly object instance;

		readonly static MethodInfo createEventDeclarationMethod;
		readonly static MethodInfo createFieldDeclaration;
		readonly static MethodInfo createMethodDeclaration;
		readonly static MethodInfo createPropertyDeclaration;
		readonly static MethodInfo createNamedTypeDeclaration;
		readonly static MethodInfo createNamespaceDeclaration;
		readonly static MethodInfo addMethodAsync;
		readonly static MethodInfo addMembersAsync;

		readonly static MethodInfo canAddTo1, canAddTo2;

		static CSharpCodeGenerationService ()
		{
			typeInfo = Type.GetType ("Microsoft.CodeAnalysis.CSharp.CodeGeneration.CSharpCodeGenerationService" + ReflectionNamespaces.CSWorkspacesAsmName, true);
			addMethod = typeInfo.GetMethod ("AddMethod", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
			createEventDeclarationMethod = typeInfo.GetMethod ("CreateEventDeclaration", BindingFlags.Instance | BindingFlags.Public);
			createFieldDeclaration = typeInfo.GetMethod ("CreateFieldDeclaration", BindingFlags.Instance | BindingFlags.Public);
			createMethodDeclaration = typeInfo.GetMethod ("CreateMethodDeclaration", BindingFlags.Instance | BindingFlags.Public);
			createPropertyDeclaration = typeInfo.GetMethod ("CreatePropertyDeclaration", BindingFlags.Instance | BindingFlags.Public);
			createNamedTypeDeclaration = typeInfo.GetMethod ("CreateNamedTypeDeclaration", BindingFlags.Instance | BindingFlags.Public);
			createNamespaceDeclaration = typeInfo.GetMethod ("CreateNamespaceDeclaration", BindingFlags.Instance | BindingFlags.Public);
			addMethodAsync = typeInfo.GetMethod ("AddMethodAsync", BindingFlags.Instance | BindingFlags.Public);
			addMembersAsync = typeInfo.GetMethod ("AddMembersAsync", BindingFlags.Instance | BindingFlags.Public);
			canAddTo1 = typeInfo.GetMethod ("CanAddTo", new [] {typeof(ISymbol), typeof(Solution), typeof(CancellationToken) });
			canAddTo2 = typeInfo.GetMethod ("CanAddTo", new [] {typeof(SyntaxNode), typeof(Solution), typeof(CancellationToken) });

			addFieldAsync = typeInfo.GetMethod ("AddFieldAsync", BindingFlags.Instance | BindingFlags.Public);
			addStatements = typeInfo.GetMethod ("AddStatements", BindingFlags.Instance | BindingFlags.Public);
		}

		public CSharpCodeGenerationService(HostLanguageServices languageServices)
		{
			instance = Activator.CreateInstance (typeInfo, new object[] {
				languageServices
			});
		}

		public CSharpCodeGenerationService (Workspace workspace, string language)
		{
			var languageService = workspace.Services.GetLanguageServices (language);

			this.instance = Activator.CreateInstance (typeInfo, new [] { languageService });
		}

		public CSharpCodeGenerationService (Workspace workspace) : this (workspace, LanguageNames.CSharp)
		{
		}

		static MethodInfo addStatements;
		public TDeclarationNode AddStatements<TDeclarationNode>(
			TDeclarationNode destinationMember,
			IEnumerable<SyntaxNode> statements,
			CodeGenerationOptions options,
			CancellationToken cancellationToken)
		{
			return (TDeclarationNode)addStatements.MakeGenericMethod (typeof (TDeclarationNode)).Invoke (instance, new object[] { destinationMember, statements, options != null ? options.Instance : null, cancellationToken });
		}

		static MethodInfo addMethod;

		/// <summary>
		/// Adds a method into destination.
		/// </summary>
		public TDeclarationNode AddMethod<TDeclarationNode>(TDeclarationNode destination, IMethodSymbol method, CodeGenerationOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) where TDeclarationNode : SyntaxNode
		{
			return (TDeclarationNode)addMethod.MakeGenericMethod (typeof (TDeclarationNode)).Invoke (instance, new object[] { destination, method, options != null ? options.Instance : null, cancellationToken });
		}


		/// <summary>
		/// Returns a newly created event declaration node from the provided event.
		/// </summary
		public SyntaxNode CreateEventDeclaration(IEventSymbol @event, CodeGenerationDestination destination = CodeGenerationDestination.Unspecified)
		{
			return (SyntaxNode)createEventDeclarationMethod.Invoke (instance, new object[] { @event, (int)destination, null });
		}

		/// <summary>
		/// Returns a newly created field declaration node from the provided field.
		/// </summary>
		public SyntaxNode CreateFieldDeclaration(IFieldSymbol field, CodeGenerationDestination destination = CodeGenerationDestination.Unspecified)
		{
			return (SyntaxNode)createFieldDeclaration.Invoke (instance, new object[] { @field, (int)destination, null });
		}

		/// <summary>
		/// Returns a newly created method declaration node from the provided method.
		/// </summary>
		public SyntaxNode CreateMethodDeclaration(IMethodSymbol method, CodeGenerationDestination destination = CodeGenerationDestination.Unspecified)
		{
			return (SyntaxNode)createMethodDeclaration.Invoke (instance, new object[] { @method, (int)destination, null });
		}

		/// <summary>
		/// Returns a newly created property declaration node from the provided property.
		/// </summary>
		public SyntaxNode CreatePropertyDeclaration(IPropertySymbol property, CodeGenerationDestination destination = CodeGenerationDestination.Unspecified)
		{
			return (SyntaxNode)createPropertyDeclaration.Invoke (instance, new object[] { @property, (int)destination, null });
		}

		/// <summary>
		/// Returns a newly created named type declaration node from the provided named type.
		/// </summary>
		public SyntaxNode CreateNamedTypeDeclaration(INamedTypeSymbol namedType, CodeGenerationDestination destination = CodeGenerationDestination.Unspecified)
		{
			return (SyntaxNode)createNamedTypeDeclaration.Invoke (instance, new object[] { @namedType, (int)destination, null });
		}

		/// <summary>
		/// Returns a newly created namespace declaration node from the provided namespace.
		/// </summary>
		public SyntaxNode CreateNamespaceDeclaration(INamespaceSymbol @namespace, CodeGenerationDestination destination = CodeGenerationDestination.Unspecified)
		{
			return (SyntaxNode)createNamespaceDeclaration.Invoke (instance, new object[] { @namespace, (int)destination, null });
		}

		public Task<Document> AddMethodAsync(Solution solution, INamedTypeSymbol destination, IMethodSymbol method, CodeGenerationOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return (Task<Document>)addMethodAsync.Invoke (instance, new object[] { solution, destination, method, options != null ? options.Instance : null, cancellationToken });
		}

		/// <summary>
		/// Adds all the provided members into destination.
		/// </summary>
		public Task<Document> AddMembersAsync(Solution solution, INamedTypeSymbol destination, IEnumerable<ISymbol> members, CodeGenerationOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return (Task<Document>)addMembersAsync.Invoke (instance, new object[] { solution, destination, members, options != null ? options.Instance : null, cancellationToken });
		}

		static MethodInfo addFieldAsync;

		public Task<Document> AddFieldAsync(Solution solution, INamedTypeSymbol destination, IFieldSymbol field, CodeGenerationOptions options, CancellationToken cancellationToken)
		{
			return (Task<Document>)addFieldAsync.Invoke (instance, new object[] { solution, destination, field, options != null ? options.Instance : null, cancellationToken });
		}


		/// <summary>
		/// <c>true</c> if destination is a location where other symbols can be added to.
		/// </summary>
		public bool CanAddTo(ISymbol destination, Solution solution, CancellationToken cancellationToken = default(CancellationToken))
		{
			return (bool)canAddTo1.Invoke (instance, new object[] { destination, solution, cancellationToken });
		}

		/// <summary>
		/// <c>true</c> if destination is a location where other symbols can be added to.
		/// </summary>
		public bool CanAddTo(SyntaxNode destination, Solution solution, CancellationToken cancellationToken = default(CancellationToken))
		{
			return (bool)canAddTo2.Invoke (instance, new object[] { destination, solution, cancellationToken });
		}

	}
}

