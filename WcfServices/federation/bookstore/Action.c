Action()
{

	/*

					The following code in SoaWcfRouter.dll is required for this:

					EndpointAddressBuilder myEndpointAddressBuilder = new EndpointAddressBuilder(this.configHelper.endpointAddress);
                    myEndpointAddressBuilder.Headers.Add(AddressHeader.CreateAddressHeader("BookName", "http://tempuri.org/", "Book Title Two"));
                    
                    var factory = new ChannelFactory<IUniversalContract>(
                        this.configHelper.clientBinding,
                        myEndpointAddressBuilder.ToEndpointAddress());

	
    */
    

	web_service_call( "StepName=BrowseBooks_101",
		"SOAPMethod=BookStoreService|WSHttpBinding_IBrowseBooks|BrowseBooks",
		"ResponseParam=response",
		"Service=BookStoreService",
		"ExpectedResponse=SoapResult",
		"Snapshot=t1234798491.inf",
		BEGIN_ARGUMENTS,
		END_ARGUMENTS,
		BEGIN_RESULT,
		END_RESULT,
		LAST);



	web_service_call( "StepName=BuyBook_101",
		"SOAPMethod=BookStoreService|WSFederationHttpBinding_IBuyBook|BuyBook",
		"ResponseParam=response",
		"Service=BookStoreService1",
		"ExpectedResponse=SoapResult",
		"Snapshot=t1234798950.inf",
		BEGIN_ARGUMENTS,
		"emailAddress=abcde",
		"shipAddress=abcde",
		END_ARGUMENTS,
		BEGIN_RESULT,
		"BuyBookResult=Param_BuyBookResult",
		END_RESULT,
		LAST);


return 0;
}
