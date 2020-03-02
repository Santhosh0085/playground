//----------------------------------------------------
// Copyright 2020 
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleEmail.REST.Models
{
	/// <summary>
	/// Helper class to handle email related operations
	/// Implemented only the basic functions needed for the problem
	/// </summary>
	public class EmailHelper
	{
		#region Private member variables

		// A static member variable to hold list of emails added. This is easier than estabilishing a database connection and stuff to store the values.
		// Just to keep things simple
		private static HashSet<string> _emailTracker; 

		private const string NoEmailError = "No valid e-mail found in the input.";
		private const string NoEmailFound = "No e-mail found in the input.";
		private const char EmailDelimiter = '@';
		private const char PlusSign = '+';
		private const string DotDelimiter = ".";

		#endregion

		#region Construtor

		/// <summary>
		/// Base constructor
		/// </summary>
		public EmailHelper()
		{
			_emailTracker = new HashSet<string>();
		}
		#endregion

		#region Public methods

		/// <summary>
		/// Method to add unique emails 
		/// </summary>
		/// <param name="emails"> List of e-mails to add</param>
		/// <param name="errorMessage"> Any error when adding e-mails </param>
		public void AddEmails(string[] emails, out string errorMessage)
		{
			bool noValidEmails = true;
			errorMessage = string.Empty;

			// No email found in the input
			if (emails == null || emails.Length == 0)
			{
				errorMessage = NoEmailFound;
				return;
			}

			// Loop through all the emails and add it to the HashSet (no duplicates, uique keys)
			foreach (string email in emails)
			{
				// First, convert the emails to it's canonical form so that we have a standard format for comparison
				// E-mails are not case sensitive so convert them to upper case for comparison
				string canonicalForm = this.ConvertToCanonical(email);

				// Add the e-mail to the HasSet if it's not already there
				if (!string.IsNullOrEmpty(canonicalForm))
				{
					if (!_emailTracker.Contains(canonicalForm))
					{
						_emailTracker.Add(canonicalForm);
						if (noValidEmails) { noValidEmails = false; }
					}
				}
			}

			// No valid emails are found in the input
			if (noValidEmails)
			{
				errorMessage = NoEmailError;
			}
		}

		/// <summary>
		/// Get unique email count
		/// </summary>
		/// <returns>Unique email count of all the emails that are added so far</returns>
		public int GetUniqueEmailCount()
		{
			return _emailTracker.Count;
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Convert an email Id to it's canonical form (lower case, + and . stripped)
		/// </summary>
		/// <param name="email">Email to be formatted</param>
		/// <returns>Formatted email id. Empty string is returned if email is not valid</returns>
		private string ConvertToCanonical(string email)
		{
			if (string.IsNullOrEmpty(email))
			{
				return string.Empty;
			}

			// Check if the email is valid
			if (!new EmailAddressAttribute().IsValid(email))
			{
				return string.Empty;
			}

			// At this point, we already checked if the email address is valid so
			// no need to check it again. Just assume that the email is valid
			string[] parts = email.ToLower().Split(EmailDelimiter);

			if (parts.Length == 2)
			{
				// Strip address after + sign like (+spam)
				if (parts[0].Contains(PlusSign))
				{
					parts[0] = parts[0].Substring(0, parts[0].IndexOf(PlusSign));
				}

				// Replace . in the address
				parts[0] = parts[0].Replace(DotDelimiter, string.Empty);
				return string.Join(EmailDelimiter.ToString(),parts);
			}

			return string.Empty;
		}
		#endregion
	}
}
