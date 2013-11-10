Action()
{
	web_service_call( "StepName=EchoString_101",
		"SOAPMethod=UsernamePasswordService|WSHttpBinding_IUsernamePasswordService|EchoString",
		"ResponseParam=response",
		"Service=UsernamePasswordService",
		"ExpectedResponse=SoapResult",
		"Snapshot=t1355847895.inf",
		BEGIN_ARGUMENTS,
		"s=abcde",
		END_ARGUMENTS,
		BEGIN_RESULT,
		END_RESULT,
		LAST);

	
	return 0;
}
