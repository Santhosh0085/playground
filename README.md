# playgroundEmail Checker:
Please write a web service that accepts http requests and returns responses based on the following problem statement. You may define the request and response format as you see fit based on the problem statement.
Problem statement: Accept a list of email addresses and return an integer indicating the number of unique email addresses. Where "unique" email addresses means they will be delivered to the same account using Gmail account matching. Specifically: Gmail will ignore the placement of "." in the username. And it will ignore any portion of the username after a "+".
Examples:
test.email@gmail.com, test.email+spam@gmail.com and testemail@gmail.com will all go to the same address, and thus the result should be 1.
For any requirements not specified via an example, use your best judgement to determine expected result.
You can use any language. When completed, please upload to a public repository, such as GitHub, and provide us with the link.

Implementation:
.NET REST 

Assumptions:
All the inputs and outputs are in JSON format.

EndPoints:
1)	Adding new emails : /EmailInput  (POST)
a.	Sample URL:
i.	http://localhost:61984/EmailService.svc/EmailInput
b.	Input in fiddler:
i.	User-Agent: Fiddler
Host: localhost:61984
Content-Type: application/json
Content-Length: 74
ii.	{"emails":["sango+dvin@mail.com","sangov.in1@mail.com","sangovin2@mail.com"]}
c.	Output: Message indicating if the add was successful.

2)	Get number of unique addresses: /UniqueEmailIDs (GET)
a.	Sample URL
i.	http://localhost:61984/EmailService.svc/UniqueEmailIDs

