Action()
{

	web_service_call( "StepName=Add_101",
		"SOAPMethod=Service1|WSFederationHttpBinding_ICalculator|Add",
		"ResponseParam=response",
		"Service=Service1",
		"ExpectedResponse=SoapResult",
		"Snapshot=t1216819465.inf",
		BEGIN_ARGUMENTS,
		"n1=2",
		"n1Specified=true",
		"n2=5",
		"n2Specified=true",
		END_ARGUMENTS,
		BEGIN_RESULT,
		END_RESULT,
		LAST);


	return 0;
}
