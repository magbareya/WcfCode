Action()
{

	web_service_call( "StepName=GetWeather_101",
		"SOAPMethod=ForacstService|CustomBinding_IForacstService|GetWeather",
		"ResponseParam=response",
		"Service=ForacstService",
		"ExpectedResponse=SoapResult",
		"Snapshot=t1234786768.inf",
		BEGIN_ARGUMENTS,
		"city=abcde",
		END_ARGUMENTS,
		BEGIN_RESULT,
		"GetWeatherResult/Forcast=Param_Forcast",
		"GetWeatherResult/Temperature=Param_Temperature",
		END_RESULT,
		LAST);


	return 0;
}
