Action()
{



	//service is in C:\Documents and Settings\naveh\My Documents\Visual Studio 2008\Projects\MyMultiFederationSample
	web_service_call( "StepName=GetWeather_101",
		"SOAPMethod=ForacstService|WSFederationHttpBinding_IForacstService|GetWeather",
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
