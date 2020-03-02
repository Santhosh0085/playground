//----------------------------------------------------
// Copyright 2020 Epic Systems Corporation
//----------------------------------------------------

//----------------------------------------------------
// Copyright 2020 
//----------------------------------------------------

using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using SampleEmail.REST.Models;

namespace SampleEmail.REST
{
	// NOTE: HAVEN'T WRITTEN UNIT TEST DUE TO THE LACK OF ACCESS TO NECESSARY LIBRARY FILES
	// IT IS QUITE EASY TO WRITE THEM SINCE THE PROBLEM ITSELF HAS A NICE TEST CASE

	/// <summary>
	/// Web service to return unique email IDs
	/// </summary>
	[ServiceContract(Namespace = "EmailREST")]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class EmailService
	{
		private static EmailHelper _emailHelper = new EmailHelper(); //E-mail helper class

		/// <summary>
		/// POST API to add a list of e-mail ids
		/// </summary>
		/// <param name="emails">List of emails to validate</param>
		/// <returns> Message indicating if the input was valid</returns>
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/EmailInput", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
		public string AddEmails(string[] emails)
		{
			string errorMessage;
			_emailHelper.AddEmails(emails, out errorMessage);

			// Show a successful message if at least one e-mail is valid
			if (string.IsNullOrEmpty(errorMessage))
			{
				return "E-mails successfully added";
			}
			else
			{
				return errorMessage;
			}
		}

		/// <summary>
		/// GET API to get the list of unique emails
		/// </summary>
		/// <returns></returns>
		[WebGet(UriTemplate = "/UniqueEmailIDs")]
		public string GetUniqueEmailIDs()
		{
			return _emailHelper.GetUniqueEmailCount().ToString();
		}

	}
}
