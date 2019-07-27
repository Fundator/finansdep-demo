# Demonstration of explainable prediction of housing values using machine learning
The live demo application is available here: https://finansdep-demo.azurewebsites.net/

The data set used is the [Melbourne Housing Clearance Data (2016) from Kaggle](https://www.kaggle.com/anthonypino/melbourne-housing-market).

# How it works
![Architecture drawing](https://github.com/Fundator/finansdep-demo/blob/master/finansdep-ark.png?raw=true)
The model is trained and deployed as a Docker container instance in Azure. From this container instance, a [simple REST API is exposed using Flask](http://5364e0bd-1a4e-4579-98de-4bd9b11ca807.westus.azurecontainer.io/score). This API is utilized by the web backend. The frontend itself is written in TypeScript and Angular 8, and uses a [simplified REST API](https://finansdep-demo.azurewebsites.net/swagger) exposed from the [PredictionController](https://github.com/Fundator/finansdep-demo/blob/master/Finansdep.Demo.WebUI/Finansdep.Demo.WebUI/Controllers/PredictionController.cs) in the backend.

# Useful resources
- Link to the live demo application: https://finansdep-demo.azurewebsites.net/
- API Documentation: https://finansdep-demo.azurewebsites.net/swagger
- Web application source code (this repository): https://github.com/Fundator/finansdep-demo
- MLFlow backend source code: https://github.com/Fundator/finansdep
- Our website: https://www.nois.no/produkter/IT-tjenester/maskinlaring-og-kunstig-intelligens/
