Action()
{

	web_service_call( "StepName=GetWeather_101",
		"SOAPMethod=ForacstService|CustomBinding_IForacstService|GetWeather",
		"ResponseParam=response",					  
		"Service=ForacstService",
		"ExpectedResponse=SoapResult",
		"Snapshot=t1242737441.inf",
		BEGIN_ARGUMENTS,
		"city=NY",
		END_ARGUMENTS,
		BEGIN_RESULT,
		END_RESULT,
		LAST);


	return 0;
}
