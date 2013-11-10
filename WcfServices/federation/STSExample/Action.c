Action()
{

    //The service is in IIS
    //The project is in:
    //C:\examples\security\Wcf\STSSample1\STSExample\STSExample.sln    

	web_service_call( "StepName=helloWorld_101",
		"SOAPMethod=HelloWorldService|WSFederationHttpBinding_IHelloWorld|helloWorld",
		"ResponseParam=response",
		"Service=HelloWorldService",
		"ExpectedResponse=SoapResult",
		"Snapshot=t1228682440.inf",
		BEGIN_ARGUMENTS,
		"message=abcde",
		END_ARGUMENTS,
		BEGIN_RESULT,
		END_RESULT,
		LAST);


	return 0;
}
