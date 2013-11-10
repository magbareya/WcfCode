Action()
{	
	web_service_call( "StepName=GetWeather_101",
		"SOAPMethod=ForacstService|CustomBinding_IForacstService|GetWeather",
		"ResponseParam=response",
		"Service=ForacstService",
		"ExpectedResponse=SoapResult",
		"Snapshot=t1234454470.inf",
		BEGIN_ARGUMENTS,
		"city=abcde",
		END_ARGUMENTS,
		BEGIN_RESULT,
		END_RESULT,
		LAST);


return 0;
}
